﻿// <auto-generated />
using System;
using DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataModel.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190805203054_AddWeatherMigration1")]
    partial class AddWeatherMigration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataModel.Models.DirectionWind", b =>
                {
                    b.Property<int>("DirectionWindId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("DirectionWindId");

                    b.ToTable("DirectionWinds");
                });

            modelBuilder.Entity("DataModel.Models.Weather", b =>
                {
                    b.Property<int>("WeatherId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Atmosphere");

                    b.Property<int>("H");

                    b.Property<int>("Humidity");

                    b.Property<int>("OverCast");

                    b.Property<int>("SpeedWind");

                    b.Property<double>("Td");

                    b.Property<double>("Temperature");

                    b.Property<DateTime>("TimeMeasuring");

                    b.Property<int?>("VW");

                    b.Property<int?>("WeatherConditionId");

                    b.HasKey("WeatherId");

                    b.HasIndex("WeatherConditionId");

                    b.ToTable("Weathers");
                });

            modelBuilder.Entity("DataModel.Models.WeatherCondition", b =>
                {
                    b.Property<int>("WeatherConditionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("WeatherConditionId");

                    b.ToTable("WeatherConditions");
                });

            modelBuilder.Entity("DataModel.Models.WeatherDirectionWind", b =>
                {
                    b.Property<int>("WeatherDirectionWindId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DirectionWindId");

                    b.Property<int?>("WeatherId");

                    b.HasKey("WeatherDirectionWindId");

                    b.HasIndex("DirectionWindId");

                    b.HasIndex("WeatherId");

                    b.ToTable("WeatherDirectionWinds");
                });

            modelBuilder.Entity("DataModel.Models.Weather", b =>
                {
                    b.HasOne("DataModel.Models.WeatherCondition", "WeatherCondition")
                        .WithMany()
                        .HasForeignKey("WeatherConditionId");
                });

            modelBuilder.Entity("DataModel.Models.WeatherDirectionWind", b =>
                {
                    b.HasOne("DataModel.Models.DirectionWind", "DirectionWind")
                        .WithMany()
                        .HasForeignKey("DirectionWindId");

                    b.HasOne("DataModel.Models.Weather", "Weather")
                        .WithMany("WeatherDirectionWinds")
                        .HasForeignKey("WeatherId");
                });
#pragma warning restore 612, 618
        }
    }
}
