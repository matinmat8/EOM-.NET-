using Microsoft.EntityFrameworkCore;
using EomWebApiProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;



namespace EomWebApiProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }


        public DbSet<Song> Songs { get; set; }
        public DbSet<Singer> Singers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<PlaylistSong> PlaylistSongs { get; set; }
        public DbSet<AlbumSong> AlbumSongs { get; set; }
        public DbSet<SongSinger> SongSingers { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            // Song entity configuration
            modelBuilder.Entity<Song>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MusicName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("date");

                entity.Property(e => e.PublishDate)
                    .HasColumnType("datetime");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(1000);

                entity.Property(e => e.MusicPath)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Lyrics)
                    .HasColumnType("text");

                entity.Property(e => e.Review)
                    .HasColumnType("text");

                entity.Property(e => e.Tag)
                    .HasMaxLength(100);

                entity.Property(e => e.Slug)
                    .HasMaxLength(250);

                entity.HasOne(e => e.Genre)
                    .WithMany(g => g.Songs)
                    .HasForeignKey(e => e.GenreId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Ignore(e => e.ImageFile);
                entity.Ignore(e => e.MusicFile);

                entity.HasMany(e => e.PlaylistSongs)
                    .WithOne(ps => ps.Song)
                    .HasForeignKey(ps => ps.SongId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Album)
                    .WithMany(r => r.Songs)
                    .HasForeignKey(r => r.AlbumId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.SongSingers)
                    .WithOne(ss => ss.Song)
                    .HasForeignKey(ss => ss.SongId)
                    .OnDelete(DeleteBehavior.Restrict);

                _ = entity.HasData(
                new Song
                {
                    Id = 1,
                    UserName = "Matin",
                    MusicName = "Be mine",
                    ReleaseDate = new DateOnly(2022, 2, 1),
                    PublishDate = new DateTime(2020, 1, 1),
                    MusicPath = "path/to/song1.mp3",
                    GenreId = 3,
                    AlbumId = 3
                },
                new Song
                {
                    Id = 2,
                    UserName = "user2",
                    MusicName = "Song2",
                    ReleaseDate = new DateOnly(2020, 2, 1),
                    PublishDate = new DateTime(2020, 2, 1),
                    MusicPath = "path/to/song2.mp3",
                    GenreId = 4,
                    AlbumId = 4
                }
            );
            });

            // Singer entity configuration
            modelBuilder.Entity<Singer>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Birth)
                    .HasColumnType("date");

                entity.Property(e => e.Death)
                    .HasColumnType("date");

                entity.Property(e => e.AboutSinger)
                    .HasColumnType("text");

                entity.HasOne(e => e.Genre)
                    .WithMany(g => g.Singers)
                    .HasForeignKey(e => e.GenreId);

                entity.HasMany(e => e.SongSingers)
                    .WithOne(ss => ss.Singer)
                    .HasForeignKey(ss => ss.SingerId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                entity.HasOne(e => e.Album)
                    .WithOne(a => a.Singer)
                    .HasForeignKey<Album>(e => e.SingerId);

                _ = entity.HasData(
                    new Singer { Id = 1, Name = "Drake", Birth = new DateOnly(1980, 1, 1), GenreId = 3 },
                    new Singer { Id = 2, Name = "Moein", Birth = new DateOnly(1990, 1, 1), GenreId = 4 }
                );
            });

            // Genre entity configuration
            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.GenreName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.GenreDiscription)
                    .HasColumnType("text");

                entity.HasMany(e => e.Singers)
                    .WithOne(s => s.Genre)
                    .HasForeignKey(s => s.GenreId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.Songs)
                    .WithOne(s => s.Genre)
                    .HasForeignKey(s => s.GenreId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.Albums)
                    .WithOne(a => a.Genre)
                    .HasForeignKey(a => a.GenreId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.PlayLists)
                    .WithOne(p => p.Genre)
                    .HasForeignKey(p => p.GenreId)
                    .OnDelete(DeleteBehavior.Restrict);
                _ = entity.HasData(
                    new Genre { Id = 3, GenreName = "Rock" },
                    new Genre { Id = 4, GenreName = "Pop" }
        );
            });

            modelBuilder.Entity<SongSinger>()
                .HasKey(a => new { a.SingerId, a.SongId});

            modelBuilder.Entity<PlaylistSong>()
                .HasKey(a => new { a.PlaylistId, a.SongId});

            modelBuilder.Entity<AlbumSong>()
                .HasKey(a => new { a.AlbumId, a.SongId });
            

            // Album entity configuration
            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.AlbumName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("date");

                entity.Property(e => e.TrackCount)
                    .IsRequired();

                entity.HasOne(e => e.Genre)
                    .WithMany(g => g.Albums)
                    .HasForeignKey(e => e.GenreId);

                entity.HasMany(e => e.Songs)
                    .WithOne(r => r.Album)
                    .HasForeignKey(r => r.AlbumId)
                    .OnDelete(DeleteBehavior.Restrict);
                _ = entity.HasData(
                    new Album
                    {
                        Id = 3,
                        AlbumName = "Album1",
                        ReleaseDate = new DateOnly(2023, 2, 1),
                        GenreId = 4,
                        TrackCount = 10
                    },
                    new Album
                    {
                        Id = 4,
                        AlbumName = "Album2",
                        ReleaseDate = new DateOnly(2020, 2, 1),
                        GenreId = 3,
                        TrackCount = 12
                    }
                );
            });

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=SongDatabase;User Id=SA;Password=MatinMat8; TrustServerCertificate=True;");
        }
    }
}
