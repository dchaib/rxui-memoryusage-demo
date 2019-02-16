using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using WpfApp2.Models;

namespace WpfApp2.ViewModels
{
    public class InventoryItemViewModel : ReactiveObject
    {
        public Shop Shop { get; }

        public Product Product { get; }

        public extern int ShopId { [ObservableAsProperty]get; }

        public extern string ShopName { [ObservableAsProperty]get; }

        public extern int ProductId { [ObservableAsProperty]get; }

        public extern string ProductName { [ObservableAsProperty]get; }


        public InventoryItemViewModel(Shop shop, Product product)
        {
            Shop = shop;
            Product = product;

            this.WhenAny(x => x.Shop.Id, x => x.Value).ToPropertyEx(this, x => x.ShopId, shop.Id);
            this.WhenAny(x => x.Shop.Name, x => x.Value).ToProperty(this, x => x.ShopName, shop.Name);
            this.WhenAny(x => x.Product.Id, x => x.Value).ToProperty(this, x => x.ProductId, product.Id);
            this.WhenAny(x => x.Product.Name, x => x.Value).ToProperty(this, x => x.ProductName, product.Name);
        }
    }
}