﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrepareSubmittalTool.DB.Context;

namespace PrepareSubmittalTool.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20240817231132_FixSubmittalInfoMapping")]
    partial class FixSubmittalInfoMapping
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22");

            modelBuilder.Entity("PrepareSubmittalTool.Model.Client", b =>
                {
                    b.Property<int>("Client_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Client_name")
                        .HasColumnType("TEXT");

                    b.HasKey("Client_ID");

                    b.ToTable("CLIENTS");
                });

            modelBuilder.Entity("PrepareSubmittalTool.Model.Project", b =>
                {
                    b.Property<int>("Project_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Client_ID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Project_Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Project_ID");

                    b.HasIndex("Client_ID");

                    b.ToTable("PROJECTS");
                });

            modelBuilder.Entity("PrepareSubmittalTool.Model.Submittal", b =>
                {
                    b.Property<int>("Submittal_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Project_ID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Submittal_Number")
                        .HasColumnType("INTEGER");

                    b.HasKey("Submittal_ID");

                    b.HasIndex("Project_ID");

                    b.ToTable("SUBMITTAL");
                });

            modelBuilder.Entity("PrepareSubmittalTool.Model.SubmittalInfo", b =>
                {
                    b.Property<int>("Submittal_Info_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Filter")
                        .HasColumnType("TEXT");

                    b.Property<int>("Submittal_ID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Submittal_Title")
                        .HasColumnType("TEXT");

                    b.Property<string>("Who_Prepared")
                        .HasColumnType("TEXT");

                    b.HasKey("Submittal_Info_ID");

                    b.HasIndex("Submittal_ID");

                    b.ToTable("SUBMITTAL_INFO");
                });

            modelBuilder.Entity("PrepareSubmittalTool.Model.Project", b =>
                {
                    b.HasOne("PrepareSubmittalTool.Model.Client", "Client")
                        .WithMany()
                        .HasForeignKey("Client_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PrepareSubmittalTool.Model.Submittal", b =>
                {
                    b.HasOne("PrepareSubmittalTool.Model.Project", "Project")
                        .WithMany("Submittals")
                        .HasForeignKey("Project_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PrepareSubmittalTool.Model.SubmittalInfo", b =>
                {
                    b.HasOne("PrepareSubmittalTool.Model.Submittal", "Submittal")
                        .WithMany("SubmittalInfos")
                        .HasForeignKey("Submittal_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
