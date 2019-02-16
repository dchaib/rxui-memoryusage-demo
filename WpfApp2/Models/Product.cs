using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace WpfApp2.Models
{
    public class Product : ReactiveObject
    {
        [Reactive]
        public int Id { get; set; }

        [Reactive]
        public string Name { get; set; }
    }
}
