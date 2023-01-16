﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProiectMeridian.Data;

#nullable disable

namespace ProiectMeridian.Migrations
{
    [DbContext(typeof(ProiectMeridianContext))]
    [Migration("20230108164751_Create2")]
    partial class Create2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProiectMeridian.Models.Distribuitor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Distribuitori")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Distribuitor");
                });

            modelBuilder.Entity("ProiectMeridian.Models.Producator", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Producatori")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Producator");
                });

            modelBuilder.Entity("ProiectMeridian.Models.Telefon", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Culoare")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DistribuitorID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProducatorID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DistribuitorID");

                    b.HasIndex("ProducatorID");

                    b.ToTable("Telefon");
                });

            modelBuilder.Entity("ProiectMeridian.Models.Telefon", b =>
                {
                    b.HasOne("ProiectMeridian.Models.Distribuitor", "Distribuitor")
                        .WithMany("Phones")
                        .HasForeignKey("DistribuitorID");

                    b.HasOne("ProiectMeridian.Models.Producator", "Producator")
                        .WithMany("Phones")
                        .HasForeignKey("ProducatorID");

                    b.Navigation("Distribuitor");

                    b.Navigation("Producator");
                });

            modelBuilder.Entity("ProiectMeridian.Models.Distribuitor", b =>
                {
                    b.Navigation("Phones");
                });

            modelBuilder.Entity("ProiectMeridian.Models.Producator", b =>
                {
                    b.Navigation("Phones");
                });
#pragma warning restore 612, 618
        }
    }
}
