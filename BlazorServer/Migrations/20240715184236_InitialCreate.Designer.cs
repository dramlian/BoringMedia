﻿// <auto-generated />
using System;
using BlazorServer.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlazorServer.Migrations
{
    [DbContext(typeof(MessagesContext))]
    [Migration("20240715184236_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BlazorServer.Data.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("recipientName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("recipientUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("senderUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("senderUserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("MyClasses");
                });
#pragma warning restore 612, 618
        }
    }
}
