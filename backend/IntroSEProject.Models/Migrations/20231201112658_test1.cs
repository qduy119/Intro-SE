using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IntroSEProject.Models.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Thumbnail = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Thumbnail = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    FullName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Avatar = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    Gender = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CategoryItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryItems", x => new { x.ItemId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_CategoryItems_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    OrderDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PaymentDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    OrderItemId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(type: "longtext", nullable: false),
                    ReviewId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Images_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "Thumbnail" },
                values: new object[,]
                {
                    { 1, "Consequatur officiis asperiores soluta eum praesentium voluptatem libero dolor.", "Quia qui quidem.", "https://picsum.photos/640/480/?image=876" },
                    { 2, "Qui id itaque sit hic ut quia. Eveniet velit distinctio.", "Eius voluptates quia.", "https://picsum.photos/640/480/?image=951" },
                    { 3, "Cupiditate vel maxime. Quis debitis esse quia assumenda quibusdam.", "Dolore natus iste.", "https://picsum.photos/640/480/?image=404" },
                    { 4, "Officia doloribus iure excepturi qui voluptatem. Dolore temporibus aspernatur ut ipsum sunt ut odit tempora. Sit eum rerum nihil adipisci provident vero. Aut dolor quia recusandae id in et.", "Ut dolores quibusdam.", "https://picsum.photos/640/480/?image=202" },
                    { 5, "Qui autem error et dolorum consectetur est dolore vitae.", "Debitis distinctio sunt.", "https://picsum.photos/640/480/?image=731" },
                    { 6, "Ipsa autem reprehenderit blanditiis non doloribus. Ut quidem ipsam ab optio et.", "Est sapiente est.", "https://picsum.photos/640/480/?image=939" },
                    { 7, "Animi aut vel quia sunt laboriosam magnam ad molestiae.", "Non et sed.", "https://picsum.photos/640/480/?image=537" },
                    { 8, "Harum dicta ut fugit.", "Corrupti aut delectus.", "https://picsum.photos/640/480/?image=340" },
                    { 9, "Similique dolores a facere. Fuga voluptatem ut asperiores impedit in distinctio officia qui. Ad quo excepturi. Voluptatem laboriosam dicta id dignissimos eos consequuntur reiciendis.", "Aut qui ea.", "https://picsum.photos/640/480/?image=695" },
                    { 10, "Voluptatem consequatur nulla nostrum cupiditate illo. Suscipit quasi ut vel aut ut dolores ducimus. Commodi sunt harum placeat omnis nulla deleniti necessitatibus excepturi necessitatibus.", "Esse aut blanditiis.", "https://picsum.photos/640/480/?image=457" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "Discount", "Name", "Price", "Stock", "Thumbnail" },
                values: new object[,]
                {
                    { 1, "Quia qui numquam qui vero quibusdam dolores mollitia distinctio adipisci ad doloribus minus corporis occaecati ex perferendis in et est.", 10.2533107042560870m, "Impedit similique ut.", 10.3484567652216450m, 6, "https://picsum.photos/640/480/?image=355" },
                    { 2, "Repellat eligendi quia rerum libero quibusdam magni velit et id eos omnis ducimus accusantium odio sunt assumenda nobis sint quasi.", 10.5233307739362730m, "Ducimus nam omnis.", 10.2258937946641320m, 5, "https://picsum.photos/640/480/?image=855" },
                    { 3, "Sint accusamus voluptas molestiae hic adipisci eaque dolores et blanditiis nemo est adipisci id odit minima dolorum debitis accusantium voluptatum.", 10.9090224140831370m, "Placeat repellendus sapiente.", 10.5819574867291180m, 2, "https://picsum.photos/640/480/?image=141" },
                    { 4, "Provident voluptatum veniam architecto eos aut quo non voluptas in enim consectetur ex velit non sed harum praesentium architecto voluptatem.", 10.1212688573269490m, "Odit non deserunt.", 10.4676107426488820m, 3, "https://picsum.photos/640/480/?image=854" },
                    { 5, "Vel aut nihil illo voluptatem sit id quas voluptatem dolorum vel ipsum qui ex reprehenderit omnis debitis enim nobis libero.", 10.05397090877125550m, "Aliquam est enim.", 10.0627756449686250m, 4, "https://picsum.photos/640/480/?image=856" },
                    { 6, "Quia velit incidunt quos qui esse similique blanditiis sed dolorum ut doloribus quia facere voluptates molestias repudiandae aliquam nostrum ut.", 10.07509296484063050m, "Voluptas doloremque laborum.", 10.9637959385122150m, 4, "https://picsum.photos/640/480/?image=577" },
                    { 7, "Magnam quia quidem quia est nostrum voluptate deleniti sunt temporibus magni iste possimus nesciunt ut consectetur sequi provident voluptatem excepturi.", 10.1542035113806850m, "Deleniti similique illo.", 10.9165562921746430m, 6, "https://picsum.photos/640/480/?image=395" },
                    { 8, "Est ab quasi accusamus perferendis aliquam ea voluptatem magni similique ducimus dolorum cumque assumenda ad illum porro repellendus optio provident.", 10.06385876846679430m, "Minima eaque nobis.", 10.1873567370638980m, 9, "https://picsum.photos/640/480/?image=498" },
                    { 9, "Eos explicabo omnis quia saepe est id omnis et voluptatem et fugit ullam qui voluptas assumenda fuga impedit voluptates dolorum.", 10.6427040573408380m, "Fugiat nesciunt illo.", 10.7448733890172440m, 4, "https://picsum.photos/640/480/?image=204" },
                    { 10, "Dolores qui neque aut aperiam at sed modi modi ex reprehenderit omnis recusandae explicabo consequatur voluptas quibusdam autem libero qui.", 10.3469966013669020m, "Tempore culpa quas.", 10.137527591147240m, 3, "https://picsum.photos/640/480/?image=902" },
                    { 11, "Enim dolores possimus rerum et ipsam amet aut dolor ut qui necessitatibus quaerat aspernatur quia et velit incidunt sequi aut.", 10.7368973361965720m, "Deleniti molestiae sed.", 10.5293418357751060m, 8, "https://picsum.photos/640/480/?image=284" },
                    { 12, "Commodi voluptatem quis ut in odit voluptatem necessitatibus qui laudantium velit necessitatibus labore maxime voluptatibus eum in et et voluptate.", 10.9643906019462230m, "Eaque consequatur sit.", 10.2961531236284190m, 8, "https://picsum.photos/640/480/?image=587" },
                    { 13, "Consequatur sunt eligendi eius et dolores magni qui sapiente necessitatibus consequatur maxime dolor earum non dignissimos voluptatem alias nisi sint.", 10.5463999656710770m, "Doloremque voluptas hic.", 10.2280999041293280m, 10, "https://picsum.photos/640/480/?image=959" },
                    { 14, "Necessitatibus in quam ea accusamus architecto nesciunt enim voluptatem aperiam dolore quas reprehenderit odit molestiae voluptatem earum non voluptates consequuntur.", 10.08719450891352940m, "Necessitatibus magni mollitia.", 10.467659495057380m, 6, "https://picsum.photos/640/480/?image=243" },
                    { 15, "Quisquam praesentium libero rem voluptas est ut et quam ut corrupti dolores tempore fuga et necessitatibus velit et et hic.", 10.3022614015742490m, "Aut est velit.", 10.8086636815260460m, 6, "https://picsum.photos/640/480/?image=627" },
                    { 16, "Magni et aut voluptas occaecati sit distinctio iusto at et error sint qui quos et quas deleniti qui quo labore.", 10.8393140457753620m, "Perferendis reiciendis consequatur.", 10.5027478903079160m, 2, "https://picsum.photos/640/480/?image=1046" },
                    { 17, "Animi quam itaque cumque blanditiis aliquid assumenda assumenda odio ut cumque ut enim aut amet omnis labore nulla maiores est.", 10.9431386976238060m, "Tempore eum id.", 10.4587808314053250m, 8, "https://picsum.photos/640/480/?image=118" },
                    { 18, "Quas nostrum id est dolorem eos ducimus veritatis perferendis sint hic odit similique sapiente quisquam nihil delectus dolor atque in.", 10.3147675983210880m, "Excepturi corporis quod.", 10.2302318179189380m, 1, "https://picsum.photos/640/480/?image=45" },
                    { 19, "Minima expedita fuga saepe consectetur voluptatem est voluptatem deleniti quo voluptas provident eum et hic quia eos nostrum quod quam.", 10.7375286536931660m, "Voluptatem est laborum.", 10.810841540252250m, 6, "https://picsum.photos/640/480/?image=1038" },
                    { 20, "Molestias consectetur tempora est molestias deleniti cupiditate ipsum ea reprehenderit voluptatem possimus tenetur a optio labore officia velit dolore et.", 10.2821758786599040m, "Quaerat accusantium ut.", 10.5336627389926760m, 2, "https://picsum.photos/640/480/?image=899" },
                    { 21, "Et ut eos autem harum neque magnam aspernatur architecto aliquam amet quaerat ab corporis optio perspiciatis repellendus quo provident repellendus.", 10.1137104468018330m, "Nam cupiditate ut.", 10.4606882969200090m, 5, "https://picsum.photos/640/480/?image=220" },
                    { 22, "Quis tempora ab voluptatem voluptatibus maiores non est et voluptatem mollitia iure deserunt nihil vero fuga maiores in earum velit.", 10.8376016988594090m, "Et aut quis.", 10.3492501677708930m, 8, "https://picsum.photos/640/480/?image=1009" },
                    { 23, "Consequatur est ipsa non dolorem dolorum autem aut officiis accusantium incidunt quia enim voluptas culpa et veniam amet qui itaque.", 10.6027513656778040m, "Commodi dolores quod.", 10.07736137373250040m, 5, "https://picsum.photos/640/480/?image=387" },
                    { 24, "Voluptatem provident quos eligendi expedita pariatur dolore ea eaque officia illo molestiae voluptas et dolorem maiores animi facere consectetur tempore.", 10.7688384455483590m, "Provident nobis vel.", 10.3571241769740m, 8, "https://picsum.photos/640/480/?image=556" },
                    { 25, "Distinctio sed velit non cum deleniti consequatur assumenda ut vel suscipit in ea voluptatem iusto perspiciatis deleniti incidunt omnis nobis.", 10.2509172685681460m, "Dolorem repudiandae adipisci.", 10.1367423399988290m, 7, "https://picsum.photos/640/480/?image=490" },
                    { 26, "Blanditiis aliquam omnis eaque cupiditate quod expedita qui velit voluptas inventore autem hic a aperiam deleniti id voluptatem dolor fugiat.", 10.9223015070531060m, "Omnis laboriosam perferendis.", 10.649863534909610m, 3, "https://picsum.photos/640/480/?image=967" },
                    { 27, "Inventore velit officia corporis assumenda laboriosam totam aliquid sint officia laboriosam consequatur fugiat cumque iusto ut cumque quam vero consequatur.", 10.1028037784168510m, "Modi voluptate incidunt.", 10.727255582216780m, 8, "https://picsum.photos/640/480/?image=318" },
                    { 28, "Commodi sed doloremque totam illum fugit excepturi animi quia laborum sed nostrum aperiam atque est occaecati necessitatibus voluptatem blanditiis nisi.", 10.2127119205951280m, "Et qui quas.", 10.133204307934830m, 7, "https://picsum.photos/640/480/?image=13" },
                    { 29, "Quas tenetur rerum in cum sit quo aut vel corrupti quia cupiditate optio voluptatem aut voluptatem dolorum dolorem magni qui.", 10.1191667081411770m, "Officiis commodi mollitia.", 10.3288212629634990m, 6, "https://picsum.photos/640/480/?image=568" },
                    { 30, "Quis voluptatem pariatur quas deserunt blanditiis sint aut facilis sed eaque vero odit velit vel autem aperiam assumenda quod possimus.", 10.03029855714659140m, "Placeat ipsum labore.", 10.02516628011370370m, 10, "https://picsum.photos/640/480/?image=956" },
                    { 31, "Ut eum quis possimus dolorem quas rerum laudantium tenetur delectus voluptatibus non quasi dolor nemo praesentium est qui enim voluptatem.", 10.9501299722819260m, "Ex maxime perspiciatis.", 10.621578850141530m, 4, "https://picsum.photos/640/480/?image=71" },
                    { 32, "Numquam laboriosam velit dolor ratione nulla voluptates dolore et ad omnis non aliquid neque minus molestiae dolorem ab et tempore.", 10.7170723596201610m, "Aut consequatur esse.", 10.5780456487918480m, 6, "https://picsum.photos/640/480/?image=595" },
                    { 33, "Et voluptatem inventore qui facilis qui sunt qui consequuntur facere sit fugiat soluta nesciunt recusandae soluta sit hic autem a.", 10.8873602104780080m, "Deleniti quae est.", 10.859858415489950m, 6, "https://picsum.photos/640/480/?image=242" },
                    { 34, "Quo dolores assumenda reiciendis corporis aspernatur quia doloribus non sunt qui magni reprehenderit quaerat et est tempore rerum eius natus.", 10.645587164277950m, "Dolores accusamus suscipit.", 10.5152471799008770m, 1, "https://picsum.photos/640/480/?image=541" },
                    { 35, "Et aperiam autem natus quia omnis atque aliquam incidunt ex omnis aut id iste dolorem alias aut minus illum maiores.", 10.4273633879736830m, "Ad odit sunt.", 10.6974806183471720m, 3, "https://picsum.photos/640/480/?image=421" },
                    { 36, "Illum consectetur praesentium vel cumque adipisci aut quaerat tenetur dolores aut consequuntur ex et consequatur velit magnam eveniet omnis deleniti.", 10.3466915401381870m, "Vero minima nemo.", 10.004965144211875810m, 7, "https://picsum.photos/640/480/?image=922" },
                    { 37, "Reprehenderit iusto possimus rerum cumque quae rem libero veritatis est reiciendis architecto nobis qui exercitationem numquam accusamus aspernatur id praesentium.", 10.6917929256762340m, "Expedita praesentium sed.", 10.08062616460054470m, 3, "https://picsum.photos/640/480/?image=1006" },
                    { 38, "Corporis rem unde provident quisquam et architecto et dolorem velit consectetur enim vitae aut labore earum molestiae ad dolorem architecto.", 10.7084809111936390m, "Hic aspernatur quibusdam.", 10.7542838606770540m, 2, "https://picsum.photos/640/480/?image=29" },
                    { 39, "Eaque cumque non qui asperiores id dolore ipsum adipisci sint labore aliquam fugiat est aut rem perferendis soluta temporibus occaecati.", 10.843017140795950m, "Eum illo repellat.", 10.5789497576555940m, 8, "https://picsum.photos/640/480/?image=837" },
                    { 40, "Ipsa deserunt laboriosam omnis cumque libero et aperiam repudiandae et totam adipisci nihil quo quo ipsa molestiae consectetur sit asperiores.", 10.6426857093547870m, "Facere consequuntur voluptatem.", 10.4629537255796390m, 3, "https://picsum.photos/640/480/?image=866" },
                    { 41, "Quam velit hic velit reiciendis et culpa sed in at id sed qui officia sunt velit vero perspiciatis atque vitae.", 10.865893679142880m, "Sunt ipsa provident.", 10.684731568528680m, 8, "https://picsum.photos/640/480/?image=127" },
                    { 42, "Natus in ex modi est distinctio eos dolorem quo sapiente sed quos sit quia harum eos amet eligendi et et.", 10.8887452813278630m, "Est minus dolores.", 10.4031836592607120m, 5, "https://picsum.photos/640/480/?image=349" },
                    { 43, "Pariatur omnis qui et et et minus voluptatem et eius harum ab debitis ducimus voluptas minus ut et illo sequi.", 10.05167729130558540m, "Sunt id a.", 10.961133724991760m, 8, "https://picsum.photos/640/480/?image=411" },
                    { 44, "Minus tempore tenetur reiciendis est vitae cumque nostrum enim dignissimos suscipit ea magnam mollitia aut eum sint iste rerum omnis.", 10.6382051141179190m, "Harum a corporis.", 10.9846247816386750m, 2, "https://picsum.photos/640/480/?image=663" },
                    { 45, "Repellat quibusdam dolorem repellendus repellat nulla itaque alias aliquid nulla et voluptatibus ut quia nesciunt dolores nostrum eveniet dolore et.", 10.8599842837359680m, "Est occaecati qui.", 10.5577579525102660m, 3, "https://picsum.photos/640/480/?image=230" },
                    { 46, "Voluptatem explicabo sint maxime magnam magni et nihil dolores ducimus expedita suscipit natus enim mollitia facere maiores cum sunt tempore.", 10.8266760892358960m, "Illo doloribus dolor.", 10.6017644710847010m, 2, "https://picsum.photos/640/480/?image=881" },
                    { 47, "Saepe eos in aut qui consequatur nam dolorum voluptates fugiat aut doloribus pariatur laboriosam rem nam quae quidem error est.", 10.9612987306720110m, "Enim voluptatum porro.", 10.4885798112901760m, 2, "https://picsum.photos/640/480/?image=934" },
                    { 48, "In quos hic expedita et est esse id error sint iusto molestiae sit saepe est est et aut nobis quisquam.", 10.1304000211555510m, "Eos atque voluptatem.", 10.3326652968920140m, 2, "https://picsum.photos/640/480/?image=256" },
                    { 49, "Incidunt non doloremque laboriosam officiis dolore est dicta magni a quia tempore numquam iusto animi et maxime laborum impedit incidunt.", 10.7979714622711630m, "Tempora placeat temporibus.", 10.7963706612570080m, 3, "https://picsum.photos/640/480/?image=105" },
                    { 50, "Maiores ducimus voluptas at et soluta maiores sit aut sed culpa natus soluta rerum aut natus qui maxime quia totam.", 10.730683836029230m, "Ex qui omnis.", 10.2848646767832640m, 3, "https://picsum.photos/640/480/?image=203" },
                    { 51, "Doloribus et distinctio voluptas voluptatibus nihil atque cumque rerum aut odit maxime asperiores incidunt magnam quibusdam consequatur neque ab accusantium.", 10.9903208431742720m, "Atque sint sint.", 10.5915557051038160m, 3, "https://picsum.photos/640/480/?image=454" },
                    { 52, "Voluptatum aliquam modi voluptates consequatur repudiandae neque asperiores facere ratione eligendi mollitia dolores velit itaque dolorem possimus dolorum alias non.", 10.03250778235146210m, "Dignissimos voluptatem voluptatibus.", 10.2377031325538190m, 10, "https://picsum.photos/640/480/?image=589" },
                    { 53, "Molestiae alias adipisci fugit in fugiat odio consequatur ducimus esse saepe quod eum fugiat labore et est tempore similique repudiandae.", 10.6523145361115760m, "Aliquam et quos.", 10.8286182935482910m, 9, "https://picsum.photos/640/480/?image=928" },
                    { 54, "Maxime dignissimos quia consequatur et recusandae quam ut asperiores natus doloremque exercitationem omnis eligendi consectetur quos placeat eos aut ipsum.", 10.0003698240036004340m, "Et odio itaque.", 10.3779018136569770m, 6, "https://picsum.photos/640/480/?image=523" },
                    { 55, "Nam ad dolor impedit adipisci a eveniet optio error consequuntur ab labore aut voluptate animi et itaque dolorum vel aut.", 10.6389554690751040m, "Sit est sint.", 10.2209749199547690m, 2, "https://picsum.photos/640/480/?image=308" },
                    { 56, "Natus maxime voluptates eaque amet delectus esse possimus sapiente illum pariatur quo suscipit et repellat fuga consequatur optio dolorum architecto.", 10.7785691031155030m, "Dolorum ipsa enim.", 10.7616359744042330m, 8, "https://picsum.photos/640/480/?image=82" },
                    { 57, "Exercitationem accusantium fugit aut sunt sequi est laboriosam tenetur et dicta et ad reprehenderit et rerum molestiae dicta dolor ipsa.", 10.2235977273544290m, "Nam et aut.", 10.9413582235301650m, 1, "https://picsum.photos/640/480/?image=646" },
                    { 58, "Molestias dolor doloribus ipsam quis eum vitae sed minus nulla quo omnis nobis est cupiditate quae aut minima fugiat ut.", 10.110500283125090m, "Vel repellat delectus.", 10.6833407244101820m, 2, "https://picsum.photos/640/480/?image=859" },
                    { 59, "Earum architecto aut quia quisquam sunt amet sit natus delectus laboriosam porro deleniti consectetur enim sint autem quo voluptas explicabo.", 10.4166685237626860m, "Molestias rerum omnis.", 10.39461530344310m, 2, "https://picsum.photos/640/480/?image=354" },
                    { 60, "Veniam qui rerum distinctio consequatur corrupti fuga qui quae quisquam cupiditate asperiores libero dolores totam delectus beatae harum error aliquid.", 10.4111012361995420m, "Excepturi perspiciatis et.", 10.1560818940196570m, 2, "https://picsum.photos/640/480/?image=43" },
                    { 61, "Commodi cupiditate saepe ut consequatur dolor iusto et repellendus sint corporis provident tempora vero quae tempora adipisci enim quisquam expedita.", 10.9281164668165690m, "Laborum dolor temporibus.", 10.5988406914280920m, 5, "https://picsum.photos/640/480/?image=376" },
                    { 62, "Dolores accusamus sed exercitationem ab et cumque quaerat et voluptatem facere quo vel ut deserunt nobis quae omnis aut laboriosam.", 10.1083205459212510m, "Voluptate rerum adipisci.", 10.4926915771759540m, 2, "https://picsum.photos/640/480/?image=107" },
                    { 63, "Consectetur iusto architecto autem error et voluptatibus itaque aperiam culpa fuga magnam et cupiditate animi molestiae architecto dignissimos iste et.", 10.006315835754534150m, "Beatae necessitatibus cupiditate.", 10.4230986537519370m, 3, "https://picsum.photos/640/480/?image=1084" },
                    { 64, "Cumque iure est sed numquam neque aut excepturi qui perspiciatis ex amet pariatur fugiat exercitationem natus aut nihil non velit.", 10.8927331985406260m, "Quia corporis est.", 10.8129870825507620m, 7, "https://picsum.photos/640/480/?image=437" },
                    { 65, "Aspernatur sit consectetur libero rem voluptatem aliquam minima omnis ut autem voluptate sunt et perferendis omnis rerum porro aliquam impedit.", 10.1288737422455450m, "Iste occaecati voluptatibus.", 10.07422521248190910m, 5, "https://picsum.photos/640/480/?image=119" },
                    { 66, "Autem consequatur impedit in est eligendi dolor alias voluptas et officiis aut molestiae deserunt omnis maxime non qui perferendis iusto.", 10.7989119010972380m, "Voluptatibus autem aut.", 10.4003160178662820m, 2, "https://picsum.photos/640/480/?image=154" },
                    { 67, "Et ut id ab est cum nesciunt praesentium rem voluptas assumenda qui porro voluptates quibusdam nobis voluptatem aut fugiat sit.", 10.5206482654999240m, "Reprehenderit corporis vel.", 10.1140366960847920m, 4, "https://picsum.photos/640/480/?image=861" },
                    { 68, "Cumque repellat optio sint amet ut debitis enim aperiam deserunt culpa amet sed voluptas magni vitae ut dignissimos alias ullam.", 10.6046704587548370m, "Esse delectus ea.", 10.5253242130974890m, 2, "https://picsum.photos/640/480/?image=255" },
                    { 69, "Cumque iure qui et quidem quisquam voluptatem praesentium laudantium est molestiae qui vel quo quidem omnis sunt sunt dolorem et.", 10.9822085187687580m, "Repellendus iste ut.", 10.5671936164457320m, 5, "https://picsum.photos/640/480/?image=1045" },
                    { 70, "Fugiat aspernatur aut minus magni et autem dolor rerum ducimus explicabo rerum laudantium rerum nemo nam nemo reiciendis vero dolorum.", 10.8868647543186620m, "Autem velit libero.", 10.4607367773823150m, 9, "https://picsum.photos/640/480/?image=523" },
                    { 71, "Ea porro hic aut impedit modi illo atque ea qui ipsa autem a consequatur distinctio facere ipsam repellat fuga commodi.", 10.2614895330097010m, "Qui a molestiae.", 10.744458174213980m, 4, "https://picsum.photos/640/480/?image=24" },
                    { 72, "Non rerum aliquam eos laboriosam quia cumque aut praesentium itaque nisi iure quisquam velit in rerum vitae ut sit ut.", 10.801785188634780m, "Quas recusandae autem.", 10.6142339383318250m, 2, "https://picsum.photos/640/480/?image=139" },
                    { 73, "Sit qui ea qui mollitia est et nulla ut odit est nihil dolorum aliquam aperiam velit illum aut laborum et.", 10.3447956118475620m, "Accusantium assumenda mollitia.", 10.9523026756720160m, 4, "https://picsum.photos/640/480/?image=570" },
                    { 74, "Dolor voluptate vel qui fugiat sunt in sint eum inventore fugit maxime laborum nostrum similique eos voluptas ea natus error.", 10.5804183634838180m, "Eos voluptatem aperiam.", 10.6462353675841520m, 7, "https://picsum.photos/640/480/?image=251" },
                    { 75, "Facilis quo dolorem ipsum a ad quod magnam iusto est autem necessitatibus dolores ipsa id sed qui nihil tempora repellat.", 10.385674921975320m, "Omnis velit eos.", 10.6140388080915620m, 5, "https://picsum.photos/640/480/?image=343" },
                    { 76, "Iure mollitia aut dolores dolor nihil impedit recusandae soluta consequatur rerum sequi totam officiis ipsa magni dolores laudantium rem molestiae.", 10.9086768626741490m, "Officiis ullam possimus.", 10.5201835010760390m, 4, "https://picsum.photos/640/480/?image=517" },
                    { 77, "Dolore quaerat ex ut ullam distinctio occaecati ex et harum incidunt velit laudantium nihil aut inventore velit quaerat unde possimus.", 10.5737991722178640m, "Laborum voluptas velit.", 10.128382933851510m, 3, "https://picsum.photos/640/480/?image=497" },
                    { 78, "Labore voluptatum modi ut aut pariatur aut praesentium tempore voluptas expedita qui dolores hic sint iure et et ut consequatur.", 10.4092898803806350m, "Aut in officiis.", 10.002474551555921580m, 9, "https://picsum.photos/640/480/?image=378" },
                    { 79, "Veniam tempore alias consequatur suscipit eveniet repellendus veniam debitis et quis ut ut blanditiis delectus iusto minus perspiciatis tempore ab.", 10.6110124190389240m, "Velit et sunt.", 10.8070028516496540m, 2, "https://picsum.photos/640/480/?image=192" },
                    { 80, "Accusamus eum et quae ratione illum minima est repellendus tempore voluptatem voluptatem est impedit libero rerum a numquam natus sint.", 10.03831597978170770m, "Dignissimos maxime qui.", 10.5503917371623180m, 10, "https://picsum.photos/640/480/?image=820" },
                    { 81, "Voluptas tempore corrupti dolore error deserunt quas sint blanditiis magnam iure eos non quasi qui dolor voluptas velit tempora maiores.", 10.1395980166921380m, "Harum non perferendis.", 10.3424173315718850m, 10, "https://picsum.photos/640/480/?image=129" },
                    { 82, "Nulla fugiat at molestias velit et aut sint illo ullam nihil possimus est sit autem non reprehenderit similique architecto doloremque.", 10.8213966027001840m, "Perspiciatis aut dolorem.", 10.8486587078537140m, 9, "https://picsum.photos/640/480/?image=249" },
                    { 83, "Tempore fuga cumque quaerat nihil soluta voluptas distinctio vitae animi quod aut cupiditate est omnis cum debitis laboriosam et et.", 10.5487890115700610m, "Impedit voluptate perspiciatis.", 10.8034373944641260m, 10, "https://picsum.photos/640/480/?image=225" },
                    { 84, "Reiciendis voluptatem ut est et alias architecto dolores saepe aliquid ipsa quisquam beatae sapiente occaecati impedit laborum est deserunt omnis.", 10.2950958503853040m, "Distinctio totam pariatur.", 10.3071639334350660m, 2, "https://picsum.photos/640/480/?image=628" },
                    { 85, "Quod quia optio quia mollitia ut eum temporibus quidem fugit tenetur earum aut ducimus deserunt distinctio quia quo et in.", 10.2822402097667750m, "Accusamus illo voluptates.", 10.5385968315129150m, 9, "https://picsum.photos/640/480/?image=1066" },
                    { 86, "Perspiciatis nobis debitis doloribus omnis maxime explicabo suscipit aut adipisci tempora dignissimos corrupti magnam quia aut mollitia distinctio nihil dolorum.", 10.7155839874016050m, "Non et sint.", 10.1011005458892790m, 7, "https://picsum.photos/640/480/?image=340" },
                    { 87, "Quis blanditiis veniam eum adipisci provident ipsam veniam odit omnis consequuntur quia velit aut fugit culpa totam aspernatur reprehenderit consequuntur.", 10.3657723229219080m, "Ratione magnam deleniti.", 10.3240280595254280m, 4, "https://picsum.photos/640/480/?image=891" },
                    { 88, "Illum eum ab illo voluptas non voluptatem quisquam debitis qui vel aperiam voluptates quia delectus et quia rem atque molestias.", 10.9859148715557140m, "Et modi dignissimos.", 10.7413526097039470m, 2, "https://picsum.photos/640/480/?image=263" },
                    { 89, "Sequi consequatur inventore ipsa qui ut dicta dolores blanditiis illo nihil veniam est recusandae nesciunt labore at et et atque.", 10.3580537463343020m, "Est facere quia.", 10.9529966944609750m, 3, "https://picsum.photos/640/480/?image=181" },
                    { 90, "Nihil fugiat eligendi aut sit sunt ea odit porro illum est vitae veritatis dolorem soluta excepturi perferendis esse amet quo.", 10.5837230596615580m, "Est ipsum porro.", 10.5740795333749050m, 8, "https://picsum.photos/640/480/?image=301" },
                    { 91, "Ipsum quibusdam impedit dolor enim natus aliquam eum nam omnis quia autem adipisci dolore dolorem odio quam dolorem similique alias.", 10.274270958394870m, "Excepturi distinctio enim.", 10.658522922852320m, 9, "https://picsum.photos/640/480/?image=304" },
                    { 92, "Qui sed dicta velit consequatur tempore illum incidunt nemo aut eaque esse cupiditate consequatur odio perferendis placeat quo ipsa asperiores.", 10.747361284563020m, "Eos qui sit.", 10.5894991953808340m, 2, "https://picsum.photos/640/480/?image=309" },
                    { 93, "Laborum eveniet hic nihil sint nobis tempora aut ut culpa ut aut cumque autem perferendis sint et vel placeat quae.", 10.2199649062100630m, "Fugit rerum expedita.", 10.191195387947930m, 3, "https://picsum.photos/640/480/?image=355" },
                    { 94, "Maxime qui aut possimus ullam nihil perferendis quia suscipit ea officia quia minus ullam optio quia iusto in aperiam laboriosam.", 10.5739358652261720m, "Ducimus qui officia.", 10.6164587636554890m, 3, "https://picsum.photos/640/480/?image=108" },
                    { 95, "Totam reprehenderit quidem pariatur reiciendis explicabo explicabo atque porro nostrum qui ab eum est ipsum soluta nesciunt voluptas quaerat sit.", 10.4939751226892580m, "Rerum commodi eveniet.", 10.7484387260621590m, 1, "https://picsum.photos/640/480/?image=773" },
                    { 96, "Aut ipsum dolorem voluptatem consequatur recusandae cupiditate unde vel optio molestias laborum accusantium quidem vel reiciendis aut laborum ut est.", 10.4448591840662340m, "Cumque velit atque.", 10.6519452112968760m, 9, "https://picsum.photos/640/480/?image=893" },
                    { 97, "Voluptatem aut ut vel voluptatem error laborum quia ipsam omnis accusantium aut fugit vero eos ea maiores et incidunt ut.", 10.9342153570308420m, "Accusamus est ut.", 10.381596092778070m, 6, "https://picsum.photos/640/480/?image=75" },
                    { 98, "Eum non ad explicabo reprehenderit quia officia autem sunt totam rerum ex quae esse excepturi et molestiae vero animi ut.", 10.5120416355841060m, "Non aliquid voluptas.", 10.7923195244708660m, 1, "https://picsum.photos/640/480/?image=177" },
                    { 99, "Delectus numquam praesentium sit id quibusdam et dolor deserunt eaque praesentium harum necessitatibus non atque error saepe aut exercitationem amet.", 10.8681772718523520m, "Esse quidem qui.", 10.8183644450355160m, 5, "https://picsum.photos/640/480/?image=985" },
                    { 100, "Ut voluptatem dignissimos consequatur cum possimus libero dolorum nesciunt fugit quis minima natus dolore harum et laudantium delectus modi quo.", 10.3098721817647440m, "Nemo est sed.", 10.704538005732250m, 10, "https://picsum.photos/640/480/?image=96" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/753.jpg", "b6321481-7376-447e-a2c7-3ff4e03ee7db", new DateTime(2023, 1, 22, 8, 25, 18, 410, DateTimeKind.Local).AddTicks(3100), "ClarkFadel.Stark@gmail.com", false, "Clark Fadel", "Female", false, null, null, null, "BRHDGI6qra", null, "1-498-765-3374 x93306", false, "79d291e8-a00e-45b4-88b8-b8c34158db89", false, "ClarkFadel_West82" },
                    { "10", 0, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1232.jpg", "bd6a358b-d590-4dce-86f9-27adf8072bf2", new DateTime(2023, 10, 2, 6, 19, 23, 153, DateTimeKind.Local).AddTicks(2990), "FionaChristiansen54@yahoo.com", false, "Fiona Christiansen", "Female", false, null, null, null, "zRF7QgPlRh", null, "1-742-904-3233 x336", false, "4fed2cd6-8631-4ac5-9d7e-1611cdb6484f", false, "FionaChristiansen.Cassin" },
                    { "2", 0, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/764.jpg", "72558ab8-8807-4f7f-886e-df0010a96ad1", new DateTime(2023, 3, 24, 3, 46, 7, 765, DateTimeKind.Local).AddTicks(2436), "ConorDaniel_Reinger90@gmail.com", false, "Conor Daniel", "Male", false, null, null, null, "PeJbP8ks3z", null, "(629) 275-2249", false, "9664dc50-8eb8-4074-ace9-8279213c6dbd", false, "ConorDaniel_Hudson" },
                    { "3", 0, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/842.jpg", "4430e35a-e981-451c-89d0-0bde4834b479", new DateTime(2023, 7, 28, 2, 4, 11, 453, DateTimeKind.Local).AddTicks(1885), "BudRogahn_Schulist90@yahoo.com", false, "Bud Rogahn", "Female", false, null, null, null, "y4JuoXIhC0", null, "(448) 272-0448 x49112", false, "12ffbe17-6649-4949-8db6-fc4ff3602d77", false, "BudRogahn57" },
                    { "4", 0, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/42.jpg", "1e4e38bb-bd62-4a68-99a3-b8c541a9db95", new DateTime(2023, 7, 29, 23, 43, 42, 507, DateTimeKind.Local).AddTicks(4297), "EribertoCartwright32@yahoo.com", false, "Eriberto Cartwright", "Male", false, null, null, null, "prg7dkT30Z", null, "(354) 967-1122 x76284", false, "a4b07db4-500f-4a76-92b5-f6fdaa60f5c7", false, "EribertoCartwright.Wunsch72" },
                    { "5", 0, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/669.jpg", "ca93c65c-6508-4fa3-a1bf-e68129d2dd16", new DateTime(2023, 9, 2, 16, 9, 17, 508, DateTimeKind.Local).AddTicks(6856), "BernadineWalker_Medhurst41@yahoo.com", false, "Bernadine Walker", "Male", false, null, null, null, "fM5Lp3i7Ks", null, "288-228-4631", false, "34ddcddf-67c0-4034-98d2-f873d52e73bb", false, "BernadineWalker_Weissnat" },
                    { "6", 0, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1138.jpg", "09e10432-7b20-4a3a-95da-d54d2a9d7130", new DateTime(2023, 3, 15, 6, 2, 20, 542, DateTimeKind.Local).AddTicks(7578), "SybleHilll.Emard@hotmail.com", false, "Syble Hilll", "Female", false, null, null, null, "mKfX5cv9N2", null, "838.848.3427 x080", false, "2d8c4f66-bcd7-467d-bbd9-9bafcbfbca6e", false, "SybleHilll16" },
                    { "7", 0, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/651.jpg", "6418462e-c44e-47ac-851b-b932cd3c1231", new DateTime(2023, 7, 25, 17, 55, 10, 777, DateTimeKind.Local).AddTicks(5), "DeltaDavis50@hotmail.com", false, "Delta Davis", "Male", false, null, null, null, "0UZyB6Lpp_", null, "(530) 315-2805 x618", false, "41b3fce0-b248-4d8c-9562-c72889323370", false, "DeltaDavis.Heathcote" },
                    { "8", 0, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/361.jpg", "30010be9-1640-4d19-9ec7-d16e6d364c49", new DateTime(2023, 10, 17, 5, 41, 35, 985, DateTimeKind.Local).AddTicks(8817), "ElyssaLarkin91@gmail.com", false, "Elyssa Larkin", "Female", false, null, null, null, "uG0c4HdN1L", null, "1-931-875-7509", false, "5323ab41-9cab-4821-81ac-735c6cb5751b", false, "ElyssaLarkin_Barton" },
                    { "9", 0, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/661.jpg", "6da250e0-da29-42aa-a03b-8e98e2de0a90", new DateTime(2023, 11, 14, 4, 49, 2, 853, DateTimeKind.Local).AddTicks(1066), "SkylaHessel.Jakubowski@hotmail.com", false, "Skyla Hessel", "Female", false, null, null, null, "Zqx3bsawSF", null, "598-673-0073", false, "d945c2b3-88e1-46c2-b829-0fedffb68a06", false, "SkylaHessel5" }
                });

            migrationBuilder.InsertData(
                table: "CategoryItems",
                columns: new[] { "CategoryId", "ItemId" },
                values: new object[,]
                {
                    { 7, 1 },
                    { 8, 2 },
                    { 5, 3 },
                    { 1, 4 },
                    { 3, 5 },
                    { 8, 6 },
                    { 3, 7 },
                    { 6, 8 },
                    { 9, 9 },
                    { 3, 10 },
                    { 10, 11 },
                    { 2, 12 },
                    { 5, 13 },
                    { 10, 14 },
                    { 9, 15 },
                    { 3, 16 },
                    { 2, 17 },
                    { 3, 18 },
                    { 7, 19 },
                    { 9, 20 },
                    { 7, 21 },
                    { 6, 22 },
                    { 5, 23 },
                    { 1, 24 },
                    { 9, 25 },
                    { 9, 26 },
                    { 9, 27 },
                    { 7, 28 },
                    { 2, 29 },
                    { 6, 30 },
                    { 10, 31 },
                    { 8, 32 },
                    { 7, 33 },
                    { 4, 34 },
                    { 1, 35 },
                    { 7, 36 },
                    { 6, 37 },
                    { 10, 38 },
                    { 2, 39 },
                    { 1, 40 },
                    { 8, 41 },
                    { 10, 42 },
                    { 7, 43 },
                    { 8, 44 },
                    { 4, 45 },
                    { 10, 46 },
                    { 2, 47 },
                    { 8, 48 },
                    { 10, 49 },
                    { 6, 50 },
                    { 4, 51 },
                    { 7, 52 },
                    { 9, 53 },
                    { 10, 54 },
                    { 2, 55 },
                    { 2, 56 },
                    { 4, 57 },
                    { 5, 58 },
                    { 2, 59 },
                    { 5, 60 },
                    { 10, 61 },
                    { 6, 62 },
                    { 4, 63 },
                    { 3, 64 },
                    { 4, 65 },
                    { 3, 66 },
                    { 6, 67 },
                    { 2, 68 },
                    { 10, 69 },
                    { 3, 70 },
                    { 7, 71 },
                    { 2, 72 },
                    { 1, 73 },
                    { 7, 74 },
                    { 2, 75 },
                    { 7, 76 },
                    { 9, 77 },
                    { 7, 78 },
                    { 7, 79 },
                    { 10, 80 },
                    { 7, 81 },
                    { 1, 82 },
                    { 8, 83 },
                    { 7, 84 },
                    { 2, 85 },
                    { 3, 86 },
                    { 10, 87 },
                    { 7, 88 },
                    { 2, 89 },
                    { 10, 90 },
                    { 3, 91 },
                    { 2, 92 },
                    { 9, 93 },
                    { 7, 94 },
                    { 1, 95 },
                    { 3, 96 },
                    { 6, 97 },
                    { 4, 98 },
                    { 5, 99 },
                    { 2, 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ItemId",
                table: "CartItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_UserId",
                table: "CartItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItems_CategoryId",
                table: "CategoryItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ItemId",
                table: "Images",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ReviewId",
                table: "Images",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ItemId",
                table: "OrderItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_OrderItemId",
                table: "Reviews",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "CategoryItems");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
