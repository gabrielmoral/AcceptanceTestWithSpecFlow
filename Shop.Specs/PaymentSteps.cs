using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Domain;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Shop.Specs
{
    [Binding]
    public class PaymentSteps
    {
        private Basket basket;
        private ItemList items;

        [Given(@"I have selected the items")]
        public void GivenIHaveSelectedTheItems()
        {
            basket = new Basket();
            items = new ItemList();

            items.Add(new Item("item1", 2));
            items.Add(new Item("item2", 3));

            basket.AddItems(items);
        }

        [When(@"I write the credit card")]
        public void WhenIWriteTheCreditCard()
        {
            basket.AddCreditCard("1234567890");
        }

        [Then(@"I should see a confirmation message")]
        public void ThenIShouldSeeAConfirmationMessage()
        {
            Payment payment = new CreditCardPayment();
            basket.SetPayment(payment);
            Assert.IsTrue(basket.Purchase());
        }
    }
}



