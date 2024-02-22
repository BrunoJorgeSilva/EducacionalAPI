﻿// <auto-generated />
using System;
using EducacionalAPIConexaoDB.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EducacionalAPIConexaoDB.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240222190557_EnglishDataBase")]
    partial class EnglishDataBase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EducacionalAPIConexaoDB.Models.Classroom", b =>
                {
                    b.Property<int>("ClassroomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("GradeClassRoom")
                        .HasColumnType("int");

                    b.Property<string>("LetterGrade")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<int>("YearGrade")
                        .HasColumnType("int");

                    b.HasKey("ClassroomId");

                    b.ToTable("Turma");
                });

            modelBuilder.Entity("EducacionalAPIConexaoDB.Models.Educational", b =>
                {
                    b.Property<int>("EducationalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CodInstitution")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("longtext");

                    b.Property<int>("EducationalCod")
                        .HasColumnType("int");

                    b.Property<string>("NameInstituition")
                        .HasColumnType("longtext");

                    b.HasKey("EducationalId");

                    b.ToTable("Educationals");
                });

            modelBuilder.Entity("EducacionalAPIConexaoDB.Models.Email", b =>
                {
                    b.Property<int>("EmailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("MainEmail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ResponsibleEmail")
                        .HasColumnType("longtext");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("EmailId");

                    b.HasIndex("StudentId");

                    b.ToTable("Email");
                });

            modelBuilder.Entity("EducacionalAPIConexaoDB.Models.Lack", b =>
                {
                    b.Property<int>("LackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ClassRoomId")
                        .HasColumnType("int");

                    b.Property<bool>("HealthCertificate")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LackDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("LackId");

                    b.HasIndex("ClassRoomId");

                    b.HasIndex("StudentId");

                    b.ToTable("Lacks");
                });

            modelBuilder.Entity("EducacionalAPIConexaoDB.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClassRoomId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("StudentId");

                    b.HasIndex("ClassRoomId");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("EducacionalAPIConexaoDB.Models.Email", b =>
                {
                    b.HasOne("EducacionalAPIConexaoDB.Models.Student", "Student")
                        .WithMany("Email")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EducacionalAPIConexaoDB.Models.Lack", b =>
                {
                    b.HasOne("EducacionalAPIConexaoDB.Models.Classroom", "ClassRoom")
                        .WithMany()
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EducacionalAPIConexaoDB.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassRoom");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EducacionalAPIConexaoDB.Models.Student", b =>
                {
                    b.HasOne("EducacionalAPIConexaoDB.Models.Classroom", "ClassRoom")
                        .WithMany("Students")
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassRoom");
                });

            modelBuilder.Entity("EducacionalAPIConexaoDB.Models.Classroom", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("EducacionalAPIConexaoDB.Models.Student", b =>
                {
                    b.Navigation("Email");
                });
#pragma warning restore 612, 618
        }
    }
}
