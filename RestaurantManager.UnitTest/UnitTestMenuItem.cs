
using NUnit.Framework;
using RestaurantManager.Models;
using RestaurantManager.Services;
using System;
using System.Threading.Tasks;

namespace RestaurantManager.UnitTest
{

    public class UnitTestMenuItem
    {
        MockMenuItems MMI;

        
        [SetUp]
        public void Setup()
        {
            MMI = new MockMenuItems();
        }

        [Test]
        public void TestAddMenu()
        {
            //arrange
            MenuItem It1 = new MenuItem { Id = "17", Name = "A menu", Description = "This is the menu description." };
            int MenuCount = MMI.menuItems.Count;

            //assert precondition
            Assert.IsFalse(MMI.menuItems.Exists(x => x.Id == "17"));

            //act
            _ = MMI.AddMenuAsync(It1);

            // assert
            Assert.IsTrue(MMI.menuItems.Count == MenuCount + 1);
            Assert.IsTrue(MMI.menuItems.Exists(x => x.Id == "17"));
        }

        [Test]
        public void TestDeleteMenu()
        {
            //arrange
            MenuItem It1 = new MenuItem { Id = "17", Name = "A menu", Description = "This is the menu description." };
            int MenuCount = MMI.menuItems.Count;
            _ = MMI.AddMenuAsync(It1);
            

            //assert precondition
            Assert.IsTrue(MMI.menuItems.Exists(x => x.Id == "17"));
            Assert.IsTrue(MMI.menuItems.Count == MenuCount + 1);

            //act
            _ = MMI.DeleteMenuAsync("17");

            // assert
            Assert.IsTrue(MMI.menuItems.Count == MenuCount);
            Assert.IsFalse(MMI.menuItems.Exists(x => x.Id == "17"));
        }

        [Test]
        public void TestUpdateMenu()
        {
            //arrange
            MenuItem It1 = new MenuItem { Id = "17", Name = "A menu", Description = "This is the menu description." };
            MenuItem It2 = new MenuItem { Id = "17", Name = "Some other menu", Description = "This is the menu description." };
            _ = MMI.AddMenuAsync(It1);


            //assert precondition
            Assert.IsTrue(MMI.menuItems.Contains(It1));

            //act
            _ = MMI.UpdateMenuAsync(It2);

            // assert
            Assert.IsTrue(MMI.menuItems.Contains(It2));
            Assert.IsFalse(MMI.menuItems.Contains(It1));
        }

        [Test]
        public void TestGetMenu()
        {
            //arrange
            MenuItem It1 = new MenuItem { Id = "17", Name = "A menu", Description = "This is the menu description." };
            _ = MMI.AddMenuAsync(It1);


            //assert precondition
            Assert.IsTrue(MMI.menuItems.Exists(x => x.Id == "17"));
            

            //act
            var It2 = MMI.GetMenuAsync("17");

            // assert
            Assert.IsTrue(It1.Id == It2.Result.Id);
        }
    }
}
