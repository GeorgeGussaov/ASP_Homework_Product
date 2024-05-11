using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace OnlineShop.Db
{
    public class ProductsDbRepository : IProductRepository
    {
        private readonly DatabaseContext _databaseContext;
        public ProductsDbRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        //private static List<Product> products = new List<Product>() {
        //        new Product("Death Stranding", 3990, "Death Stranding — компьютерная игра в жанре action с открытым миром, разработанная студией Kojima Productions в сотрудничестве с Guerrilla Games и изданная Sony Interactive Entertainment для PlayStation 4 в 2019 году. В 2020 году компания 505 Games выпустила версию игры для Microsoft Windows. 30 января 2024 года состоялся релиз версии для macOS и iOS. Это первая игра Хидэо Кодзимы и Kojima Productions после разрыва с Konami в 2015 году. В работе над игрой приняли участие актёры Норман Ридус, Мадс Миккельсен, Леа Сейду, Маргарет Куэлли, Томми Дженкинс, Линдси Вагнер и Трой Бейкер; в игре также появляются персонажи, моделями для внешности которых послужили кинорежиссёры Гильермо дель Торо и Николас Виндинг Рефн.","/images/DeathStranding.jpeg"),
        //        new Product("Days Gone", 2790, "Days Gone (дословно c англ. — «Минувшие дни»; в официальной русской локализации — «Жизнь после») — компьютерная игра в жанре action-adventure в открытом мире, разработанная американской студией Bend Studio и изданная компанией Sony Interactive Entertainment. Действие игры разворачивается на территории штата Орегон через два года после начала глобальной пандемии, превратившей большую часть населения в зомби, именуемых в игре «фриками». Игрок берёт на себя роль байкера Ди́кона Сент-Джона, который пытается выжить в суровом мире, практически полностью уничтоженном из-за эпидемии. В основе сюжета — поиски жены Дикона Сары, на момент событий игры считающейся мёртвой. Игровой процесс Days Gone ведётся от третьего лица и построен на исследовании открытого мира. Игрок может использовать огнестрельное оружие, оружие ближнего боя и «импровизированные» виды орудий, чтобы защитить себя от враждебных бандитов и «фриков». Основным средством передвижения по миру является мотоцикл, который можно улучшать и изменять его внешний вид.", "/images/DaysGone.jpg"),
        //        new Product("Infamous Secong son", 1600 , "Infamous: Second Son (стилизовано как inFAMOUS: Second Son, в русской локализации — «Infamous: Второй Сын») — компьютерная игра в жанре action-adventure с открытым миром, разработанная американской студией Sucker Punch Productions и изданная компанией Sony Computer Entertainment в марте 2014 года эксклюзивно для игровой консоли PlayStation 4. Игра является третьей в серии Infamous. Главным героем является Делсин Роу, обладающий сверхспособностями, которые он использует в бою и во время путешествий по Сиэтлу, который является местом действия событий Second Son. По ходу игры Делсин приобретает новые способности и становится либо героем, либо злодеем, поскольку выборы игрока влияют на сюжет, концовку и на сами силы.", "/images/InfamousSecondSon.jpg"),
        //        new Product("Red dead redemption 2", 3990 , "Red Dead Redemption 2 (стилизованно — Red Dead Redemption II, сокращённо RDR2) — компьютерная игра в жанрах action-adventure и шутера от третьего лица с открытым миром, разработанная Rockstar Studios и выпущенная Rockstar Games для консолей PlayStation 4 и Xbox One 26 октября 2018 года и для персональных компьютеров под управлением Windows 5 ноября 2019 года. Является третьей игрой в серии Red Dead и приквелом к Red Dead Redemption 2010 года.\r\n\r\nДействие Red Dead Redemption 2, оформленной в духе вестерна, происходит на территории нескольких вымышленных штатов США на рубеже XIX—XX веков. Сюжет игры построен вокруг приключений банды Датча Ван дер Линде; под управлением игрока находится один из членов банды — Артур Морган, а после прохождения сюжетной линии до эпилога — другой член банды, Джон Марстон. После неудачного ограбления парома бандиты вынуждены скрываться в глуши от федеральных агентов и охотников за головами", "/images/RDR2.jpeg"),
        //        new Product("God of war", 2990 , "God of War (с англ. — «Бог войны») — компьютерная игра в жанре action-adventure, разработанная компанией SIE Santa Monica Studio и изданная Sony Interactive Entertainment для игровой консоли PlayStation 4, а затем на Windows. Вышла 20 апреля 2018 года. Является восьмой игрой серии God of War, а также сиквелом к игре 2010 года God of War III. Игра продолжает события предыдущих игр и переносит серию в мир скандинавской мифологии — все предыдущие игры серии были основаны на греческой мифологии. 16 сентября 2020 года было анонсировано продолжение игры.", "/images/GOW.webp")
        //};
        
        public Product GetProduct(Guid id)
        {
            foreach (Product p in _databaseContext.Products.ToList())
            {
                if (p.Id == id) return p;
            }
            return null;
        }
        public List<Product> GetProducts()
        {
            return _databaseContext.Products.ToList();
        }

		public void ChangeProduct(Guid id, string newName, decimal newCost, string newDescription)
        {
			foreach (Product p in _databaseContext.Products.ToList())
			{
				if (p.Id == id)
                {
                    p.Name = newName;
                    p.Cost = newCost;
                    p.Description = newDescription;
                }
			}
            _databaseContext.SaveChanges();
		}

        public void Delete(Guid id)
        {
            Product product = GetProduct(id);
            _databaseContext.Products.Remove(product);
            _databaseContext.SaveChanges();
        }

        public void Add(Product newProduct)
        {
            _databaseContext.Products.Add(newProduct);
            _databaseContext.SaveChanges();
        }

        public List<Product> SearchProduct(string searchInfo)
        {
            return _databaseContext.Products.ToList().Where(pr => pr.Name.ToLower().Contains(searchInfo.ToLower())).ToList();
        }
    }

    public interface IProductRepository
    {
        public Product GetProduct(Guid id);
        public List<Product> GetProducts();
        public void ChangeProduct(Guid id, string newName, decimal newCost, string newDescription);
        public void Delete(Guid id);
        public void Add(Product newProduct);
        public List<Product> SearchProduct(string searchInfo);

	}
}
