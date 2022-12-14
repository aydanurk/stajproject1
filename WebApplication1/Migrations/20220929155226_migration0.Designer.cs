// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20220929155226_migration0")]
    partial class migration0
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplication1.Models.Ders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DersKodu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DersName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dersler");
                });

            modelBuilder.Entity("WebApplication1.Models.Ogrenci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("OgrenciBirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OgrenciLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OgrenciName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OgrenciNo")
                        .HasColumnType("int");

                    b.Property<string>("OgrenciTc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OgretmenId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ogrenciler");
                });

            modelBuilder.Entity("WebApplication1.Models.Ogretmen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DersId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OgretmenBirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OgretmenLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OgretmenName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OgretmenTc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ogretmenler");
                });
#pragma warning restore 612, 618
        }
    }
}
