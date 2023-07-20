using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable


namespace E_Commerce.CatalogService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "catalog");

            migrationBuilder.CreateTable(
                name: "Catalog_Brand",
                schema: "catalog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalog_Type",
                schema: "catalog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogItemVariant",
                schema: "catalog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VariantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VariantDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItemVariant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalog_Item",
                schema: "catalog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CatalogBrandId = table.Column<long>(type: "bigint", nullable: false),
                    CatalogTypeId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalog_Item_Catalog_Brand_CatalogBrandId",
                        column: x => x.CatalogBrandId,
                        principalSchema: "catalog",
                        principalTable: "Catalog_Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Catalog_Item_Catalog_Type_CatalogTypeId",
                        column: x => x.CatalogTypeId,
                        principalSchema: "catalog",
                        principalTable: "Catalog_Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Catalog_Item_Image",
                schema: "catalog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsHeader = table.Column<bool>(type: "bit", nullable: false),
                    CatalogItemId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog_Item_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalog_Item_Image_Catalog_Item_CatalogItemId",
                        column: x => x.CatalogItemId,
                        principalSchema: "catalog",
                        principalTable: "Catalog_Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogItemsVariants",
                schema: "catalog",
                columns: table => new
                {
                    CatalogItemVariantsId = table.Column<long>(type: "bigint", nullable: false),
                    CatalogItemsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItemsVariants", x => new { x.CatalogItemVariantsId, x.CatalogItemsId });
                    table.ForeignKey(
                        name: "FK_CatalogItemsVariants_CatalogItemVariant_CatalogItemVariantsId",
                        column: x => x.CatalogItemVariantsId,
                        principalSchema: "catalog",
                        principalTable: "CatalogItemVariant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogItemsVariants_Catalog_Item_CatalogItemsId",
                        column: x => x.CatalogItemsId,
                        principalSchema: "catalog",
                        principalTable: "Catalog_Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "catalog",
                table: "Catalog_Brand",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 7, 20, 2, 21, 0, 7, DateTimeKind.Local).AddTicks(6589), "Nike", null },
                    { 2L, new DateTime(2023, 7, 20, 2, 21, 0, 7, DateTimeKind.Local).AddTicks(6606), "Adidas", null },
                    { 3L, new DateTime(2023, 7, 20, 2, 21, 0, 7, DateTimeKind.Local).AddTicks(6608), "Puma", null }
                });

            migrationBuilder.InsertData(
                schema: "catalog",
                table: "Catalog_Type",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 7, 20, 2, 21, 0, 9, DateTimeKind.Local).AddTicks(4706), "Shoes", null },
                    { 2L, new DateTime(2023, 7, 20, 2, 21, 0, 9, DateTimeKind.Local).AddTicks(4721), "T-Shirt", null },
                    { 3L, new DateTime(2023, 7, 20, 2, 21, 0, 9, DateTimeKind.Local).AddTicks(4722), "tracksuit", null }
                });

            migrationBuilder.InsertData(
                schema: "catalog",
                table: "Catalog_Item",
                columns: new[] { "Id", "CatalogBrandId", "CatalogTypeId", "CreatedDate", "Description", "Name", "Price", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, 1L, 1L, new DateTime(2023, 7, 20, 2, 21, 0, 8, DateTimeKind.Local).AddTicks(3682), "Nike'ın günlük giyim için tasarlanmış ilk Air Max modeli olan Nike Air Max 270, dikkat çeken stili rahatlıkla buluşturuyor. Air Max ikonlarından ilham alan tasarım, büyük penceresi ve yeni renkleriyle Nike'ın en büyük yeniliğini sergiliyor.", "Nike Air Max 270", 1499.99m, null },
                    { 2L, 1L, 2L, new DateTime(2023, 7, 20, 2, 21, 0, 8, DateTimeKind.Local).AddTicks(3695), "Her takımın onu ligdeki diğer takımlardan ayıran gerçek renkleri ve eşsiz bir kimliği bulunur. Zengin basketbol mirasını onurlandıran bu Golden State Warriors Forma, takım ayrıntılarından ter tutmayan hafif fileye kadar profesyonellerin sahada giydiği formalardan ilham alır. Favori oyuncunu ve sevdiğin oyunu temsil ederken hem sahada hem de saha dışında kuru ve serin kalmana yardımcı olur", "Golden State Warriors Icon Edition 2022/23", 1849.90m, null },
                    { 10032L, 2L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Debitis voluptatem sapiente quia quod. Pariatur et officia rem aliquam. Eos eum placeat optio labore. Natus quod qui aut doloremque repellat natus ut et. Voluptatem repellendus omnis ut ut sint. Et possimus voluptas velit perferendis repellat cupiditate eveniet non aut.", "Sleek Plastic Shirt", 782.75m, null },
                    { 10033L, 3L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blanditiis at commodi tempora veritatis est hic saepe et explicabo. Quam quibusdam consequatur assumenda minima vel. İllum ullam dolores. Tempora eum et error quibusdam architecto ut beatae. Ea sed eveniet suscipit quos aut nam asperiores fugiat. Nam aut perferendis alias hic voluptatem ut quas aliquam et.", "Licensed Plastic Hat", 606.51m, null },
                    { 10034L, 3L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sit animi consectetur consequuntur. Ut recusandae molestiae consequuntur molestias voluptatem facere eos aut et. Qui ipsum omnis corrupti doloribus et. Nihil quia et sequi quis. Et eius rerum maxime qui ut.", "Rustic Plastic Chicken", 867.24m, null },
                    { 10035L, 1L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dolorum quam perspiciatis consequatur placeat. Nulla enim doloremque nulla libero. Repellendus illo et. Est itaque pariatur nobis quo molestiae hic.", "Practical Fresh Pants", 905.13m, null },
                    { 10036L, 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Occaecati officiis ea nostrum assumenda qui cum. Vero laboriosam nihil eius at ullam soluta. İn vitae eos impedit et recusandae. Explicabo esse tenetur et veritatis.", "Awesome Granite Ball", 605.15m, null },
                    { 10037L, 3L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quam sit incidunt eum ut. İpsam quia quibusdam eius sit enim. Quo rerum et unde odio eos temporibus. Similique ut sed dolorem qui.", "Licensed Wooden Chips", 120.00m, null },
                    { 10038L, 3L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Non necessitatibus officiis natus doloremque voluptate officia dicta ut. Laborum et natus. Et quis nihil. Aut quaerat eum sequi sint ea quis vero.", "Small Fresh Hat", 280.92m, null },
                    { 10039L, 1L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dolore et et et est veniam impedit praesentium. Harum sed facere cupiditate molestiae qui eligendi quibusdam et. Culpa odio omnis similique velit. Veniam aliquid aut. Et est eos quia cupiditate. Fugit voluptatem nihil laboriosam qui ut.", "Handcrafted Steel Hat", 670.76m, null },
                    { 10040L, 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İpsum sed est. Odio et quo consequuntur optio asperiores sint qui repellat. Quia rerum ut consequatur id. Placeat quia delectus culpa.", "Rustic Soft Hat", 475.19m, null },
                    { 10041L, 3L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Voluptas aspernatur et enim tempora corrupti dicta voluptatem. Reiciendis ipsum nostrum quod enim. Non numquam voluptatem consequuntur nam sed.", "Generic Concrete Ball", 429.34m, null },
                    { 10042L, 3L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Atque vitae dicta sit dolorem facilis ut quos quae saepe. Aut tempore perspiciatis voluptas assumenda quo. Eum aut molestias et consequatur enim consequatur numquam explicabo quia. Provident minus eveniet sit fuga ipsam deleniti.", "Ergonomic Concrete Mouse", 236.70m, null },
                    { 10043L, 3L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Et fuga corporis molestiae cum quibusdam. Dolor dolor nemo neque nostrum est est quia. Nihil qui soluta. Alias magnam neque dolores placeat repellendus nam illo. Ea vel excepturi voluptatem et perferendis quod porro. Doloribus aut neque animi consequatur quia reprehenderit nulla voluptatum.", "Handmade Granite Mouse", 47.07m, null },
                    { 10044L, 3L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perspiciatis qui et voluptatem aut impedit rerum praesentium reprehenderit ex. Consequatur vel harum blanditiis beatae rerum. Optio vitae minus ullam molestias perspiciatis. Assumenda voluptas ut aut. Aspernatur veritatis consequatur consequatur optio praesentium. Exercitationem nemo voluptatem.", "Licensed Steel Tuna", 226.89m, null },
                    { 10045L, 1L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consequatur mollitia eligendi ut tenetur iste veniam qui qui. Dolore blanditiis laboriosam et aut. Occaecati totam delectus veritatis.", "Practical Concrete Soap", 364.96m, null },
                    { 10046L, 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perferendis eveniet deleniti cumque labore optio odit quas commodi. Nulla architecto illum modi commodi et quae ut ducimus magni. Eligendi dolor vitae beatae quas numquam est voluptatem. Recusandae mollitia sed. Voluptas exercitationem temporibus provident ab. Assumenda suscipit voluptatum enim fugiat repudiandae quae nam.", "Licensed Concrete Tuna", 166.81m, null },
                    { 10047L, 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Qui accusantium repellendus nobis qui soluta. Nulla quia et velit deleniti necessitatibus. Corporis debitis error voluptatem sed accusantium debitis non. Alias molestiae dolore possimus numquam consequuntur. Excepturi earum consequuntur voluptates esse dolor quia deserunt dolorum fuga. Nulla voluptatibus temporibus.", "Awesome Concrete Mouse", 566.47m, null },
                    { 10048L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amet similique exercitationem et. Ducimus minima esse est praesentium voluptas quo et. Placeat non quia rerum hic. Rerum culpa sequi omnis nam. Occaecati id autem perferendis voluptas cum laboriosam esse.", "Sleek Soft Mouse", 174.23m, null },
                    { 10049L, 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eos alias sapiente distinctio velit asperiores earum commodi. Occaecati id accusantium. Autem voluptatem est odio.", "Awesome Rubber Chicken", 111.69m, null },
                    { 10050L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Occaecati ratione dolorem ex eos omnis. Labore repudiandae et et quisquam et reiciendis. Quia recusandae laudantium cum. Et dolor nihil.", "Awesome Frozen Chips", 239.33m, null },
                    { 10051L, 3L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Qui aut magnam sit et. Aut quibusdam deserunt aliquam quia velit ut odit reprehenderit. Est ex alias numquam eligendi sit nulla minima.", "Licensed Concrete Shirt", 414.00m, null },
                    { 10052L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quas nobis laborum laborum a. Qui optio nisi qui et. Temporibus architecto autem amet rem officia doloremque sunt. Eum odio sint beatae quidem vel autem vero vitae et. Enim qui rerum.", "Practical Wooden Bike", 353.20m, null },
                    { 10053L, 1L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İnventore ab saepe. Facilis a cupiditate ut vitae porro commodi in recusandae odit. Laudantium et facere. Perspiciatis unde et quidem tempora ipsam molestiae consequatur.", "Tasty Granite Pants", 928.56m, null },
                    { 10054L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ut et expedita doloribus architecto. Placeat qui et aliquid officia soluta vel rerum quia facere. Officia non fugiat expedita quod voluptatem sed a perspiciatis. Expedita aut nesciunt deleniti id. Eos quibusdam mollitia est voluptates impedit cum nostrum sit.", "Gorgeous Plastic Ball", 699.44m, null },
                    { 10055L, 2L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saepe ipsa dignissimos veniam. İmpedit esse id molestias. Occaecati dignissimos repellat aliquid qui quibusdam qui quidem. Blanditiis necessitatibus veniam asperiores nulla sed. Ea soluta dolor.", "Licensed Frozen Shoes", 279.94m, null },
                    { 10056L, 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Et quo et quaerat vero veritatis eos est impedit. Beatae harum odio quasi est molestiae a perspiciatis consequuntur. Animi qui inventore. Sequi ea temporibus accusantium qui ut quis praesentium odit quae. İncidunt minima perspiciatis. Ea enim sit voluptatum fuga non esse aliquam eveniet.", "Refined Concrete Pants", 220.31m, null },
                    { 10057L, 1L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rerum voluptatem cum at odio non necessitatibus est voluptas velit. Voluptas voluptatibus assumenda error deleniti vero voluptate. Consequatur autem praesentium fuga iure nulla magni nam.", "Intelligent Rubber Chips", 597.53m, null },
                    { 10058L, 2L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Possimus magnam minima. İllum beatae qui molestias omnis magni facere illo voluptatem est. Doloremque sed commodi consequatur facilis quia sed. Perferendis deleniti recusandae asperiores iste consequatur sapiente minima consectetur possimus. Sint fuga nulla excepturi sint ipsum illo. Quia asperiores magnam qui dolorum omnis est.", "Intelligent Plastic Keyboard", 369.40m, null },
                    { 10059L, 3L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Et eum consequuntur. Saepe perspiciatis et in cum corrupti. Dolore assumenda nam asperiores. Quasi ut voluptate qui voluptatem reprehenderit qui adipisci ea. Quasi voluptatum impedit dolores sed vel. Voluptatem at voluptatem voluptatum voluptatem ipsam omnis.", "Unbranded Soft Car", 160.39m, null },
                    { 10060L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deleniti commodi aut iste ipsa pariatur magni dolor porro. Placeat voluptate enim consequuntur ad in impedit reiciendis earum ad. Enim doloremque dignissimos natus labore vitae voluptate nam et.", "Small Plastic Car", 58.92m, null },
                    { 10061L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quisquam pariatur tenetur unde sunt. Sint veniam porro. Et incidunt dolores recusandae. Perspiciatis quis qui corporis incidunt dolore voluptatem qui. Aut dolor labore nihil.", "Small Fresh Sausages", 67.45m, null },
                    { 10062L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Voluptas sequi explicabo libero illum atque ipsum. Recusandae suscipit rerum soluta qui magni aliquam laudantium. Quis vitae dolor tempora corporis alias est ipsum eos.", "Licensed Wooden Salad", 160.84m, null },
                    { 10063L, 3L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dolores et illo ea in voluptatum qui magnam nihil omnis. İd inventore inventore odit minima consequatur odio reprehenderit voluptas. Cum rerum culpa eligendi.", "Unbranded Fresh Ball", 246.76m, null },
                    { 10064L, 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Expedita vel aut nihil magnam aut. Qui quae pariatur eos. Neque hic tenetur molestias doloremque rerum.", "Sleek Granite Pants", 475.33m, null },
                    { 10065L, 1L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eaque quo voluptas repellendus labore iure et ut. Esse voluptas perferendis sed quas. Molestiae qui doloribus aliquam.", "Fantastic Frozen Ball", 348.44m, null },
                    { 10066L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eveniet sit consectetur. Doloremque aperiam minima commodi placeat delectus dolore earum. Qui qui rerum et ea voluptas totam pariatur deleniti et.", "Ergonomic Granite Bike", 146.38m, null },
                    { 10067L, 3L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Et dolorum sit id sit exercitationem sed. İd et voluptatum amet quidem est aliquid dolorum. Amet sint laudantium provident. Aut rerum tempore eum ut eaque quia eum id autem. Placeat est minus expedita. Et itaque cumque.", "Practical Granite Mouse", 10.67m, null },
                    { 10068L, 1L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Corrupti exercitationem dolores sint sunt possimus fuga ipsa. Reprehenderit dolores eos praesentium. Qui amet est exercitationem. Repellat at officia. Voluptas et aut autem inventore ut consectetur. Sit sit nisi qui suscipit dolor quae nobis.", "Intelligent Concrete Chicken", 852.45m, null },
                    { 10069L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quasi quia animi at et. Eos mollitia aperiam quia sit sed placeat. Et et asperiores optio officiis qui enim nam. Dolorem porro vitae nihil. Eum fugit assumenda debitis eveniet. Sint maxime distinctio iusto eaque aperiam magnam et et.", "Small Concrete Chicken", 238.10m, null },
                    { 10070L, 3L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laudantium similique alias. Nam voluptas inventore sint dignissimos sed est aut deleniti non. Mollitia odit veniam qui. Voluptate quis quo fuga eos et ut veritatis delectus. Alias eius commodi.", "Ergonomic Fresh Gloves", 949.68m, null },
                    { 10071L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eos tenetur consequatur aut vel magni. Quia nulla sint quas enim accusantium vero voluptates quia et. Eaque minus vel quia sint aut voluptas. Tempora rem et velit quo dignissimos et qui. Et ut itaque maiores qui vel et quod soluta.", "Tasty Metal Car", 884.30m, null },
                    { 10072L, 3L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Qui minima sit suscipit et. Laudantium perferendis consequuntur aut voluptatibus. Aut consequuntur enim alias veniam officiis iste numquam suscipit incidunt. Maxime ut delectus aspernatur.", "Intelligent Steel Shirt", 315.93m, null },
                    { 10073L, 1L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aut atque rerum. Quidem nam possimus dolores dicta. Aut rerum ipsa blanditiis nemo accusantium esse magni id.", "Handmade Wooden Bacon", 1.31m, null },
                    { 10074L, 2L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İure dolores voluptatem voluptates accusantium et reiciendis omnis. Maiores harum quod veniam odit quibusdam velit iste eos exercitationem. Veniam quam sapiente. Nobis dolor commodi qui consequuntur.", "Awesome Metal Fish", 272.69m, null },
                    { 10075L, 3L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Omnis ut totam cupiditate magni fuga a. Provident provident impedit. Voluptas accusantium dicta at eum iste. Excepturi voluptatem inventore est explicabo possimus aspernatur ab similique.", "Small Concrete Towels", 148.24m, null },
                    { 10076L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Voluptate voluptatem voluptatem sit fugit non officia qui tempore esse. Aut magni rerum voluptates porro illo qui iusto eos soluta. Consequatur aut aut eaque exercitationem laudantium aut doloribus amet quasi. Ullam qui perferendis ducimus sunt iusto omnis. Doloribus veritatis beatae voluptates veritatis. İtaque atque est id alias voluptatem voluptates ab sit.", "Handmade Plastic Computer", 995.02m, null },
                    { 10077L, 1L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mollitia velit et sit magnam magnam. Voluptatem ratione occaecati cum enim blanditiis quam. Ut maxime consequuntur.", "Ergonomic Steel Car", 314.89m, null },
                    { 10078L, 1L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İd repudiandae vitae. Et quisquam sint porro omnis perspiciatis nesciunt. Nesciunt quae laborum modi ipsam aliquam aliquam ea aut itaque. Omnis vel voluptatum dolorem aliquid laudantium neque fuga qui.", "Handmade Frozen Pants", 465.12m, null },
                    { 10079L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Minus praesentium sequi quis. İn similique suscipit rerum et quasi et adipisci asperiores odit. Error veniam ea.", "Tasty Concrete Pants", 130.45m, null },
                    { 10080L, 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aut sit beatae asperiores et et sit et mollitia optio. İllum voluptatem dolores nesciunt possimus et quisquam et. Deleniti illum in. Laudantium et eius incidunt quia.", "Handcrafted Plastic Chips", 29.26m, null },
                    { 10081L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İn ut qui odit eligendi. Rerum id assumenda aut tenetur earum. Molestias pariatur magni dolor enim sint aut. Et alias quo qui nihil vel molestiae error. Quidem consequatur aliquid eum reprehenderit animi corporis quam ratione.", "Generic Steel Sausages", 341.23m, null },
                    { 10082L, 3L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Expedita eos omnis incidunt qui dolor. Asperiores tempore voluptas a. Totam tempore eligendi asperiores doloribus reiciendis qui illo non rerum. Aliquid ut beatae hic ratione. Ea aliquam non alias. Earum explicabo est blanditiis sapiente.", "Handmade Rubber Soap", 555.76m, null },
                    { 10083L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İusto veritatis sunt dolores ab. Sit sed et porro nesciunt explicabo. Voluptatibus officiis dolor hic voluptas facere nulla aut qui.", "Ergonomic Fresh Fish", 926.43m, null },
                    { 10084L, 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consequatur et et eos. Eius excepturi voluptas tempora voluptatem alias quibusdam eos non quae. Voluptate quae numquam molestiae voluptatem in eaque ut est. Est sequi odio consequatur reiciendis illum pariatur omnis molestias ut. Esse ut tenetur necessitatibus consequatur.", "Tasty Fresh Chips", 412.92m, null },
                    { 10085L, 1L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Architecto molestiae expedita. Distinctio quia vero aliquid tempore quibusdam eos facere cumque. Blanditiis aperiam rem veritatis. Non labore sed. Doloremque molestiae velit voluptates consequatur culpa.", "Incredible Soft Keyboard", 820.59m, null },
                    { 10086L, 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dolores sed deleniti eum aspernatur eaque aut voluptatem dicta. Non hic iusto ut dolorum reprehenderit cupiditate tenetur et expedita. Quam officia cum.", "Handcrafted Metal Ball", 83.05m, null },
                    { 10087L, 1L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laudantium architecto blanditiis vel laborum reiciendis laboriosam aut dolore. Ex quis ratione vero non error qui quam. Aut officia illo aliquid explicabo reprehenderit. İure qui sed atque asperiores officia fugiat sint. Assumenda id et. Veritatis tenetur quo fuga sequi.", "Awesome Fresh Sausages", 800.14m, null },
                    { 10088L, 3L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ut dicta praesentium nobis et voluptatem rerum et. Mollitia atque cumque et sunt cum. Ut mollitia aperiam laudantium non. Explicabo harum voluptatem in culpa nemo.", "Fantastic Wooden Chips", 38.24m, null },
                    { 10089L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reprehenderit quidem praesentium eius quis est sint recusandae atque repellat. Voluptate illum quas impedit. Placeat illum alias sed impedit dolores dolorum.", "Intelligent Rubber Keyboard", 231.22m, null },
                    { 10090L, 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sed doloribus voluptas voluptatibus minus. Assumenda ea alias temporibus qui vero et aut occaecati laborum. Odio soluta laudantium dolorem corrupti at. Nihil quibusdam consequuntur ea perspiciatis corrupti nisi est.", "Handcrafted Concrete Chicken", 772.82m, null },
                    { 10091L, 1L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Expedita et similique. İmpedit cum vitae sint sunt. Dolorem omnis voluptatem neque ex facere velit repellendus ipsum amet. Et quod est et qui aspernatur. Vel excepturi hic.", "Awesome Metal Chips", 225.13m, null },
                    { 10092L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sequi minus nesciunt. Odit tenetur ut doloribus. Et in aperiam.", "Rustic Wooden Gloves", 657.69m, null },
                    { 10093L, 2L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Et veritatis ex omnis ullam qui qui consequatur occaecati voluptate. Facilis blanditiis aut corporis quis commodi molestiae. Corporis veritatis et dicta voluptatum suscipit. Numquam sed eos iusto velit doloribus ab incidunt optio. Nostrum ipsam omnis et maiores qui eos velit est autem. Molestias cumque iusto molestiae.", "Fantastic Steel Computer", 413.32m, null },
                    { 10094L, 1L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nesciunt sed ut debitis ducimus pariatur provident quisquam quas ut. Rerum maxime dolor beatae. İllo iure accusantium a aut tempora vero. Atque et aut et corrupti consequatur et eius. Qui sequi molestiae vel. İllo dolores voluptate.", "Tasty Concrete Chips", 195.82m, null },
                    { 10095L, 3L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fugiat libero dicta repudiandae placeat quis est qui ipsum. Debitis culpa et blanditiis natus vero numquam. Consequuntur sunt qui cum nobis ratione quis aspernatur. Aperiam et dicta aliquam iste. Mollitia corporis amet.", "Small Rubber Salad", 775.80m, null },
                    { 10096L, 1L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aut consectetur ea. Voluptates est est autem aperiam natus quae quos quas perspiciatis. Fugiat consectetur exercitationem reiciendis iusto culpa distinctio aut laudantium. Velit quos consequatur non pariatur recusandae. İn aliquid eos laborum et deserunt dolorum. Maiores quia temporibus asperiores recusandae.", "Licensed Cotton Towels", 990.29m, null },
                    { 10097L, 3L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A molestiae assumenda accusamus dolores quibusdam excepturi. İd sed eos eum. Qui in ut voluptas magni recusandae qui debitis dolores facere. Distinctio ut numquam doloremque tempora consequuntur quod est et. Nulla doloremque voluptates nobis velit. Architecto maiores et a quidem sit rerum minus blanditiis doloribus.", "Tasty Rubber Pizza", 92.38m, null },
                    { 10098L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sed impedit dolorem quibusdam sit et voluptatem molestiae totam repellat. Qui quia vitae occaecati officiis. Repellendus dolores illum id ipsum soluta et reprehenderit sit sit. Voluptas nemo sed consequatur atque illo doloribus quidem. Aut suscipit in esse.", "Handcrafted Metal Chips", 524.57m, null },
                    { 10099L, 3L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Provident alias est voluptatem placeat sit assumenda suscipit. Quas nihil est distinctio dolores qui cupiditate molestiae voluptas. Cumque unde sit iusto mollitia consequatur explicabo pariatur. Sint animi dolor ea ut fugit necessitatibus optio et. Rerum quisquam soluta asperiores eligendi laboriosam aut impedit corporis vel. Tempore ut soluta.", "Tasty Wooden Salad", 782.79m, null },
                    { 10100L, 3L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Et perspiciatis et doloremque velit ut. Consectetur voluptatem ratione animi quibusdam aut quam reiciendis ut et. Aut esse exercitationem quo qui et aut. Et perferendis aliquam possimus est soluta nihil qui. A voluptatem dolore officia reiciendis est numquam.", "Incredible Concrete Keyboard", 246.13m, null },
                    { 10101L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dolores adipisci et. Quas hic voluptatibus est iusto qui laboriosam qui laudantium qui. Quam voluptatibus fuga laborum eos soluta. Dolores nihil iste. Voluptatum maiores enim aspernatur. Dolorem possimus maxime nisi quis distinctio ab distinctio vero quisquam.", "Handmade Plastic Tuna", 188.14m, null },
                    { 10102L, 2L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ex commodi aut officiis aut. Vero maxime est iusto sint molestias. Magnam odio sint quod reiciendis velit adipisci quia dolor quam. İusto quae sed. Et a consequatur dolor sunt optio minima.", "Tasty Metal Sausages", 495.75m, null },
                    { 10103L, 2L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Non omnis ut dolores. Magni ratione ut sit quibusdam quis ut molestiae. Adipisci ut cumque ipsa necessitatibus quo quo.", "Generic Granite Ball", 456.95m, null },
                    { 10104L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ut culpa veritatis quaerat. Voluptas ea impedit rerum alias rem. Quia modi commodi. Est et facere voluptatem ad nihil et suscipit eum. Deleniti eum ipsa qui est nihil minus ut nostrum.", "Fantastic Metal Chair", 381.46m, null },
                    { 10105L, 3L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pariatur sapiente dolor. Necessitatibus molestias sequi enim. Architecto voluptas quia impedit. Doloribus eum rem ut. Quis perferendis ut. Dolore consequatur ut et repellendus tempore sunt ex.", "Rustic Plastic Hat", 842.73m, null },
                    { 10106L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Omnis quia molestiae nihil nisi sunt accusantium. At voluptatem culpa ullam facere. İn atque dolor quam rerum repellat temporibus. Odit nesciunt sequi dolorem. İnventore aut qui voluptatibus voluptatem ut ipsum ab ut impedit. Eligendi consequatur est.", "Rustic Metal Sausages", 874.97m, null },
                    { 10107L, 3L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eligendi quia ut id officiis provident quis voluptatem qui fugiat. Quasi occaecati magni est amet omnis non ad minima. Natus exercitationem numquam. Molestiae animi sunt. Maiores aut tempore qui in et voluptatem. Laborum quo dolore.", "Incredible Cotton Sausages", 533.67m, null },
                    { 10108L, 2L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ea pariatur iure aspernatur quia quos similique voluptas. Rerum numquam maxime dolor fugiat vel. İmpedit atque necessitatibus cum aut tempora officia.", "Generic Cotton Pizza", 134.79m, null },
                    { 10109L, 3L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Voluptate aut quos ad minus nisi optio esse. Ullam velit a ipsa non quia ut earum sit ea. Est possimus ut iure voluptatem voluptatem. Architecto est nostrum. Corporis quis veritatis est quidem repellat necessitatibus modi.", "Handmade Steel Chips", 882.04m, null },
                    { 10110L, 3L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perspiciatis repellat id nulla autem. Eveniet qui nam aliquam praesentium. Possimus voluptatem aut tempora. Asperiores libero sed sed in. Soluta non consectetur at ut dolores rerum. Soluta laudantium quas.", "Small Soft Towels", 256.73m, null },
                    { 10111L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Et repellat doloremque in et ut maiores perspiciatis sapiente quibusdam. Quo quia dignissimos. Cupiditate rerum velit delectus mollitia. Suscipit est laborum. İncidunt sint ab maiores vel. Molestiae libero perferendis cupiditate et vel aut ex.", "Awesome Fresh Towels", 397.82m, null },
                    { 10112L, 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sunt nesciunt ut cupiditate repudiandae quis aliquid. Sed amet voluptates laboriosam occaecati impedit occaecati est aspernatur. Sunt quaerat sed eius dolor est eum. Et vitae rerum voluptatem et.", "Unbranded Soft Table", 76.25m, null },
                    { 10113L, 2L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Repellat esse illo est laborum eveniet consectetur nesciunt officiis quod. Saepe id est voluptatem impedit excepturi est. Tempore quia illum accusamus est qui distinctio provident.", "Handcrafted Cotton Keyboard", 53.89m, null },
                    { 10114L, 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sapiente rem rem tempore et. Reprehenderit et et architecto alias neque molestias. Voluptate eius incidunt enim omnis libero delectus modi vel. Architecto placeat atque.", "Incredible Soft Bike", 149.83m, null },
                    { 10115L, 1L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ut ab libero nihil eum cupiditate laborum. Tempore voluptas id quae autem voluptatibus eos est quas distinctio. Dolor rerum reiciendis provident atque sint et. Sunt harum quia sunt quas vero incidunt.", "Handmade Fresh Sausages", 173.76m, null },
                    { 10116L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nam est dolorem inventore. Earum eum consequuntur ullam commodi officiis consectetur et illum. Explicabo quia quisquam rerum. Dolore voluptatem rerum dignissimos velit quis.", "Small Concrete Chair", 59.72m, null },
                    { 10117L, 1L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deserunt consectetur totam est magnam omnis culpa dolores maiores fuga. Voluptatibus quas quo voluptas cupiditate suscipit qui non debitis perspiciatis. Libero pariatur aliquam veniam dolorem recusandae in est explicabo reprehenderit. Recusandae nulla veniam rem sunt repellendus et.", "Sleek Steel Bike", 213.97m, null },
                    { 10118L, 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sunt sint natus reprehenderit quae eaque consequatur sit et earum. Fuga ducimus aut deleniti quaerat incidunt. Suscipit odit omnis debitis consequatur repudiandae.", "Licensed Metal Soap", 683.30m, null },
                    { 10119L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Voluptatum doloribus est eius voluptatibus. Dolorem et at magnam perferendis non sit quod rerum fugit. Earum quis aut tempore soluta aliquid animi facere et. Facere debitis vitae vitae fugiat pariatur.", "Handcrafted Plastic Chair", 39.39m, null },
                    { 10120L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quasi aut non sequi alias animi. Assumenda adipisci reiciendis eum commodi ab ab ut architecto sequi. Nihil animi ipsa error omnis qui ullam veniam. Enim omnis est ut est sapiente similique et laboriosam in. Ea quisquam architecto.", "Licensed Concrete Gloves", 248.28m, null },
                    { 10121L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saepe amet ea. Tempore et aliquid nisi magnam ex quae numquam. Qui sequi expedita quis. İpsa soluta voluptatem quod molestiae doloribus ex excepturi atque similique.", "Awesome Steel Shoes", 847.89m, null },
                    { 10122L, 2L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Necessitatibus cumque unde velit autem. Beatae rem commodi et consectetur iusto. Nihil vero itaque corporis rerum earum. Voluptatem non provident.", "Refined Frozen Chips", 261.15m, null },
                    { 10123L, 3L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Qui perspiciatis cumque aut quasi voluptatibus. Tenetur autem assumenda natus. Quia dolores provident perferendis perferendis tempore in reiciendis qui.", "Licensed Soft Ball", 816.08m, null },
                    { 10124L, 1L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Accusamus occaecati consequatur veniam qui. Eius est ipsam ut. Molestiae consequuntur aut doloribus facilis repellendus ducimus unde laboriosam. Unde quia tempore qui magnam voluptates. Repellendus suscipit eveniet enim quod. Vero veniam qui et.", "Handmade Frozen Fish", 915.98m, null },
                    { 10125L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fuga quia ut a fugiat temporibus. Tenetur alias eaque dolorem perspiciatis eveniet enim delectus quo. Atque voluptas doloribus ducimus enim et.", "Rustic Wooden Hat", 75.93m, null },
                    { 10126L, 3L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ex officiis porro ea excepturi adipisci. Ullam quos suscipit ipsa fuga eum consequuntur aut suscipit. Qui provident a. Dolorem aut a sed et voluptatum vel amet.", "Practical Metal Salad", 358.95m, null },
                    { 10127L, 3L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consectetur est et dignissimos nostrum. İllum inventore labore in et quidem ea. Nisi nisi repellat consequuntur. Pariatur rerum quo veritatis.", "Gorgeous Wooden Towels", 696.20m, null },
                    { 10128L, 3L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tenetur assumenda ut maxime ut. Omnis officia aspernatur. Delectus ut debitis eius tempora numquam ut et excepturi.", "Refined Plastic Mouse", 132.48m, null },
                    { 10129L, 3L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Repudiandae non qui magnam non. Autem voluptates qui in pariatur est aperiam dolores quia. Neque quia assumenda et quam ut blanditiis temporibus vel excepturi. Vel qui et ut qui et omnis rem voluptate. Perferendis nobis dolores deleniti rem quia fuga.", "Rustic Soft Bacon", 451.32m, null },
                    { 10130L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Numquam similique sapiente qui numquam est neque dolorem. Velit eveniet eveniet est non dolor est culpa voluptatem illo. Mollitia accusamus est consequatur voluptatem ut.", "Fantastic Wooden Pants", 424.53m, null },
                    { 10131L, 2L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dicta est deleniti provident aspernatur unde illo sit. Voluptatum aut sed asperiores blanditiis assumenda sit minus et ut. Saepe itaque tempora quis consequatur incidunt repudiandae voluptatem impedit. Voluptatum qui iusto rerum aliquam natus nesciunt sunt aut. Consequatur animi illum eum vero ut.", "Licensed Granite Chair", 104.53m, null },
                    { 10132L, 3L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eos quod quia deleniti sint rerum nisi ducimus. Ut voluptatibus ut. İd consequatur sequi autem omnis ut et. Consequatur accusamus nemo nisi nemo. Quibusdam iure eius asperiores minima. Aut qui aliquam velit nam et ut.", "Practical Soft Sausages", 472.43m, null },
                    { 10133L, 2L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Et et occaecati id sed enim sed voluptatem quos et. Pariatur quos repellendus qui. Quae qui nesciunt vero perspiciatis magni nemo. Sit consequatur recusandae quae sapiente aut sequi.", "Licensed Steel Chair", 95.15m, null },
                    { 10134L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beatae aut nemo voluptas ad ea non voluptates hic beatae. Sequi omnis eaque aut quae. Consequatur placeat veniam rem. İn est est consequatur id vitae. Magnam dolorum voluptatem dolore sunt.", "Incredible Rubber Bacon", 478.85m, null },
                    { 10135L, 3L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ab explicabo ad eaque quasi sequi perspiciatis ullam. İtaque dolores aut est voluptatibus consequatur dignissimos ipsa quia. Similique sed hic nihil neque est exercitationem rerum. Quis at et voluptas. Consequatur doloremque deserunt.", "Sleek Wooden Shoes", 957.92m, null },
                    { 10136L, 3L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Explicabo dolores voluptate saepe fugit optio consequatur autem sit qui. Et incidunt ipsa. Aut provident dolores aspernatur odit aperiam et. Consequatur sint inventore sed et aut est ratione et nostrum.", "Unbranded Soft Sausages", 708.62m, null },
                    { 10137L, 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eius molestias animi quo eligendi non. Et autem pariatur beatae sapiente voluptas non et. Asperiores ut aut est ea saepe cupiditate iste quibusdam aut. Vel quaerat sint expedita. Amet quas sit dolore id magni ut quia dicta. Doloribus perferendis omnis.", "Refined Cotton Chips", 764.72m, null },
                    { 10138L, 1L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aut consectetur ad est beatae aut in doloremque. Sed laboriosam sapiente. Accusamus reiciendis sunt architecto distinctio est aut perspiciatis beatae. Est dicta magni eveniet quisquam dicta nihil magni.", "Licensed Plastic Chips", 888.22m, null },
                    { 10139L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A qui qui nam quis. Provident voluptas qui laborum et. Omnis ullam alias tempora reiciendis pariatur temporibus ipsum voluptatem aperiam. Sit sed provident maiores laborum. Quia quia omnis.", "Small Cotton Sausages", 261.10m, null },
                    { 10140L, 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eos praesentium quas qui. Est accusamus quas placeat fuga dolorem omnis. Distinctio illum atque minus provident. Est odit eum ut consequatur et nihil. Dolore autem id odit nesciunt repellendus qui quaerat debitis aliquid.", "Refined Wooden Bike", 122.45m, null },
                    { 10141L, 3L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Labore voluptas ut omnis enim. Hic tempore harum. İpsam debitis sit repellendus soluta vero omnis minima voluptatum. Ut voluptatem dolorem eos doloremque. Provident perspiciatis repudiandae delectus sunt vel. Ea inventore rerum recusandae totam hic.", "Sleek Granite Chips", 942.45m, null },
                    { 10142L, 1L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Possimus asperiores deserunt et voluptas sed eveniet est. Vel suscipit ut possimus quis totam. Exercitationem dolores veniam ullam corporis hic. Velit sed architecto quisquam praesentium aut doloribus nulla ducimus aut.", "Refined Plastic Towels", 194.96m, null },
                    { 10143L, 3L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rem qui non et rerum explicabo. İd error porro dignissimos. Ratione modi dolor incidunt eum aut nostrum laudantium optio placeat. Voluptas consequatur id et quia doloremque impedit fugiat corporis. Et reiciendis eaque voluptatem quia cumque et.", "Practical Wooden Bike", 715.45m, null },
                    { 10144L, 1L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Possimus qui et et optio. Similique perspiciatis aut ut vel eum placeat magni. Eum mollitia in qui quod voluptas. Aut consequatur suscipit est. Et omnis perferendis labore. Dolor enim fuga tempora.", "Rustic Concrete Chicken", 894.90m, null },
                    { 10145L, 3L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dolorem corporis et quia sed. Dignissimos et iusto velit. Non excepturi libero. Quam culpa itaque placeat. Deleniti cumque facilis qui numquam esse. Aut in porro aut hic id.", "Rustic Soft Chair", 407.52m, null },
                    { 10146L, 1L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Voluptatem corporis atque cum dolores dicta ullam. Quia recusandae et velit quia inventore non. Velit qui esse. Veniam qui labore. Eum provident eligendi velit ut est labore. Recusandae eos cum maiores magnam et molestiae ut rerum.", "Rustic Cotton Computer", 85.89m, null },
                    { 10147L, 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hic tempore in earum molestiae. Nobis minima mollitia explicabo ad quisquam quibusdam dolorem repudiandae delectus. Vero eos nisi ut.", "Ergonomic Rubber Table", 813.95m, null },
                    { 10148L, 1L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vel quia aut quidem enim. Sed sint nobis est aut. Quidem vel voluptatem.", "Practical Frozen Chips", 812.88m, null },
                    { 10149L, 1L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aperiam voluptatem assumenda fuga et officia quod. Laboriosam in omnis hic. Sit dicta porro sit similique.", "Sleek Wooden Pants", 552.08m, null },
                    { 10150L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consequatur est nostrum ut laudantium non accusantium. Ut debitis quaerat ipsam ex consequatur deserunt. Deserunt sed nobis eos molestiae. Rerum et eos deserunt et.", "Gorgeous Metal Pizza", 441.59m, null },
                    { 10151L, 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ut voluptas saepe totam et dolor sed cupiditate vel ab. Corrupti qui sit rerum officiis magni. Non non fugiat eligendi modi alias nihil recusandae qui eligendi. Sequi totam aut omnis sed ratione dignissimos libero quasi corrupti.", "Gorgeous Concrete Chair", 795.18m, null },
                    { 10152L, 3L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quidem maxime nostrum nulla pariatur. Et quas est eos asperiores enim ullam dignissimos. Doloribus similique saepe et libero recusandae dolores est itaque. Omnis commodi blanditiis ad quos laudantium sed illum ut.", "Refined Concrete Chair", 667.86m, null },
                    { 10153L, 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beatae nam sed mollitia et. Provident quis ut corporis exercitationem ullam distinctio expedita odit iusto. Sed impedit nostrum. Optio mollitia necessitatibus non sequi temporibus. Ut blanditiis natus quae totam voluptatum consequatur. Nesciunt distinctio autem.", "Rustic Plastic Keyboard", 852.58m, null },
                    { 10154L, 1L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İd assumenda non deleniti vel qui. Neque laboriosam molestiae rerum et. Sunt earum labore aspernatur suscipit ut. Necessitatibus pariatur corrupti autem eveniet enim suscipit. Rerum rem expedita laborum magni voluptatum.", "Fantastic Fresh Ball", 783.32m, null },
                    { 10155L, 1L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Et similique voluptatibus et autem. Nam dignissimos soluta nobis eum maxime distinctio consequatur repudiandae. İste voluptates et beatae perferendis. Eaque vero et rem saepe. Non est occaecati possimus nemo harum quia consectetur velit.", "Rustic Fresh Sausages", 467.58m, null },
                    { 10156L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sint minus eos quisquam totam. Vel est a deleniti ut tenetur quia. Qui iure molestias qui. Minima voluptas enim dolorum ut. İtaque dolor odit.", "Handmade Granite Car", 18.05m, null },
                    { 10157L, 1L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aut perferendis corrupti omnis sint. İd facilis aut et voluptatem dolorem magnam. Nihil qui necessitatibus aut eum delectus sapiente non incidunt voluptatem. Minima sint voluptatem ut et cumque voluptates qui ullam soluta. Veritatis explicabo corrupti.", "Awesome Plastic Pizza", 279.11m, null },
                    { 10158L, 3L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ex cum alias dolores ea illo facere cupiditate. Porro quia praesentium dolores. Nemo delectus consequatur non voluptates velit alias. Sit facere amet molestias enim beatae tenetur aut.", "Handmade Cotton Sausages", 99.74m, null },
                    { 10159L, 1L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hic eaque nulla. İusto velit quia iste. Veritatis sint nihil maxime blanditiis voluptates aut. İnventore quo tenetur nam nostrum commodi. Porro ut eveniet in repellat consequatur cupiditate cumque eos.", "Practical Soft Fish", 611.58m, null },
                    { 10160L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ut rerum sit nisi vel consequatur laudantium eum aut. Accusantium earum omnis adipisci vitae explicabo. Et mollitia non quaerat non reprehenderit. Est autem ea provident. Repellat reiciendis suscipit.", "Refined Metal Soap", 156.79m, null },
                    { 10161L, 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Velit in ut in natus quae. Expedita doloribus reiciendis exercitationem aut. Fuga dolorem qui debitis.", "Ergonomic Steel Bike", 735.42m, null },
                    { 10162L, 2L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Voluptate ad id est autem et voluptatem voluptas temporibus ut. Dolorem inventore iure itaque expedita praesentium qui qui. İusto enim fugiat iste.", "Refined Wooden Mouse", 733.69m, null },
                    { 10163L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Qui repudiandae sapiente. Et neque nemo et quos molestiae. Voluptatibus deserunt ut quaerat officiis id dolorem. Sed pariatur ullam ut cumque ut sapiente. Molestiae mollitia maiores sit ducimus animi neque temporibus optio. Labore eos ut voluptatem.", "Generic Cotton Bacon", 482.33m, null },
                    { 10164L, 3L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ad distinctio eum aut omnis. Et rerum inventore est et illo pariatur ut minus numquam. Optio voluptatem deserunt ut doloribus. Nulla provident sit consequuntur eius. Expedita molestias sit ut tenetur debitis corrupti cum. Blanditiis saepe laborum quod modi consequatur quia quis illum.", "Intelligent Cotton Gloves", 907.58m, null },
                    { 10165L, 3L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Similique omnis quia quia laborum quam quo distinctio dolorem maiores. Magni optio quae eaque sed asperiores. İpsum quia aliquam. Laboriosam ea omnis quae sit eum voluptatum. Voluptas nulla voluptatum.", "Awesome Fresh Ball", 671.97m, null },
                    { 10166L, 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quas fugit voluptatum. Ut consequatur tempore ut explicabo natus cumque autem non. Officiis debitis nemo vitae et maxime eos et sequi. Optio magnam sed aut et ipsum ut quo suscipit quibusdam.", "Fantastic Steel Towels", 259.30m, null },
                    { 10167L, 1L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Officiis minima architecto ut quidem sed velit commodi. Reiciendis consectetur sequi occaecati molestiae sapiente. Nulla quia in fuga et ipsum doloremque quia esse quas. Architecto et ea magnam rem beatae voluptatem. Earum consequuntur aut mollitia consequatur natus eligendi qui quidem.", "Handcrafted Concrete Fish", 724.99m, null },
                    { 10168L, 3L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Voluptates nemo rerum nulla sint nam. Non libero molestiae neque. Magni et illum aut quaerat quod inventore quaerat omnis aut.", "Refined Fresh Mouse", 418.90m, null },
                    { 10169L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Possimus vitae repellendus quis. Provident magnam unde reiciendis error eum non. Omnis tempore corporis amet qui rerum necessitatibus sit quibusdam consequatur. Neque aliquid aut sit.", "Intelligent Soft Chips", 781.34m, null },
                    { 10170L, 3L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cupiditate nobis nostrum officia est nostrum aliquid est animi. Nemo rerum et nobis voluptatum unde. Alias fugit doloribus laudantium aut rerum possimus ut tempore tenetur. Omnis est at laborum natus omnis qui.", "Rustic Wooden Gloves", 803.82m, null },
                    { 10171L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Est nihil dolorem dolorem sint soluta placeat. Dolores deserunt unde ut tempore eos eos doloremque. Sed similique qui nulla suscipit temporibus. Assumenda fugit vero ipsa neque est rerum reprehenderit voluptas. İpsa et voluptatem omnis qui fugiat voluptatum. Totam sed incidunt ut.", "Incredible Frozen Bacon", 39.94m, null },
                    { 10172L, 1L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Necessitatibus minima illo voluptatem eius aliquam facere. Non eligendi qui sit nulla vero. Alias architecto modi voluptatem laboriosam iste.", "Generic Metal Mouse", 521.50m, null },
                    { 10173L, 3L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dignissimos doloremque voluptas. Cumque quaerat dolorem dolor quia rerum est. Nulla similique labore. Facere eum eum cumque distinctio. Aperiam alias fuga.", "Ergonomic Steel Chair", 256.45m, null },
                    { 10174L, 3L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Veritatis voluptates quibusdam. A et rerum enim minima voluptates qui dolorum quia. Tenetur error voluptas quae in cumque quo neque dolorem commodi.", "Refined Wooden Computer", 845.62m, null },
                    { 10175L, 3L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pariatur quia autem ut nam tempore eos necessitatibus. Accusamus omnis vel tempora blanditiis voluptatem aliquid. Voluptatem sint temporibus.", "Small Plastic Chicken", 408.47m, null },
                    { 10176L, 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nulla sunt cupiditate nam maiores enim pariatur ut enim iusto. Voluptate laudantium voluptas ut non. Quam est voluptas molestiae at minima animi. Est sit repellendus. Debitis est optio doloribus incidunt laudantium ratione excepturi reiciendis. İncidunt recusandae ad accusamus similique vero.", "Generic Soft Pizza", 537.08m, null },
                    { 10177L, 2L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Repudiandae praesentium quasi deleniti voluptatum voluptatem et soluta minima. Quis libero molestiae aut praesentium aperiam aut id. Excepturi minima nobis blanditiis repellendus nam.", "Ergonomic Metal Bacon", 156.66m, null },
                    { 10178L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eius quam id adipisci voluptatibus quod excepturi. Maxime amet qui nihil animi tenetur deserunt numquam. Accusantium omnis est quo distinctio. Nisi corporis et consequatur et. Et mollitia aut.", "Tasty Rubber Tuna", 935.84m, null },
                    { 10179L, 2L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Corrupti iusto beatae necessitatibus dicta doloremque quisquam. Dolores voluptas quam. İnventore enim facilis qui optio est adipisci sit. Alias ut ullam. Assumenda assumenda velit neque. İtaque tempora nisi id est quaerat perferendis.", "Generic Cotton Tuna", 112.21m, null },
                    { 10180L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quidem quibusdam officia recusandae adipisci et est sapiente voluptatem nihil. Autem minus ea. Et earum quisquam. Exercitationem adipisci pariatur sit quam. Perferendis in suscipit qui dolor.", "Handmade Wooden Ball", 927.33m, null },
                    { 10181L, 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quidem amet pariatur consectetur reprehenderit eius. Nulla similique natus ad dolor nobis et modi id. Consequatur sint architecto vero deleniti eaque ab rerum. Et dolorem rerum neque alias qui.", "Small Frozen Sausages", 776.72m, null },
                    { 10182L, 3L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Officiis sint voluptates earum enim officiis id. Similique aperiam consequatur tempore ut. Asperiores quo mollitia vel pariatur consectetur molestias ad.", "Intelligent Rubber Shirt", 480.07m, null },
                    { 10183L, 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sed eius officia enim officia. Et aspernatur ut molestiae quia molestiae suscipit. Quis quos quos sunt animi aut. Doloribus sint vero. Maxime ab cumque libero.", "Handmade Steel Hat", 252.14m, null },
                    { 10184L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İnventore nostrum doloribus neque deserunt est dolor voluptates deserunt. Laudantium omnis dolores quisquam corporis quaerat voluptas. İnventore officiis in. Quasi ut qui alias eum et laborum totam porro. İn suscipit occaecati consequatur voluptatibus nam unde harum veniam non. Maxime animi odio quaerat ullam eum.", "Tasty Plastic Ball", 901.30m, null },
                    { 10185L, 3L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eos voluptatibus et laboriosam quia et aperiam. Voluptas numquam sit dolor. Modi deserunt vel. Nihil at perferendis sint alias.", "Fantastic Metal Gloves", 246.82m, null },
                    { 10186L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Earum rerum accusamus nemo occaecati ipsum odio. Reiciendis ut ut laudantium. Fuga et fugiat voluptate consequuntur voluptates laboriosam voluptas laudantium amet. Error consequuntur est accusamus sed. Hic voluptatum veniam officiis inventore velit inventore.", "Fantastic Plastic Soap", 996.53m, null },
                    { 10187L, 2L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Voluptates sit eum fuga distinctio. Dolorem in iure et non. İncidunt modi at. Atque quam ut debitis non quod fugiat unde est. Eos culpa provident aut facere quis eaque. Ullam dignissimos qui quibusdam neque iusto autem consectetur et eos.", "Ergonomic Concrete Car", 986.58m, null },
                    { 10188L, 3L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nemo ut aut omnis quis illum ut tenetur doloremque minima. Dolorem nostrum numquam dolores accusamus architecto voluptatem accusamus velit voluptatibus. Vel odio aut enim illum excepturi tenetur.", "Gorgeous Metal Bike", 850.84m, null },
                    { 10189L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Temporibus et qui atque. Saepe eos ad veniam. Praesentium dolorem sed commodi ut qui.", "Gorgeous Soft Keyboard", 278.78m, null },
                    { 10190L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Qui dicta ducimus praesentium voluptas aut error et similique. Aut a rerum facere rerum quia eos dolores deserunt. Libero accusantium officia aliquid consequatur quo maxime maxime occaecati quos. İpsum laudantium magni architecto.", "Gorgeous Soft Car", 484.98m, null },
                    { 10191L, 1L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quam voluptate ut et consequatur eveniet perferendis. Accusamus aliquam voluptatibus praesentium tenetur quae quo non. Reprehenderit consequuntur cum consequatur cumque ad voluptates unde necessitatibus. Eaque ea molestias officia aut amet maiores consectetur.", "Unbranded Granite Pizza", 981.57m, null },
                    { 10192L, 3L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consequatur esse occaecati sit explicabo et. Est qui maiores repellat. At iusto consequatur labore omnis mollitia velit.", "Intelligent Plastic Mouse", 61.83m, null },
                    { 10193L, 2L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İn unde magni. Placeat iusto perspiciatis voluptas ut veniam sunt dolore sint non. Quasi quod porro. Dolor laborum beatae nobis est perferendis architecto nobis occaecati id. Fuga ex ipsum qui minima ullam minus quidem.", "Unbranded Cotton Chips", 992.84m, null },
                    { 10194L, 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nisi sequi aliquid laudantium id aspernatur fugit maiores. Animi voluptatibus eum ut esse in et. Alias aut vitae nihil.", "Sleek Rubber Ball", 930.68m, null },
                    { 10195L, 1L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dolores iste rerum. İllum cumque quos facilis alias architecto est saepe et. Non occaecati at accusamus qui sit animi nesciunt est omnis.", "Refined Steel Keyboard", 779.23m, null },
                    { 10196L, 1L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Magni illo nihil qui et dolorem eligendi. Fuga hic qui sunt voluptatem eum. Deserunt totam rerum consequatur dignissimos qui dolores earum ipsam perferendis. Sapiente esse ea quasi neque placeat enim et odio eos. Assumenda nulla temporibus inventore dolorum explicabo totam. Ea qui repellendus voluptas rem veniam beatae libero.", "Incredible Granite Table", 910.70m, null },
                    { 10197L, 3L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quia quo non aliquam mollitia adipisci explicabo eligendi distinctio recusandae. Tempore ducimus id ut. Omnis non sunt corporis quam sapiente architecto. Aut voluptatem consectetur exercitationem sapiente fuga aperiam sint. Laudantium hic rerum.", "Awesome Soft Salad", 404.75m, null },
                    { 10198L, 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consequatur provident odio quo adipisci officiis inventore. Ut possimus qui distinctio eius omnis libero. Qui ut architecto unde.", "Gorgeous Soft Sausages", 535.37m, null },
                    { 10199L, 2L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Accusamus rerum quidem doloribus modi molestias et debitis asperiores vel. Fugiat delectus suscipit. Eum rerum corrupti enim natus voluptate accusamus et aperiam nobis. Cumque velit rerum a veniam aliquid voluptas ea eaque doloremque. Voluptatem accusantium fugit temporibus ut minima ut sint.", "Handcrafted Cotton Mouse", 178.57m, null },
                    { 10200L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ex hic quae aut quibusdam quis voluptate. Vero excepturi non. Repudiandae repudiandae et est dolor vel eveniet eius. Odio voluptas recusandae aut repellat amet ipsum dolorum est nisi. Velit sunt laboriosam voluptate porro deserunt et quis qui assumenda.", "Gorgeous Metal Cheese", 747.44m, null },
                    { 10201L, 3L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İpsum qui sapiente molestiae. İn aliquam deserunt ipsam odio. Laborum odit quasi eos cupiditate provident qui quis. Amet vel sed blanditiis voluptas sint omnis voluptas harum. Magni expedita corporis. Vel libero ut.", "Practical Metal Shoes", 73.95m, null },
                    { 10202L, 3L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Et quibusdam et commodi. Eius accusantium illum voluptas tenetur tenetur velit eos. Voluptatem possimus quisquam temporibus et praesentium. Expedita sed velit qui debitis quod vero et. Delectus qui voluptas velit accusamus perspiciatis.", "Tasty Cotton Hat", 647.41m, null },
                    { 10203L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Est delectus nisi animi necessitatibus laborum sed non ut. Perferendis harum est dolores qui corporis dolor recusandae ut deleniti. Facere dolor praesentium est commodi natus vitae voluptatem. Mollitia aut exercitationem quasi porro. Totam illum dolor tenetur accusantium ullam laudantium fugiat optio. Nihil molestias iure nam harum nisi provident et porro.", "Ergonomic Soft Ball", 545.13m, null },
                    { 10204L, 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cumque tempore ut accusamus itaque nobis unde omnis autem soluta. Suscipit quo perferendis. Quia ad fugiat aut fugit tempore. Quis voluptatem iusto et deserunt natus omnis pariatur quis. İn quae corrupti.", "Ergonomic Concrete Salad", 218.48m, null },
                    { 10205L, 1L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Et in occaecati impedit magnam temporibus perferendis. Quasi excepturi inventore ex numquam optio sunt. Voluptas eaque maxime quibusdam consequuntur odit sint blanditiis autem.", "Fantastic Frozen Pants", 447.11m, null },
                    { 10206L, 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Non eius et ducimus consequuntur quidem libero eveniet et. Distinctio impedit enim suscipit. Facere consequatur ex. Libero eum ipsam sit dolor. Dolorum qui minus nihil. Reiciendis ea voluptatem commodi sit velit et inventore.", "Fantastic Metal Chicken", 644.13m, null },
                    { 10207L, 3L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Natus ut minima dolorum officia aut dolorem et. Dicta in sit ullam eveniet sit maiores recusandae nostrum autem. Temporibus omnis qui sint et quia amet delectus atque. Doloribus consectetur consequuntur vero rerum magnam quam ut quaerat quam. Rerum id non in ullam.", "Unbranded Steel Shirt", 60.79m, null },
                    { 10208L, 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Unde cumque optio praesentium quod qui necessitatibus. Mollitia aut aperiam error atque fugiat. Sed unde amet amet possimus est maxime ut.", "Rustic Plastic Tuna", 183.93m, null },
                    { 10209L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quasi non dolore aut velit repudiandae consectetur culpa iusto. Voluptatem sed dolores aut omnis. A veniam ullam provident officiis distinctio eaque odit beatae. Qui exercitationem et est tempore omnis quo. Excepturi ut voluptatibus amet sequi.", "Rustic Rubber Shirt", 384.30m, null },
                    { 10210L, 1L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cum ea esse officia deserunt ab perspiciatis error sequi reprehenderit. Odio molestias est. Ratione libero omnis officiis ipsum id sed non animi. Recusandae temporibus delectus maiores incidunt pariatur provident ipsam et. Quasi necessitatibus eveniet temporibus autem. Aliquid sunt vel facere quisquam voluptas quisquam molestiae.", "Handmade Granite Sausages", 161.26m, null },
                    { 10211L, 2L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ut optio rerum qui non quo a sed sed. Ullam quibusdam autem nobis eos quo et dolor et. Nulla blanditiis esse non quisquam consequatur ab. Consequatur et et necessitatibus porro facere quod totam voluptate totam. Praesentium blanditiis rerum excepturi adipisci et neque consequatur.", "Licensed Rubber Tuna", 225.84m, null },
                    { 10212L, 2L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aut minus est sed molestiae sit voluptatum id natus. Rem quas qui consequatur mollitia amet error animi iusto. Omnis sint eaque illum fuga sit omnis ipsam. İn voluptatem possimus dolor hic nihil est aut placeat. Eos repellat cumque id voluptas ullam sequi temporibus omnis. Fugiat est quia cumque aspernatur repellendus iusto non voluptatem facilis.", "Ergonomic Wooden Ball", 191.38m, null },
                    { 10213L, 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Culpa repellendus ratione enim consequatur. Eaque eligendi est sapiente tempora ad accusantium rerum. Saepe amet laboriosam cum soluta. Sit omnis aut ea sint illum ea porro.", "Gorgeous Concrete Soap", 293.26m, null },
                    { 10214L, 3L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Minima voluptates ut tenetur voluptate occaecati voluptatibus praesentium ipsam. Aut sint sit. Autem excepturi rem eos perspiciatis.", "Unbranded Metal Soap", 375.15m, null },
                    { 10215L, 3L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Et blanditiis blanditiis et mollitia mollitia sint vitae pariatur eos. Sequi rerum exercitationem accusantium earum quis rem. Quam culpa voluptas et delectus nisi temporibus ducimus consequatur rem. Est quis quia et accusantium dolores dolore laboriosam reprehenderit.", "Licensed Steel Table", 728.07m, null },
                    { 10216L, 2L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Totam nisi velit. Culpa molestiae dolore consectetur ratione est amet dolorem esse. Quibusdam in hic labore. Dolores velit rem et quia quam provident quo atque. Cupiditate et enim tempora nisi est laudantium sequi. Veniam et similique reiciendis quisquam.", "Incredible Frozen Soap", 808.92m, null },
                    { 10217L, 1L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İtaque deserunt sed consectetur consequatur nulla delectus aperiam nulla. Aliquid cupiditate voluptatum officiis quo reiciendis possimus repudiandae error. Sunt accusamus cupiditate ex quo harum rem maxime consequatur sint. Sunt et provident facere. Repellat omnis officia tenetur et quos culpa et reprehenderit. Veniam molestias rerum omnis voluptate quisquam sapiente nam qui possimus.", "Refined Steel Gloves", 172.84m, null },
                    { 10218L, 1L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aut illo ducimus numquam et suscipit accusamus. İpsam est nihil occaecati est ullam ex et enim. Eos qui quis. Similique laborum atque voluptatem enim rerum accusamus quisquam facilis. Facilis debitis ea corporis ad reprehenderit vel. Atque et voluptas.", "Rustic Cotton Sausages", 641.14m, null },
                    { 10219L, 1L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saepe ut adipisci nesciunt omnis. Unde nostrum deleniti. Tempora exercitationem esse dolor sunt dolores hic. Non dolores maxime distinctio. Atque odio dolor tenetur quis dolorum mollitia adipisci.", "Unbranded Concrete Chicken", 600.37m, null },
                    { 10220L, 3L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Minus autem sed velit officiis facilis a deleniti. İn placeat eum consectetur dolorum sint facere quas unde nobis. Saepe quaerat natus nam temporibus beatae fugiat consequuntur minus maxime. Est beatae rerum veritatis at magni. İpsa vel ullam accusantium pariatur incidunt.", "Incredible Cotton Keyboard", 13.25m, null },
                    { 10221L, 3L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sed eos sint deserunt quia. Error libero eaque error fugiat animi esse numquam cumque id. Aut voluptatum voluptatum. Numquam a asperiores ex non ea.", "Fantastic Plastic Bacon", 843.36m, null },
                    { 10222L, 1L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Numquam quas adipisci corporis autem voluptatem voluptatem. Adipisci eius vel. Ea tempora est dolores.", "Rustic Metal Salad", 885.21m, null },
                    { 10223L, 3L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İllum ea voluptas explicabo nesciunt vel aspernatur et perferendis expedita. Praesentium mollitia cumque nesciunt. Quia est qui non dicta ullam temporibus laborum sapiente est. Autem illum enim eligendi. Quo commodi possimus. Sed aliquid itaque qui aut rerum dolorum at.", "Generic Plastic Chicken", 576.04m, null },
                    { 10224L, 2L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alias et necessitatibus dignissimos iure ut eligendi. Qui quod quisquam suscipit natus deserunt ipsam facilis ut vel. Soluta voluptas molestias cum temporibus facere est reprehenderit.", "Gorgeous Wooden Car", 495.31m, null },
                    { 10225L, 2L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nihil temporibus hic est velit cumque mollitia vitae et. Eum nulla accusamus provident id velit autem sed. İd ut est omnis voluptatem. Unde fugiat quidem soluta esse.", "Awesome Steel Pants", 740.97m, null },
                    { 10226L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Facere quia non. Quis iste deserunt deleniti. Aliquid similique inventore cum eveniet aut laudantium blanditiis.", "Fantastic Wooden Chicken", 336.49m, null },
                    { 10227L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vel optio sunt perspiciatis voluptatum tempora officiis fugiat. Veniam reiciendis explicabo nostrum quae expedita placeat quia libero rerum. A laudantium omnis odio iusto. Eveniet culpa possimus a ullam quo qui est voluptatibus. Nobis laborum qui recusandae aut nemo similique fugit. Laboriosam nobis veritatis veniam non eveniet ex.", "Incredible Metal Keyboard", 747.51m, null },
                    { 10228L, 1L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nihil qui adipisci hic nihil nobis. Tenetur non vel incidunt nam aperiam aut doloribus. Voluptates et est voluptatibus suscipit ut quaerat eos. Et sunt odit molestias. Cumque quibusdam cupiditate mollitia corporis saepe pariatur labore.", "Refined Cotton Sausages", 660.72m, null },
                    { 10229L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Et quos aut culpa sint et. Laboriosam omnis distinctio non ab esse quo omnis odio modi. Minus sunt sit quia culpa sed architecto maxime aut rerum. Voluptas dolorem deserunt magni et voluptatem delectus repellendus molestiae recusandae.", "Incredible Granite Sausages", 796.49m, null },
                    { 10230L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consequatur autem rerum error in iusto iste rerum qui. Sit corrupti at nemo commodi assumenda. Quisquam occaecati explicabo iste animi et perspiciatis.", "Unbranded Rubber Soap", 857.82m, null },
                    { 10231L, 3L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İste unde optio repudiandae omnis sunt sed dolore. Fuga quia iure. Ullam voluptatum iusto eos hic sit adipisci. Dolore quia saepe mollitia. Dolores quod deserunt fugit.", "Ergonomic Steel Towels", 9.99m, null }
                });

            migrationBuilder.InsertData(
                schema: "catalog",
                table: "Catalog_Item_Image",
                columns: new[] { "Id", "CatalogItemId", "CreatedDate", "FileName", "IsHeader", "Path", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2023, 7, 20, 2, 21, 0, 8, DateTimeKind.Local).AddTicks(7678), "Airmax270.png", false, "Product//Shoes//Airmax270.png", null },
                    { 2L, 2L, new DateTime(2023, 7, 20, 2, 21, 0, 8, DateTimeKind.Local).AddTicks(7688), "GoldenState2022/23_uniform.png", false, "Product//T-Shirt//GoldenState2022/23_uniform.png", null },
                    { 20028L, 10196L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20029L, 10052L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20030L, 10143L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20031L, 10075L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20032L, 10063L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20033L, 10072L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20034L, 10138L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20035L, 10184L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20036L, 10190L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20037L, 10123L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20038L, 10092L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20039L, 10125L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20040L, 10143L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20041L, 10183L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20042L, 10054L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20043L, 10094L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20044L, 10050L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20045L, 10180L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20046L, 10183L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20047L, 10175L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20048L, 10070L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20049L, 10162L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20050L, 10177L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20051L, 10087L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20052L, 10102L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20053L, 10153L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20054L, 10123L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20055L, 10180L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20056L, 10055L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20057L, 10215L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20058L, 10161L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20059L, 10168L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20060L, 10111L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20061L, 10052L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20062L, 10048L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20063L, 10200L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20064L, 10040L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20065L, 10090L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20066L, 10103L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20067L, 10143L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20068L, 10119L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20069L, 10037L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20070L, 10141L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20071L, 10141L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20072L, 10190L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20073L, 10096L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20074L, 10075L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20075L, 10212L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20076L, 10201L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20077L, 10161L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20078L, 10110L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20079L, 10107L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20080L, 10083L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20081L, 10056L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20082L, 10189L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20083L, 10101L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20084L, 10122L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20085L, 10132L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20086L, 10041L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20087L, 10114L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20088L, 10148L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20089L, 10037L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20090L, 10045L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20091L, 10220L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20092L, 10057L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20093L, 10152L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20094L, 10049L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20095L, 10043L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20096L, 10094L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20097L, 10090L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20098L, 10151L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20099L, 10210L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20100L, 10081L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20101L, 10184L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20102L, 10196L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20103L, 10044L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20104L, 10099L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20105L, 10180L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20106L, 10158L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20107L, 10072L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20108L, 10170L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20109L, 10165L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20110L, 10230L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20111L, 10102L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20112L, 10148L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20113L, 10081L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20114L, 10101L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20115L, 10143L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20116L, 10221L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20117L, 10037L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20118L, 10072L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20119L, 10142L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20120L, 10099L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20121L, 10081L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20122L, 10069L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20123L, 10069L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20124L, 10106L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20125L, 10185L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20126L, 10102L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20127L, 10219L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20128L, 10046L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20129L, 10041L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20130L, 10218L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20131L, 10225L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20132L, 10155L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20133L, 10119L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20134L, 10156L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20135L, 10163L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20136L, 10158L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20137L, 10124L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20138L, 10157L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20139L, 10202L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20140L, 10130L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20141L, 10076L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20142L, 10146L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20143L, 10153L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20144L, 10050L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20145L, 10118L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20146L, 10132L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20147L, 10207L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20148L, 10060L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20149L, 10064L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20150L, 10187L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20151L, 10133L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20152L, 10140L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20153L, 10162L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20154L, 10208L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20155L, 10165L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20156L, 10040L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20157L, 10032L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20158L, 10119L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20159L, 10094L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20160L, 10222L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20161L, 10050L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20162L, 10092L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20163L, 10133L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20164L, 10061L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20165L, 10141L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20166L, 10094L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20167L, 10082L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20168L, 10227L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20169L, 10190L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20170L, 10162L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20171L, 10186L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20172L, 10194L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20173L, 10146L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20174L, 10116L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20175L, 10088L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20176L, 10102L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20177L, 10056L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20178L, 10041L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20179L, 10207L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20180L, 10098L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20181L, 10082L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20182L, 10084L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20183L, 10157L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20184L, 10193L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20185L, 10173L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20186L, 10212L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20187L, 10090L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20188L, 10080L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20189L, 10221L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20190L, 10118L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20191L, 10176L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20192L, 10136L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20193L, 10225L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20194L, 10093L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20195L, 10188L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20196L, 10191L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20197L, 10192L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20198L, 10164L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20199L, 10056L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20200L, 10196L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20201L, 10039L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20202L, 10215L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20203L, 10178L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20204L, 10190L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20205L, 10156L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20206L, 10176L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20207L, 10082L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20208L, 10035L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20209L, 10188L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20210L, 10223L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20211L, 10059L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20212L, 10169L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20213L, 10080L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20214L, 10093L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20215L, 10044L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20216L, 10098L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20217L, 10073L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20218L, 10141L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20219L, 10097L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20220L, 10167L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20221L, 10213L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20222L, 10110L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20223L, 10188L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20224L, 10199L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20225L, 10090L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20226L, 10049L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null },
                    { 20227L, 10152L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbey.jpg", true, "v1671933877/shoes/akbey_qqopy0", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_Item_CatalogBrandId",
                schema: "catalog",
                table: "Catalog_Item",
                column: "CatalogBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_Item_CatalogTypeId",
                schema: "catalog",
                table: "Catalog_Item",
                column: "CatalogTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_Item_Image_CatalogItemId",
                schema: "catalog",
                table: "Catalog_Item_Image",
                column: "CatalogItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItemsVariants_CatalogItemsId",
                schema: "catalog",
                table: "CatalogItemsVariants",
                column: "CatalogItemsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalog_Item_Image",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "CatalogItemsVariants",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "CatalogItemVariant",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "Catalog_Item",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "Catalog_Brand",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "Catalog_Type",
                schema: "catalog");
        }
    }
}
