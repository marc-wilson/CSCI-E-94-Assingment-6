﻿// <auto-generated />
using System;
using HW6MovieSharing.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HW6MovieSharing.Migrations
{
    [DbContext(typeof(MoviesDbContext))]
    [Migration("20190420015957_moreuserinfo")]
    partial class moreuserinfo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HW6MovieSharing.Models.BarrowRequest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateRequested");

                    b.Property<int>("MovieID");

                    b.Property<string>("MovieOwner");

                    b.Property<string>("MovieTitle");

                    b.Property<string>("RequestedByEmailAddress");

                    b.Property<string>("RequestedByFirstName");

                    b.Property<string>("RequestedByLastName");

                    b.Property<string>("RequestedByObjectIdentifier");

                    b.Property<int>("Status");

                    b.HasKey("ID");

                    b.ToTable("BarrowRequest");
                });

            modelBuilder.Entity("HW6MovieSharing.Models.Movie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BarrowedByObjectIdentifier");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("OwnerObjectIdentifier")
                        .IsRequired();

                    b.Property<bool>("Sharable");

                    b.Property<DateTime>("SharedDate");

                    b.Property<string>("SharedWithEmailAddress")
                        .HasMaxLength(256);

                    b.Property<string>("SharedWithFirstName")
                        .HasMaxLength(256);

                    b.Property<string>("SharedWithLastName")
                        .HasMaxLength(256);

                    b.Property<int>("Status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(1024);

                    b.HasKey("ID");

                    b.ToTable("Movie");
                });
#pragma warning restore 612, 618
        }
    }
}
