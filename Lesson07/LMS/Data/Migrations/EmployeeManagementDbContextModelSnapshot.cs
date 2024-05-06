﻿// <auto-generated />
using System;
using LMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LMS.Data.Migrations
{
    [DbContext(typeof(EmployeeManagementDbContext))]
    partial class EmployeeManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LMS.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("LMS.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("LMS.Models.Department", b =>
                {
                    b.Property<decimal>("Number")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CityNumber")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Number");

                    b.HasIndex("CityNumber");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("LMS.Models.Employee", b =>
                {
                    b.Property<decimal>("Number")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Commission")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DepartmentNumber")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Hiredate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Job")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("ManagerNumber")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Number");

                    b.HasIndex("DepartmentNumber");

                    b.HasIndex("ManagerNumber");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("LMS.Models.Salgrade", b =>
                {
                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<decimal>("HighestSalary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("LowestSalary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Grade");

                    b.ToTable("Salgrades");
                });

            modelBuilder.Entity("LMS.Models.Street", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValue("Oybek street");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Street", (string)null);
                });

            modelBuilder.Entity("LMS.Models.City", b =>
                {
                    b.HasOne("LMS.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("LMS.Models.Department", b =>
                {
                    b.HasOne("LMS.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("LMS.Models.Employee", b =>
                {
                    b.HasOne("LMS.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LMS.Models.Employee", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerNumber");

                    b.Navigation("Department");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("LMS.Models.Street", b =>
                {
                    b.HasOne("LMS.Models.City", "City")
                        .WithMany("Streets")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Street_City_FK");

                    b.Navigation("City");
                });

            modelBuilder.Entity("LMS.Models.City", b =>
                {
                    b.Navigation("Streets");
                });

            modelBuilder.Entity("LMS.Models.Country", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
