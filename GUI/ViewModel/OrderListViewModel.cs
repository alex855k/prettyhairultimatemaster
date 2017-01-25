using GUI;
using System.Collections.ObjectModel;
using PrettyHairLibrary;

namespace View.ViewModel
{
    public class OrderListViewModel
    {
        public OrderRepository ORep = OrderRepository.Instance;

        public ObservableCollection<Order> AllOrders
        {
            get;
            set;
        }

        public void Loaded()
        {
            ObservableCollection<Order> ord = new ObservableCollection<Order>();

            foreach (Order o in ORep.GetUnproccessedOrders())
            {
                ord.Add(o);
            }
            AllOrders = ord;
        }
    }
}
