using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieConsoleApp
{
    public class ApplicationDbContext : DbContext
    {
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        //{

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlServer("data source=CRIZMA-LAPTOP\\HAGAR; initial catalog=MovieDB; User Id=saa; Password=123456;");
        //protected override void OnConfiging(DbContextOptionsBuilder options)

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //DataType Of Columns On Entities Using Fluint Api
            modelBuilder.Entity<Models.Actor>(a =>
            {
                a.Property(ac => ac.FirstName).HasColumnType("varchar(20)");
                a.Property(ac => ac.LastName).HasColumnType("varchar(20)");
                a.Property(ac => ac.Gender).HasColumnType("varchar(1)");
            });

            modelBuilder.Entity<Models.Director>(D =>
            {
                D.Property(di => di.FirstName).HasColumnType("varchar(20)");
                D.Property(di => di.LastName).HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<Models.Movie>(M =>
            {
                M.Property(mo => mo.Title).HasColumnType("varchar(50)");
                M.Property(mo => mo.Language).HasColumnType("varchar(50)");
                M.Property(mo => mo.Country).HasColumnType("varchar(5)");
            });

            modelBuilder.Entity<Models.Reviewer>(R =>
            {
                R.Property(re => re.Name).HasColumnType("varchar(30)");
            });

            modelBuilder.Entity<Models.Genre>(G =>
            {
                G.Property(ge => ge.Title).HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<Models.MovieCast>(C =>
              C.Property(c => c.Role).HasColumnType("varchar(30)"));


            //Relations
            modelBuilder.Entity<Models.Rating>()
                .HasKey(R => new { R.MovieId, R.ReviewerId });


            //Many To Many between Movie & Director (MovieDirector Table) - "Indirect Relation"
            modelBuilder.Entity<Models.MovieDirector>()
                .HasKey(MD => new { MD.MovieId, MD.DirectorId });

            modelBuilder.Entity<Models.MovieDirector>()
                .HasOne(m => m.Movie)
                .WithMany(md => md.MovieDirectors)
                .HasForeignKey(m => m.MovieId);

            modelBuilder.Entity<Models.MovieDirector>()
               .HasOne(d => d.Director)
               .WithMany(md => md.MovieDirectors)
               .HasForeignKey(d => d.DirectorId);

            //Many To Many between Movie & Genre (MovieGenre Table) - "Indirect Relation"
            modelBuilder.Entity<Models.MovieGenre>()
                .HasKey(MG => new { MG.MovieId, MG.GenreId });

            modelBuilder.Entity<Models.MovieGenre>()
                .HasOne(m => m.Movie)
                .WithMany(mg => mg.MovieGenres)
                .HasForeignKey(m => m.MovieId);

            modelBuilder.Entity<Models.MovieGenre>()
                .HasOne(g => g.Genre)
                .WithMany(mg => mg.MovieGenres)
                .HasForeignKey(g => g.GenreId);

            //Many To Many between Movie & Actor (MovieCast Table) - "Indirect Relation"
            modelBuilder.Entity<Models.MovieCast>()
                .HasKey(MC => new { MC.MovieId, MC.ActorId , MC.Role});

            modelBuilder.Entity<Models.MovieCast>()
                .HasOne(m => m.Movie)
                .WithMany(mc => mc.MovieCasts)
                .HasForeignKey(m => m.MovieId);

            modelBuilder.Entity<Models.MovieCast>()
                .HasOne(c => c.Actor)
                .WithMany(mg => mg.MovieCasts)
                .HasForeignKey(c => c.ActorId);

        }






        public DbSet<Models.Actor> Actors { get; set; }
        public DbSet<Models.Director> Directors { get; set; }
        public DbSet<Models.Genre> Genres { get; set; }
        public DbSet<Models.Movie> Movies { get; set; }
        public DbSet<Models.Reviewer> Reviewers { get; set; }
        public DbSet<Models.Rating> Ratings { get; set; }

    }
}