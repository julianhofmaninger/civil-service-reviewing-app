﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AgencyPosition", b =>
                {
                    b.Property<Guid>("AgenciesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PositionsId")
                        .HasColumnType("uuid");

                    b.HasKey("AgenciesId", "PositionsId");

                    b.HasIndex("PositionsId");

                    b.ToTable("AgencyPosition");
                });

            modelBuilder.Entity("Domain.Agencies.Agency", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ComplexProperty<Dictionary<string, object>>("Address", "Domain.Agencies.Agency.Address#Address", b1 =>
                        {
                            b1.Property<string>("AddressName")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("AreaCode")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("DistrictCode")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Region")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnType("text");
                        });

                    b.HasKey("Id");

                    b.ToTable("Agencies");
                });

            modelBuilder.Entity("Domain.Departments.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Domain.Owners.Owner", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ComplexProperty<Dictionary<string, object>>("Address", "Domain.Owners.Owner.Address#Address", b1 =>
                        {
                            b1.Property<string>("AddressName")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("AreaCode")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("DistrictCode")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Region")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnType("text");
                        });

                    b.HasKey("Id");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("Domain.Positions.Position", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Activity")
                        .HasColumnType("text");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LastSyncedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ComplexProperty<Dictionary<string, object>>("Address", "Domain.Positions.Position.Address#Address", b1 =>
                        {
                            b1.Property<string>("AddressName")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("AreaCode")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("DistrictCode")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Region")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnType("text");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Code", "Domain.Positions.Position.Code#Code", b1 =>
                        {
                            b1.Property<int>("Value")
                                .HasColumnType("integer");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Contact", "Domain.Positions.Position.Contact#Contact", b1 =>
                        {
                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Homepage")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Phone")
                                .IsRequired()
                                .HasColumnType("text");
                        });

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Domain.Slots.Slot", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<int>("Available")
                        .HasColumnType("integer");

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<Guid>("PositionId")
                        .HasColumnType("uuid");

                    b.Property<int>("Used")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Slots");
                });

            modelBuilder.Entity("Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EmailConfirmedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ComplexProperty<Dictionary<string, object>>("Name", "Domain.Users.User.Name#Name", b1 =>
                        {
                            b1.Property<string>("Firstname")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Lastname")
                                .IsRequired()
                                .HasColumnType("text");
                        });

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AgencyPosition", b =>
                {
                    b.HasOne("Domain.Agencies.Agency", null)
                        .WithMany()
                        .HasForeignKey("AgenciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Positions.Position", null)
                        .WithMany()
                        .HasForeignKey("PositionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Positions.Position", b =>
                {
                    b.HasOne("Domain.Departments.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Owners.Owner", "Owner")
                        .WithMany("Positions")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Domain.Slots.Slot", b =>
                {
                    b.HasOne("Domain.Positions.Position", "Position")
                        .WithMany("Slots")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");
                });

            modelBuilder.Entity("Domain.Owners.Owner", b =>
                {
                    b.Navigation("Positions");
                });

            modelBuilder.Entity("Domain.Positions.Position", b =>
                {
                    b.Navigation("Slots");
                });
#pragma warning restore 612, 618
        }
    }
}
