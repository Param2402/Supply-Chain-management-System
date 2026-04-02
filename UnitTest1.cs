using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupplyChainManagementSystem;

namespace SupplyChain.Tests
{
    [TestClass]
    public class InventoryTests
    {
        //FurnitureItem Tests 

        [TestMethod]
        public void Item_Init_Values()
        {
            FurnitureItem item = new FurnitureItem(10004, "Oak Table", "Dining Room", 149.99, 8, "Zone D");
            Assert.AreEqual(10004, item.ItemID);
            Assert.AreEqual("Oak Table", item.Name);
            Assert.AreEqual("Dining Room", item.Category);
            Assert.AreEqual(149.99, item.Price, 0.001);
            Assert.AreEqual(8, item.StockLevel);
            Assert.AreEqual("Zone D", item.WarehouseZone);
        }

        [TestMethod]
        public void Item_DefaultSession_Zero()
        {
            FurnitureItem item = new FurnitureItem(10005, "Bookshelf", "Storage", 79.99, 12, "Zone E");
            Assert.AreEqual(0, item.QuantitySold);
            Assert.AreEqual(0, item.QuantityRestocked);
        }

        [TestMethod]
        public void Sold_Increment_Works()
        {
            FurnitureItem item = new FurnitureItem(10006, "Dining Chair", "Dining Room", 39.99, 15, "Zone A");
            item.StockLevel -= 4;
            item.QuantitySold += 4;
            Assert.AreEqual(11, item.StockLevel);
            Assert.AreEqual(4, item.QuantitySold);
        }

        [TestMethod]
        public void Restock_Increment_Works()
        {
            FurnitureItem item = new FurnitureItem(10007, "Wardrobe", "Bedroom", 349.99, 2, "Zone D");
            item.StockLevel += 10;
            item.QuantityRestocked += 10;
            Assert.AreEqual(12, item.StockLevel);
            Assert.AreEqual(10, item.QuantityRestocked);
        }

        [TestMethod]
        public void StockUpdate_Works()
        {
            FurnitureItem item = new FurnitureItem(10003, "Office Chair", "Office", 89.99, 20, "Zone C");
            item.StockLevel -= 5;
            item.StockLevel += 10;
            Assert.AreEqual(25, item.StockLevel);
        }

        //  BST Insert & Search

        [TestMethod]
        public void InsertSearch_Works()
        {
            CustomBST inventoryTree = new CustomBST();
            inventoryTree.Insert(new FurnitureItem(10001, "Leather Sofa", "Living Room", 299.99, 10, "Zone A"));
            FurnitureItem foundItem = inventoryTree.Search(10001);
            Assert.IsNotNull(foundItem);
            Assert.AreEqual("Leather Sofa", foundItem.Name);
            Assert.AreEqual(10, foundItem.StockLevel);
        }

        [TestMethod]
        public void Search_InvalidID_ReturnsNull()
        {
            CustomBST inventoryTree = new CustomBST();
            inventoryTree.Insert(new FurnitureItem(10002, "Wooden Bed", "Bedroom", 499.99, 5, "Zone B"));
            Assert.IsNull(inventoryTree.Search(999));
        }

        [TestMethod]
        public void Insert_Multi_Search_OK()
        {
            CustomBST inventoryTree = new CustomBST();
            inventoryTree.Insert(new FurnitureItem(150, "Sofa", "Living Room", 499.99, 6, "Zone C"));
            inventoryTree.Insert(new FurnitureItem(30, "Chair", "Office", 89.99, 10, "Zone A"));
            inventoryTree.Insert(new FurnitureItem(70, "Desk", "Office", 199.99, 4, "Zone B"));

            Assert.AreEqual("Sofa", inventoryTree.Search(150).Name);
            Assert.AreEqual("Chair", inventoryTree.Search(30).Name);
            Assert.AreEqual("Desk", inventoryTree.Search(70).Name);
        }

