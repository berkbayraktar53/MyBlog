using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class mig_database_tables_updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "BlogRatings");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Notifications",
                newName: "NotificationType");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Notifications",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Messages",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Contacts",
                newName: "NameSurname");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Contacts",
                newName: "AddedDate");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Comments",
                newName: "NameSurname");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Comments",
                newName: "AddedDate");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Blogs",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "AspNetUsers",
                newName: "NameSurname");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "Notifications",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "Messages",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "Blogs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "NotificationType",
                table: "Notifications",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Notifications",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Messages",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "NameSurname",
                table: "Contacts",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "AddedDate",
                table: "Contacts",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "NameSurname",
                table: "Comments",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "AddedDate",
                table: "Comments",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Blogs",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "NameSurname",
                table: "AspNetUsers",
                newName: "FullName");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "BlogRatings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
