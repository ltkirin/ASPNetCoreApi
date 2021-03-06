﻿// <auto-generated />
using System;
using DomainModel.DbModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DomainModel.Migrations
{
    [DbContext(typeof(AirsoftBaseContext))]
    partial class AirsoftBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DomainModel.Entity.team.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("DomainModel.Entity.user.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Callsign");

                    b.Property<string>("Login");

                    b.Property<string>("PasswordHash");

                    b.Property<int?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DomainModel.Entity.weapon.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BallVelocity");

                    b.Property<string>("Name");

                    b.Property<int?>("OwnerId");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("DomainModel.Entity.user.User", b =>
                {
                    b.HasOne("DomainModel.Entity.team.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("DomainModel.Entity.weapon.Weapon", b =>
                {
                    b.HasOne("DomainModel.Entity.user.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");
                });
#pragma warning restore 612, 618
        }
    }
}
