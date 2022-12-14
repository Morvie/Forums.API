using ForumsService.Application.Interface;
using ForumsService.Infrastructure.Context;
using ForumsService.Infrastructure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CommandsMediatR = ForumsService.Application.Command;
using QueriesMediatR = ForumsService.Application.Query;
using MassTransit;
using Forums.Models;
using FeedMessages.Application.Notifications;

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
var rabbitMqSettings = builder.Configuration.GetSection(nameof(RabbitMqSettings)).Get<RabbitMqSettings>();


builder.Services.AddMassTransit(config =>
{
    config.UsingRabbitMq((cxt, cfg) =>
    {
        cfg.Host(rabbitMqSettings.Uri, "/", c =>
        {
            c.Username(rabbitMqSettings.UserName);
            c.Password(rabbitMqSettings.Password);
        });
        cfg.ReceiveEndpoint("feed_service", (c) =>
        {
            c.Consumer<CommandMessageConsumer>();
        });
    });
});

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