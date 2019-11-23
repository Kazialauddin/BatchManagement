﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project_09.Models;

namespace Project_09.Migrations
{
    [DbContext(typeof(BatchDbContext))]
    [Migration("20190728165629_Batch_CreateInit")]
    partial class Batch_CreateInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Project_09.Models.Batch", b =>
                {
                    b.Property<int>("BatchId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BatchName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("CourseHours");

                    b.HasKey("BatchId");

                    b.ToTable("Batches");
                });

            modelBuilder.Entity("Project_09.Models.Trainee", b =>
                {
                    b.Property<int>("TraineeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BatchId");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("TID")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<int>("TSP");

                    b.Property<string>("TraineeName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("TraineeId");

                    b.HasIndex("BatchId");

                    b.ToTable("Trainees");
                });

            modelBuilder.Entity("Project_09.Models.Trainee", b =>
                {
                    b.HasOne("Project_09.Models.Batch", "Batch")
                        .WithMany("Trainees")
                        .HasForeignKey("BatchId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
