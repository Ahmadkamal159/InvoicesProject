﻿// <auto-generated />
using System;
using InvoicesProject.APPDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InvoicesProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230314105116_init01")]
    partial class init01
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InvoicesProject.Models.NWC_Default_Slice_Value", b =>
                {
                    b.Property<string>("NWC_Default_Slice_ValueID")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)");

                    b.Property<short?>("NWC_Default_Slice_Value_Condtion")
                        .HasColumnType("smallint");

                    b.Property<string>("NWC_Default_Slice_Value_Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("NWC_Default_Slice_Value_Sanitation_Price")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<decimal?>("NWC_Default_Slice_Value_Water_Price")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<string>("NWC_Default_Slice_Values_Reason")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("NWC_Default_Slice_ValueID");

                    b.HasIndex("NWC_Default_Slice_ValueID")
                        .IsUnique();

                    b.ToTable("NWC_Default_Slice_Values");
                });

            modelBuilder.Entity("InvoicesProject.Models.NWC_Invoice", b =>
                {
                    b.Property<int>("NWC_InvoiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NWC_InvoiceID"));

                    b.Property<int?>("NWC_Invoice_Amount_Consumption")
                        .HasColumnType("int");

                    b.Property<decimal?>("NWC_Invoice_Consumption_Value")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int?>("NWC_Invoice_Current_Consumption_Amount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NWC_Invoice_Date")
                        .HasColumnType("date");

                    b.Property<DateTime?>("NWC_Invoice_From")
                        .HasColumnType("date");

                    b.Property<bool?>("NWC_Invoice_Is_There_Sanitation")
                        .HasColumnType("bit");

                    b.Property<int?>("NWC_Invoice_Previous_Consumption_Amount")
                        .HasColumnType("int");

                    b.Property<decimal?>("NWC_Invoice_Service_Fee")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal?>("NWC_Invoice_Tax_Rate")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal?>("NWC_Invoice_Tax_Value")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<DateTime?>("NWC_Invoice_To")
                        .HasColumnType("date");

                    b.Property<decimal?>("NWC_Invoice_Total_Bill")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal?>("NWC_Invoice_Total_Invoice")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("NWC_Invoice_Total_Reasons")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("NWC_Invoice_Wastewater_Consumption_Value")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("NWC_Invoice_Year")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("NWC_Rreal_Estate_TypeID")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)");

                    b.Property<string>("NWC_Rreal_Estate_TypesID")
                        .HasColumnType("varchar(1)");

                    b.Property<string>("NWC_Subscriber_FileID")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<int?>("NWC_Subscription_FileID")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("int");

                    b.HasKey("NWC_InvoiceID");

                    b.HasIndex("NWC_Rreal_Estate_TypesID");

                    b.HasIndex("NWC_Subscriber_FileID");

                    b.HasIndex("NWC_Subscription_FileID");

                    b.ToTable("NWC_Invoices");
                });

            modelBuilder.Entity("InvoicesProject.Models.NWC_Rreal_Estate_Type", b =>
                {
                    b.Property<string>("NWC_Rreal_Estate_TypeID")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)");

                    b.Property<string>("NWC_Rreal_Estate_Type_Name")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("NWC_Rreal_Estate_Type_Reasons")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("NWC_Rreal_Estate_TypeID");

                    b.HasIndex("NWC_Rreal_Estate_TypeID")
                        .IsUnique();

                    b.ToTable("NWC_Rreal_Estate_Types");
                });

            modelBuilder.Entity("InvoicesProject.Models.NWC_Subscriber_File", b =>
                {
                    b.Property<string>("NWC_Subscriber_FileId")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("NWC_Subscriber_File_Area")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NWC_Subscriber_File_City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NWC_Subscriber_File_Mobile")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("NWC_Subscriber_File_Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NWC_Subscriber_File_Reasons")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("NWC_Subscriber_FileId");

                    b.ToTable("NWC_Subscriber_Files");
                });

            modelBuilder.Entity("InvoicesProject.Models.NWC_Subscription_File", b =>
                {
                    b.Property<int>("NWC_Subscription_FileID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NWC_Subscription_FileID"));

                    b.Property<string>("NWC_Rreal_Estate_TypesID")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)");

                    b.Property<bool>("NWC_Subscription_File_Is_There_Sanitation")
                        .HasColumnType("bit");

                    b.Property<int?>("NWC_Subscription_File_Last_Reading_Meter")
                        .HasColumnType("int");

                    b.Property<string>("NWC_Subscription_File_Reasons")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NWC_Subscription_File_SubscriberID")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<byte>("NWC_Subscription_File_Unit_No")
                        .HasColumnType("tinyint");

                    b.HasKey("NWC_Subscription_FileID");

                    b.HasIndex("NWC_Rreal_Estate_TypesID");

                    b.HasIndex("NWC_Subscription_File_SubscriberID");

                    b.ToTable("NWC_Subscription_Files");
                });

            modelBuilder.Entity("InvoicesProject.Models.NWC_Invoice", b =>
                {
                    b.HasOne("InvoicesProject.Models.NWC_Rreal_Estate_Type", "NWC_Rreal_Estate_Type")
                        .WithMany("NWC_Invoices")
                        .HasForeignKey("NWC_Rreal_Estate_TypesID");

                    b.HasOne("InvoicesProject.Models.NWC_Subscriber_File", "NWC_Invoices_Subscriber_file")
                        .WithMany("NWC_Invoices")
                        .HasForeignKey("NWC_Subscriber_FileID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InvoicesProject.Models.NWC_Subscription_File", "NWC_Subscription")
                        .WithMany("NWC_Invoices")
                        .HasForeignKey("NWC_Subscription_FileID");

                    b.Navigation("NWC_Invoices_Subscriber_file");

                    b.Navigation("NWC_Rreal_Estate_Type");

                    b.Navigation("NWC_Subscription");
                });

            modelBuilder.Entity("InvoicesProject.Models.NWC_Subscription_File", b =>
                {
                    b.HasOne("InvoicesProject.Models.NWC_Rreal_Estate_Type", "NWC_Rreal_Estate_Types")
                        .WithMany("NWC_Subscription_Files")
                        .HasForeignKey("NWC_Rreal_Estate_TypesID");

                    b.HasOne("InvoicesProject.Models.NWC_Subscriber_File", "NWC_Subscription_File_Subscriber")
                        .WithMany("NWC_Subscription_Files")
                        .HasForeignKey("NWC_Subscription_File_SubscriberID");

                    b.Navigation("NWC_Rreal_Estate_Types");

                    b.Navigation("NWC_Subscription_File_Subscriber");
                });

            modelBuilder.Entity("InvoicesProject.Models.NWC_Rreal_Estate_Type", b =>
                {
                    b.Navigation("NWC_Invoices");

                    b.Navigation("NWC_Subscription_Files");
                });

            modelBuilder.Entity("InvoicesProject.Models.NWC_Subscriber_File", b =>
                {
                    b.Navigation("NWC_Invoices");

                    b.Navigation("NWC_Subscription_Files");
                });

            modelBuilder.Entity("InvoicesProject.Models.NWC_Subscription_File", b =>
                {
                    b.Navigation("NWC_Invoices");
                });
#pragma warning restore 612, 618
        }
    }
}
