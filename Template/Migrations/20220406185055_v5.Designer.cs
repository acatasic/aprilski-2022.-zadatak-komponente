﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Template.Models;

namespace Template.Migrations
{
    [DbContext(typeof(IspitDbContext))]
    [Migration("20220406185055_v5")]
    partial class v5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BrendProdavnica", b =>
                {
                    b.Property<int>("BrendID")
                        .HasColumnType("int");

                    b.Property<int>("ProdavnicaID")
                        .HasColumnType("int");

                    b.HasKey("BrendID", "ProdavnicaID");

                    b.HasIndex("ProdavnicaID");

                    b.ToTable("BrendProdavnica");
                });

            modelBuilder.Entity("ProdavnicaTip", b =>
                {
                    b.Property<int>("ProdavnicaID")
                        .HasColumnType("int");

                    b.Property<int>("TipID")
                        .HasColumnType("int");

                    b.HasKey("ProdavnicaID", "TipID");

                    b.HasIndex("TipID");

                    b.ToTable("ProdavnicaTip");
                });

            modelBuilder.Entity("Template.Models.Brend", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Brend");
                });

            modelBuilder.Entity("Template.Models.Prodavnica", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("Prodavnica");
                });

            modelBuilder.Entity("Template.Models.Proizvod", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BrendID")
                        .HasColumnType("int");

                    b.Property<int?>("ProdavnicaID")
                        .HasColumnType("int");

                    b.Property<int?>("TipID")
                        .HasColumnType("int");

                    b.Property<int>("cena")
                        .HasColumnType("int")
                        .HasColumnName("Cena");

                    b.Property<string>("naziv")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Naziv");

                    b.Property<int>("sifra")
                        .HasColumnType("int")
                        .HasColumnName("Sifra");

                    b.HasKey("ID");

                    b.HasIndex("BrendID");

                    b.HasIndex("ProdavnicaID");

                    b.HasIndex("TipID");

                    b.ToTable("Proizvod");
                });

            modelBuilder.Entity("Template.Models.Tip", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Tip");
                });

            modelBuilder.Entity("BrendProdavnica", b =>
                {
                    b.HasOne("Template.Models.Brend", null)
                        .WithMany()
                        .HasForeignKey("BrendID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Template.Models.Prodavnica", null)
                        .WithMany()
                        .HasForeignKey("ProdavnicaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProdavnicaTip", b =>
                {
                    b.HasOne("Template.Models.Prodavnica", null)
                        .WithMany()
                        .HasForeignKey("ProdavnicaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Template.Models.Tip", null)
                        .WithMany()
                        .HasForeignKey("TipID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Template.Models.Proizvod", b =>
                {
                    b.HasOne("Template.Models.Brend", "Brend")
                        .WithMany("Proizvod")
                        .HasForeignKey("BrendID");

                    b.HasOne("Template.Models.Prodavnica", "Prodavnica")
                        .WithMany("Proizvod")
                        .HasForeignKey("ProdavnicaID");

                    b.HasOne("Template.Models.Tip", "Tip")
                        .WithMany("Proizvod")
                        .HasForeignKey("TipID");

                    b.Navigation("Brend");

                    b.Navigation("Prodavnica");

                    b.Navigation("Tip");
                });

            modelBuilder.Entity("Template.Models.Brend", b =>
                {
                    b.Navigation("Proizvod");
                });

            modelBuilder.Entity("Template.Models.Prodavnica", b =>
                {
                    b.Navigation("Proizvod");
                });

            modelBuilder.Entity("Template.Models.Tip", b =>
                {
                    b.Navigation("Proizvod");
                });
#pragma warning restore 612, 618
        }
    }
}
