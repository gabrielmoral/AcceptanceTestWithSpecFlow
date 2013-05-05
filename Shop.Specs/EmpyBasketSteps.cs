using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Domain;
using System;
using TechTalk.SpecFlow;

namespace Shop.Specs
{
    [Binding]
    public class EmpyBasketSteps
    {
        private Basket basket;
        private ItemList items;

        [Given(@": I have selected then items")]
        public void GivenIHaveSelectedThenItems()
        {
            basket = new Basket();
            items = new ItemList();

            items.Add(new Item("item1", 1));
            items.Add(new Item("item2", 2));

            basket.AddItems(items);
        }
        
        [When(@": I empty the basket")]
        public void WhenIEmptyTheBasket()
        {
            basket.Empty();
        }
        
        [Then(@": I should see the basket empty")]
        public void ThenIShouldSeeTheBasketEmpty()
        {
            Assert.IsTrue(basket.IsEmpty());
        }
    }
}
