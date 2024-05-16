using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class AddFirstProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImgLink", "Name", "WishlistId" },
                values: new object[,]
                {
                    { new Guid("3c5a6e0e-7117-4c32-b5f4-8dc7ee4defeb"), 3990m, "Death Stranding — компьютерная игра в жанре action с открытым миром, разработанная студией Kojima Productions в сотрудничестве с Guerrilla Games и изданная Sony Interactive Entertainment для PlayStation 4 в 2019 году. В 2020 году компания 505 Games выпустила версию игры для Microsoft Windows. 30 января 2024 года состоялся релиз версии для macOS и iOS. Это первая игра Хидэо Кодзимы и Kojima Productions после разрыва с Konami в 2015 году. В работе над игрой приняли участие актёры Норман Ридус, Мадс Миккельсен, Леа Сейду, Маргарет Куэлли, Томми Дженкинс, Линдси Вагнер и Трой Бейкер; в игре также появляются персонажи, моделями для внешности которых послужили кинорежиссёры Гильермо дель Торо и Николас Виндинг Рефн.", "/images/DeathStranding.jpeg", "Death Stranding", null },
                    { new Guid("96dd3d74-e971-40c5-932b-0e031f15423a"), 2790m, "Days Gone (дословно c англ. — «Минувшие дни»; в официальной русской локализации — «Жизнь после») — компьютерная игра в жанре action-adventure в открытом мире, разработанная американской студией Bend Studio и изданная компанией Sony Interactive Entertainment. Действие игры разворачивается на территории штата Орегон через два года после начала глобальной пандемии, превратившей большую часть населения в зомби, именуемых в игре «фриками». Игрок берёт на себя роль байкера Ди́кона Сент-Джона, который пытается выжить в суровом мире, практически полностью уничтоженном из-за эпидемии. В основе сюжета — поиски жены Дикона Сары, на момент событий игры считающейся мёртвой. Игровой процесс Days Gone ведётся от третьего лица и построен на исследовании открытого мира. Игрок может использовать огнестрельное оружие, оружие ближнего боя и «импровизированные» виды орудий, чтобы защитить себя от враждебных бандитов и «фриков». Основным средством передвижения по миру является мотоцикл, который можно улучшать и изменять его внешний вид.", "/images/DaysGone.jpg", "Days Gone", null },
                    { new Guid("84dc641c-bd66-4545-87b7-fe578411a874"), 1600m, "Infamous: Second Son (стилизовано как inFAMOUS: Second Son, в русской локализации — «Infamous: Второй Сын») — компьютерная игра в жанре action-adventure с открытым миром, разработанная американской студией Sucker Punch Productions и изданная компанией Sony Computer Entertainment в марте 2014 года эксклюзивно для игровой консоли PlayStation 4. Игра является третьей в серии Infamous. Главным героем является Делсин Роу, обладающий сверхспособностями, которые он использует в бою и во время путешествий по Сиэтлу, который является местом действия событий Second Son. По ходу игры Делсин приобретает новые способности и становится либо героем, либо злодеем, поскольку выборы игрока влияют на сюжет, концовку и на сами силы.", "/images/InfamousSecondSon.jpg", "Infamous Secong son", null },
                    { new Guid("3ef21e93-f308-4581-8d18-3c6b93d92d88"), 3990m, "Red Dead Redemption 2 (стилизованно — Red Dead Redemption II, сокращённо RDR2) — компьютерная игра в жанрах action-adventure и шутера от третьего лица с открытым миром, разработанная Rockstar Studios и выпущенная Rockstar Games для консолей PlayStation 4 и Xbox One 26 октября 2018 года и для персональных компьютеров под управлением Windows 5 ноября 2019 года. Является третьей игрой в серии Red Dead и приквелом к Red Dead Redemption 2010 года.\r\n\r\nДействие Red Dead Redemption 2, оформленной в духе вестерна, происходит на территории нескольких вымышленных штатов США на рубеже XIX—XX веков. Сюжет игры построен вокруг приключений банды Датча Ван дер Линде; под управлением игрока находится один из членов банды — Артур Морган, а после прохождения сюжетной линии до эпилога — другой член банды, Джон Марстон. После неудачного ограбления парома бандиты вынуждены скрываться в глуши от федеральных агентов и охотников за головами", "/images/RDR2.jpeg", "Red dead redemption 2", null },
                    { new Guid("3adb9654-464a-499a-8cb6-f626beba82fd"), 2990m, "God of War (с англ. — «Бог войны») — компьютерная игра в жанре action-adventure, разработанная компанией SIE Santa Monica Studio и изданная Sony Interactive Entertainment для игровой консоли PlayStation 4, а затем на Windows. Вышла 20 апреля 2018 года. Является восьмой игрой серии God of War, а также сиквелом к игре 2010 года God of War III. Игра продолжает события предыдущих игр и переносит серию в мир скандинавской мифологии — все предыдущие игры серии были основаны на греческой мифологии. 16 сентября 2020 года было анонсировано продолжение игры.", "/images/GOW.webp", "God of war", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3adb9654-464a-499a-8cb6-f626beba82fd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3c5a6e0e-7117-4c32-b5f4-8dc7ee4defeb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3ef21e93-f308-4581-8d18-3c6b93d92d88"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("84dc641c-bd66-4545-87b7-fe578411a874"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("96dd3d74-e971-40c5-932b-0e031f15423a"));
        }
    }
}
