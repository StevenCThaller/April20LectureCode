﻿// <auto-generated />
using System;
using EntityIntro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityIntro.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20200420180406_AddingVeggies")]
    partial class AddingVeggies
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EntityIntro.Models.Burrito", b =>
                {
                    b.Property<int>("BurritoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Beans")
                        .IsRequired();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("Guac");

                    b.Property<string>("Meat")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Rice")
                        .IsRequired();

                    b.Property<int>("RitoMasterId");

                    b.Property<string>("Tortilla")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("BurritoId");

                    b.HasIndex("RitoMasterId");

                    b.ToTable("Burritos");
                });

            modelBuilder.Entity("EntityIntro.Models.RitoMaster", b =>
                {
                    b.Property<int>("RitoMasterId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("RitoMasterId");

                    b.ToTable("RitoMasters");
                });

            modelBuilder.Entity("EntityIntro.Models.VegRito", b =>
                {
                    b.Property<int>("VegRitoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BurritoId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("VegetableId");

                    b.HasKey("VegRitoId");

                    b.HasIndex("BurritoId");

                    b.HasIndex("VegetableId");

                    b.ToTable("VegRitos");
                });

            modelBuilder.Entity("EntityIntro.Models.Vegetable", b =>
                {
                    b.Property<int>("VegetableId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("VegetableId");

                    b.ToTable("Veggies");
                });

            modelBuilder.Entity("EntityIntro.Models.Burrito", b =>
                {
                    b.HasOne("EntityIntro.Models.RitoMaster", "RitoMaster")
                        .WithMany("Burritos")
                        .HasForeignKey("RitoMasterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EntityIntro.Models.VegRito", b =>
                {
                    b.HasOne("EntityIntro.Models.Burrito", "Burrito")
                        .WithMany("VegetablesInBurrito")
                        .HasForeignKey("BurritoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EntityIntro.Models.Vegetable", "Vegetable")
                        .WithMany("BurritosWithVegetable")
                        .HasForeignKey("VegetableId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}