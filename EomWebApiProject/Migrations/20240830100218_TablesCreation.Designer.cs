﻿// <auto-generated />
using System;
using EomWebApiProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EomWebApiProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240830100218_TablesCreation")]
    partial class TablesCreation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EomWebApiProject.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<int>("SingerId")
                        .HasColumnType("int");

                    b.Property<int>("TrackCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("SingerId")
                        .IsUnique();

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("EomWebApiProject.Models.AlbumSong", b =>
                {
                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int>("SongId")
                        .HasColumnType("int");

                    b.HasKey("AlbumId", "SongId");

                    b.HasIndex("SongId");

                    b.ToTable("AlbumSongs");
                });

            modelBuilder.Entity("EomWebApiProject.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("GenreDiscription")
                        .HasColumnType("text");

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("EomWebApiProject.Models.PlayList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("PlayListName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("PlayList");
                });

            modelBuilder.Entity("EomWebApiProject.Models.PlaylistSong", b =>
                {
                    b.Property<int>("PlaylistId")
                        .HasColumnType("int");

                    b.Property<int>("SongId")
                        .HasColumnType("int");

                    b.HasKey("PlaylistId", "SongId");

                    b.HasIndex("SongId");

                    b.ToTable("PlaylistSongs");
                });

            modelBuilder.Entity("EomWebApiProject.Models.Singer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AboutSinger")
                        .HasColumnType("text");

                    b.Property<DateOnly?>("Birth")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("Death")
                        .HasColumnType("date");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Singers");
                });

            modelBuilder.Entity("EomWebApiProject.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int?>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Lyrics")
                        .HasColumnType("text");

                    b.Property<string>("MusicName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("MusicPath")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime?>("PublishDate")
                        .HasColumnType("datetime");

                    b.Property<DateOnly?>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<string>("Review")
                        .HasColumnType("text");

                    b.Property<string>("Slug")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Tag")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Views")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("GenreId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("EomWebApiProject.Models.SongSinger", b =>
                {
                    b.Property<int>("SingerId")
                        .HasColumnType("int");

                    b.Property<int>("SongId")
                        .HasColumnType("int");

                    b.HasKey("SingerId", "SongId");

                    b.HasIndex("SongId");

                    b.ToTable("SongSingers");
                });

            modelBuilder.Entity("EomWebApiProject.Models.Album", b =>
                {
                    b.HasOne("EomWebApiProject.Models.Genre", "Genre")
                        .WithMany("Albums")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EomWebApiProject.Models.Singer", "Singer")
                        .WithOne("Album")
                        .HasForeignKey("EomWebApiProject.Models.Album", "SingerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Singer");
                });

            modelBuilder.Entity("EomWebApiProject.Models.AlbumSong", b =>
                {
                    b.HasOne("EomWebApiProject.Models.Album", "Album")
                        .WithMany()
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EomWebApiProject.Models.Song", "Song")
                        .WithMany()
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("EomWebApiProject.Models.PlayList", b =>
                {
                    b.HasOne("EomWebApiProject.Models.Genre", "Genre")
                        .WithMany("PlayLists")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("EomWebApiProject.Models.PlaylistSong", b =>
                {
                    b.HasOne("EomWebApiProject.Models.PlayList", "PlayList")
                        .WithMany("PlaylistSongs")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EomWebApiProject.Models.Song", "Song")
                        .WithMany("PlaylistSongs")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PlayList");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("EomWebApiProject.Models.Singer", b =>
                {
                    b.HasOne("EomWebApiProject.Models.Genre", "Genre")
                        .WithMany("Singers")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("EomWebApiProject.Models.Song", b =>
                {
                    b.HasOne("EomWebApiProject.Models.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EomWebApiProject.Models.Genre", "Genre")
                        .WithMany("Songs")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Album");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("EomWebApiProject.Models.SongSinger", b =>
                {
                    b.HasOne("EomWebApiProject.Models.Singer", "Singer")
                        .WithMany("SongSingers")
                        .HasForeignKey("SingerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EomWebApiProject.Models.Song", "Song")
                        .WithMany("SongSingers")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Singer");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("EomWebApiProject.Models.Album", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("EomWebApiProject.Models.Genre", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("PlayLists");

                    b.Navigation("Singers");

                    b.Navigation("Songs");
                });

            modelBuilder.Entity("EomWebApiProject.Models.PlayList", b =>
                {
                    b.Navigation("PlaylistSongs");
                });

            modelBuilder.Entity("EomWebApiProject.Models.Singer", b =>
                {
                    b.Navigation("Album")
                        .IsRequired();

                    b.Navigation("SongSingers");
                });

            modelBuilder.Entity("EomWebApiProject.Models.Song", b =>
                {
                    b.Navigation("PlaylistSongs");

                    b.Navigation("SongSingers");
                });
#pragma warning restore 612, 618
        }
    }
}
