using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Domain;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Shop.Specs
{
    [Binding]
    public class CheckOutSteps
    {
        private Basket basket;
        private ItemList items;

        [Given(@"I have a list of selected items")]
        public void GivenIHaveAListOfSelectedItems()
        {
            basket = new Basket();
            items = new ItemList();

            items.Add(new Item("item1", 1));
            items.Add(new Item("item2", 2));

            basket.AddItems(items);
        }
        
        [When(@"I want to buy them")]
        public void WhenIWantToBuyThem()
        {
            basket.Purchase();
        }
        
        [Then(@"I can see them before pay")]
        public void ThenICanSeeThemBeforePay()
        {
            ItemList selectedItems = basket.SelectedItems();

            Assert.AreEqual(items, selectedItems);
        }

       

    }
}
