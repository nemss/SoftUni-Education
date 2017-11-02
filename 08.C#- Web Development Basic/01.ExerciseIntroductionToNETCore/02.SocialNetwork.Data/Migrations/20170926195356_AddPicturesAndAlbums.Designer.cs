﻿// <auto-generated />
using _02.SocialNetwork.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace _02.SocialNetwork.Data.Migrations
{
    [DbContext(typeof(SocialNetworkDbContext))]
    [Migration("20170926195356_AddPicturesAndAlbums")]
    partial class AddPicturesAndAlbums
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("__02.SocialNetwork.Data.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Background")
                        .IsRequired();

                    b.Property<bool>("IsPublic");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("_02.SocialNetwork.Data.AlbumPicture", b =>
                {
                    b.Property<int>("AlbumId");

                    b.Property<int>("PictureId");

                    b.HasKey("AlbumId", "PictureId");

                    b.HasIndex("PictureId");

                    b.ToTable("AlbumPictures");
                });

            modelBuilder.Entity("_02.SocialNetwork.Data.FriendShip", b =>
                {
                    b.Property<int>("FromUserId");

                    b.Property<int>("ToUserId");

                    b.HasKey("FromUserId", "ToUserId");

                    b.HasIndex("ToUserId");

                    b.ToTable("FriendShips");
                });

            modelBuilder.Entity("_02.SocialNetwork.Data.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Caption")
                        .IsRequired();

                    b.Property<string>("Path")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("_02.SocialNetwork.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Age");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastTimeLoggetIn");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<byte[]>("ProfilePictire")
                        .HasMaxLength(1024);

                    b.Property<DateTime?>("RegisteredOn");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("_02.SocialNetwork.Data.AlbumPicture", b =>
                {
                    b.HasOne("__02.SocialNetwork.Data.Album", "Album")
                        .WithMany("Pictures")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("_02.SocialNetwork.Data.Picture", "Picture")
                        .WithMany("Albums")
                        .HasForeignKey("PictureId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("_02.SocialNetwork.Data.FriendShip", b =>
                {
                    b.HasOne("_02.SocialNetwork.Data.User", "FromUser")
                        .WithMany("FromFriends")
                        .HasForeignKey("FromUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("_02.SocialNetwork.Data.User", "ToUser")
                        .WithMany("ToFriends")
                        .HasForeignKey("ToUserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}