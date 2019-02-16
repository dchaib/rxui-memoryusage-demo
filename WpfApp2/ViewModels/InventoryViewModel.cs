using DynamicData;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WpfApp2.Models;

namespace WpfApp2.ViewModels
{
    public class InventoryViewModel : ReactiveObject
    {

        private readonly ReadOnlyObservableCollection<InventoryItemViewModel> inventoryItems;
        public ReadOnlyObservableCollection<InventoryItemViewModel> InventoryItems => inventoryItems;

        public InventoryViewModel(IObservableList<Shop> shops)
        {
            shops.Connect()
                .TransformMany(s => s.Products.Select(p => new InventoryItemViewModel(s, p)), new InventoryItemViewModelEqualityComparer())
                .Bind(out inventoryItems)
                .Subscribe();
        }

        private class InventoryItemViewModelEqualityComparer : IEqualityComparer<InventoryItemViewModel>
        {
            public bool Equals(InventoryItemViewModel x, InventoryItemViewModel y)
            {
                if (x == null || y == null)
                    return false;

                return x.Product.Id == y.Product.Id;
            }

            public int GetHashCode(InventoryItemViewModel obj)
            {
                return obj.Product.Id.GetHashCode();
            }
        }
    }
}
