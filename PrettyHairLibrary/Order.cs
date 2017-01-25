using PrettyHairLibrary.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PrettyHairLibrary
{
    public enum picked
    {
        Processed,
        NotProcessed,
        BeingProcessed,
        Canceled
    }
    public class Order : INotifyPropertyChanged
    {
        // Unique key for the product, and then the amount of this product in the order
        Dictionary<ProductType, int> orderlines = new Dictionary<ProductType, int>();
        private DateTime deliveryDate;
        private DateTime orderDate;
        private EntityKeyGenerator EKR = EntityKeyGenerator.Instance;

        public event PropertyChangedEventHandler PropertyChanged;
        public string DeliveryDate {
            get {
                return deliveryDate.ToString();
                }
        }

        public string OrderDate
        {
            get
            {
                return orderDate.ToString();
            }
        }
        public picked ProcessStatus { get; set; }
        public int OrderId { get; private set; } 
        
        public Order(int orderid, DateTime dd, DateTime od, Dictionary<ProductType, int> ol, picked status)
        {
            
            orderlines = ol;
            deliveryDate = dd;
            orderDate = od;
            this.OrderId = orderid;
            this.ProcessStatus = status;
        }

        public Order(DateTime dd, DateTime od, Dictionary<ProductType, int> ol)
        {
            orderlines = ol;
            deliveryDate = dd;
            orderDate = od;
            OrderId = EKR.NextKey;
            ProcessStatus = picked.NotProcessed;
        }
        public Order()
        {

        }
        
        public bool CheckQuantity()
        {
            bool cond = true;

            foreach(KeyValuePair<ProductType,int> p in orderlines)
            {
                if (p.Key.Amount < p.Value) {
                    cond = false;
                }
            }
            return cond;
        }

        public Dictionary<ProductType, int> GetOrderLines()
        {
            return orderlines;
        }

        public override string ToString()
        {
            string orderString = "order [deliverydate="+ this.deliveryDate +", orderdate="+this.orderDate+"]";
            return orderString;
        }
         /*public event PropertyChangedEventHandler PropertyChanged;

            private void RaisePropertyChanged(string property)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                }
            }
            */
    }
}
