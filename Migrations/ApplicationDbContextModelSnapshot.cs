﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Bank.Entities;

#nullable disable

namespace Bank.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bank.Entities.Deposit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("FromAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OperationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OperationId")
                        .IsUnique();

                    b.ToTable("Deposits");
                });

            modelBuilder.Entity("Bank.Entities.Operation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("OperationTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OperationTypeId");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("Bank.Entities.OperationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OperationTypes");
                });

            modelBuilder.Entity("Bank.Entities.TradeOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("OperationId")
                        .HasColumnType("int");

                    b.Property<int>("TradeOrderTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OperationId")
                        .IsUnique();

                    b.HasIndex("TradeOrderTypeId");

                    b.ToTable("TradeOrders");
                });

            modelBuilder.Entity("Bank.Entities.TradeOrderType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TradeOrderTypes");
                });

            modelBuilder.Entity("Bank.Entities.Withdrawal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("OperationId")
                        .HasColumnType("int");

                    b.Property<string>("ToAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("WasApprovedByUser2FA")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("OperationId")
                        .IsUnique();

                    b.ToTable("Withdrawals");
                });

            modelBuilder.Entity("Bank.Entities.Deposit", b =>
                {
                    b.HasOne("Bank.Entities.Operation", "Operation")
                        .WithOne("Deposit")
                        .HasForeignKey("Bank.Entities.Deposit", "OperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Operation");
                });

            modelBuilder.Entity("Bank.Entities.Operation", b =>
                {
                    b.HasOne("Bank.Entities.OperationType", "OperationType")
                        .WithMany("Operations")
                        .HasForeignKey("OperationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OperationType");
                });

            modelBuilder.Entity("Bank.Entities.TradeOrder", b =>
                {
                    b.HasOne("Bank.Entities.Operation", "Operation")
                        .WithOne("TradeOrder")
                        .HasForeignKey("Bank.Entities.TradeOrder", "OperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bank.Entities.TradeOrderType", "TradeOrderType")
                        .WithMany("TradeOrders")
                        .HasForeignKey("TradeOrderTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Operation");

                    b.Navigation("TradeOrderType");
                });

            modelBuilder.Entity("Bank.Entities.Withdrawal", b =>
                {
                    b.HasOne("Bank.Entities.Operation", "Operation")
                        .WithOne("Withdrawal")
                        .HasForeignKey("Bank.Entities.Withdrawal", "OperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Operation");
                });

            modelBuilder.Entity("Bank.Entities.Operation", b =>
                {
                    b.Navigation("Deposit")
                        .IsRequired();

                    b.Navigation("TradeOrder")
                        .IsRequired();

                    b.Navigation("Withdrawal")
                        .IsRequired();
                });

            modelBuilder.Entity("Bank.Entities.OperationType", b =>
                {
                    b.Navigation("Operations");
                });

            modelBuilder.Entity("Bank.Entities.TradeOrderType", b =>
                {
                    b.Navigation("TradeOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
