using DynamicData;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WpfApp2.Models
{
    public class Shop : ReactiveObject
    {
        private readonly SourceList<Product> _products = new SourceList<Product>();

        [Reactive]
        public int Id { get; set; }

        [Reactive]
        public string Name { get; set; }

        private ReadOnlyObservableCollection<Product> readOnlyProducts;
        public ReadOnlyObservableCollection<Product> Products => readOnlyProducts;

        public Shop(IEnumerable<Product> products)
        {
            _products.AddRange(products);
            _products.Connect()
                .Bind(out readOnlyProducts)
                .Subscribe();
        }

    }
}
