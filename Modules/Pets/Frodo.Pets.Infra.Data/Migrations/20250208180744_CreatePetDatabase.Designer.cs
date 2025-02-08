﻿// <auto-generated />
using System;
using Frodo.Pets.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Frodo.Pets.Infra.Data.Migrations
{
    [DbContext(typeof(PetContext))]
    [Migration("20250208180744_CreatePetDatabase")]
    partial class CreatePetDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Pets")
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Frodo.Pets.Domain.Entities.Medication", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedIn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVaccine")
                        .HasColumnType("bit");

                    b.Property<bool>("Mandatory")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedIn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Medications", "Pets");
                });

            modelBuilder.Entity("Frodo.Pets.Domain.Entities.Pet", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedIn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Race")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedIn")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Pets", "Pets");
                });

            modelBuilder.Entity("Frodo.Pets.Domain.Entities.PetUser", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedIn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedIn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.ToTable("PetUsers", "Pets");
                });

            modelBuilder.Entity("Frodo.Pets.Domain.Entities.PetVaccine", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedIn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DoctorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Laboratory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MedicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedIn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.ToTable("PetVaccines", "Pets");
                });

            modelBuilder.Entity("Frodo.Pets.Domain.Entities.PetVaccineDate", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedIn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PetVaccineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("RevaccinateIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VaccinationIn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PetVaccineId");

                    b.ToTable("PetVaccineDates", "Pets");
                });

            modelBuilder.Entity("Frodo.Pets.Domain.Entities.PetUser", b =>
                {
                    b.HasOne("Frodo.Pets.Domain.Entities.Pet", null)
                        .WithMany("Users")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Frodo.Pets.Domain.Entities.PetVaccine", b =>
                {
                    b.HasOne("Frodo.Pets.Domain.Entities.Pet", null)
                        .WithMany("Vaccines")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Frodo.Pets.Domain.Entities.PetVaccineDate", b =>
                {
                    b.HasOne("Frodo.Pets.Domain.Entities.PetVaccine", null)
                        .WithMany("Dates")
                        .HasForeignKey("PetVaccineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Frodo.Pets.Domain.Entities.Pet", b =>
                {
                    b.Navigation("Users");

                    b.Navigation("Vaccines");
                });

            modelBuilder.Entity("Frodo.Pets.Domain.Entities.PetVaccine", b =>
                {
                    b.Navigation("Dates");
                });
#pragma warning restore 612, 618
        }
    }
}
