﻿// <auto-generated />
using System;
using DBTemplate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DBTemplate.Migrations
{
    [DbContext(typeof(UniDbContext))]
    [Migration("20231216210840_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("PersonSequence");

            modelBuilder.Entity("DBTemplate.Entities.Chair", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FacultyId")
                        .HasColumnType("int");

                    b.Property<int?>("HeadId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.HasIndex("HeadId");

                    b.ToTable("Chairs");
                });

            modelBuilder.Entity("DBTemplate.Entities.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DeanId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeanId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("DBTemplate.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SpecialityId")
                        .HasColumnType("int");

                    b.Property<int?>("SupervisorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpecialityId");

                    b.HasIndex("SupervisorId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("DBTemplate.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR [PersonSequence]");

                    SqlServerPropertyBuilderExtensions.UseSequence(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People");

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("DBTemplate.Entities.Speciality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ChairId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChairId");

                    b.ToTable("Specialities");
                });

            modelBuilder.Entity("DBTemplate.Entities.Employee", b =>
                {
                    b.HasBaseType("DBTemplate.Entities.Person");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "whitetpm@gmail.com",
                            FirstName = "Tom",
                            LastName = "White",
                            Phone = "380508854711"
                        });
                });

            modelBuilder.Entity("DBTemplate.Entities.Student", b =>
                {
                    b.HasBaseType("DBTemplate.Entities.Person");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.HasIndex("GroupId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("DBTemplate.Entities.Chair", b =>
                {
                    b.HasOne("DBTemplate.Entities.Faculty", "Faculty")
                        .WithMany("Chairs")
                        .HasForeignKey("FacultyId");

                    b.HasOne("DBTemplate.Entities.Employee", "Head")
                        .WithMany()
                        .HasForeignKey("HeadId");

                    b.Navigation("Faculty");

                    b.Navigation("Head");
                });

            modelBuilder.Entity("DBTemplate.Entities.Faculty", b =>
                {
                    b.HasOne("DBTemplate.Entities.Employee", "Dean")
                        .WithMany()
                        .HasForeignKey("DeanId");

                    b.Navigation("Dean");
                });

            modelBuilder.Entity("DBTemplate.Entities.Group", b =>
                {
                    b.HasOne("DBTemplate.Entities.Speciality", "Speciality")
                        .WithMany()
                        .HasForeignKey("SpecialityId");

                    b.HasOne("DBTemplate.Entities.Employee", "Supervisor")
                        .WithMany()
                        .HasForeignKey("SupervisorId");

                    b.Navigation("Speciality");

                    b.Navigation("Supervisor");
                });

            modelBuilder.Entity("DBTemplate.Entities.Speciality", b =>
                {
                    b.HasOne("DBTemplate.Entities.Chair", "Chair")
                        .WithMany("Specialities")
                        .HasForeignKey("ChairId");

                    b.Navigation("Chair");
                });

            modelBuilder.Entity("DBTemplate.Entities.Student", b =>
                {
                    b.HasOne("DBTemplate.Entities.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("DBTemplate.Entities.Chair", b =>
                {
                    b.Navigation("Specialities");
                });

            modelBuilder.Entity("DBTemplate.Entities.Faculty", b =>
                {
                    b.Navigation("Chairs");
                });

            modelBuilder.Entity("DBTemplate.Entities.Group", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
