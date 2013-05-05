using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Domain
{
    public class Basket
    {
        private ItemList items;
        private ItemList selectedItems = new ItemList();
        private string creditCard;
        private Payment payment;

        public string CreditCard
        {
            get
            {
                return creditCard;
            }
        }

        public void AddItems(ItemList items)
        {
            this.items = items;
        }

        public bool Purchase()
        {
            bool confirmation = false;

            selectedItems = items;
            bool hasCreditCard = HasCreditCard();
            if (hasCreditCard)
            {
                double totalOrder = CalculateTotalOrder();
                confirmation = payment.Pay(totalOrder, creditCard);
            }
            return confirmation;
        }

        public ItemList SelectedItems()
        {
            return selectedItems;
        }

        public bool IsEmpty()
        {
            bool isEmpty = false;
            if (items.IsEmpty() && selectedItems.IsEmpty())
            {
                isEmpty = true;
            }
            return isEmpty;
        }

        public void AddCreditCard(string creditCard)
        {
            this.creditCard = creditCard;
        }
              
        public void SetPayment(Payment payment)
        {
            this.payment = payment;
        }

        public double CalculateTotalOrder()
        {
            return selectedItems.CalcultateTotalItemsPrice();
        }

        public void Empty()
        {
            items = new ItemList();
            selectedItems = new ItemList();
        }

        private bool HasCreditCard()
        {
            return !string.IsNullOrEmpty(creditCard);
        }
    }
}
