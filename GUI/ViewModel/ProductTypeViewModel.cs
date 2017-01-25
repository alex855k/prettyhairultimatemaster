using GUI;
using System.Collections.ObjectModel;
using PrettyHairLibrary;
using System.Collections.Generic;

namespace View.ViewModel
{
    public class ProductTypeViewModel
    {

        ProductTypeRepository proRep = ProductTypeRepository.Instance;
      
        public ObservableCollection<ProductType> ProductTypeList
        {
            get;
            set;
        }

        public void Loaded() {
            ObservableCollection<ProductType> ptl = new ObservableCollection<ProductType>();

            foreach (KeyValuePair<int,ProductType> k in proRep.GetAllProductTypes())
            {
                ptl.Add(k.Value);
            }
            ProductTypeList = ptl;
        }
    }
}
