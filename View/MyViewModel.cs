using PrettyHairLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{

    public class MyViewModel
    {

        OrderRepository oRep = new OrderRepository();
        ProductTypeRepository proRep = new ProductTypeRepository();

        public List<Order> checkInventory() {
            Dictionary<ProductType, int> orderlines = new Dictionary<ProductType, int>();
            orderlines.Add(new ProductType())
            DateTime date1 = new DateTime(2016, 7, 18);
            oRep.Add(new Order(1, DateTime.Today, date1));
            oRep.Add(new Order(1, date1));
            return oRep.GetUnproccessedOrders();
        }
    }

}