        [TestMethod]
        public void Insert_Duplicate_NoOverwrite()
        {
            CustomBST inventoryTree = new CustomBST();
            inventoryTree.Insert(new FurnitureItem(200, "Original Item", "Chair", 50.00, 5, "Zone A"));
            inventoryTree.Insert(new FurnitureItem(200, "Duplicate Item", "Chair", 99.00, 999, "Zone Z"));
            Assert.AreEqual("Original Item", inventoryTree.Search(200).Name);
        }

        [TestMethod]
        public void Search_Empty_ReturnsNull()
        {
            CustomBST inventoryTree = new CustomBST();
            Assert.IsNull(inventoryTree.Search(10001));
        }

        // Delete Tests

        [TestMethod]
        public void Delete_Leaf_Works()
        {
            CustomBST inventoryTree = new CustomBST();
            inventoryTree.Insert(new FurnitureItem(10, "Table", "Dining Room", 199.99, 5, "Zone A"));
            inventoryTree.Insert(new FurnitureItem(5, "Stool", "Kitchen", 29.99, 2, "Zone B"));
            inventoryTree.Insert(new FurnitureItem(15, "Lamp", "Living Room", 19.99, 8, "Zone C"));
            Assert.IsTrue(inventoryTree.Delete(5));
            Assert.IsNull(inventoryTree.Search(5));
        }

        [TestMethod]
        public void Delete_TwoChildren_Works()
        {
            CustomBST inventoryTree = new CustomBST();
            inventoryTree.Insert(new FurnitureItem(10, "Table", "Dining Room", 199.99, 5, "Zone A"));
            inventoryTree.Insert(new FurnitureItem(5, "Stool", "Kitchen", 29.99, 2, "Zone B"));
            inventoryTree.Insert(new FurnitureItem(15, "Lamp", "Living Room", 19.99, 8, "Zone C"));
            Assert.IsTrue(inventoryTree.Delete(10));
            Assert.IsNull(inventoryTree.Search(10));
            Assert.IsNotNull(inventoryTree.Search(5));
            Assert.IsNotNull(inventoryTree.Search(15));
        }

        [TestMethod]
        public void Delete_NotFound_ReturnsFalse()
        {
            CustomBST inventoryTree = new CustomBST();
            inventoryTree.Insert(new FurnitureItem(10, "Chair", "Office", 89.99, 6, "Zone A"));
            Assert.IsFalse(inventoryTree.Delete(999));
        }

        [TestMethod]
        public void Delete_Empty_ReturnsFalse()
        {
            CustomBST inventoryTree = new CustomBST();
            Assert.IsFalse(inventoryTree.Delete(10001));
        }

        // GetMaxID Tests 

        [TestMethod]
        public void GetMaxID_ReturnsHighest()
        {
            CustomBST inventoryTree = new CustomBST();
            inventoryTree.Insert(new FurnitureItem(10, "Chair", "Office", 89.99, 6, "Zone A"));
            inventoryTree.Insert(new FurnitureItem(25, "Sofa", "Living Room", 499.99, 3, "Zone C"));
            inventoryTree.Insert(new FurnitureItem(5, "Stool", "Kitchen", 29.99, 2, "Zone B"));
            Assert.AreEqual(25, inventoryTree.GetMaxID());
        }

        [TestMethod]
        public void GetMaxID_Empty_ReturnsZero()
        {
            CustomBST inventoryTree = new CustomBST();
            Assert.AreEqual(0, inventoryTree.GetMaxID());
        }

        // Stock Boundary Tests

        [TestMethod]
        public void Stock_NotBelowZero()
        {
            FurnitureItem item = new FurnitureItem(10008, "Rocking Chair", "Living Room", 119.99, 3, "Zone A");
            int quantityToSell = 3;
            Assert.IsTrue(quantityToSell <= item.StockLevel);
            item.StockLevel -= quantityToSell;
            item.QuantitySold += quantityToSell;
            Assert.AreEqual(0, item.StockLevel);
        }

        [TestMethod]
        public void Stock_Zero_OutOfStock()
        {
            FurnitureItem item = new FurnitureItem(10009, "Glass Table", "Dining Room", 249.99, 0, "Zone B");
            Assert.AreEqual(0, item.StockLevel);
        }
    }
}