﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Infrastructure.Migrations
{
  /// <inheritdoc />
  public partial class Initial : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
        name: "Users",
        columns: table => new
        {
          Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
          LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
          Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
          Password = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
          PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
          CountryCode = table.Column<string>(
            type: "nvarchar(3)",
            maxLength: 3,
            nullable: false,
            defaultValue: "251"
          ),
          Street = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
          City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
          State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
          Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
          ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Users", x => x.Id);
        }
      );

      migrationBuilder.CreateTable(
        name: "Notifications",
        columns: table => new
        {
          NotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
          Description = table.Column<string>(
            type: "nvarchar(1000)",
            maxLength: 1000,
            nullable: false
          ),
          NotificationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
          NotificationStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
          ReadAt = table.Column<DateTime>(type: "datetime2", nullable: false),
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Notifications", x => x.NotificationId);
          table.ForeignKey(
            name: "FK_Notifications_Users_UserId",
            column: x => x.UserId,
            principalTable: "Users",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade
          );
        }
      );

      migrationBuilder.CreateTable(
        name: "Orders",
        columns: table => new
        {
          OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
          UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
          Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
          ShippingStreet = table.Column<string>(
            type: "nvarchar(255)",
            maxLength: 255,
            nullable: false
          ),
          ShippingCity = table.Column<string>(
            type: "nvarchar(100)",
            maxLength: 100,
            nullable: false
          ),
          ShippingState = table.Column<string>(
            type: "nvarchar(100)",
            maxLength: 100,
            nullable: false
          ),
          ShippingCountry = table.Column<string>(
            type: "nvarchar(100)",
            maxLength: 100,
            nullable: false
          ),
          ShippingZipCode = table.Column<string>(
            type: "nvarchar(10)",
            maxLength: 10,
            nullable: false
          ),
          BillingStreet = table.Column<string>(
            type: "nvarchar(255)",
            maxLength: 255,
            nullable: false
          ),
          BillingCity = table.Column<string>(
            type: "nvarchar(100)",
            maxLength: 100,
            nullable: false
          ),
          BillingState = table.Column<string>(
            type: "nvarchar(100)",
            maxLength: 100,
            nullable: false
          ),
          BillingCountry = table.Column<string>(
            type: "nvarchar(100)",
            maxLength: 100,
            nullable: false
          ),
          BillingZipCode = table.Column<string>(
            type: "nvarchar(10)",
            maxLength: 10,
            nullable: false
          ),
          Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Orders", x => x.OrderId);
          table.ForeignKey(
            name: "FK_Orders_Users_UserId",
            column: x => x.UserId,
            principalTable: "Users",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade
          );
        }
      );

      migrationBuilder.CreateTable(
        name: "Products",
        columns: table => new
        {
          Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
          Description = table.Column<string>(
            type: "nvarchar(1000)",
            maxLength: 1000,
            nullable: false
          ),
          PriceValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
          PriceCurrency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
          StockQuantity = table.Column<int>(type: "int", nullable: false),
          StockReserved = table.Column<int>(type: "int", nullable: false),
          SellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          AverageRating = table.Column<decimal>(
            type: "decimal(18,2)",
            nullable: false,
            defaultValue: 0m
          ),
          CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
          UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Products", x => x.Id);
          table.ForeignKey(
            name: "FK_Products_Users_SellerId",
            column: x => x.SellerId,
            principalTable: "Users",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade
          );
        }
      );

      migrationBuilder.CreateTable(
        name: "UserCarts",
        columns: table => new
        {
          CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_UserCarts", x => x.CartId);
          table.ForeignKey(
            name: "FK_UserCarts_Users_UserId",
            column: x => x.UserId,
            principalTable: "Users",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade
          );
        }
      );

      migrationBuilder.CreateTable(
        name: "Wishlists",
        columns: table => new
        {
          WishlistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Wishlists", x => x.WishlistId);
          table.ForeignKey(
            name: "FK_Wishlists_Users_UserId",
            column: x => x.UserId,
            principalTable: "Users",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade
          );
        }
      );

      migrationBuilder.CreateTable(
        name: "OrderItems",
        columns: table => new
        {
          OrderItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          Quantity = table.Column<int>(type: "int", nullable: false),
          PriceValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
          PriceCurrency = table.Column<string>(type: "nvarchar(max)", nullable: false),
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_OrderItems", x => new { x.OrderItemId, x.OrderId });
          table.ForeignKey(
            name: "FK_OrderItems_Orders_OrderId",
            column: x => x.OrderId,
            principalTable: "Orders",
            principalColumn: "OrderId",
            onDelete: ReferentialAction.Cascade
          );
          table.ForeignKey(
            name: "FK_OrderItems_Products_ProductId",
            column: x => x.ProductId,
            principalTable: "Products",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict
          );
        }
      );

      migrationBuilder.CreateTable(
        name: "ProductCategories",
        columns: table => new
        {
          Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
          ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_ProductCategories", x => x.Id);
          table.ForeignKey(
            name: "FK_ProductCategories_Products_ProductId",
            column: x => x.ProductId,
            principalTable: "Products",
            principalColumn: "Id"
          );
        }
      );

      migrationBuilder.CreateTable(
        name: "ProductImages",
        columns: table => new
        {
          ProductImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          LeftImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
          RightImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
          FrontImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
          BackImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_ProductImages", x => new { x.ProductImageId, x.ProductId });
          table.ForeignKey(
            name: "FK_ProductImages_Products_ProductId",
            column: x => x.ProductId,
            principalTable: "Products",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade
          );
        }
      );

      migrationBuilder.CreateTable(
        name: "ProductPromotions",
        columns: table => new
        {
          ProductPromotionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          DiscountPercentage = table.Column<int>(type: "int", nullable: false),
          StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
          EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_ProductPromotions", x => new { x.ProductPromotionId, x.ProductId });
          table.ForeignKey(
            name: "FK_ProductPromotions_Products_ProductId",
            column: x => x.ProductId,
            principalTable: "Products",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade
          );
        }
      );

      migrationBuilder.CreateTable(
        name: "ProductReviews",
        columns: table => new
        {
          ReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          Description = table.Column<string>(
            type: "nvarchar(1000)",
            maxLength: 1000,
            nullable: false
          ),
          Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_ProductReviews", x => new { x.ReviewId, x.ProductId });
          table.ForeignKey(
            name: "FK_ProductReviews_Products_ProductId",
            column: x => x.ProductId,
            principalTable: "Products",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade
          );
        }
      );

      migrationBuilder.CreateTable(
        name: "ProductTags",
        columns: table => new
        {
          TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          TagName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_ProductTags", x => new { x.TagId, x.ProductId });
          table.ForeignKey(
            name: "FK_ProductTags_Products_ProductId",
            column: x => x.ProductId,
            principalTable: "Products",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade
          );
        }
      );

      migrationBuilder.CreateTable(
        name: "ProductThumbnails",
        columns: table => new
        {
          Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
          FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
          FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
          FileSize = table.Column<long>(type: "bigint", nullable: true),
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_ProductThumbnails", x => new { x.Id, x.ProductId });
          table.ForeignKey(
            name: "FK_ProductThumbnails_Products_ProductId",
            column: x => x.ProductId,
            principalTable: "Products",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade
          );
        }
      );

      migrationBuilder.CreateTable(
        name: "UserCartItems",
        columns: table => new
        {
          CartItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          Quantity = table.Column<int>(type: "int", nullable: false),
          ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_UserCartItems", x => new { x.CartItemId, x.CartId });
          table.ForeignKey(
            name: "FK_UserCartItems_Products_ProductId",
            column: x => x.ProductId,
            principalTable: "Products",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict
          );
          table.ForeignKey(
            name: "FK_UserCartItems_UserCarts_CartId",
            column: x => x.CartId,
            principalTable: "UserCarts",
            principalColumn: "CartId",
            onDelete: ReferentialAction.Cascade
          );
        }
      );

      migrationBuilder.CreateTable(
        name: "WishlistProducts",
        columns: table => new
        {
          ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          WishlistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          ProductId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_WishlistProducts", x => new { x.ProductId, x.WishlistId });
          table.ForeignKey(
            name: "FK_WishlistProducts_Products_ProductId1",
            column: x => x.ProductId1,
            principalTable: "Products",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict
          );
          table.ForeignKey(
            name: "FK_WishlistProducts_Wishlists_WishlistId",
            column: x => x.WishlistId,
            principalTable: "Wishlists",
            principalColumn: "WishlistId",
            onDelete: ReferentialAction.Cascade
          );
        }
      );

      migrationBuilder.CreateTable(
        name: "ProductCategoryLink",
        columns: table => new
        {
          ProductCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_ProductCategoryLink", x => new { x.ProductCategoryId, x.ProductId });
          table.ForeignKey(
            name: "FK_ProductCategoryLink_ProductCategories_ProductCategoryId",
            column: x => x.ProductCategoryId,
            principalTable: "ProductCategories",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade
          );
          table.ForeignKey(
            name: "FK_ProductCategoryLink_Products_ProductId",
            column: x => x.ProductId,
            principalTable: "Products",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade
          );
        }
      );

      migrationBuilder.CreateIndex(
        name: "IX_Notifications_UserId",
        table: "Notifications",
        column: "UserId"
      );

      migrationBuilder.CreateIndex(
        name: "IX_OrderItems_OrderId",
        table: "OrderItems",
        column: "OrderId"
      );

      migrationBuilder.CreateIndex(
        name: "IX_OrderItems_ProductId",
        table: "OrderItems",
        column: "ProductId"
      );

      migrationBuilder.CreateIndex(name: "IX_Orders_UserId", table: "Orders", column: "UserId");

      migrationBuilder.CreateIndex(
        name: "IX_ProductCategories_ProductId",
        table: "ProductCategories",
        column: "ProductId"
      );

      migrationBuilder.CreateIndex(
        name: "IX_ProductCategoryLink_ProductId",
        table: "ProductCategoryLink",
        column: "ProductId"
      );

      migrationBuilder.CreateIndex(
        name: "IX_ProductImages_ProductId",
        table: "ProductImages",
        column: "ProductId",
        unique: true
      );

      migrationBuilder.CreateIndex(
        name: "IX_ProductPromotions_ProductId",
        table: "ProductPromotions",
        column: "ProductId",
        unique: true
      );

      migrationBuilder.CreateIndex(
        name: "IX_ProductReviews_ProductId",
        table: "ProductReviews",
        column: "ProductId"
      );

      migrationBuilder.CreateIndex(
        name: "IX_Products_SellerId",
        table: "Products",
        column: "SellerId"
      );

      migrationBuilder.CreateIndex(
        name: "IX_ProductTags_ProductId",
        table: "ProductTags",
        column: "ProductId"
      );

      migrationBuilder.CreateIndex(
        name: "IX_ProductThumbnails_ProductId",
        table: "ProductThumbnails",
        column: "ProductId",
        unique: true
      );

      migrationBuilder.CreateIndex(
        name: "IX_UserCartItems_CartId",
        table: "UserCartItems",
        column: "CartId"
      );

      migrationBuilder.CreateIndex(
        name: "IX_UserCartItems_ProductId",
        table: "UserCartItems",
        column: "ProductId"
      );

      migrationBuilder.CreateIndex(
        name: "IX_UserCarts_UserId",
        table: "UserCarts",
        column: "UserId"
      );

      migrationBuilder.CreateIndex(
        name: "IX_WishlistProducts_ProductId1",
        table: "WishlistProducts",
        column: "ProductId1"
      );

      migrationBuilder.CreateIndex(
        name: "IX_WishlistProducts_WishlistId",
        table: "WishlistProducts",
        column: "WishlistId"
      );

      migrationBuilder.CreateIndex(
        name: "IX_Wishlists_UserId",
        table: "Wishlists",
        column: "UserId",
        unique: true
      );
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(name: "Notifications");

      migrationBuilder.DropTable(name: "OrderItems");

      migrationBuilder.DropTable(name: "ProductCategoryLink");

      migrationBuilder.DropTable(name: "ProductImages");

      migrationBuilder.DropTable(name: "ProductPromotions");

      migrationBuilder.DropTable(name: "ProductReviews");

      migrationBuilder.DropTable(name: "ProductTags");

      migrationBuilder.DropTable(name: "ProductThumbnails");

      migrationBuilder.DropTable(name: "UserCartItems");

      migrationBuilder.DropTable(name: "WishlistProducts");

      migrationBuilder.DropTable(name: "Orders");

      migrationBuilder.DropTable(name: "ProductCategories");

      migrationBuilder.DropTable(name: "UserCarts");

      migrationBuilder.DropTable(name: "Wishlists");

      migrationBuilder.DropTable(name: "Products");

      migrationBuilder.DropTable(name: "Users");
    }
  }
}