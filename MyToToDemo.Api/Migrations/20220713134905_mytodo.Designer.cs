﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyToToDemo.Api.Context;

namespace MyToToDemo.Api.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20220713134905_mytodo")]
    partial class mytodo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("MyToToDemo.Api.Context.Memo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Memos");
                });

            modelBuilder.Entity("MyToToDemo.Api.Context.ToDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("content")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ToDos");
                });

            modelBuilder.Entity("MyToToDemo.Api.Context.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Account")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("PassWord")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}