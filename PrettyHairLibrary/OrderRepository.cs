using System;
using System.Collections.Generic;
using PrettyHairLibrary;
using PrettyHairLibrary.Database;

namespace PrettyHairLibrary
{

    public class OrderRepository
    {
        private static OrderRepository instance;
        public ProductTypeRepository pRep = ProductTypeRepository.Instance;
        public event TickHandler Tick;
        public EventArgs e = null;
        public delegate void TickHandler(OrderRepository m, EventArgs e);
        private List<Order> _orders = new List<Order>();


        private OrderRepository() {
            this.LoadEverything();
        }

        public static OrderRepository Instance{
            get {
                if (instance == null) {
                    instance = new OrderRepository();
                }
                return instance;
                }
            }

        public void Add(Order o)
        {
            _orders.Add(o);
            this.ReceivedOrderNotification(o);
            if (!o.CheckQuantity()) NotifPurchaserAboutAmount(o); 
        }

        private void ReceivedOrderNotification(Order o)
        {
            Tick?.Invoke(this, e);
        }

        private void NotifPurchaserAboutAmount(Order o)
        {
            Tick?.Invoke(this, e);
        }


        public void Remove(Order o) {
            _orders.Remove(o);
        }

        public void Remove(int orderid)
        {
            _orders.Remove(FindOrder(orderid));
        }

        public Order FindOrder(int orderid)
        {
            Order o = null;
            foreach (Order ord in _orders)
            {
                if (ord.OrderId == orderid) o = ord;
            }
            return o;
        }

        public Order GetOrder(int orderid)
        {
            return FindOrder(orderid);
        }
        //Local version, make DB query instead
        public List<Order> GetUnproccessedOrders()
        {
            List<Order> orders = new List<Order>();
            foreach (Order ord in _orders)
            {
               if ((ord.ProcessStatus == picked.NotProcessed)) orders.Add(ord);
            }
            return orders;
        }

        public void GetUnprocessedOrders()
        {
                
        }

        public void GetOrders()
        {
            
        }

        public void LoadEverything()
        {

            // Creating local instance of productTypes
            pRep.Add(new ProductType(1,"Shampoo", 300, 10));
            pRep.Add(new ProductType(2,"Gel", 20, 20));
            pRep.Add(new ProductType(3,"L'oreal because you're trash", 40, 5));
            pRep.Add(new ProductType(4,"Rufies", 10, 4));
            pRep.Add(new ProductType(5,"Brush", 100, 6));

            // Creating local instances but should pull from database instead
            Dictionary<ProductType, int> orderLine1 = new Dictionary<ProductType, int>();
            orderLine1.Add(pRep.GetProduct(1), 4);
            orderLine1.Add(pRep.GetProduct(4), 2);
            
            Dictionary<ProductType, int> orderLine2 = new Dictionary<ProductType , int>();
            orderLine2.Add(pRep.GetProduct(5), 2);
            orderLine2.Add(pRep.GetProduct(2), 5);

            _orders.Add(new Order(DateTime.Now, DateTime.Now, orderLine1));
            _orders.Add(new Order(DateTime.Now, DateTime.Now, orderLine2));

        }
    }
}
