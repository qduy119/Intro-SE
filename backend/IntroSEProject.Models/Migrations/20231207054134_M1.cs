using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IntroSEProject.Models.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
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
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Images = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: false),
                    FullName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Avatar = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    Gender = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Role = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
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
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                name: "SeatReservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatReservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeatReservation_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
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
                    Images = table.Column<string>(type: "longtext", nullable: false),
                    OrderItemId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "Thumbnail" },
                values: new object[,]
                {
                    { 1, "Fugit quis minima natus. Harum et laudantium delectus. Quo nihil enim rerum.", "Cum possimus libero.", "https://picsum.photos/640/480/?image=399" },
                    { 2, "Dolor consequatur officiis. Soluta eum praesentium voluptatem libero dolor debitis eius voluptates quia. Id qui id itaque sit hic.", "Consequatur quia qui.", "https://picsum.photos/640/480/?image=210" },
                    { 3, "Quis dolore natus iste corporis aperiam cupiditate vel. Velit quis debitis esse quia assumenda quibusdam amet.", "Quia vitae eveniet.", "https://picsum.photos/640/480/?image=1052" },
                    { 4, "Doloribus iure excepturi qui voluptatem vel dolore. Aspernatur ut ipsum sunt ut odit tempora sunt sit.", "Dolores quibusdam maiores.", "https://picsum.photos/640/480/?image=375" },
                    { 5, "Cupiditate aut dolor quia recusandae id in et tempore. Distinctio sunt dolorem autem qui autem error et dolorum consectetur. Dolore vitae et est sapiente est enim.", "Rerum nihil adipisci.", "https://picsum.photos/640/480/?image=417" },
                    { 6, "Doloribus odio ut quidem ipsam ab optio. Dolores non et sed inventore omnis animi aut.", "Ipsa autem reprehenderit.", "https://picsum.photos/640/480/?image=446" },
                    { 7, "Molestiae ipsam corrupti aut delectus. Quia harum dicta.", "Quia sunt laboriosam.", "https://picsum.photos/640/480/?image=412" },
                    { 8, "Molestiae sit similique dolores a facere.", "Fugit rerum aut.", "https://picsum.photos/640/480/?image=289" },
                    { 9, "In distinctio officia qui fugit ad quo excepturi. Voluptatem laboriosam dicta id dignissimos eos consequuntur reiciendis. Esse aut blanditiis est qui voluptatem. Nulla nostrum cupiditate.", "Fuga voluptatem ut.", "https://picsum.photos/640/480/?image=946" },
                    { 10, "Aut ut dolores ducimus repellat commodi. Harum placeat omnis. Deleniti necessitatibus excepturi necessitatibus maxime facilis qui corrupti voluptatem. Autem non error vel enim.", "Eligendi suscipit quasi.", "https://picsum.photos/640/480/?image=59" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "Discount", "Images", "Name", "Price", "Stock", "Thumbnail" },
                values: new object[,]
                {
                    { 1, "Voluptatem quidem hic provident voluptate et occaecati aperiam placeat sapiente a quas aut non quae voluptas ratione voluptas impedit similique.", 10.1235174667665350m, null, "Autem commodi qui.", 10.2664954160649770m, 4, "https://picsum.photos/640/480/?image=233" },
                    { 2, "Dolores mollitia distinctio adipisci ad doloribus minus corporis occaecati ex perferendis in et est ut aliquam iste temporibus ducimus nam.", 10.9982851473606590m, null, "Qui vero quibusdam.", 10.7592835932780450m, 7, "https://picsum.photos/640/480/?image=232" },
                    { 3, "Magni velit et id eos omnis ducimus accusantium odio sunt assumenda nobis sint quasi tempora cupiditate velit magni placeat repellendus.", 10.9180386508433330m, null, "Rerum libero quibusdam.", 10.9608586942594770m, 9, "https://picsum.photos/640/480/?image=223" },
                    { 4, "Eaque dolores et blanditiis nemo est adipisci id odit minima dolorum debitis accusantium voluptatum culpa voluptates dolorem temporibus odit non.", 10.5333897986139120m, null, "Molestiae hic adipisci.", 10.591338782846620m, 5, "https://picsum.photos/640/480/?image=911" },
                    { 5, "Quo non voluptas in enim consectetur ex velit non sed harum praesentium architecto voluptatem totam quia et temporibus aliquam est.", 10.3789012075303590m, null, "Architecto eos aut.", 10.3123202479036150m, 1, "https://picsum.photos/640/480/?image=306" },
                    { 6, "Id quas voluptatem dolorum vel ipsum qui ex reprehenderit omnis debitis enim nobis libero veritatis illo quis provident voluptas doloremque.", 10.1237280401977380m, null, "Illo voluptatem sit.", 10.6104881640572510m, 5, "https://picsum.photos/640/480/?image=765" },
                    { 7, "Similique blanditiis sed dolorum ut doloribus quia facere voluptates molestias repudiandae aliquam nostrum ut sapiente architecto nisi commodi deleniti similique.", 10.249544602934990m, null, "Quos qui esse.", 10.05369568572086080m, 4, "https://picsum.photos/640/480/?image=251" },
                    { 8, "Voluptate deleniti sunt temporibus magni iste possimus nesciunt ut consectetur sequi provident voluptatem excepturi sint sequi unde praesentium minima eaque.", 10.6466922255450360m, null, "Quia est nostrum.", 10.6838695107418440m, 1, "https://picsum.photos/640/480/?image=689" },
                    { 9, "Ea voluptatem magni similique ducimus dolorum cumque assumenda ad illum porro repellendus optio provident amet veritatis rerum amet fugiat nesciunt.", 10.1371393935462180m, null, "Accusamus perferendis aliquam.", 10.05465095353063710m, 1, "https://picsum.photos/640/480/?image=74" },
                    { 10, "Id omnis et voluptatem et fugit ullam qui voluptas assumenda fuga impedit voluptates dolorum maxime facilis suscipit fugiat tempore culpa.", 10.4965127736779460m, null, "Quia saepe est.", 10.5029513349304680m, 6, "https://picsum.photos/640/480/?image=843" },
                    { 11, "Sed modi modi ex reprehenderit omnis recusandae explicabo consequatur voluptas quibusdam autem libero qui eos ut exercitationem voluptatem deleniti molestiae.", 10.3097775645133940m, null, "Aut aperiam at.", 10.5359777289144590m, 5, "https://picsum.photos/640/480/?image=177" },
                    { 12, "Amet aut dolor ut qui necessitatibus quaerat aspernatur quia et velit incidunt sequi aut non id et ut eaque consequatur.", 10.3654237437832280m, null, "Rerum et ipsam.", 10.1844345122503280m, 2, "https://picsum.photos/640/480/?image=823" },
                    { 13, "Voluptatem necessitatibus qui laudantium velit necessitatibus labore maxime voluptatibus eum in et et voluptate exercitationem delectus qui rerum doloremque voluptas.", 10.006635893139352970m, null, "Ut in odit.", 10.9508450799392740m, 6, "https://picsum.photos/640/480/?image=310" },
                    { 14, "Magni qui sapiente necessitatibus consequatur maxime dolor earum non dignissimos voluptatem alias nisi sint tempora unde et modi necessitatibus magni.", 10.8882813886219080m, null, "Eius et dolores.", 10.5966029826535860m, 5, "https://picsum.photos/640/480/?image=753" },
                    { 15, "Nesciunt enim voluptatem aperiam dolore quas reprehenderit odit molestiae voluptatem earum non voluptates consequuntur totam dicta occaecati in aut est.", 10.7227451758099460m, null, "Ea accusamus architecto.", 10.4103319758597440m, 5, "https://picsum.photos/640/480/?image=454" },
                    { 16, "Ut et quam ut corrupti dolores tempore fuga et necessitatibus velit et et hic consequatur corporis cupiditate delectus perferendis reiciendis.", 10.1289434875962060m, null, "Rem voluptas est.", 10.007128125525604990m, 9, "https://picsum.photos/640/480/?image=723" },
                    { 17, "Distinctio iusto at et error sint qui quos et quas deleniti qui quo labore quas quo adipisci aut tempore eum.", 10.6016682943336980m, null, "Voluptas occaecati sit.", 10.7360985971689680m, 5, "https://picsum.photos/640/480/?image=956" },
                    { 18, "Assumenda assumenda odio ut cumque ut enim aut amet omnis labore nulla maiores est praesentium earum quibusdam ipsa excepturi corporis.", 10.5043802352176890m, null, "Cumque blanditiis aliquid.", 10.7401526457351410m, 3, "https://picsum.photos/640/480/?image=1016" },
                    { 19, "Ducimus veritatis perferendis sint hic odit similique sapiente quisquam nihil delectus dolor atque in incidunt ipsam veritatis a voluptatem est.", 10.2773177657636430m, null, "Est dolorem eos.", 10.6116690354476070m, 7, "https://picsum.photos/640/480/?image=655" },
                    { 20, "Est voluptatem deleniti quo voluptas provident eum et hic quia eos nostrum quod quam consequatur id occaecati eum quaerat accusantium.", 10.5099208278162040m, null, "Saepe consectetur voluptatem.", 10.9031889466118020m, 2, "https://picsum.photos/640/480/?image=677" },
                    { 21, "Cupiditate ipsum ea reprehenderit voluptatem possimus tenetur a optio labore officia velit dolore et provident veniam qui sed nam cupiditate.", 10.8008274951953570m, null, "Est molestias deleniti.", 10.2681808975842690m, 6, "https://picsum.photos/640/480/?image=245" },
                    { 22, "Magnam aspernatur architecto aliquam amet quaerat ab corporis optio perspiciatis repellendus quo provident repellendus praesentium fugit dolores non et aut.", 10.3695262076191260m, null, "Autem harum neque.", 10.3723594035824570m, 3, "https://picsum.photos/640/480/?image=151" },
                    { 23, "Non est et voluptatem mollitia iure deserunt nihil vero fuga maiores in earum velit ut quo id ex commodi dolores.", 10.807492600664260m, null, "Voluptatem voluptatibus maiores.", 10.7392903392851770m, 7, "https://picsum.photos/640/480/?image=52" },
                    { 24, "Autem aut officiis accusantium incidunt quia enim voluptas culpa et veniam amet qui itaque beatae id quos excepturi provident nobis.", 10.02310923581156380m, null, "Non dolorem dolorum.", 10.8147748177008590m, 6, "https://picsum.photos/640/480/?image=45" },
                    { 25, "Dolore ea eaque officia illo molestiae voluptas et dolorem maiores animi facere consectetur tempore ex assumenda est qui dolorem repudiandae.", 10.6619289655526770m, null, "Eligendi expedita pariatur.", 10.1935321968950020m, 3, "https://picsum.photos/640/480/?image=533" },
                    { 26, "Consequatur assumenda ut vel suscipit in ea voluptatem iusto perspiciatis deleniti incidunt omnis nobis eos magnam et saepe omnis laboriosam.", 10.4576506407268580m, null, "Non cum deleniti.", 10.01329588750996440m, 3, "https://picsum.photos/640/480/?image=213" },
                    { 27, "Expedita qui velit voluptas inventore autem hic a aperiam deleniti id voluptatem dolor fugiat est et tempora exercitationem modi voluptate.", 10.05678985689617220m, null, "Eaque cupiditate quod.", 10.2294453928384210m, 5, "https://picsum.photos/640/480/?image=824" },
                    { 28, "Totam aliquid sint officia laboriosam consequatur fugiat cumque iusto ut cumque quam vero consequatur qui aut est perferendis et qui.", 10.3634323526003550m, null, "Corporis assumenda laboriosam.", 10.5036332684120320m, 6, "https://picsum.photos/640/480/?image=637" },
                    { 29, "Excepturi animi quia laborum sed nostrum aperiam atque est occaecati necessitatibus voluptatem blanditiis nisi dolores non est cupiditate officiis commodi.", 10.5021898106216410m, null, "Totam illum fugit.", 10.597817600983110m, 10, "https://picsum.photos/640/480/?image=30" },
                    { 30, "Quo aut vel corrupti quia cupiditate optio voluptatem aut voluptatem dolorum dolorem magni qui voluptas sed qui aut placeat ipsum.", 10.3704289604772020m, null, "In cum sit.", 10.2397404244354650m, 2, "https://picsum.photos/640/480/?image=692" },
                    { 31, "Sint aut facilis sed eaque vero odit velit vel autem aperiam assumenda quod possimus accusantium doloremque hic et ex maxime.", 10.2689963380196110m, null, "Quas deserunt blanditiis.", 10.5433295725580910m, 4, "https://picsum.photos/640/480/?image=919" },
                    { 32, "Rerum laudantium tenetur delectus voluptatibus non quasi dolor nemo praesentium est qui enim voluptatem dolorum hic voluptas unde aut consequatur.", 10.2145741443217610m, null, "Possimus dolorem quas.", 10.41459125253120m, 4, "https://picsum.photos/640/480/?image=402" },
                    { 33, "Voluptates dolore et ad omnis non aliquid neque minus molestiae dolorem ab et tempore in porro sunt modi deleniti quae.", 10.921750722416560m, null, "Dolor ratione nulla.", 10.7233792882055880m, 4, "https://picsum.photos/640/480/?image=217" },
                    { 34, "Sunt qui consequuntur facere sit fugiat soluta nesciunt recusandae soluta sit hic autem a eos rerum cupiditate et dolores accusamus.", 10.8365456037393520m, null, "Qui facilis qui.", 10.3342450346491510m, 5, "https://picsum.photos/640/480/?image=62" },
                    { 35, "Quia doloribus non sunt qui magni reprehenderit quaerat et est tempore rerum eius natus sint facilis eaque iure ad odit.", 10.8635208727156380m, null, "Reiciendis corporis aspernatur.", 10.09030015398296540m, 1, "https://picsum.photos/640/480/?image=833" },
                    { 36, "Atque aliquam incidunt ex omnis aut id iste dolorem alias aut minus illum maiores optio molestiae minima pariatur vero minima.", 10.8189978547482740m, null, "Natus quia omnis.", 10.3066452379835050m, 2, "https://picsum.photos/640/480/?image=862" },
                    { 37, "Aut quaerat tenetur dolores aut consequuntur ex et consequatur velit magnam eveniet omnis deleniti consequatur ut rerum molestiae expedita praesentium.", 10.3928195356357930m, null, "Vel cumque adipisci.", 10.1204490364158750m, 5, "https://picsum.photos/640/480/?image=499" },
                    { 38, "Rem libero veritatis est reiciendis architecto nobis qui exercitationem numquam accusamus aspernatur id praesentium vitae eligendi tempora accusantium hic aspernatur.", 10.3016800937716290m, null, "Rerum cumque quae.", 10.7980541199436660m, 5, "https://picsum.photos/640/480/?image=820" },
                    { 39, "Architecto et dolorem velit consectetur enim vitae aut labore earum molestiae ad dolorem architecto facere impedit dolores est eum illo.", 10.03982287181533080m, null, "Provident quisquam et.", 10.9981208210802270m, 8, "https://picsum.photos/640/480/?image=595" },
                    { 40, "Dolore ipsum adipisci sint labore aliquam fugiat est aut rem perferendis soluta temporibus occaecati culpa voluptas placeat quibusdam facere consequuntur.", 10.04377025926661220m, null, "Qui asperiores id.", 10.02355291183272050m, 6, "https://picsum.photos/640/480/?image=226" },
                    { 41, "Et aperiam repudiandae et totam adipisci nihil quo quo ipsa molestiae consectetur sit asperiores laudantium facilis ut sed sunt ipsa.", 10.4191710634246330m, null, "Omnis cumque libero.", 10.5321416121591540m, 2, "https://picsum.photos/640/480/?image=368" },
                    { 42, "Culpa sed in at id sed qui officia sunt velit vero perspiciatis atque vitae nobis et et quia est minus.", 10.5605991862530820m, null, "Velit reiciendis et.", 10.1343380595251630m, 5, "https://picsum.photos/640/480/?image=1032" },
                    { 43, "Eos dolorem quo sapiente sed quos sit quia harum eos amet eligendi et et ea necessitatibus dignissimos vel sunt id.", 10.8474100436304740m, null, "Modi est distinctio.", 10.9588632378535640m, 6, "https://picsum.photos/640/480/?image=387" },
                    { 44, "Minus voluptatem et eius harum ab debitis ducimus voluptas minus ut et illo sequi sapiente ab qui laborum harum a.", 10.7311544002644510m, null, "Et et et.", 10.3020839380575740m, 7, "https://picsum.photos/640/480/?image=430" },
                    { 45, "Cumque nostrum enim dignissimos suscipit ea magnam mollitia aut eum sint iste rerum omnis maiores quidem sequi non est occaecati.", 10.9977295128618040m, null, "Reiciendis est vitae.", 10.450777666387510m, 8, "https://picsum.photos/640/480/?image=1036" },
                    { 46, "Itaque alias aliquid nulla et voluptatibus ut quia nesciunt dolores nostrum eveniet dolore et iste eos eius vel illo doloribus.", 10.3174591564188990m, null, "Repellendus repellat nulla.", 10.1795593505630080m, 1, "https://picsum.photos/640/480/?image=893" },
                    { 47, "Et nihil dolores ducimus expedita suscipit natus enim mollitia facere maiores cum sunt tempore animi dolorem qui eos enim voluptatum.", 10.8930197138772440m, null, "Maxime magnam magni.", 10.7177520411637390m, 2, "https://picsum.photos/640/480/?image=562" },
                    { 48, "Nam dolorum voluptates fugiat aut doloribus pariatur laboriosam rem nam quae quidem error est corrupti sapiente odit ut eos atque.", 10.5777948794783070m, null, "Aut qui consequatur.", 10.318862877468980m, 5, "https://picsum.photos/640/480/?image=624" },
                    { 49, "Esse id error sint iusto molestiae sit saepe est est et aut nobis quisquam sit magni neque aspernatur tempora placeat.", 10.2291722298735620m, null, "Expedita et est.", 10.7879984741043290m, 10, "https://picsum.photos/640/480/?image=1029" },
                    { 50, "Est dicta magni a quia tempore numquam iusto animi et maxime laborum impedit incidunt quibusdam quibusdam enim amet ex qui.", 10.9861975805769660m, null, "Laboriosam officiis dolore.", 10.7614635255939620m, 5, "https://picsum.photos/640/480/?image=32" },
                    { 51, "Maiores sit aut sed culpa natus soluta rerum aut natus qui maxime quia totam veniam qui modi quam atque sint.", 10.9916278128473220m, null, "At et soluta.", 10.5179485965138060m, 5, "https://picsum.photos/640/480/?image=355" },
                    { 52, "Atque cumque rerum aut odit maxime asperiores incidunt magnam quibusdam consequatur neque ab accusantium deserunt doloribus labore perspiciatis dignissimos voluptatem.", 10.4765988488106980m, null, "Voluptas voluptatibus nihil.", 10.9822460743515970m, 3, "https://picsum.photos/640/480/?image=714" },
                    { 53, "Neque asperiores facere ratione eligendi mollitia dolores velit itaque dolorem possimus dolorum alias non labore aperiam recusandae vero aliquam et.", 10.926392891409990m, null, "Voluptates consequatur repudiandae.", 10.491745424220220m, 1, "https://picsum.photos/640/480/?image=241" },
                    { 54, "Odio consequatur ducimus esse saepe quod eum fugiat labore et est tempore similique repudiandae eum et dolorem atque et odio.", 10.7445429417977780m, null, "Fugit in fugiat.", 10.936789435770730m, 5, "https://picsum.photos/640/480/?image=209" },
                    { 55, "Quam ut asperiores natus doloremque exercitationem omnis eligendi consectetur quos placeat eos aut ipsum vel alias provident veniam sit est.", 10.6631271306719290m, null, "Consequatur et recusandae.", 10.5177929566790320m, 3, "https://picsum.photos/640/480/?image=348" },
                    { 56, "Eveniet optio error consequuntur ab labore aut voluptate animi et itaque dolorum vel aut modi rerum nesciunt architecto dolorum ipsa.", 10.5588876221137530m, null, "Impedit adipisci a.", 10.2695852528650240m, 8, "https://picsum.photos/640/480/?image=191" },
                    { 57, "Esse possimus sapiente illum pariatur quo suscipit et repellat fuga consequatur optio dolorum architecto omnis omnis possimus mollitia nam et.", 10.2968180367242630m, null, "Eaque amet delectus.", 10.8824484766844890m, 1, "https://picsum.photos/640/480/?image=987" },
                    { 58, "Est laboriosam tenetur et dicta et ad reprehenderit et rerum molestiae dicta dolor ipsa earum modi perferendis autem vel repellat.", 10.5079492784607920m, null, "Aut sunt sequi.", 10.9657960217286810m, 8, "https://picsum.photos/640/480/?image=124" },
                    { 59, "Vitae sed minus nulla quo omnis nobis est cupiditate quae aut minima fugiat ut nobis aut eos voluptas molestias rerum.", 10.9410902531543240m, null, "Ipsam quis eum.", 10.7599210542440050m, 1, "https://picsum.photos/640/480/?image=1072" },
                    { 60, "Amet sit natus delectus laboriosam porro deleniti consectetur enim sint autem quo voluptas explicabo qui esse dolor ipsa excepturi perspiciatis.", 10.2824552973184990m, null, "Quia quisquam sunt.", 10.6532198221670560m, 4, "https://picsum.photos/640/480/?image=12" },
                    { 61, "Fuga qui quae quisquam cupiditate asperiores libero dolores totam delectus beatae harum error aliquid sequi velit adipisci ut laborum dolor.", 10.3653057508009050m, null, "Distinctio consequatur corrupti.", 10.7878158543202170m, 6, "https://picsum.photos/640/480/?image=694" },
                    { 62, "Iusto et repellendus sint corporis provident tempora vero quae tempora adipisci enim quisquam expedita animi non qui aspernatur voluptate rerum.", 10.4971379281473990m, null, "Ut consequatur dolor.", 10.1949364152713380m, 9, "https://picsum.photos/640/480/?image=970" },
                    { 63, "Cumque quaerat et voluptatem facere quo vel ut deserunt nobis quae omnis aut laboriosam quos odit sit repellat beatae necessitatibus.", 10.1889751628921250m, null, "Exercitationem ab et.", 10.5232153006471760m, 5, "https://picsum.photos/640/480/?image=221" },
                    { 64, "Voluptatibus itaque aperiam culpa fuga magnam et cupiditate animi molestiae architecto dignissimos iste et nihil consequatur dolore ea quia corporis.", 10.7022448380953840m, null, "Autem error et.", 10.6078902332148940m, 4, "https://picsum.photos/640/480/?image=79" },
                    { 65, "Aut excepturi qui perspiciatis ex amet pariatur fugiat exercitationem natus aut nihil non velit vel saepe soluta aut iste occaecati.", 10.1001166468952390m, null, "Sed numquam neque.", 10.9816900407810180m, 2, "https://picsum.photos/640/480/?image=745" },
                    { 66, "Aliquam minima omnis ut autem voluptate sunt et perferendis omnis rerum porro aliquam impedit architecto magni ducimus qui voluptatibus autem.", 10.7949031506641320m, null, "Libero rem voluptatem.", 10.1024271073296790m, 9, "https://picsum.photos/640/480/?image=208" },
                    { 67, "Dolor alias voluptas et officiis aut molestiae deserunt omnis maxime non qui perferendis iusto in quibusdam fugit autem reprehenderit corporis.", 10.9074648282991090m, null, "In est eligendi.", 10.8148550413618120m, 10, "https://picsum.photos/640/480/?image=770" },
                    { 68, "Nesciunt praesentium rem voluptas assumenda qui porro voluptates quibusdam nobis voluptatem aut fugiat sit fugit occaecati eum ut esse delectus.", 10.7021110894633970m, null, "Ab est cum.", 10.3590631211917210m, 10, "https://picsum.photos/640/480/?image=797" },
                    { 69, "Debitis enim aperiam deserunt culpa amet sed voluptas magni vitae ut dignissimos alias ullam cupiditate id fugit delectus repellendus iste.", 10.700818345277020m, null, "Sint amet ut.", 10.9706492340055520m, 4, "https://picsum.photos/640/480/?image=754" },
                    { 70, "Voluptatem praesentium laudantium est molestiae qui vel quo quidem omnis sunt sunt dolorem et similique voluptatibus iusto atque autem velit.", 10.8337389080942320m, null, "Et quidem quisquam.", 10.6696907135982490m, 1, "https://picsum.photos/640/480/?image=635" },
                    { 71, "Autem dolor rerum ducimus explicabo rerum laudantium rerum nemo nam nemo reiciendis vero dolorum praesentium rerum voluptas voluptatem qui a.", 10.403455617559820m, null, "Minus magni et.", 10.9273080499504260m, 8, "https://picsum.photos/640/480/?image=957" },
                    { 72, "Illo atque ea qui ipsa autem a consequatur distinctio facere ipsam repellat fuga commodi maxime voluptatem ipsam consequuntur quas recusandae.", 10.2089539362159340m, null, "Aut impedit modi.", 10.792949590735580m, 10, "https://picsum.photos/640/480/?image=1030" },
                    { 73, "Cumque aut praesentium itaque nisi iure quisquam velit in rerum vitae ut sit ut laborum et dolores cupiditate accusantium assumenda.", 10.1828498757364460m, null, "Eos laboriosam quia.", 10.5962622629461170m, 2, "https://picsum.photos/640/480/?image=277" },
                    { 74, "Et nulla ut odit est nihil dolorum aliquam aperiam velit illum aut laborum et tenetur nisi ipsam incidunt eos voluptatem.", 10.1787156524037550m, null, "Qui mollitia est.", 10.032667683918340m, 5, "https://picsum.photos/640/480/?image=437" },
                    { 75, "In sint eum inventore fugit maxime laborum nostrum similique eos voluptas ea natus error facilis culpa animi ipsam omnis velit.", 10.64395958727410m, null, "Qui fugiat sunt.", 10.8619070215438990m, 9, "https://picsum.photos/640/480/?image=882" },
                    { 76, "Quod magnam iusto est autem necessitatibus dolores ipsa id sed qui nihil tempora repellat laborum iure atque voluptatum officiis ullam.", 10.3864323163341880m, null, "Ipsum a ad.", 10.7572268139371770m, 6, "https://picsum.photos/640/480/?image=895" },
                    { 77, "Impedit recusandae soluta consequatur rerum sequi totam officiis ipsa magni dolores laudantium rem molestiae occaecati voluptates autem praesentium laborum voluptas.", 10.2478682134523370m, null, "Dolores dolor nihil.", 10.4123074367699710m, 3, "https://picsum.photos/640/480/?image=873" },
                    { 78, "Occaecati ex et harum incidunt velit laudantium nihil aut inventore velit quaerat unde possimus consequuntur sunt aliquam ut aut in.", 10.2370433128611390m, null, "Ut ullam distinctio.", 10.8727692248638580m, 5, "https://picsum.photos/640/480/?image=384" },
                    { 79, "Aut praesentium tempore voluptas expedita qui dolores hic sint iure et et ut consequatur alias voluptate pariatur dolor velit et.", 10.2839245029184620m, null, "Ut aut pariatur.", 10.5703252822022540m, 7, "https://picsum.photos/640/480/?image=240" },
                    { 80, "Repellendus veniam debitis et quis ut ut blanditiis delectus iusto minus perspiciatis tempore ab aut laborum amet possimus dignissimos maxime.", 10.8702946733079360m, null, "Consequatur suscipit eveniet.", 10.3943443784463890m, 9, "https://picsum.photos/640/480/?image=3" },
                    { 81, "Minima est repellendus tempore voluptatem voluptatem est impedit libero rerum a numquam natus sint omnis eaque aut sed harum non.", 10.7633224305525990m, null, "Quae ratione illum.", 10.01354223909487120m, 7, "https://picsum.photos/640/480/?image=680" },
                    { 82, "Quas sint blanditiis magnam iure eos non quasi qui dolor voluptas velit tempora maiores nisi eos ut incidunt perspiciatis aut.", 10.8439526412840710m, null, "Dolore error deserunt.", 10.826712912333530m, 9, "https://picsum.photos/640/480/?image=529" },
                    { 83, "Aut sint illo ullam nihil possimus est sit autem non reprehenderit similique architecto doloremque pariatur qui eos quia impedit voluptate.", 10.6711249075229860m, null, "Molestias velit et.", 10.5430672832499570m, 7, "https://picsum.photos/640/480/?image=927" },
                    { 84, "Voluptas distinctio vitae animi quod aut cupiditate est omnis cum debitis laboriosam et et aut unde molestiae culpa distinctio totam.", 10.9780542044798160m, null, "Quaerat nihil soluta.", 10.8511975178733460m, 1, "https://picsum.photos/640/480/?image=762" },
                    { 85, "Architecto dolores saepe aliquid ipsa quisquam beatae sapiente occaecati impedit laborum est deserunt omnis nemo exercitationem ratione voluptatibus accusamus illo.", 10.7396298887858310m, null, "Est et alias.", 10.9093970506961440m, 2, "https://picsum.photos/640/480/?image=1053" },
                    { 86, "Eum temporibus quidem fugit tenetur earum aut ducimus deserunt distinctio quia quo et in ut veniam quo ipsam non et.", 10.544033584438280m, null, "Quia mollitia ut.", 10.9191903788220090m, 7, "https://picsum.photos/640/480/?image=756" },
                    { 87, "Explicabo suscipit aut adipisci tempora dignissimos corrupti magnam quia aut mollitia distinctio nihil dolorum aut porro harum qui ratione magnam.", 10.3708002191832290m, null, "Doloribus omnis maxime.", 10.48063099034160m, 5, "https://picsum.photos/640/480/?image=951" },
                    { 88, "Ipsam veniam odit omnis consequuntur quia velit aut fugit culpa totam aspernatur reprehenderit consequuntur quia consequatur in et et modi.", 10.818089832932730m, null, "Eum adipisci provident.", 10.4443407796529780m, 9, "https://picsum.photos/640/480/?image=307" },
                    { 89, "Voluptatem quisquam debitis qui vel aperiam voluptates quia delectus et quia rem atque molestias quod maiores dolores dolorem est facere.", 10.1566029308161710m, null, "Illo voluptas non.", 10.1240372821334920m, 1, "https://picsum.photos/640/480/?image=53" },
                    { 90, "Dicta dolores blanditiis illo nihil veniam est recusandae nesciunt labore at et et atque tenetur ea ullam minima est ipsum.", 10.702988169949030m, null, "Ipsa qui ut.", 10.7157305016721280m, 9, "https://picsum.photos/640/480/?image=63" },
                    { 91, "Ea odit porro illum est vitae veritatis dolorem soluta excepturi perferendis esse amet quo sunt qui placeat minima excepturi distinctio.", 10.1710405876725170m, null, "Aut sit sunt.", 10.2710094215679030m, 8, "https://picsum.photos/640/480/?image=752" },
                    { 92, "Aliquam eum nam omnis quia autem adipisci dolore dolorem odio quam dolorem similique alias expedita ad pariatur veniam eos qui.", 10.1416509682972220m, null, "Dolor enim natus.", 10.3329820108287880m, 2, "https://picsum.photos/640/480/?image=767" },
                    { 93, "Illum incidunt nemo aut eaque esse cupiditate consequatur odio perferendis placeat quo ipsa asperiores officia placeat qui voluptas fugit rerum.", 10.6124864987155830m, null, "Velit consequatur tempore.", 10.6583467846076690m, 9, "https://picsum.photos/640/480/?image=91" },
                    { 94, "Tempora aut ut culpa ut aut cumque autem perferendis sint et vel placeat quae consectetur eius quaerat aspernatur ducimus qui.", 10.7434828154479540m, null, "Nihil sint nobis.", 10.589980723611070m, 4, "https://picsum.photos/640/480/?image=1031" },
                    { 95, "Perferendis quia suscipit ea officia quia minus ullam optio quia iusto in aperiam laboriosam et sunt incidunt quo rerum commodi.", 10.4671513966597390m, null, "Possimus ullam nihil.", 10.8983149057712010m, 4, "https://picsum.photos/640/480/?image=1058" },
                    { 96, "Explicabo atque porro nostrum qui ab eum est ipsum soluta nesciunt voluptas quaerat sit placeat quos quae dolorem cumque velit.", 10.9735219599555810m, null, "Pariatur reiciendis explicabo.", 10.4831295485995380m, 2, "https://picsum.photos/640/480/?image=691" },
                    { 97, "Cupiditate unde vel optio molestias laborum accusantium quidem vel reiciendis aut laborum ut est et dignissimos saepe quasi accusamus est.", 10.1498761797090420m, null, "Voluptatem consequatur recusandae.", 10.3474627888516820m, 10, "https://picsum.photos/640/480/?image=178" },
                    { 98, "Laborum quia ipsam omnis accusantium aut fugit vero eos ea maiores et incidunt ut eum recusandae sint neque non aliquid.", 10.8311843373026630m, null, "Vel voluptatem error.", 10.7630700737997280m, 6, "https://picsum.photos/640/480/?image=374" },
                    { 99, "Officia autem sunt totam rerum ex quae esse excepturi et molestiae vero animi ut autem excepturi dicta voluptates esse quidem.", 10.9658666960736120m, null, "Explicabo reprehenderit quia.", 10.4536638727661520m, 3, "https://picsum.photos/640/480/?image=300" },
                    { 100, "Et dolor deserunt eaque praesentium harum necessitatibus non atque error saepe aut exercitationem amet illum accusamus et sunt nemo est.", 10.9707505493288630m, null, "Sit id quibusdam.", 10.1176604615140990m, 4, "https://picsum.photos/640/480/?image=497" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "DateOfBirth", "Email", "FullName", "Gender", "Password", "PhoneNumber", "Role" },
                values: new object[,]
                {
                    { 1, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/753.jpg", new DateTime(2023, 1, 28, 2, 39, 54, 596, DateTimeKind.Local).AddTicks(3506), "ClarkFadel.Stark@gmail.com", "Clark Fadel", "Female", "DZBRHDGI6q", "1-889-737-9865 x33749", "Customer" },
                    { 2, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/76.jpg", new DateTime(2023, 3, 17, 15, 25, 5, 56, DateTimeKind.Local).AddTicks(8202), "BethNicolas17@hotmail.com", "Beth Nicolas", "Female", "7JyPeJbP8k", "1-666-934-7051 x29752", "Customer" },
                    { 3, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/789.jpg", new DateTime(2023, 2, 13, 12, 18, 33, 706, DateTimeKind.Local).AddTicks(7182), "AylaEbert74@hotmail.com", "Ayla Ebert", "Female", "FGtKv09y4J", "(663) 951-5830 x4872", "Customer" },
                    { 4, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/947.jpg", new DateTime(2023, 7, 22, 15, 34, 22, 623, DateTimeKind.Local).AddTicks(1802), "EstevanBogisich.Skiles@yahoo.com", "Estevan Bogisich", "Female", "yNeq0uPIe4", "1-713-316-9030", "Customer" },
                    { 5, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1062.jpg", new DateTime(2023, 1, 25, 6, 15, 19, 367, DateTimeKind.Local).AddTicks(380), "PhilipPollich_Terry@gmail.com", "Philip Pollich", "Male", "GR7yOwso6s", "317.752.1611 x9359", "Customer" },
                    { 6, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/49.jpg", new DateTime(2023, 10, 29, 10, 22, 39, 271, DateTimeKind.Local).AddTicks(9308), "LibbieHeathcote.Bins14@gmail.com", "Libbie Heathcote", "Male", "o4vdUhkpIn", "319.502.8272 x48793", "Customer" },
                    { 7, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1020.jpg", new DateTime(2023, 11, 24, 5, 39, 48, 591, DateTimeKind.Local).AddTicks(4296), "HildaGraham.Balistreri6@hotmail.com", "Hilda Graham", "Male", "1zF6OQAGJL", "597-752-7924 x0122", "Customer" },
                    { 8, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/109.jpg", new DateTime(2023, 6, 1, 11, 45, 26, 595, DateTimeKind.Local).AddTicks(6618), "EulaliaBartell87@gmail.com", "Eulalia Bartell", "Male", "_nP5wBstle", "(315) 869-1332 x0488", "Customer" },
                    { 9, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/88.jpg", new DateTime(2023, 3, 22, 1, 57, 42, 158, DateTimeKind.Local).AddTicks(3749), "PaoloMcCullough.Weimann17@gmail.com", "Paolo McCullough", "Female", "I7RR7JTvse", "541-747-8384", "Customer" },
                    { 10, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1170.jpg", new DateTime(2023, 10, 13, 12, 9, 8, 410, DateTimeKind.Local).AddTicks(8416), "AndreaneBogisich_Hintz@hotmail.com", "Andreane Bogisich", "Male", "SFATDQgzLK", "238-766-1993", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "CategoryItems",
                columns: new[] { "CategoryId", "ItemId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 5, 2 },
                    { 10, 3 },
                    { 9, 4 },
                    { 3, 5 },
                    { 2, 6 },
                    { 3, 7 },
                    { 7, 8 },
                    { 9, 9 },
                    { 7, 10 },
                    { 6, 11 },
                    { 5, 12 },
                    { 1, 13 },
                    { 9, 14 },
                    { 9, 15 },
                    { 9, 16 },
                    { 7, 17 },
                    { 2, 18 },
                    { 6, 19 },
                    { 10, 20 },
                    { 8, 21 },
                    { 7, 22 },
                    { 4, 23 },
                    { 1, 24 },
                    { 7, 25 },
                    { 6, 26 },
                    { 10, 27 },
                    { 2, 28 },
                    { 1, 29 },
                    { 8, 30 },
                    { 10, 31 },
                    { 7, 32 },
                    { 8, 33 },
                    { 4, 34 },
                    { 10, 35 },
                    { 2, 36 },
                    { 8, 37 },
                    { 10, 38 },
                    { 6, 39 },
                    { 4, 40 },
                    { 7, 41 },
                    { 9, 42 },
                    { 10, 43 },
                    { 2, 44 },
                    { 2, 45 },
                    { 4, 46 },
                    { 5, 47 },
                    { 2, 48 },
                    { 5, 49 },
                    { 10, 50 },
                    { 6, 51 },
                    { 4, 52 },
                    { 3, 53 },
                    { 4, 54 },
                    { 3, 55 },
                    { 6, 56 },
                    { 2, 57 },
                    { 10, 58 },
                    { 3, 59 },
                    { 7, 60 },
                    { 2, 61 },
                    { 1, 62 },
                    { 7, 63 },
                    { 2, 64 },
                    { 7, 65 },
                    { 9, 66 },
                    { 7, 67 },
                    { 7, 68 },
                    { 10, 69 },
                    { 7, 70 },
                    { 1, 71 },
                    { 8, 72 },
                    { 7, 73 },
                    { 2, 74 },
                    { 3, 75 },
                    { 10, 76 },
                    { 7, 77 },
                    { 2, 78 },
                    { 10, 79 },
                    { 3, 80 },
                    { 2, 81 },
                    { 9, 82 },
                    { 7, 83 },
                    { 1, 84 },
                    { 3, 85 },
                    { 6, 86 },
                    { 4, 87 },
                    { 5, 88 },
                    { 2, 89 },
                    { 4, 90 },
                    { 1, 91 },
                    { 9, 92 },
                    { 8, 93 },
                    { 9, 94 },
                    { 2, 95 },
                    { 6, 96 },
                    { 3, 97 },
                    { 9, 98 },
                    { 5, 99 },
                    { 3, 100 }
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
                name: "IX_SeatReservation_OrderId",
                table: "SeatReservation",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "CategoryItems");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "SeatReservation");

            migrationBuilder.DropTable(
                name: "Categories");

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
