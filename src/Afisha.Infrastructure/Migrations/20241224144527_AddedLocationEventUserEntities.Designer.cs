﻿// <auto-generated />
using System;
using Afisha.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Afisha.Infrastructure.Migrations
{
    [DbContext(typeof(AfishaDbContext))]
    [Migration("20241224144527_AddedLocationEventUserEntities")]
    partial class AddedLocationEventUserEntities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Afisha.Domain.Entities.Event", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateOnly>("DateStart")
                        .HasColumnType("date");

                    b.Property<long>("LocationId")
                        .HasColumnType("bigint");

                    b.Property<long>("SponsorId")
                        .HasColumnType("bigint");

                    b.Property<long>("SponsorId1")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SponsorId");

                    b.HasIndex("SponsorId1");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Afisha.Domain.Entities.Location", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("IsWarmPlace")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(140)
                        .HasColumnType("character varying(140)");

                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Pricing")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Afisha.Domain.Entities.LocationEvent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("EventId")
                        .HasColumnType("bigint");

                    b.Property<long>("LocationId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("LocationId", "EventId")
                        .IsUnique();

                    b.ToTable("LocationEvents");
                });

            modelBuilder.Entity("Afisha.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool?>("IsMale")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SurName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Afisha.Domain.Entities.Event", b =>
                {
                    b.HasOne("Afisha.Domain.Entities.User", null)
                        .WithMany("Events")
                        .HasForeignKey("SponsorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Afisha.Domain.Entities.User", "Sponsor")
                        .WithMany()
                        .HasForeignKey("SponsorId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sponsor");
                });

            modelBuilder.Entity("Afisha.Domain.Entities.Location", b =>
                {
                    b.HasOne("Afisha.Domain.Entities.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Afisha.Domain.Entities.LocationEvent", b =>
                {
                    b.HasOne("Afisha.Domain.Entities.Event", "Event")
                        .WithMany("LocationEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Afisha.Domain.Entities.Location", "Location")
                        .WithMany("LocationEvents")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Afisha.Domain.Entities.Event", b =>
                {
                    b.Navigation("LocationEvents");
                });

            modelBuilder.Entity("Afisha.Domain.Entities.Location", b =>
                {
                    b.Navigation("LocationEvents");
                });

            modelBuilder.Entity("Afisha.Domain.Entities.User", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
