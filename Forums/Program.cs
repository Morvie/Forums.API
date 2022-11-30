using ForumsService.Application.Interface;
using ForumsService.Infrastructure.Context;
using ForumsService.Infrastructure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CommandsMediatR = ForumsService.Application.Command;
using QueriesMediatR = ForumsService.Application.Query;
using MassTransit;
using ForumsService.Application.Consumer;
using MassTransit.DependencyInjection.Registration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency injections via MediatR:
builder.Services.AddMediatR(new Type[]
{
    typeof(CommandsMediatR.CreateForum.CreateForumCommand),
    typeof(CommandsMediatR.UpdateForum.UpdateForumCommand),
    typeof(CommandsMediatR.DeleteForum.DeleteForumCommand),
    typeof(QueriesMediatR.GetAllForums.GetAllForumsQuery),
    typeof(QueriesMediatR.GetAllForums.GetAllForumsQuery)
});

// Inject normal dependencies:
builder.Services.AddScoped<ICommandForumRepository, CommandForumRepository>();
builder.Services.AddScoped<IQueryForumRepository, QueryForumRepository>();

// Add Entity Framework for SQL to project:
ConfigurationManager configuration = builder.Configuration;
builder.Services.AddDbContext<ForumDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("Forums").EnableRetryOnFailure())
);

//RabbitMQ 
builder.Services.AddMassTransit(config => 
{
    config.AddConsumer<FeedConsumer>();
    config.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
    {
        cfg.Host(new Uri("rabbitmq://" + builder.Configuration.GetValue<string>("RabbitMQ:QueueSettings:HostName")), h =>
        {
            h.Username(builder.Configuration.GetValue<string>("RabbitMQ:QueueSettings:UserName"));
            h.Password(builder.Configuration.GetValue<string>("RabbitMQ:QueueSettings:Password"));
        });
        cfg.ReceiveEndpoint("Feed-POST", ep =>
        {
            ep.PrefetchCount = 16;
            ep.UseMessageRetry(r => r.Interval(2, 100));
            ep.ConfigureConsumer<FeedConsumer>(provider);
        });
    }));
});

builder.Services.AddMassTransitHostedService();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


public partial class Program { }