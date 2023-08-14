using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Controllers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Controllers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Storage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    ShowCase = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Sale = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Basket",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Basket_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Endpoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HttpType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Definition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControllerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endpoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endpoints_Controllers_ControllerId",
                        column: x => x.ControllerId,
                        principalTable: "Controllers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FavoriteProduct",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteProduct", x => new { x.ProductId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FavoriteProduct_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDetail_Products_Id",
                        column: x => x.Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductImageFile",
                columns: table => new
                {
                    ProductImageFilesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductImageFile", x => new { x.ProductImageFilesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_ProductProductImageFile_Files_ProductImageFilesId",
                        column: x => x.ProductImageFilesId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductImageFile_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasketItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BasketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketItem_Basket_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Basket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Basket_Id",
                        column: x => x.Id,
                        principalTable: "Basket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppRoleEndpoint",
                columns: table => new
                {
                    EndpointsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RolesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleEndpoint", x => new { x.EndpointsId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_AppRoleEndpoint_AspNetRoles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppRoleEndpoint_Endpoints_EndpointsId",
                        column: x => x.EndpointsId,
                        principalTable: "Endpoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComplatedOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplatedOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplatedOrders_Orders_Id",
                        column: x => x.Id,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Name", "Price", "Quantity", "Sale", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0134900e-3ad0-8928-2472-ae63afa0d2dc"), new DateTime(2022, 9, 13, 20, 27, 17, 994, DateTimeKind.Local).AddTicks(6298), "Practical Rubber Salad", 16458.566927699849851m, 100754530, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("01a5c575-a38f-1626-d4e1-fa354e224851"), new DateTime(2017, 11, 9, 5, 16, 52, 178, DateTimeKind.Local).AddTicks(3510), "Unbranded Concrete Salad", 90081.764407674656731m, 1527492690, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("09b8be47-7bda-cb72-2a84-9a4a24480a91"), new DateTime(2022, 2, 9, 21, 35, 53, 282, DateTimeKind.Local).AddTicks(1046), "Unbranded Granite Pants", 45950.663825346534202m, 1035089425, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0abb8165-9765-017b-20dd-60bf0af50f1c"), new DateTime(2021, 3, 12, 17, 35, 41, 347, DateTimeKind.Local).AddTicks(4701), "Gorgeous Wooden Cheese", 20632.517848406843515m, 1509017481, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0c4444c5-e400-1c9b-d5c4-8549a74d175a"), new DateTime(2013, 12, 2, 22, 3, 20, 856, DateTimeKind.Local).AddTicks(6283), "Rustic Cotton Salad", 28372.214881377336367m, 1017536814, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0ddaf0a0-9419-1656-bddc-75b0139b663d"), new DateTime(2014, 8, 26, 0, 18, 21, 811, DateTimeKind.Local).AddTicks(9284), "Intelligent Soft Ball", 38865.000163830322816m, 1994976791, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("12a8c329-63d4-addf-6811-aaa46f0f1965"), new DateTime(2016, 2, 5, 16, 33, 18, 567, DateTimeKind.Local).AddTicks(7021), "Fantastic Steel Hat", 42821.985560712451498m, 1876713821, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("12cb4a96-fb33-8a9f-559e-2cf46ba2cecc"), new DateTime(2018, 5, 3, 19, 43, 7, 87, DateTimeKind.Local).AddTicks(4042), "Sleek Rubber Mouse", 49172.216410080628381m, 1282252538, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("13a87a0b-2a53-4f9b-7582-7aee804f6b58"), new DateTime(2014, 9, 24, 22, 20, 5, 555, DateTimeKind.Local).AddTicks(6796), "Gorgeous Steel Fish", 712.43093794618373293m, 228239484, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("19acb876-9c2a-f59d-7514-7eb834ae0d98"), new DateTime(2018, 1, 21, 9, 12, 12, 856, DateTimeKind.Local).AddTicks(6945), "Handcrafted Frozen Car", 67543.701215215010185m, 960071072, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1bbbb3e7-71ae-f77d-ba66-e6fe98f7e192"), new DateTime(2017, 5, 13, 23, 58, 26, 411, DateTimeKind.Local).AddTicks(3651), "Rustic Soft Towels", 66162.816538713865045m, 1514746621, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1d1aff1a-69cb-2ade-d0a2-01a03318d8cb"), new DateTime(2016, 2, 25, 17, 44, 45, 402, DateTimeKind.Local).AddTicks(6124), "Generic Frozen Pants", 93651.366619686772819m, 149816278, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1ddb8ea0-5885-73cc-b11f-d898dfb14463"), new DateTime(2013, 12, 21, 17, 5, 20, 232, DateTimeKind.Local).AddTicks(566), "Refined Fresh Keyboard", 90434.387487199298824m, 631061331, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1f46faf5-a145-fdca-8b12-8ef301aafc1d"), new DateTime(2015, 8, 19, 12, 48, 8, 394, DateTimeKind.Local).AddTicks(8176), "Tasty Rubber Mouse", 9882.8197175729224171m, 1911071962, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("209e2643-63f2-2312-c9fc-0cdfe4d6f868"), new DateTime(2020, 7, 1, 9, 16, 46, 980, DateTimeKind.Local).AddTicks(8411), "Refined Steel Bike", 89542.967984935164307m, 1129590088, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("238e1bb5-b382-6a51-db8b-bd2ecb50df4c"), new DateTime(2021, 5, 10, 8, 27, 11, 195, DateTimeKind.Local).AddTicks(219), "Licensed Plastic Towels", 98590.837597677740872m, 1222072545, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("27015c28-5740-9221-8df5-b66b1cff9cf4"), new DateTime(2015, 4, 9, 3, 40, 7, 798, DateTimeKind.Local).AddTicks(9874), "Tasty Frozen Chips", 44549.871316824200077m, 1668313644, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("27142818-8ba3-f92f-0986-5168fa9af276"), new DateTime(2023, 2, 14, 14, 36, 39, 252, DateTimeKind.Local).AddTicks(3237), "Awesome Wooden Chips", 12129.951277732215421m, 1375146936, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2a0179f6-2c69-9494-f0d7-06f009d2e1da"), new DateTime(2023, 6, 8, 14, 34, 39, 242, DateTimeKind.Local).AddTicks(4892), "Practical Wooden Salad", 2686.9384900975624894m, 998800509, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2cd3866e-5a4e-90d1-47e9-c29597537ee4"), new DateTime(2018, 11, 3, 12, 26, 43, 397, DateTimeKind.Local).AddTicks(4122), "Fantastic Steel Soap", 66589.29463645373941m, 719316823, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("31584698-40fd-3bb2-3715-3ebbb0ac7f0b"), new DateTime(2018, 6, 26, 16, 4, 51, 527, DateTimeKind.Local).AddTicks(4840), "Practical Metal Tuna", 87082.231744689442849m, 327459256, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("31de77f5-ca5a-4a61-3353-6ec7db45dc3c"), new DateTime(2016, 7, 22, 20, 14, 47, 866, DateTimeKind.Local).AddTicks(4594), "Refined Soft Ball", 18411.157956444101353m, 1534164051, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3316a657-0738-fba4-fad8-26660e43fab2"), new DateTime(2023, 6, 18, 17, 30, 27, 460, DateTimeKind.Local).AddTicks(2221), "Handcrafted Granite Chicken", 2438.5724310198401209m, 343656839, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("331addc2-384c-cac3-8afc-268da5e5c67b"), new DateTime(2023, 4, 28, 12, 19, 27, 631, DateTimeKind.Local).AddTicks(5551), "Rustic Fresh Cheese", 17110.992201399869671m, 627461783, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3338174e-e0c0-a19c-e7d4-010ec0be2bba"), new DateTime(2015, 7, 16, 22, 44, 36, 81, DateTimeKind.Local).AddTicks(7217), "Intelligent Granite Chicken", 63133.41298787281684m, 214207724, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33a2c883-ab8e-177e-1bfe-41b9af0062a2"), new DateTime(2021, 4, 25, 13, 4, 53, 355, DateTimeKind.Local).AddTicks(476), "Awesome Wooden Chips", 84416.946841083010069m, 1889563185, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("360a1081-95b8-367e-1d23-61d6173b5bb3"), new DateTime(2023, 5, 20, 0, 5, 20, 835, DateTimeKind.Local).AddTicks(1426), "Incredible Wooden Soap", 58227.304261212099226m, 139418328, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("36355ab1-d62d-aebd-8e00-33f78606a4b9"), new DateTime(2013, 12, 30, 23, 14, 50, 768, DateTimeKind.Local).AddTicks(9514), "Sleek Granite Shirt", 8673.9993519648317434m, 979569804, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("36e033d3-99d6-4ede-9918-fb1f0dc8d7d7"), new DateTime(2017, 5, 16, 3, 55, 43, 627, DateTimeKind.Local).AddTicks(788), "Fantastic Soft Towels", 26046.855570831080086m, 1042472082, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("377897fa-47c9-bbc8-04be-a3880d6ba39b"), new DateTime(2019, 3, 2, 16, 11, 1, 290, DateTimeKind.Local).AddTicks(7788), "Incredible Cotton Sausages", 1783.9932275572633216m, 78445052, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("39d6ff41-5177-7dc2-5659-5f10ae37a988"), new DateTime(2020, 1, 14, 22, 22, 50, 425, DateTimeKind.Local).AddTicks(7292), "Awesome Frozen Shoes", 29468.091825553905811m, 1733312426, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3a7950da-949f-2a35-ef4d-800d2b79172c"), new DateTime(2023, 1, 8, 19, 17, 10, 375, DateTimeKind.Local).AddTicks(4349), "Licensed Frozen Bacon", 24762.874257733810474m, 2094225707, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3cdae490-2eac-1a22-ade1-6a62d88ab6c6"), new DateTime(2018, 6, 12, 21, 18, 33, 777, DateTimeKind.Local).AddTicks(3412), "Incredible Frozen Cheese", 50246.817451276055248m, 1115052044, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3d1d4aaf-c544-227b-21f1-145064f0e916"), new DateTime(2023, 6, 5, 17, 13, 43, 966, DateTimeKind.Local).AddTicks(3356), "Unbranded Frozen Tuna", 32555.733121523878894m, 2106801033, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("42180075-1a2f-c3e8-b60f-cfd8b07415c8"), new DateTime(2019, 9, 14, 2, 30, 14, 159, DateTimeKind.Local).AddTicks(5749), "Intelligent Soft Keyboard", 92285.44719516351136m, 1939180373, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("45ba5a78-52c1-dff1-54b1-ff16b3cf504c"), new DateTime(2018, 6, 12, 13, 25, 15, 133, DateTimeKind.Local).AddTicks(1614), "Small Granite Car", 46521.563825092446172m, 499057967, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4679cbd0-3ba8-8356-26d4-8d239ae17f77"), new DateTime(2019, 3, 31, 16, 27, 2, 170, DateTimeKind.Local).AddTicks(7277), "Generic Concrete Mouse", 39561.733574088046201m, 2063724863, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4eaa95a1-9694-2b08-14bf-1ada8fbe8b11"), new DateTime(2014, 12, 4, 0, 30, 16, 659, DateTimeKind.Local).AddTicks(365), "Practical Frozen Fish", 4123.8340998656738104m, 1320340148, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4f89b81e-3b29-6a7d-f0a6-baa2e5ad0cc0"), new DateTime(2019, 2, 21, 0, 3, 16, 226, DateTimeKind.Local).AddTicks(9924), "Rustic Plastic Computer", 98603.826035318165611m, 2042797690, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("530ae6ba-d679-7a15-4a92-dbd3a0570d01"), new DateTime(2021, 12, 12, 23, 9, 10, 371, DateTimeKind.Local).AddTicks(1540), "Intelligent Granite Soap", 34060.964741958049885m, 1936749948, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("56147394-5384-bd05-5aa0-0147e08d6938"), new DateTime(2014, 3, 13, 19, 17, 46, 852, DateTimeKind.Local).AddTicks(6000), "Gorgeous Soft Towels", 34646.76175934179576m, 1941570766, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("561abce4-c4b8-8e02-5ccf-0cea6807f7ca"), new DateTime(2018, 2, 2, 15, 20, 35, 495, DateTimeKind.Local).AddTicks(2756), "Fantastic Metal Sausages", 6649.6643614269626455m, 1044503612, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5b109f9a-fe3a-5543-e6dc-41a65ac7ff16"), new DateTime(2013, 10, 15, 13, 25, 27, 7, DateTimeKind.Local).AddTicks(7855), "Ergonomic Plastic Shoes", 19014.713147951730154m, 2043614577, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5d186386-dd7c-175e-5c4b-b138612ea411"), new DateTime(2020, 10, 7, 3, 46, 7, 847, DateTimeKind.Local).AddTicks(5456), "Licensed Frozen Bike", 7533.9631736047401022m, 1652165382, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5e00661a-3f54-c47c-7b84-8b181bf8aae4"), new DateTime(2015, 1, 15, 6, 55, 49, 578, DateTimeKind.Local).AddTicks(7317), "Fantastic Metal Car", 1216.0132825468519882m, 1485368415, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("60570bb9-a895-bc61-76cf-b0bbb8245e42"), new DateTime(2023, 8, 2, 6, 2, 37, 830, DateTimeKind.Local).AddTicks(8388), "Awesome Cotton Table", 28075.910889868882147m, 1792987246, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("64be298d-f98b-322a-b0a9-c7c7c47b9e85"), new DateTime(2015, 10, 20, 1, 35, 42, 157, DateTimeKind.Local).AddTicks(3893), "Rustic Frozen Pizza", 31626.200901496333321m, 926017161, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6697d726-19a9-87a3-b120-ca38bb20394e"), new DateTime(2021, 3, 3, 9, 5, 26, 119, DateTimeKind.Local).AddTicks(1678), "Intelligent Plastic Chair", 23229.430560086232853m, 1947624148, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6d6f9ace-cd33-5bb0-94b1-8f28a47e844b"), new DateTime(2015, 6, 3, 12, 49, 37, 553, DateTimeKind.Local).AddTicks(882), "Small Steel Car", 96932.077150145593897m, 10953412, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6ee10180-0daa-4329-7ed2-d18bc51e5bcf"), new DateTime(2022, 11, 3, 19, 44, 19, 133, DateTimeKind.Local).AddTicks(2802), "Sleek Concrete Table", 85227.744079564544719m, 2024482696, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("70ce6489-4fa5-aa33-5bfb-025c670d94c4"), new DateTime(2013, 8, 16, 7, 1, 3, 6, DateTimeKind.Local).AddTicks(4885), "Intelligent Frozen Pants", 63499.053560911322032m, 43981144, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7163f720-7c5b-3f06-b137-5cc2238171cc"), new DateTime(2022, 9, 16, 15, 38, 37, 738, DateTimeKind.Local).AddTicks(5927), "Handcrafted Rubber Bike", 63362.570233579243822m, 1561310026, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("71c8dedf-455a-fc8c-2f70-caf63facfa34"), new DateTime(2019, 6, 15, 19, 46, 28, 646, DateTimeKind.Local).AddTicks(3125), "Ergonomic Rubber Fish", 20385.822365348943889m, 1432007118, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("73e14dd1-e191-70f8-23fc-655a3ccb9387"), new DateTime(2018, 8, 27, 18, 42, 53, 218, DateTimeKind.Local).AddTicks(7868), "Small Fresh Soap", 33453.827771234371426m, 844802309, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7aac4f42-82fe-2fef-2f86-35ffb9393d2b"), new DateTime(2022, 4, 27, 4, 52, 47, 500, DateTimeKind.Local).AddTicks(8121), "Rustic Frozen Tuna", 90318.006762528183724m, 1017641300, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7ae0275d-927c-76e6-36ee-443cb39d2ee9"), new DateTime(2018, 12, 18, 9, 10, 48, 689, DateTimeKind.Local).AddTicks(6453), "Unbranded Rubber Salad", 23523.576434112477709m, 1624773635, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7c0bc791-10bc-53ac-2e18-92436dfe2da5"), new DateTime(2019, 10, 3, 5, 23, 39, 870, DateTimeKind.Local).AddTicks(1722), "Practical Frozen Hat", 37151.190193460309227m, 769418634, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8abcd486-74ba-7c00-6c6b-588e49a81b17"), new DateTime(2018, 8, 21, 3, 34, 13, 988, DateTimeKind.Local).AddTicks(96), "Tasty Wooden Cheese", 2053.6750888171922665m, 114217933, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8ef48546-bd29-8288-f240-9e56203eb9eb"), new DateTime(2018, 2, 18, 11, 15, 45, 605, DateTimeKind.Local).AddTicks(1186), "Rustic Frozen Car", 739.77356803992450517m, 24237089, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8f60bcc4-04ec-46f9-78f2-6b99a3f42c28"), new DateTime(2021, 2, 27, 2, 22, 36, 59, DateTimeKind.Local).AddTicks(9567), "Ergonomic Plastic Computer", 7517.853078372023455m, 825633910, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("92aee9f2-61a0-2561-2adc-50089e7fdd19"), new DateTime(2015, 2, 23, 18, 54, 23, 34, DateTimeKind.Local).AddTicks(9097), "Intelligent Metal Salad", 13977.281952865529173m, 32550297, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("95d01f0b-1eb7-0bc5-2052-1cc3dd3b50b0"), new DateTime(2014, 11, 25, 3, 30, 43, 735, DateTimeKind.Local).AddTicks(3368), "Sleek Soft Gloves", 76017.127694094270271m, 352530709, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("961e0845-d10e-2728-847e-9b2cf9f7d71c"), new DateTime(2019, 6, 10, 16, 17, 41, 85, DateTimeKind.Local).AddTicks(1892), "Licensed Rubber Soap", 66614.231020384206442m, 701211552, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("97f650a3-eab1-e020-0843-d5d2970bed66"), new DateTime(2020, 6, 15, 23, 59, 6, 775, DateTimeKind.Local).AddTicks(1273), "Ergonomic Frozen Hat", 54016.308808946425639m, 366936646, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9b0ea4a1-e39e-927d-0b23-25e9f8243e91"), new DateTime(2021, 7, 19, 12, 38, 22, 406, DateTimeKind.Local).AddTicks(3632), "Rustic Soft Chicken", 21803.427633937696057m, 274177635, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9c99160d-4dcc-5782-343d-e0e7ee463075"), new DateTime(2016, 2, 21, 1, 8, 49, 693, DateTimeKind.Local).AddTicks(7671), "Licensed Cotton Cheese", 72764.296903298364562m, 1468059292, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a283bb77-23ec-1795-df09-a1a7411a4110"), new DateTime(2021, 2, 21, 9, 43, 8, 332, DateTimeKind.Local).AddTicks(7940), "Awesome Steel Fish", 22141.494458292845485m, 1589126620, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a33ce490-d684-3a9a-c945-e361269b414e"), new DateTime(2013, 9, 10, 3, 52, 7, 537, DateTimeKind.Local).AddTicks(1990), "Ergonomic Metal Pants", 9794.167478791485544m, 474541330, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ac316b5b-bc22-502f-3a96-05b2a3706ce4"), new DateTime(2019, 7, 2, 19, 3, 43, 475, DateTimeKind.Local).AddTicks(14), "Handmade Concrete Pants", 78973.508163619634014m, 1772089399, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("acdec479-713d-36ba-20a2-fa0f537009c7"), new DateTime(2019, 12, 18, 6, 26, 1, 806, DateTimeKind.Local).AddTicks(9846), "Sleek Rubber Car", 87510.305429235089596m, 1452800850, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("af824eae-b385-3fe4-6cac-6b4cd0e0a6f8"), new DateTime(2018, 12, 5, 6, 54, 13, 851, DateTimeKind.Local).AddTicks(2239), "Sleek Cotton Pants", 45768.787015664118889m, 257540947, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b18c6784-2112-8798-42a9-c382240740eb"), new DateTime(2014, 7, 23, 13, 48, 41, 493, DateTimeKind.Local).AddTicks(8211), "Licensed Plastic Pizza", 5775.5129749633032949m, 945799264, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b4b5f393-343c-2b1d-f3a2-86455cea25f8"), new DateTime(2017, 4, 12, 12, 45, 25, 170, DateTimeKind.Local).AddTicks(5256), "Refined Plastic Computer", 29978.830818556801372m, 260480948, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b764fc01-6d90-3f97-4f7c-58841c2bb034"), new DateTime(2019, 5, 29, 21, 41, 32, 284, DateTimeKind.Local).AddTicks(1188), "Practical Concrete Cheese", 81152.170631111590669m, 1990073586, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b7d839e5-c618-6c4f-73ad-2834867b5135"), new DateTime(2014, 6, 3, 18, 46, 53, 30, DateTimeKind.Local).AddTicks(6935), "Unbranded Concrete Tuna", 81374.350177725306355m, 1610409996, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c184edce-74d5-8238-70cb-8e04d75ea4fd"), new DateTime(2021, 5, 22, 4, 22, 14, 686, DateTimeKind.Local).AddTicks(3356), "Unbranded Wooden Salad", 63351.305883658469476m, 878876180, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c1ca8c2b-c845-bb7d-9ac7-bdd0a8598e9d"), new DateTime(2022, 6, 25, 9, 49, 53, 355, DateTimeKind.Local).AddTicks(6551), "Practical Wooden Mouse", 56715.210125970662566m, 1817327993, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c55605b3-522d-324b-75ce-2d5506cb4666"), new DateTime(2017, 4, 24, 16, 0, 42, 32, DateTimeKind.Local).AddTicks(4523), "Intelligent Frozen Computer", 60303.6070169895091m, 1821724848, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cb3320ac-aff4-716b-bbb7-55bc4149eccc"), new DateTime(2016, 11, 16, 8, 57, 41, 886, DateTimeKind.Local).AddTicks(3208), "Fantastic Cotton Towels", 61061.732917885986787m, 648965311, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ce9bf854-65e8-c38d-b28a-9dc2396613d5"), new DateTime(2014, 6, 12, 1, 57, 27, 821, DateTimeKind.Local).AddTicks(7363), "Generic Soft Fish", 93069.395253941327992m, 1385514324, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cfafb0fa-edfe-50dc-23d8-2206166604c7"), new DateTime(2015, 1, 1, 19, 25, 14, 815, DateTimeKind.Local).AddTicks(8390), "Licensed Frozen Mouse", 31795.342983586198045m, 562428145, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cff0794c-9072-c106-2235-4fd909906c2b"), new DateTime(2018, 3, 21, 21, 13, 58, 259, DateTimeKind.Local).AddTicks(320), "Tasty Rubber Table", 36585.586565794746811m, 1659162202, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d3fb52d4-64db-88f8-6996-8c8160e36033"), new DateTime(2015, 3, 11, 17, 57, 4, 992, DateTimeKind.Local).AddTicks(4794), "Generic Plastic Mouse", 44718.993018463671343m, 667601773, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d670029d-5490-630e-d429-33701442ea35"), new DateTime(2020, 7, 8, 0, 6, 44, 131, DateTimeKind.Local).AddTicks(1284), "Awesome Concrete Pizza", 56779.613092973352178m, 1586797832, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d7dd100f-ce3d-5144-f7ec-306c2e7c7470"), new DateTime(2014, 4, 19, 22, 35, 41, 51, DateTimeKind.Local).AddTicks(6647), "Refined Metal Fish", 80356.004753833580833m, 1150631697, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dd9192ef-3675-52a0-adfa-d06024508abe"), new DateTime(2014, 7, 10, 15, 56, 5, 464, DateTimeKind.Local).AddTicks(2937), "Handmade Concrete Shirt", 34780.400255357271622m, 1711566786, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e0078862-955a-0c2d-7a00-90d270349b2b"), new DateTime(2020, 4, 19, 21, 58, 13, 789, DateTimeKind.Local).AddTicks(5369), "Handmade Rubber Chicken", 84633.562248760371538m, 1954578372, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e1a7fd48-55a5-2290-4260-c760471ab3fc"), new DateTime(2017, 3, 12, 0, 38, 7, 744, DateTimeKind.Local).AddTicks(7081), "Handmade Concrete Shoes", 65779.02474633366841m, 231902741, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e3099416-90a2-d532-4dcc-8bab17acb4a3"), new DateTime(2016, 1, 19, 0, 3, 8, 523, DateTimeKind.Local).AddTicks(5295), "Ergonomic Wooden Bike", 3300.8297035963377664m, 1055511638, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e32a1f79-c228-f348-bb01-9d66d78067cb"), new DateTime(2023, 5, 23, 19, 13, 7, 266, DateTimeKind.Local).AddTicks(5050), "Awesome Wooden Chips", 17353.769224406161663m, 387265613, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e458ada2-79fa-e1c2-63fb-a4b808a307de"), new DateTime(2020, 10, 4, 15, 38, 53, 932, DateTimeKind.Local).AddTicks(2676), "Licensed Steel Car", 42008.578458662213524m, 419800254, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e6053e73-76de-81cf-b609-7f8d8f53440f"), new DateTime(2017, 5, 30, 2, 31, 54, 512, DateTimeKind.Local).AddTicks(5984), "Awesome Fresh Table", 1988.2233714310313653m, 1688159324, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("eb414c07-5e92-a384-977b-9170383868a8"), new DateTime(2020, 9, 2, 1, 42, 29, 880, DateTimeKind.Local).AddTicks(236), "Unbranded Frozen Fish", 72859.358701741373857m, 1371209972, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("eb8f06a2-a73e-192e-d686-b8dee2db2ec1"), new DateTime(2018, 4, 10, 1, 11, 25, 159, DateTimeKind.Local).AddTicks(4682), "Rustic Granite Shirt", 65075.048567102359045m, 1986446931, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ef30eb69-892f-17b7-87d6-68f84564ed29"), new DateTime(2016, 8, 29, 4, 29, 16, 252, DateTimeKind.Local).AddTicks(1372), "Practical Cotton Chair", 64715.437890895882537m, 1853193406, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f1a30eda-3311-6ae1-5ae9-e4f20d05f3ef"), new DateTime(2021, 9, 9, 15, 25, 36, 546, DateTimeKind.Local).AddTicks(4273), "Small Steel Pizza", 85083.471233638731406m, 630195926, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f50ade3c-8a1e-ac18-22f6-8d18c33a4531"), new DateTime(2023, 7, 20, 0, 16, 40, 613, DateTimeKind.Local).AddTicks(9896), "Tasty Concrete Bike", 35138.53178659634572m, 1737238323, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f561d81e-2865-94dd-83ab-959900f40c9d"), new DateTime(2014, 3, 4, 23, 17, 28, 192, DateTimeKind.Local).AddTicks(7905), "Handmade Metal Chips", 25569.445831098218866m, 1122342683, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ff901011-4f86-0a87-11e4-eb3b46975c84"), new DateTime(2022, 10, 25, 9, 18, 42, 915, DateTimeKind.Local).AddTicks(7305), "Practical Soft Gloves", 1186.0354221080641921m, 1143425577, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ffc39be3-c5da-29fb-a93a-8648ddf7de87"), new DateTime(2015, 10, 26, 13, 38, 52, 40, DateTimeKind.Local).AddTicks(7080), "Awesome Rubber Soap", 82817.810370995926186m, 1326179415, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleEndpoint_RolesId",
                table: "AppRoleEndpoint",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Basket_AppUserId",
                table: "Basket",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItem_BasketId",
                table: "BasketItem",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItem_ProductId",
                table: "BasketItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Endpoints_ControllerId",
                table: "Endpoints",
                column: "ControllerId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteProduct_UserId",
                table: "FavoriteProduct",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserId",
                table: "Message",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderCode",
                table: "Orders",
                column: "OrderCode",
                unique: true,
                filter: "[OrderCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_CategoryId",
                table: "ProductCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductImageFile_ProductsId",
                table: "ProductProductImageFile",
                column: "ProductsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRoleEndpoint");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BasketItem");

            migrationBuilder.DropTable(
                name: "ComplatedOrders");

            migrationBuilder.DropTable(
                name: "FavoriteProduct");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "ProductDetail");

            migrationBuilder.DropTable(
                name: "ProductProductImageFile");

            migrationBuilder.DropTable(
                name: "Endpoints");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Controllers");

            migrationBuilder.DropTable(
                name: "Basket");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
