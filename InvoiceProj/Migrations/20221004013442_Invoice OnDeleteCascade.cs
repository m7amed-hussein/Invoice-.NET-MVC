using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceProj.Migrations
{
    public partial class InvoiceOnDeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemInvoices_Invoices_InvoiceId",
                table: "ItemInvoices");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemInvoices_Invoices_InvoiceId",
                table: "ItemInvoices",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemInvoices_Invoices_InvoiceId",
                table: "ItemInvoices");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemInvoices_Invoices_InvoiceId",
                table: "ItemInvoices",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id");
        }
    }
}
