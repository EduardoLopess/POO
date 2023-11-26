﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231126143156_camposRestante")]
    partial class camposRestante
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("AddressUser", b =>
                {
                    b.Property<int>("AddressesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AddressesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("AddressUser");
                });

            modelBuilder.Entity("Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("Complement")
                        .HasColumnType("TEXT");

                    b.Property<int>("DonationPointId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InstituteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Neighborhood")
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ZipCode")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Domain.Entities.Benefit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int?>("VolunteeringId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VolunteeringId");

                    b.ToTable("Benefits");
                });

            modelBuilder.Entity("Domain.Entities.DonationMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DonationPointId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("InstituteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("PriorityDonation")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TypeMaterial")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DonationPointId");

                    b.HasIndex("InstituteId");

                    b.ToTable("DonationMaterials");
                });

            modelBuilder.Entity("Domain.Entities.DonationPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("InstituteId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("InstituteId");

                    b.ToTable("DonationPoints");
                });

            modelBuilder.Entity("Domain.Entities.Institute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CNPJ")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int>("InstitutionType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordHashSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProfileAcess")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Institutes");
                });

            modelBuilder.Entity("Domain.Entities.Responsibility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int?>("VolunteeringId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VolunteeringId");

                    b.ToTable("Responsibilities");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPF")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("LoginId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordHashSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProfileAcess")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LoginId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entities.Volunteering", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("TEXT");

                    b.Property<int?>("InstituteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int>("TypeVolunteering")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("InstituteId");

                    b.ToTable("Volunteerings");
                });

            modelBuilder.Entity("Domain.Services.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProfileAcess")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("UserVolunteering", b =>
                {
                    b.Property<int>("UsersParticipantsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VolunteeringsSubscriberId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UsersParticipantsId", "VolunteeringsSubscriberId");

                    b.HasIndex("VolunteeringsSubscriberId");

                    b.ToTable("UserVolunteering");
                });

            modelBuilder.Entity("AddressUser", b =>
                {
                    b.HasOne("Domain.Entities.Address", null)
                        .WithMany()
                        .HasForeignKey("AddressesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Benefit", b =>
                {
                    b.HasOne("Domain.Entities.Volunteering", "Volunteering")
                        .WithMany("Benefits")
                        .HasForeignKey("VolunteeringId");

                    b.Navigation("Volunteering");
                });

            modelBuilder.Entity("Domain.Entities.DonationMaterial", b =>
                {
                    b.HasOne("Domain.Entities.DonationPoint", "DonationPoint")
                        .WithMany("DonationMaterials")
                        .HasForeignKey("DonationPointId");

                    b.HasOne("Domain.Entities.Institute", "Institute")
                        .WithMany("DonationMaterials")
                        .HasForeignKey("InstituteId");

                    b.Navigation("DonationPoint");

                    b.Navigation("Institute");
                });

            modelBuilder.Entity("Domain.Entities.DonationPoint", b =>
                {
                    b.HasOne("Domain.Entities.Address", "Address")
                        .WithMany("DonationPoints")
                        .HasForeignKey("AddressId");

                    b.HasOne("Domain.Entities.Institute", "Institute")
                        .WithMany()
                        .HasForeignKey("InstituteId");

                    b.Navigation("Address");

                    b.Navigation("Institute");
                });

            modelBuilder.Entity("Domain.Entities.Institute", b =>
                {
                    b.HasOne("Domain.Entities.Address", "Address")
                        .WithMany("Institutes")
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Domain.Entities.Responsibility", b =>
                {
                    b.HasOne("Domain.Entities.Volunteering", "Volunteering")
                        .WithMany("Responsibility")
                        .HasForeignKey("VolunteeringId");

                    b.Navigation("Volunteering");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Domain.Services.Login", "Login")
                        .WithMany()
                        .HasForeignKey("LoginId");

                    b.Navigation("Login");
                });

            modelBuilder.Entity("Domain.Entities.Volunteering", b =>
                {
                    b.HasOne("Domain.Entities.Institute", "Institute")
                        .WithMany("Volunteerings")
                        .HasForeignKey("InstituteId");

                    b.Navigation("Institute");
                });

            modelBuilder.Entity("UserVolunteering", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersParticipantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Volunteering", null)
                        .WithMany()
                        .HasForeignKey("VolunteeringsSubscriberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Address", b =>
                {
                    b.Navigation("DonationPoints");

                    b.Navigation("Institutes");
                });

            modelBuilder.Entity("Domain.Entities.DonationPoint", b =>
                {
                    b.Navigation("DonationMaterials");
                });

            modelBuilder.Entity("Domain.Entities.Institute", b =>
                {
                    b.Navigation("DonationMaterials");

                    b.Navigation("Volunteerings");
                });

            modelBuilder.Entity("Domain.Entities.Volunteering", b =>
                {
                    b.Navigation("Benefits");

                    b.Navigation("Responsibility");
                });
#pragma warning restore 612, 618
        }
    }
}
