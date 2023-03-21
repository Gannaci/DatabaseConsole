﻿// <auto-generated />
using System;
using DatabaseConsole.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DatabaseConsole.Migrations
{
    [DbContext(typeof(DataContexts))]
    [Migration("20230319235426_Imtestingalot")]
    partial class Imtestingalot
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DatabaseConsole.Models.Entity.CustomerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("char(13)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DatabaseConsole.Models.Entity.ErrandEntity", b =>
                {
                    b.Property<int>("ErrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ErrandId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("ErrandDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("ErrandId");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("Errands");
                });

            modelBuilder.Entity("DatabaseConsole.Models.Entity.StatusEntity", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ErrandId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("StatusId");

                    b.HasIndex("ErrandId")
                        .IsUnique();

                    b.ToTable("Status");
                });

            modelBuilder.Entity("DatabaseConsole.Models.Entity.ErrandEntity", b =>
                {
                    b.HasOne("DatabaseConsole.Models.Entity.CustomerEntity", "Customer")
                        .WithOne("Errand")
                        .HasForeignKey("DatabaseConsole.Models.Entity.ErrandEntity", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("DatabaseConsole.Models.Entity.StatusEntity", b =>
                {
                    b.HasOne("DatabaseConsole.Models.Entity.ErrandEntity", "Errand")
                        .WithOne("StatusAndComment")
                        .HasForeignKey("DatabaseConsole.Models.Entity.StatusEntity", "ErrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Errand");
                });

            modelBuilder.Entity("DatabaseConsole.Models.Entity.CustomerEntity", b =>
                {
                    b.Navigation("Errand")
                        .IsRequired();
                });

            modelBuilder.Entity("DatabaseConsole.Models.Entity.ErrandEntity", b =>
                {
                    b.Navigation("StatusAndComment")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
