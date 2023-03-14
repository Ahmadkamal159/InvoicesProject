using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoicesProject.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NWC_Default_Slice_Values",
                columns: table => new
                {
                    NWC_Default_Slice_ValueID = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    NWC_Default_Slice_Value_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NWC_Default_Slice_Value_Condtion = table.Column<short>(type: "smallint", nullable: true),
                    NWC_Default_Slice_Value_Water_Price = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    NWC_Default_Slice_Value_Sanitation_Price = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    NWC_Default_Slice_Values_Reason = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NWC_Default_Slice_Values", x => x.NWC_Default_Slice_ValueID);
                });

            migrationBuilder.CreateTable(
                name: "NWC_Rreal_Estate_Types",
                columns: table => new
                {
                    NWC_Rreal_Estate_TypeID = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    NWC_Rreal_Estate_Type_Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    NWC_Rreal_Estate_Type_Reasons = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NWC_Rreal_Estate_Types", x => x.NWC_Rreal_Estate_TypeID);
                });

            migrationBuilder.CreateTable(
                name: "NWC_Subscriber_Files",
                columns: table => new
                {
                    NWC_Subscriber_FileId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    NWC_Subscriber_File_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NWC_Subscriber_File_City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NWC_Subscriber_File_Area = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NWC_Subscriber_File_Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NWC_Subscriber_File_Reasons = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NWC_Subscriber_Files", x => x.NWC_Subscriber_FileId);
                });

            migrationBuilder.CreateTable(
                name: "NWC_Subscription_Files",
                columns: table => new
                {
                    NWC_Subscription_FileID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NWC_Subscription_File_SubscriberID = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    NWC_Rreal_Estate_TypesID = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    NWC_Subscription_File_Unit_No = table.Column<byte>(type: "tinyint", nullable: false),
                    NWC_Subscription_File_Is_There_Sanitation = table.Column<bool>(type: "bit", nullable: false),
                    NWC_Subscription_File_Last_Reading_Meter = table.Column<int>(type: "int", nullable: true),
                    NWC_Subscription_File_Reasons = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NWC_Subscription_Files", x => x.NWC_Subscription_FileID);
                    table.ForeignKey(
                        name: "FK_NWC_Subscription_Files_NWC_Rreal_Estate_Types_NWC_Rreal_Estate_TypesID",
                        column: x => x.NWC_Rreal_Estate_TypesID,
                        principalTable: "NWC_Rreal_Estate_Types",
                        principalColumn: "NWC_Rreal_Estate_TypeID");
                    table.ForeignKey(
                        name: "FK_NWC_Subscription_Files_NWC_Subscriber_Files_NWC_Subscription_File_SubscriberID",
                        column: x => x.NWC_Subscription_File_SubscriberID,
                        principalTable: "NWC_Subscriber_Files",
                        principalColumn: "NWC_Subscriber_FileId");
                });

            migrationBuilder.CreateTable(
                name: "NWC_Invoices",
                columns: table => new
                {
                    NWC_InvoiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NWC_Invoice_Year = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    NWC_Rreal_Estate_TypeID = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    NWC_Rreal_Estate_TypesID = table.Column<string>(type: "varchar(1)", nullable: true),
                    NWC_Subscription_FileID = table.Column<int>(type: "int", unicode: false, maxLength: 10, nullable: true),
                    NWC_Subscriber_FileID = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    NWC_Invoice_Date = table.Column<DateTime>(type: "date", nullable: true),
                    NWC_Invoice_From = table.Column<DateTime>(type: "date", nullable: true),
                    NWC_Invoice_To = table.Column<DateTime>(type: "date", nullable: true),
                    NWC_Invoice_Previous_Consumption_Amount = table.Column<int>(type: "int", nullable: true),
                    NWC_Invoice_Current_Consumption_Amount = table.Column<int>(type: "int", nullable: true),
                    NWC_Invoice_Amount_Consumption = table.Column<int>(type: "int", nullable: true),
                    NWC_Invoice_Service_Fee = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    NWC_Invoice_Tax_Rate = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    NWC_Invoice_Is_There_Sanitation = table.Column<bool>(type: "bit", nullable: true),
                    NWC_Invoice_Consumption_Value = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    NWC_Invoice_Wastewater_Consumption_Value = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    NWC_Invoice_Total_Invoice = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    NWC_Invoice_Tax_Value = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    NWC_Invoice_Total_Bill = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    NWC_Invoice_Total_Reasons = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NWC_Invoices", x => x.NWC_InvoiceID);
                    table.ForeignKey(
                        name: "FK_NWC_Invoices_NWC_Rreal_Estate_Types_NWC_Rreal_Estate_TypesID",
                        column: x => x.NWC_Rreal_Estate_TypesID,
                        principalTable: "NWC_Rreal_Estate_Types",
                        principalColumn: "NWC_Rreal_Estate_TypeID");
                    table.ForeignKey(
                        name: "FK_NWC_Invoices_NWC_Subscriber_Files_NWC_Subscriber_FileID",
                        column: x => x.NWC_Subscriber_FileID,
                        principalTable: "NWC_Subscriber_Files",
                        principalColumn: "NWC_Subscriber_FileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NWC_Invoices_NWC_Subscription_Files_NWC_Subscription_FileID",
                        column: x => x.NWC_Subscription_FileID,
                        principalTable: "NWC_Subscription_Files",
                        principalColumn: "NWC_Subscription_FileID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NWC_Default_Slice_Values_NWC_Default_Slice_ValueID",
                table: "NWC_Default_Slice_Values",
                column: "NWC_Default_Slice_ValueID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NWC_Invoices_NWC_Rreal_Estate_TypesID",
                table: "NWC_Invoices",
                column: "NWC_Rreal_Estate_TypesID");

            migrationBuilder.CreateIndex(
                name: "IX_NWC_Invoices_NWC_Subscriber_FileID",
                table: "NWC_Invoices",
                column: "NWC_Subscriber_FileID");

            migrationBuilder.CreateIndex(
                name: "IX_NWC_Invoices_NWC_Subscription_FileID",
                table: "NWC_Invoices",
                column: "NWC_Subscription_FileID");

            migrationBuilder.CreateIndex(
                name: "IX_NWC_Rreal_Estate_Types_NWC_Rreal_Estate_TypeID",
                table: "NWC_Rreal_Estate_Types",
                column: "NWC_Rreal_Estate_TypeID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NWC_Subscription_Files_NWC_Rreal_Estate_TypesID",
                table: "NWC_Subscription_Files",
                column: "NWC_Rreal_Estate_TypesID");

            migrationBuilder.CreateIndex(
                name: "IX_NWC_Subscription_Files_NWC_Subscription_File_SubscriberID",
                table: "NWC_Subscription_Files",
                column: "NWC_Subscription_File_SubscriberID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NWC_Default_Slice_Values");

            migrationBuilder.DropTable(
                name: "NWC_Invoices");

            migrationBuilder.DropTable(
                name: "NWC_Subscription_Files");

            migrationBuilder.DropTable(
                name: "NWC_Rreal_Estate_Types");

            migrationBuilder.DropTable(
                name: "NWC_Subscriber_Files");
        }
    }
}
