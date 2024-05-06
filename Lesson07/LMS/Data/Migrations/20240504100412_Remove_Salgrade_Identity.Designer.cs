﻿// <auto-generated />
using System;
using LMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LMS.Data.Migrations
{
    [DbContext(typeof(EmployeeManagementDbContext))]
    [Migration("20240504100412_Remove_Salgrade_Identity")]
    partial class Remove_Salgrade_Identity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LMS.Models.Department", b =>
                {
                    b.Property<decimal>("Number")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Number");

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
#pragma warning restore 612, 618
        }
    }
}
