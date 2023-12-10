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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    FullName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Avatar = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                    Gender = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Role = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EmailConfirmToken = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                    Images = table.Column<string>(type: "longtext", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
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
                name: "SeatReservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeatReservations_Orders_OrderId",
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
                    { 1, "Hic provident voluptate et occaecati aperiam placeat sapiente. Quas aut non quae voluptas ratione voluptas impedit similique ut.", "Autem commodi qui.", "https://picsum.photos/640/480/?image=233" },
                    { 2, "Dolores mollitia distinctio adipisci ad doloribus minus corporis occaecati. Perferendis in et est ut. Iste temporibus ducimus nam omnis. Eligendi quia rerum libero quibusdam magni velit et id eos.", "Qui numquam qui.", "https://picsum.photos/640/480/?image=134" },
                    { 3, "Nobis sint quasi tempora cupiditate velit magni placeat repellendus.", "Ducimus accusantium odio.", "https://picsum.photos/640/480/?image=597" },
                    { 4, "Adipisci eaque dolores et blanditiis nemo est adipisci id odit. Dolorum debitis accusantium voluptatum culpa.", "Sint accusamus voluptas.", "https://picsum.photos/640/480/?image=1042" },
                    { 5, "Provident voluptatum veniam architecto eos aut quo. Voluptas in enim consectetur. Velit non sed harum praesentium. Voluptatem totam quia.", "Dolorem temporibus odit.", "https://picsum.photos/640/480/?image=986" },
                    { 6, "Aut nihil illo voluptatem sit id. Voluptatem dolorum vel ipsum qui ex reprehenderit.", "Temporibus aliquam est.", "https://picsum.photos/640/480/?image=263" },
                    { 7, "Illo quis provident. Doloremque laborum quia velit incidunt. Qui esse similique blanditiis sed dolorum.", "Debitis enim nobis.", "https://picsum.photos/640/480/?image=843" },
                    { 8, "Repudiandae aliquam nostrum ut sapiente architecto nisi. Deleniti similique illo magnam quia. Quia est nostrum voluptate deleniti sunt temporibus magni. Possimus nesciunt ut consectetur sequi provident voluptatem.", "Doloribus quia facere.", "https://picsum.photos/640/480/?image=378" },
                    { 9, "Eaque nobis est ab quasi. Perferendis aliquam ea voluptatem magni similique ducimus dolorum cumque.", "Sint sequi unde.", "https://picsum.photos/640/480/?image=555" },
                    { 10, "Provident amet veritatis rerum amet fugiat nesciunt illo. Explicabo omnis quia saepe. Id omnis et voluptatem et fugit ullam qui. Assumenda fuga impedit voluptates dolorum maxime facilis suscipit fugiat.", "Ad illum porro.", "https://picsum.photos/640/480/?image=832" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Description", "Discount", "Images", "Name", "Price", "Stock", "Thumbnail" },
                values: new object[,]
                {
                    { 1, null, "Neque aut aperiam at sed modi modi ex reprehenderit omnis recusandae explicabo consequatur voluptas quibusdam autem libero qui eos ut.", 10.2625183897384060m, null, "Quas dolores qui.", 10.2963503856660570m, 5, "https://picsum.photos/640/480/?image=630" },
                    { 2, null, "Possimus rerum et ipsam amet aut dolor ut qui necessitatibus quaerat aspernatur quia et velit incidunt sequi aut non id.", 10.5412858498940640m, null, "Sed enim dolores.", 10.7996915331108920m, 1, "https://picsum.photos/640/480/?image=1004" },
                    { 3, null, "Quis ut in odit voluptatem necessitatibus qui laudantium velit necessitatibus labore maxime voluptatibus eum in et et voluptate exercitationem delectus.", 10.8842109040749310m, null, "Sit commodi voluptatem.", 10.7302641648474450m, 1, "https://picsum.photos/640/480/?image=5" },
                    { 4, null, "Eligendi eius et dolores magni qui sapiente necessitatibus consequatur maxime dolor earum non dignissimos voluptatem alias nisi sint tempora unde.", 10.2241724879593460m, null, "Hic consequatur sunt.", 10.9056787346050510m, 9, "https://picsum.photos/640/480/?image=354" },
                    { 5, null, "Quam ea accusamus architecto nesciunt enim voluptatem aperiam dolore quas reprehenderit odit molestiae voluptatem earum non voluptates consequuntur totam dicta.", 10.5782992362875020m, null, "Mollitia necessitatibus in.", 10.5199016712232970m, 9, "https://picsum.photos/640/480/?image=143" },
                    { 6, null, "Libero rem voluptas est ut et quam ut corrupti dolores tempore fuga et necessitatibus velit et et hic consequatur corporis.", 10.9647345128304950m, null, "Velit quisquam praesentium.", 10.5237351872603110m, 1, "https://picsum.photos/640/480/?image=745" },
                    { 7, null, "Aut voluptas occaecati sit distinctio iusto at et error sint qui quos et quas deleniti qui quo labore quas quo.", 10.1093169958839740m, null, "Consequatur magni et.", 10.1964963391406910m, 7, "https://picsum.photos/640/480/?image=1062" },
                    { 8, null, "Itaque cumque blanditiis aliquid assumenda assumenda odio ut cumque ut enim aut amet omnis labore nulla maiores est praesentium earum.", 10.04209549307920760m, null, "Id animi quam.", 10.7963249775563950m, 6, "https://picsum.photos/640/480/?image=415" },
                    { 9, null, "Id est dolorem eos ducimus veritatis perferendis sint hic odit similique sapiente quisquam nihil delectus dolor atque in incidunt ipsam.", 10.9568571205981340m, null, "Quod quas nostrum.", 10.06344848129127570m, 3, "https://picsum.photos/640/480/?image=328" },
                    { 10, null, "Fuga saepe consectetur voluptatem est voluptatem deleniti quo voluptas provident eum et hic quia eos nostrum quod quam consequatur id.", 10.8291591614620570m, null, "Laborum minima expedita.", 10.5186430129775050m, 3, "https://picsum.photos/640/480/?image=745" },
                    { 11, null, "Tempora est molestias deleniti cupiditate ipsum ea reprehenderit voluptatem possimus tenetur a optio labore officia velit dolore et provident veniam.", 10.2035620613971550m, null, "Ut molestias consectetur.", 10.1409733831607610m, 7, "https://picsum.photos/640/480/?image=29" },
                    { 12, null, "Eos autem harum neque magnam aspernatur architecto aliquam amet quaerat ab corporis optio perspiciatis repellendus quo provident repellendus praesentium fugit.", 10.9305860870194560m, null, "Ut et ut.", 10.4976657640643720m, 7, "https://picsum.photos/640/480/?image=567" },
                    { 13, null, "Ab voluptatem voluptatibus maiores non est et voluptatem mollitia iure deserunt nihil vero fuga maiores in earum velit ut quo.", 10.3572064481476350m, null, "Quis quis tempora.", 10.7361000388563140m, 4, "https://picsum.photos/640/480/?image=12" },
                    { 14, null, "Ipsa non dolorem dolorum autem aut officiis accusantium incidunt quia enim voluptas culpa et veniam amet qui itaque beatae id.", 10.5130112019893770m, null, "Quod consequatur est.", 10.4902248785319850m, 6, "https://picsum.photos/640/480/?image=143" },
                    { 15, null, "Quos eligendi expedita pariatur dolore ea eaque officia illo molestiae voluptas et dolorem maiores animi facere consectetur tempore ex assumenda.", 10.4521177147757810m, null, "Vel voluptatem provident.", 10.7715774889903040m, 2, "https://picsum.photos/640/480/?image=744" },
                    { 16, null, "Velit non cum deleniti consequatur assumenda ut vel suscipit in ea voluptatem iusto perspiciatis deleniti incidunt omnis nobis eos magnam.", 10.8917455817068670m, null, "Adipisci distinctio sed.", 10.61712907562830m, 8, "https://picsum.photos/640/480/?image=992" },
                    { 17, null, "Omnis eaque cupiditate quod expedita qui velit voluptas inventore autem hic a aperiam deleniti id voluptatem dolor fugiat est et.", 10.2934667613792540m, null, "Perferendis blanditiis aliquam.", 10.2260272005694110m, 3, "https://picsum.photos/640/480/?image=367" },
                    { 18, null, "Officia corporis assumenda laboriosam totam aliquid sint officia laboriosam consequatur fugiat cumque iusto ut cumque quam vero consequatur qui aut.", 10.01217651647151290m, null, "Incidunt inventore velit.", 10.772347067376760m, 7, "https://picsum.photos/640/480/?image=443" },
                    { 19, null, "Doloremque totam illum fugit excepturi animi quia laborum sed nostrum aperiam atque est occaecati necessitatibus voluptatem blanditiis nisi dolores non.", 10.5239242629725130m, null, "Quas commodi sed.", 10.6876236846147220m, 9, "https://picsum.photos/640/480/?image=633" },
                    { 20, null, "Rerum in cum sit quo aut vel corrupti quia cupiditate optio voluptatem aut voluptatem dolorum dolorem magni qui voluptas sed.", 10.8813037503889310m, null, "Mollitia quas tenetur.", 10.5830614453102750m, 8, "https://picsum.photos/640/480/?image=395" },
                    { 21, null, "Pariatur quas deserunt blanditiis sint aut facilis sed eaque vero odit velit vel autem aperiam assumenda quod possimus accusantium doloremque.", 10.06547855030069060m, null, "Labore quis voluptatem.", 10.9501842874801640m, 4, "https://picsum.photos/640/480/?image=187" },
                    { 22, null, "Quis possimus dolorem quas rerum laudantium tenetur delectus voluptatibus non quasi dolor nemo praesentium est qui enim voluptatem dolorum hic.", 10.5492717509853060m, null, "Perspiciatis ut eum.", 10.325572630076470m, 2, "https://picsum.photos/640/480/?image=808" },
                    { 23, null, "Velit dolor ratione nulla voluptates dolore et ad omnis non aliquid neque minus molestiae dolorem ab et tempore in porro.", 10.2236160059569480m, null, "Esse numquam laboriosam.", 10.5723281044384130m, 5, "https://picsum.photos/640/480/?image=7" },
                    { 24, null, "Inventore qui facilis qui sunt qui consequuntur facere sit fugiat soluta nesciunt recusandae soluta sit hic autem a eos rerum.", 10.4987478989636280m, null, "Est et voluptatem.", 10.5240934512224480m, 5, "https://picsum.photos/640/480/?image=52" },
                    { 25, null, "Assumenda reiciendis corporis aspernatur quia doloribus non sunt qui magni reprehenderit quaerat et est tempore rerum eius natus sint facilis.", 10.3883683166412490m, null, "Suscipit quo dolores.", 10.03705571453881250m, 3, "https://picsum.photos/640/480/?image=942" },
                    { 26, null, "Autem natus quia omnis atque aliquam incidunt ex omnis aut id iste dolorem alias aut minus illum maiores optio molestiae.", 10.8501755552600020m, null, "Sunt et aperiam.", 10.2783502318329880m, 9, "https://picsum.photos/640/480/?image=114" },
                    { 27, null, "Praesentium vel cumque adipisci aut quaerat tenetur dolores aut consequuntur ex et consequatur velit magnam eveniet omnis deleniti consequatur ut.", 10.9276658724656640m, null, "Nemo illum consectetur.", 10.6417086662918840m, 7, "https://picsum.photos/640/480/?image=303" },
                    { 28, null, "Possimus rerum cumque quae rem libero veritatis est reiciendis architecto nobis qui exercitationem numquam accusamus aspernatur id praesentium vitae eligendi.", 10.02674661531427250m, null, "Sed reprehenderit iusto.", 10.2271170817441850m, 10, "https://picsum.photos/640/480/?image=498" },
                    { 29, null, "Unde provident quisquam et architecto et dolorem velit consectetur enim vitae aut labore earum molestiae ad dolorem architecto facere impedit.", 10.7716372403184120m, null, "Quibusdam corporis rem.", 10.132797752568870m, 9, "https://picsum.photos/640/480/?image=105" },
                    { 30, null, "Non qui asperiores id dolore ipsum adipisci sint labore aliquam fugiat est aut rem perferendis soluta temporibus occaecati culpa voluptas.", 10.7986734266386710m, null, "Repellat eaque cumque.", 10.7497750365872750m, 8, "https://picsum.photos/640/480/?image=57" },
                    { 31, null, "Laboriosam omnis cumque libero et aperiam repudiandae et totam adipisci nihil quo quo ipsa molestiae consectetur sit asperiores laudantium facilis.", 10.1175255370873610m, null, "Voluptatem ipsa deserunt.", 10.2361786836926730m, 1, "https://picsum.photos/640/480/?image=137" },
                    { 32, null, "Hic velit reiciendis et culpa sed in at id sed qui officia sunt velit vero perspiciatis atque vitae nobis et.", 10.3221771779107760m, null, "Provident quam velit.", 10.7998278447426050m, 7, "https://picsum.photos/640/480/?image=46" },
                    { 33, null, "Ex modi est distinctio eos dolorem quo sapiente sed quos sit quia harum eos amet eligendi et et ea necessitatibus.", 10.3790180587112060m, null, "Dolores natus in.", 10.4457808325280350m, 6, "https://picsum.photos/640/480/?image=797" },
                    { 34, null, "Qui et et et minus voluptatem et eius harum ab debitis ducimus voluptas minus ut et illo sequi sapiente ab.", 10.6115497143992920m, null, "A pariatur omnis.", 10.7293328008285410m, 7, "https://picsum.photos/640/480/?image=657" },
                    { 35, null, "Tenetur reiciendis est vitae cumque nostrum enim dignissimos suscipit ea magnam mollitia aut eum sint iste rerum omnis maiores quidem.", 10.2123176568245130m, null, "Corporis minus tempore.", 10.153865368177120m, 8, "https://picsum.photos/640/480/?image=1037" },
                    { 36, null, "Dolorem repellendus repellat nulla itaque alias aliquid nulla et voluptatibus ut quia nesciunt dolores nostrum eveniet dolore et iste eos.", 10.8122466238272590m, null, "Qui repellat quibusdam.", 10.2205955820254030m, 1, "https://picsum.photos/640/480/?image=562" },
                    { 37, null, "Sint maxime magnam magni et nihil dolores ducimus expedita suscipit natus enim mollitia facere maiores cum sunt tempore animi dolorem.", 10.8613360998506360m, null, "Dolor voluptatem explicabo.", 10.1441102019250910m, 4, "https://picsum.photos/640/480/?image=1074" },
                    { 38, null, "In aut qui consequatur nam dolorum voluptates fugiat aut doloribus pariatur laboriosam rem nam quae quidem error est corrupti sapiente.", 10.2361827233043420m, null, "Porro saepe eos.", 10.108236453080660m, 2, "https://picsum.photos/640/480/?image=518" },
                    { 39, null, "Hic expedita et est esse id error sint iusto molestiae sit saepe est est et aut nobis quisquam sit magni.", 10.09695433922901490m, null, "Voluptatem in quos.", 10.1631260836325240m, 3, "https://picsum.photos/640/480/?image=524" },
                    { 40, null, "Doloremque laboriosam officiis dolore est dicta magni a quia tempore numquam iusto animi et maxime laborum impedit incidunt quibusdam quibusdam.", 10.1879016962777370m, null, "Temporibus incidunt non.", 10.2728776951659830m, 4, "https://picsum.photos/640/480/?image=814" },
                    { 41, null, "Voluptas at et soluta maiores sit aut sed culpa natus soluta rerum aut natus qui maxime quia totam veniam qui.", 10.4188375945290730m, null, "Omnis maiores ducimus.", 10.2248756094951530m, 5, "https://picsum.photos/640/480/?image=489" },
                    { 42, null, "Distinctio voluptas voluptatibus nihil atque cumque rerum aut odit maxime asperiores incidunt magnam quibusdam consequatur neque ab accusantium deserunt doloribus.", 10.5436557617707440m, null, "Sint doloribus et.", 10.2384263864897310m, 5, "https://picsum.photos/640/480/?image=561" },
                    { 43, null, "Modi voluptates consequatur repudiandae neque asperiores facere ratione eligendi mollitia dolores velit itaque dolorem possimus dolorum alias non labore aperiam.", 10.8556824600583330m, null, "Voluptatibus voluptatum aliquam.", 10.9340387042304680m, 3, "https://picsum.photos/640/480/?image=161" },
                    { 44, null, "Adipisci fugit in fugiat odio consequatur ducimus esse saepe quod eum fugiat labore et est tempore similique repudiandae eum et.", 10.4822876003954040m, null, "Quos molestiae alias.", 10.82436314915510m, 10, "https://picsum.photos/640/480/?image=470" },
                    { 45, null, "Quia consequatur et recusandae quam ut asperiores natus doloremque exercitationem omnis eligendi consectetur quos placeat eos aut ipsum vel alias.", 10.283886613456480m, null, "Itaque maxime dignissimos.", 10.5336411034379350m, 2, "https://picsum.photos/640/480/?image=478" },
                    { 46, null, "Dolor impedit adipisci a eveniet optio error consequuntur ab labore aut voluptate animi et itaque dolorum vel aut modi rerum.", 10.07597833037189130m, null, "Sint nam ad.", 10.1596197956984960m, 7, "https://picsum.photos/640/480/?image=746" },
                    { 47, null, "Voluptates eaque amet delectus esse possimus sapiente illum pariatur quo suscipit et repellat fuga consequatur optio dolorum architecto omnis omnis.", 10.5954902589300140m, null, "Enim natus maxime.", 10.7555677032822590m, 7, "https://picsum.photos/640/480/?image=43" },
                    { 48, null, "Fugit aut sunt sequi est laboriosam tenetur et dicta et ad reprehenderit et rerum molestiae dicta dolor ipsa earum modi.", 10.7919964435473070m, null, "Aut exercitationem accusantium.", 10.01299157087364770m, 4, "https://picsum.photos/640/480/?image=870" },
                    { 49, null, "Doloribus ipsam quis eum vitae sed minus nulla quo omnis nobis est cupiditate quae aut minima fugiat ut nobis aut.", 10.3263529498718460m, null, "Delectus molestias dolor.", 10.1397751793916220m, 6, "https://picsum.photos/640/480/?image=1084" },
                    { 50, null, "Aut quia quisquam sunt amet sit natus delectus laboriosam porro deleniti consectetur enim sint autem quo voluptas explicabo qui esse.", 10.04027663592262040m, null, "Omnis earum architecto.", 10.1792029795140040m, 6, "https://picsum.photos/640/480/?image=959" },
                    { 51, null, "Rerum distinctio consequatur corrupti fuga qui quae quisquam cupiditate asperiores libero dolores totam delectus beatae harum error aliquid sequi velit.", 10.3470614828854150m, null, "Et veniam qui.", 10.1934269728108430m, 7, "https://picsum.photos/640/480/?image=592" },
                    { 52, null, "Saepe ut consequatur dolor iusto et repellendus sint corporis provident tempora vero quae tempora adipisci enim quisquam expedita animi non.", 10.09918526192157770m, null, "Temporibus commodi cupiditate.", 10.4508439374393060m, 5, "https://picsum.photos/640/480/?image=195" },
                    { 53, null, "Sed exercitationem ab et cumque quaerat et voluptatem facere quo vel ut deserunt nobis quae omnis aut laboriosam quos odit.", 10.9992359527383170m, null, "Adipisci dolores accusamus.", 10.1845749920162260m, 1, "https://picsum.photos/640/480/?image=1027" },
                    { 54, null, "Architecto autem error et voluptatibus itaque aperiam culpa fuga magnam et cupiditate animi molestiae architecto dignissimos iste et nihil consequatur.", 10.4033411249533950m, null, "Cupiditate consectetur iusto.", 10.2453226457561010m, 4, "https://picsum.photos/640/480/?image=964" },
                    { 55, null, "Est sed numquam neque aut excepturi qui perspiciatis ex amet pariatur fugiat exercitationem natus aut nihil non velit vel saepe.", 10.1097446620044040m, null, "Est cumque iure.", 10.6788819202589250m, 6, "https://picsum.photos/640/480/?image=328" },
                    { 56, null, "Consectetur libero rem voluptatem aliquam minima omnis ut autem voluptate sunt et perferendis omnis rerum porro aliquam impedit architecto magni.", 10.1422118177368360m, null, "Voluptatibus aspernatur sit.", 10.4473151529428150m, 10, "https://picsum.photos/640/480/?image=566" },
                    { 57, null, "Impedit in est eligendi dolor alias voluptas et officiis aut molestiae deserunt omnis maxime non qui perferendis iusto in quibusdam.", 10.7941882250803470m, null, "Aut autem consequatur.", 10.1137928213522740m, 4, "https://picsum.photos/640/480/?image=862" },
                    { 58, null, "Id ab est cum nesciunt praesentium rem voluptas assumenda qui porro voluptates quibusdam nobis voluptatem aut fugiat sit fugit occaecati.", 10.2350595738902030m, null, "Vel et ut.", 10.3854172478362070m, 5, "https://picsum.photos/640/480/?image=327" },
                    { 59, null, "Optio sint amet ut debitis enim aperiam deserunt culpa amet sed voluptas magni vitae ut dignissimos alias ullam cupiditate id.", 10.964003807382660m, null, "Ea cumque repellat.", 10.113875129313150m, 8, "https://picsum.photos/640/480/?image=1049" },
                    { 60, null, "Qui et quidem quisquam voluptatem praesentium laudantium est molestiae qui vel quo quidem omnis sunt sunt dolorem et similique voluptatibus.", 10.4827937085567010m, null, "Ut cumque iure.", 10.4372206611732120m, 8, "https://picsum.photos/640/480/?image=604" },
                    { 61, null, "Aut minus magni et autem dolor rerum ducimus explicabo rerum laudantium rerum nemo nam nemo reiciendis vero dolorum praesentium rerum.", 10.02253259300372220m, null, "Libero fugiat aspernatur.", 10.8417166182034260m, 4, "https://picsum.photos/640/480/?image=448" },
                    { 62, null, "Hic aut impedit modi illo atque ea qui ipsa autem a consequatur distinctio facere ipsam repellat fuga commodi maxime voluptatem.", 10.128223581299290m, null, "Molestiae ea porro.", 10.315551537235990m, 6, "https://picsum.photos/640/480/?image=1040" },
                    { 63, null, "Aliquam eos laboriosam quia cumque aut praesentium itaque nisi iure quisquam velit in rerum vitae ut sit ut laborum et.", 10.5256288393985610m, null, "Autem non rerum.", 10.1337730722193480m, 1, "https://picsum.photos/640/480/?image=1013" },
                    { 64, null, "Ea qui mollitia est et nulla ut odit est nihil dolorum aliquam aperiam velit illum aut laborum et tenetur nisi.", 10.2319496312327450m, null, "Mollitia sit qui.", 10.3165358092247210m, 9, "https://picsum.photos/640/480/?image=832" },
                    { 65, null, "Vel qui fugiat sunt in sint eum inventore fugit maxime laborum nostrum similique eos voluptas ea natus error facilis culpa.", 10.3164532651735720m, null, "Aperiam dolor voluptate.", 10.6021839858042930m, 6, "https://picsum.photos/640/480/?image=348" },
                    { 66, null, "Dolorem ipsum a ad quod magnam iusto est autem necessitatibus dolores ipsa id sed qui nihil tempora repellat laborum iure.", 10.4766084325856570m, null, "Eos facilis quo.", 10.4839656918700620m, 9, "https://picsum.photos/640/480/?image=447" },
                    { 67, null, "Aut dolores dolor nihil impedit recusandae soluta consequatur rerum sequi totam officiis ipsa magni dolores laudantium rem molestiae occaecati voluptates.", 10.4588748796185830m, null, "Possimus iure mollitia.", 10.3765562299529820m, 7, "https://picsum.photos/640/480/?image=325" },
                    { 68, null, "Ex ut ullam distinctio occaecati ex et harum incidunt velit laudantium nihil aut inventore velit quaerat unde possimus consequuntur sunt.", 10.3488673327252580m, null, "Velit dolore quaerat.", 10.255452916145070m, 1, "https://picsum.photos/640/480/?image=354" },
                    { 69, null, "Modi ut aut pariatur aut praesentium tempore voluptas expedita qui dolores hic sint iure et et ut consequatur alias voluptate.", 10.177217262413920m, null, "Officiis labore voluptatum.", 10.8510268143615810m, 3, "https://picsum.photos/640/480/?image=434" },
                    { 70, null, "Alias consequatur suscipit eveniet repellendus veniam debitis et quis ut ut blanditiis delectus iusto minus perspiciatis tempore ab aut laborum.", 10.7566518964044060m, null, "Sunt veniam tempore.", 10.1863352820213580m, 5, "https://picsum.photos/640/480/?image=71" },
                    { 71, null, "Et quae ratione illum minima est repellendus tempore voluptatem voluptatem est impedit libero rerum a numquam natus sint omnis eaque.", 10.1191966506276260m, null, "Qui accusamus eum.", 10.9728669999040980m, 7, "https://picsum.photos/640/480/?image=808" },
                    { 72, null, "Corrupti dolore error deserunt quas sint blanditiis magnam iure eos non quasi qui dolor voluptas velit tempora maiores nisi eos.", 10.2299060785350880m, null, "Perferendis voluptas tempore.", 10.970132082221160m, 6, "https://picsum.photos/640/480/?image=573" },
                    { 73, null, "At molestias velit et aut sint illo ullam nihil possimus est sit autem non reprehenderit similique architecto doloremque pariatur qui.", 10.2080831104927150m, null, "Dolorem nulla fugiat.", 10.8610583063499340m, 8, "https://picsum.photos/640/480/?image=957" },
                    { 74, null, "Cumque quaerat nihil soluta voluptas distinctio vitae animi quod aut cupiditate est omnis cum debitis laboriosam et et aut unde.", 10.579013284099760m, null, "Perspiciatis tempore fuga.", 10.926886341966170m, 7, "https://picsum.photos/640/480/?image=443" },
                    { 75, null, "Ut est et alias architecto dolores saepe aliquid ipsa quisquam beatae sapiente occaecati impedit laborum est deserunt omnis nemo exercitationem.", 10.9829677720474860m, null, "Pariatur reiciendis voluptatem.", 10.1459347629667890m, 9, "https://picsum.photos/640/480/?image=509" },
                    { 76, null, "Optio quia mollitia ut eum temporibus quidem fugit tenetur earum aut ducimus deserunt distinctio quia quo et in ut veniam.", 10.3139813948953440m, null, "Voluptates quod quia.", 10.8391761173676590m, 10, "https://picsum.photos/640/480/?image=59" },
                    { 77, null, "Debitis doloribus omnis maxime explicabo suscipit aut adipisci tempora dignissimos corrupti magnam quia aut mollitia distinctio nihil dolorum aut porro.", 10.8212262163037560m, null, "Sint perspiciatis nobis.", 10.6337013038032230m, 2, "https://picsum.photos/640/480/?image=71" },
                    { 78, null, "Veniam eum adipisci provident ipsam veniam odit omnis consequuntur quia velit aut fugit culpa totam aspernatur reprehenderit consequuntur quia consequatur.", 10.2426582617883840m, null, "Deleniti quis blanditiis.", 10.3993027226064830m, 7, "https://picsum.photos/640/480/?image=273" },
                    { 79, null, "Ab illo voluptas non voluptatem quisquam debitis qui vel aperiam voluptates quia delectus et quia rem atque molestias quod maiores.", 10.1676369962131780m, null, "Dignissimos illum eum.", 10.1345337923311320m, 8, "https://picsum.photos/640/480/?image=242" },
                    { 80, null, "Inventore ipsa qui ut dicta dolores blanditiis illo nihil veniam est recusandae nesciunt labore at et et atque tenetur ea.", 10.2780036573661510m, null, "Quia sequi consequatur.", 10.2976047537744070m, 8, "https://picsum.photos/640/480/?image=816" },
                    { 81, null, "Eligendi aut sit sunt ea odit porro illum est vitae veritatis dolorem soluta excepturi perferendis esse amet quo sunt qui.", 10.2808535696383810m, null, "Porro nihil fugiat.", 10.7474854177550810m, 6, "https://picsum.photos/640/480/?image=183" },
                    { 82, null, "Impedit dolor enim natus aliquam eum nam omnis quia autem adipisci dolore dolorem odio quam dolorem similique alias expedita ad.", 10.2848370737791230m, null, "Enim ipsum quibusdam.", 10.8479602108001520m, 9, "https://picsum.photos/640/480/?image=715" },
                    { 83, null, "Dicta velit consequatur tempore illum incidunt nemo aut eaque esse cupiditate consequatur odio perferendis placeat quo ipsa asperiores officia placeat.", 10.327725228074810m, null, "Sit qui sed.", 10.1433788375665340m, 2, "https://picsum.photos/640/480/?image=632" },
                    { 84, null, "Hic nihil sint nobis tempora aut ut culpa ut aut cumque autem perferendis sint et vel placeat quae consectetur eius.", 10.09983164821743580m, null, "Expedita laborum eveniet.", 10.2594854227544210m, 5, "https://picsum.photos/640/480/?image=1024" },
                    { 85, null, "Aut possimus ullam nihil perferendis quia suscipit ea officia quia minus ullam optio quia iusto in aperiam laboriosam et sunt.", 10.7128968009319610m, null, "Officia maxime qui.", 10.2294630488517990m, 10, "https://picsum.photos/640/480/?image=892" },
                    { 86, null, "Quidem pariatur reiciendis explicabo explicabo atque porro nostrum qui ab eum est ipsum soluta nesciunt voluptas quaerat sit placeat quos.", 10.8239505439176920m, null, "Eveniet totam reprehenderit.", 10.0470165815423320m, 8, "https://picsum.photos/640/480/?image=395" },
                    { 87, null, "Dolorem voluptatem consequatur recusandae cupiditate unde vel optio molestias laborum accusantium quidem vel reiciendis aut laborum ut est et dignissimos.", 10.06979585255952360m, null, "Atque aut ipsum.", 10.8926951242111140m, 9, "https://picsum.photos/640/480/?image=448" },
                    { 88, null, "Ut vel voluptatem error laborum quia ipsam omnis accusantium aut fugit vero eos ea maiores et incidunt ut eum recusandae.", 10.1637916761281860m, null, "Ut voluptatem aut.", 10.5148289038403090m, 3, "https://picsum.photos/640/480/?image=745" },
                    { 89, null, "Ad explicabo reprehenderit quia officia autem sunt totam rerum ex quae esse excepturi et molestiae vero animi ut autem excepturi.", 10.9084927658124330m, null, "Voluptas eum non.", 10.08601284729596820m, 5, "https://picsum.photos/640/480/?image=381" },
                    { 90, null, "Praesentium sit id quibusdam et dolor deserunt eaque praesentium harum necessitatibus non atque error saepe aut exercitationem amet illum accusamus.", 10.08893009651868140m, null, "Qui delectus numquam.", 10.4336202803224420m, 4, "https://picsum.photos/640/480/?image=691" },
                    { 91, null, "Dignissimos consequatur cum possimus libero dolorum nesciunt fugit quis minima natus dolore harum et laudantium delectus modi quo nihil enim.", 10.1944147423815050m, null, "Sed ut voluptatem.", 10.9462282508361280m, 9, "https://picsum.photos/640/480/?image=661" },
                    { 92, null, "Dolor consequatur officiis asperiores soluta eum praesentium voluptatem libero dolor debitis eius voluptates quia qui id qui id itaque sit.", 10.969801669926290m, null, "Qui quidem aspernatur.", 10.9484977763837660m, 2, "https://picsum.photos/640/480/?image=133" },
                    { 93, null, "Quis dolore natus iste corporis aperiam cupiditate vel maxime velit quis debitis esse quia assumenda quibusdam amet ut dolores quibusdam.", 10.4961576869227730m, null, "Eveniet velit distinctio.", 10.9869944909526940m, 6, "https://picsum.photos/640/480/?image=91" },
                    { 94, null, "Voluptatem vel dolore temporibus aspernatur ut ipsum sunt ut odit tempora sunt sit eum rerum nihil adipisci provident vero cupiditate.", 10.1799076777789310m, null, "Iure excepturi qui.", 10.01135355327807070m, 2, "https://picsum.photos/640/480/?image=1072" },
                    { 95, null, "Tempore debitis distinctio sunt dolorem autem qui autem error et dolorum consectetur est dolore vitae et est sapiente est enim.", 10.04164590967895740m, null, "Id in et.", 10.4111543388157870m, 8, "https://picsum.photos/640/480/?image=1013" },
                    { 96, null, "Odio ut quidem ipsam ab optio et dolores non et sed inventore omnis animi aut vel quia sunt laboriosam magnam.", 10.9270845907400760m, null, "Blanditiis non doloribus.", 10.2756533200273540m, 4, "https://picsum.photos/640/480/?image=426" },
                    { 97, null, "Quia harum dicta ut fugit rerum aut qui ea molestiae sit similique dolores a facere officiis fuga voluptatem ut asperiores.", 10.3999534367583480m, null, "Aut delectus sunt.", 10.7107035898187680m, 7, "https://picsum.photos/640/480/?image=528" },
                    { 98, null, "Quo excepturi expedita voluptatem laboriosam dicta id dignissimos eos consequuntur reiciendis quam esse aut blanditiis est qui voluptatem consequatur nulla.", 10.5232886097036720m, null, "Qui fugit ad.", 10.2923071204183190m, 1, "https://picsum.photos/640/480/?image=636" },
                    { 99, null, "Vel aut ut dolores ducimus repellat commodi sunt harum placeat omnis nulla deleniti necessitatibus excepturi necessitatibus maxime facilis qui corrupti.", 10.2540876820004020m, null, "Suscipit quasi ut.", 10.02099296451592490m, 8, "https://picsum.photos/640/480/?image=750" },
                    { 100, null, "Maiores consectetur praesentium sapiente vel enim sed tempora rerum saepe et non nihil ab aut dolorem vero cum dolor cupiditate.", 10.780064592966840m, null, "Error vel enim.", 10.9556769486310320m, 7, "https://picsum.photos/640/480/?image=226" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "DateOfBirth", "Email", "EmailConfirmToken", "EmailConfirmed", "FullName", "Gender", "Password", "PhoneNumber", "Role" },
                values: new object[,]
                {
                    { 1, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/753.jpg", new DateTime(2023, 1, 31, 11, 12, 16, 481, DateTimeKind.Local).AddTicks(4398), "ClarkFadel.Stark@gmail.com", null, false, "Clark Fadel", "Female", "DZBRHDGI6q", "1-889-737-9865 x33749", "Customer" },
                    { 2, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/76.jpg", new DateTime(2023, 3, 20, 23, 57, 26, 941, DateTimeKind.Local).AddTicks(8328), "BethNicolas17@hotmail.com", null, false, "Beth Nicolas", "Female", "7JyPeJbP8k", "1-666-934-7051 x29752", "Customer" },
                    { 3, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/789.jpg", new DateTime(2023, 2, 16, 20, 50, 55, 591, DateTimeKind.Local).AddTicks(7213), "AylaEbert74@hotmail.com", null, false, "Ayla Ebert", "Female", "FGtKv09y4J", "(663) 951-5830 x4872", "Customer" },
                    { 4, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/947.jpg", new DateTime(2023, 7, 26, 0, 6, 44, 508, DateTimeKind.Local).AddTicks(1782), "EstevanBogisich.Skiles@yahoo.com", null, false, "Estevan Bogisich", "Female", "yNeq0uPIe4", "1-713-316-9030", "Customer" },
                    { 5, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1062.jpg", new DateTime(2023, 1, 28, 14, 47, 41, 252, DateTimeKind.Local).AddTicks(134), "PhilipPollich_Terry@gmail.com", null, false, "Philip Pollich", "Male", "GR7yOwso6s", "317.752.1611 x9359", "Customer" },
                    { 6, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/49.jpg", new DateTime(2023, 11, 1, 18, 55, 1, 156, DateTimeKind.Local).AddTicks(8956), "LibbieHeathcote.Bins14@gmail.com", null, false, "Libbie Heathcote", "Male", "o4vdUhkpIn", "319.502.8272 x48793", "Customer" },
                    { 7, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1020.jpg", new DateTime(2023, 11, 27, 14, 12, 10, 476, DateTimeKind.Local).AddTicks(3894), "HildaGraham.Balistreri6@hotmail.com", null, false, "Hilda Graham", "Male", "1zF6OQAGJL", "597-752-7924 x0122", "Customer" },
                    { 8, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/109.jpg", new DateTime(2023, 6, 4, 20, 17, 48, 480, DateTimeKind.Local).AddTicks(6117), "EulaliaBartell87@gmail.com", null, false, "Eulalia Bartell", "Male", "_nP5wBstle", "(315) 869-1332 x0488", "Customer" },
                    { 9, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/88.jpg", new DateTime(2023, 3, 25, 10, 30, 4, 43, DateTimeKind.Local).AddTicks(3183), "PaoloMcCullough.Weimann17@gmail.com", null, false, "Paolo McCullough", "Female", "I7RR7JTvse", "541-747-8384", "Customer" },
                    { 10, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1170.jpg", new DateTime(2023, 10, 16, 20, 41, 30, 295, DateTimeKind.Local).AddTicks(7756), "AndreaneBogisich_Hintz@hotmail.com", null, false, "Andreane Bogisich", "Male", "SFATDQgzLK", "238-766-1993", "Customer" }
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
                name: "IX_Items_CategoryId",
                table: "Items",
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
                name: "IX_SeatReservations_OrderId",
                table: "SeatReservations",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "SeatReservations");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
