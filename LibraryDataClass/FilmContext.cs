using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer
{
    public class FilmContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            SqliteConnectionStringBuilder sb = new SqliteConnectionStringBuilder();
            sb.Add("cache", "shared");
            sb.DataSource = "C:\\Users\\Oli\\Documents\\Movies.sqlite";
            optionsBuilder.UseSqlite(sb.ToString());
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.EnableDetailedErrors(true);
        }
        public FilmContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Film> Films { get; set; }
        public DbSet<FilmType> FilmTypes { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
