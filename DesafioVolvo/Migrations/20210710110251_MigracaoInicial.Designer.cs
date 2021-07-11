﻿// <auto-generated />
using DesafioVolvo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DesafioVolvo.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210710110251_MigracaoInicial")]
    partial class MigracaoInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("DesafioVolvo.Truck", b =>
                {
                    b.Property<int>("TruckId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ManufactureYear");

                    b.Property<int>("ModelYear");

                    b.Property<int>("TruckModelId");

                    b.Property<string>("TruckName");

                    b.HasKey("TruckId");

                    b.ToTable("Trucks");
                });

            modelBuilder.Entity("DesafioVolvo.TruckModel", b =>
                {
                    b.Property<int>("TruckModelId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ModelName");

                    b.HasKey("TruckModelId");

                    b.ToTable("TruckModels");
                });
#pragma warning restore 612, 618
        }
    }
}