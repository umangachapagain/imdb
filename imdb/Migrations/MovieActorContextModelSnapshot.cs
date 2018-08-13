﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using imdb.Models;

namespace imdb.Migrations
{
    [DbContext(typeof(MovieActorContext))]
    partial class MovieActorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("imdb.Models.Actor", b =>
                {
                    b.Property<int>("ActorID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bio");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Name");

                    b.Property<string>("Sex");

                    b.HasKey("ActorID");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("imdb.Models.Movie", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Plot");

                    b.Property<string>("Poster");

                    b.Property<int>("ProducerID");

                    b.Property<DateTime>("ReleaseYear");

                    b.HasKey("MovieID");

                    b.HasIndex("ProducerID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("imdb.Models.MovieActor", b =>
                {
                    b.Property<int>("ActorID");

                    b.Property<int>("MovieID");

                    b.Property<int>("MovieActorID");

                    b.HasKey("ActorID", "MovieID");

                    b.HasIndex("MovieID");

                    b.ToTable("MovieActors");
                });

            modelBuilder.Entity("imdb.Models.Producer", b =>
                {
                    b.Property<int>("ProducerID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bio");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Name");

                    b.Property<string>("Sex");

                    b.HasKey("ProducerID");

                    b.ToTable("Producer");
                });

            modelBuilder.Entity("imdb.Models.Movie", b =>
                {
                    b.HasOne("imdb.Models.Producer", "Producer")
                        .WithMany("Movies")
                        .HasForeignKey("ProducerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("imdb.Models.MovieActor", b =>
                {
                    b.HasOne("imdb.Models.Actor", "Actor")
                        .WithMany("MovieActors")
                        .HasForeignKey("ActorID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("imdb.Models.Movie", "Movie")
                        .WithMany("MovieActors")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
