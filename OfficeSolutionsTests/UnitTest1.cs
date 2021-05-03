using Home_Office_Solutions.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace OfficeSolutionsTests
{
    public class Tests
    {

        [TestClass()]
        public class HomeOfficeSolutionsTests
        {
            [TestMethod()]
            public void CreateStationaryItem()
            {
                StationaryItem b = new StationaryItem() { ProductID = 1, Name = "2019/2020 Academic Diary", Brand = "Stauntons", Color = "White", ProductType = ProductType.Diary, ProductDescription =" 2019/2020 Red White Cover Academic Diary for all your needs."};
                Assert.IsInstanceOfType(b, typeof(StationaryItem));
                Assert.AreEqual(b.ProductID, 1);
                Assert.AreEqual(b.Name, "2019/2020 Academic Diary");
                Assert.AreEqual(b.Brand, "Stauntons");
                Assert.AreEqual(b.Color, "White");
                Assert.AreEqual(b.ProductDescription, "2019 / 2020 Red White Cover Academic Diary for all your needs.");
                Assert.AreEqual(b.ProductType, ProductType.Diary);
            }

            [TestMethod()]
            public void CreateShop()
            {
                Shop sh = new Shop() { ShopID = 1, ShopName = "Office Supplies 101", ShopAddress = "Main Street" };
                Assert.IsInstanceOfType(sh, typeof(Shop));
                Assert.AreEqual(sh.ShopID, 1);
                Assert.AreEqual(sh.ShopName, "Office Supplies 101");
                Assert.AreEqual(sh.ShopAddress, "Main Street");
            }

            [TestMethod()]
            public void CreateStock()
            {
                Stock st = new Stock() { StockID = 1, ProductID = 1, ShopID = 1, Price = 3 };
                Assert.IsInstanceOfType(st, typeof(Stock));
                Assert.AreEqual(st.StockID, 1);
                Assert.AreEqual(st.ShopID, 1);
                Assert.AreEqual(st.ProductID, 1);
                Assert.AreEqual(st.Price, 3);
            }



        }
    }
}