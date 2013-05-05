using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Domain;
using Moq;

namespace AcceptanceTestWithSpecFlow.Specs
{
    [TestClass]
    public class BasketTest
    {
        private Basket basket;
        private ItemList items;

        [TestInitialize]
        public void SetUp()
        {
            basket = new Basket();
            items = new ItemList();
            items.Add(new Item("a game", 3));
        }

        [TestMethod]
        public void ExistsItemsWhenPurchasing()
        {
            basket.AddItems(items);
            basket.Purchase();

            Assert.IsFalse(basket.IsEmpty());
        }

        [TestMethod]
        public void SelectsItemsWhenPurchasing()
        {
            basket.AddItems(items);

            basket.Purchase();

            Assert.AreEqual(items, basket.SelectedItems());
        }

        [TestMethod]
        public void PayBasketWithCreditCardReturnsTrue()
        {
            basket.AddItems(items);
            var payment = new Mock<Payment>();

            basket.SetPayment(payment.Object);
            basket.AddCreditCard("q32q324");

            payment.Setup(p => p.Pay(basket.CalculateTotalOrder(), basket.CreditCard)).Returns(true);

            bool result = basket.Purchase();

            payment.Verify(p => p.Pay(basket.CalculateTotalOrder(), basket.CreditCard));
        }

        [TestMethod]
        public void EmptyBasketDeleteSelectedItems()
        {
            basket.AddItems(items);

            basket.Empty();

            Assert.IsTrue(basket.IsEmpty());
        }
    }
}
