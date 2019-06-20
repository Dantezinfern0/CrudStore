﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using crudstore;

namespace crudstore.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20190620174258_Data model updated")]
    partial class Datamodelupdated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("crudstore.Models.CrudItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOrdered");

                    b.Property<string>("Description");

                    b.Property<int?>("LocationId");

                    b.Property<string>("Name");

                    b.Property<int>("NumberInStock");

                    b.Property<decimal>("Price");

                    b.Property<int>("SKU");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("CrudItems");
                });

            modelBuilder.Entity("crudstore.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("ManagerName");

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("StoreNumber");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("crudstore.Models.CrudItem", b =>
                {
                    b.HasOne("crudstore.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");
                });
#pragma warning restore 612, 618
        }
    }
}
