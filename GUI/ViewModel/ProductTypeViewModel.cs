using GUI;
using System.Collections.ObjectModel;
using PrettyHairLibrary;

namespace View.ViewModel
{
    public class ProductTypeViewModel
    {

        public ObservableCollection<Order> UnprocessedOrders
        {
            get;
            set;
        }

        public ObservableCollection<Order> AllOrders
        {
            get;
            set;
        }

        public void Loaded() {

        }

    }
}
