﻿// <auto-generated />
using System;
using ForumsService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Forums.Migrations
{
    [DbContext(typeof(ForumDbContext))]
    partial class ForumDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ForumsService.Domain.Entities.ForumsDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amountoflikes")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<Guid>("Ownership")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Reported")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Forums");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1c565daf-3eaa-4b60-bc11-d0a96fce249e"),
                            Amountoflikes = 4,
                            DateOfAdded = new DateTime(2022, 11, 16, 11, 20, 51, 634, DateTimeKind.Local).AddTicks(2679),
                            Description = "I don't think this is a good movie at all! It contains a lot of bad filming.",
                            MovieId = 42543,
                            Ownership = new Guid("1c565daf-3eaa-4b60-bc11-d0a96fce249e"),
                            Reported = false,
                            Title = "Is the Star-Wars - Rise of Empire movie good?"
                        },
                        new
                        {
                            Id = new Guid("208e2274-db97-4ac4-b17c-27d10abca7a8"),
                            Amountoflikes = 245,
                            DateOfAdded = new DateTime(2022, 11, 16, 11, 20, 51, 634, DateTimeKind.Local).AddTicks(2716),
                            Description = "Just Hagrid in the movie?!.",
                            MovieId = 5345,
                            Ownership = new Guid("48aff7a7-702c-40d7-bbb0-417c0d775c08"),
                            Reported = false,
                            Title = "Harry Potter & The Deathly Hallows Part 1 - Hagrid?!"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
