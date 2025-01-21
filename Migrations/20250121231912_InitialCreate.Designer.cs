﻿// <auto-generated />
using System;
using FarmAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiFarm.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250121231912_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("FarmAPI.Models.Farm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CurrentPlantId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ReadyProducts")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsedSpace")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CurrentPlantId");

                    b.HasIndex("UserId");

                    b.ToTable("Farms");
                });

            modelBuilder.Entity("FarmAPI.Models.Plant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("GrowthTime")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("KeepOnCollect")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.PrimitiveCollection<string>("RequiredAchievements")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Season")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SpaceRequired")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Plants");
                });

            modelBuilder.Entity("FarmAPI.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.PrimitiveCollection<string>("Achievements")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("JoinedAt")
                        .HasColumnType("TEXT");

                    b.Property<ulong>("Level")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("Money")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("Popularity")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FarmAPI.Models.Farm", b =>
                {
                    b.HasOne("FarmAPI.Models.Plant", "CurrentPlant")
                        .WithMany()
                        .HasForeignKey("CurrentPlantId");

                    b.HasOne("FarmAPI.Models.User", null)
                        .WithMany("Farms")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentPlant");
                });

            modelBuilder.Entity("FarmAPI.Models.User", b =>
                {
                    b.Navigation("Farms");
                });
#pragma warning restore 612, 618
        }
    }
}
