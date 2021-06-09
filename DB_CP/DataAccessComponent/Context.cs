using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
#nullable disable

namespace DataAccessComponent
{
    public partial class Context : DbContext
    {
        private string ConnectionString { get; set; }
        IConfiguration _config;
        public Context()
        {
            ConfigurationBuilder cfg = new ConfigurationBuilder();
            _config = cfg
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
        }

        public Context(string connect)
        {
            ConnectionString = connect;
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Studio> Studios { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserActor> UserActors { get; set; }
        public virtual DbSet<UserGenre> UserGenres { get; set; }
        public IQueryable<Recommends> get_recommended_films(int userId) => FromExpression(() => get_recommended_films(userId));

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United States.1252");
            modelBuilder.HasDbFunction(() => get_recommended_films(default));

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.ToTable("actors");

                entity.Property(e => e.ActorId)
                    .ValueGeneratedNever()
                    .HasColumnName("actor_id");

                entity.Property(e => e.ActorName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("actor_name");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Awards).HasColumnName("awards");

                entity.Property(e => e.Fee).HasColumnName("fee");

                entity.Property(e => e.FilmId).HasColumnName("film_id");

                entity.Property(e => e.Nationality)
                    .HasMaxLength(40)
                    .HasColumnName("nationality");

                entity.Property(e => e.Sex)
                    .HasMaxLength(6)
                    .HasColumnName("sex");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.Actors)
                    .HasForeignKey(d => d.FilmId)
                    .HasConstraintName("actors_film_id_fkey");
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.ToTable("directors");

                entity.Property(e => e.DirectorId)
                    .ValueGeneratedNever()
                    .HasColumnName("director_id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.DirectorName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("director_name");

                entity.Property(e => e.FilmsAmount).HasColumnName("films_amount");

                entity.Property(e => e.Sex)
                    .HasMaxLength(6)
                    .HasColumnName("sex");
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.ToTable("films");

                entity.Property(e => e.FilmId)
                    .ValueGeneratedNever()
                    .HasColumnName("film_id");

                entity.Property(e => e.AvgPrice).HasColumnName("avg_price");

                entity.Property(e => e.Budget).HasColumnName("budget");

                entity.Property(e => e.DirectorId).HasColumnName("director_id");

                entity.Property(e => e.Fees).HasColumnName("fees");

                entity.Property(e => e.FilmName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("film_name");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("date")
                    .HasColumnName("release_date");

                entity.Property(e => e.StudioId).HasColumnName("studio_id");

                entity.HasOne(d => d.Director)
                    .WithMany(p => p.Films)
                    .HasForeignKey(d => d.DirectorId)
                    .HasConstraintName("films_director_id_fkey");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Films)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("films_genre_id_fkey");

                entity.HasOne(d => d.Studio)
                    .WithMany(p => p.Films)
                    .HasForeignKey(d => d.StudioId)
                    .HasConstraintName("films_studio_id_fkey");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genres");

                entity.Property(e => e.GenreId)
                    .ValueGeneratedNever()
                    .HasColumnName("genre_id");

                entity.Property(e => e.GenreName)
                    .HasMaxLength(40)
                    .HasColumnName("genre_name");
            });

            modelBuilder.Entity<Studio>(entity =>
            {
                entity.ToTable("studios");

                entity.Property(e => e.StudioId)
                    .ValueGeneratedNever()
                    .HasColumnName("studio_id");

                entity.Property(e => e.DateOfCreation)
                    .HasColumnType("date")
                    .HasColumnName("date_of_creation");

                entity.Property(e => e.StudioName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("studio_name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("password");

                entity.Property(e => e.Permissions).HasColumnName("permissions");
            });

            modelBuilder.Entity<UserActor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("user_actors");

                entity.Property(e => e.ActorId).HasColumnName("actor_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Actor)
                    .WithMany()
                    .HasForeignKey(d => d.ActorId)
                    .HasConstraintName("user_actors_actor_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_actors_user_id_fkey");
            });

            modelBuilder.Entity<UserGenre>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("user_genres");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Genre)
                    .WithMany()
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("user_genres_genre_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_genres_user_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
