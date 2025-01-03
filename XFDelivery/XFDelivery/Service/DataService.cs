using System.Collections.ObjectModel;
using Xamarin.Forms;
using XFDelivery.Models;

namespace XFDelivery.Service
{
    public class DataService
    {
        private static Item[] _items = new[]
        {
            new Item()
            {
                description = "Margherita",
                groups = new [] {GroupType.All, GroupType.Pizza},
                complement = "Tomato sauce, fresh mozzarella, olive oil, fresh basi",
                image = "item1",
                calories = 76,
                price = 45,
                rating = 4.2,
                favorite = true
            },
            new Item()
            {
                description = "Rughetta",
                groups = new [] {GroupType.All, GroupType.Pizza},
                complement = "Arugula, Cherry Tomatoes, Artichokes, Shaved Parmigiano, Lemon/E.V.O.O. Dressing",
                calories = 70,
                image = "item2",
                price = 59,
                rating = 3.8,
                favorite = false
            },
            new Item()
            {
                description = "Banoffie Pie",
                groups = new [] {GroupType.All, GroupType.Burgers},
                complement = "Breaded chicken, ham and bacon, drizzled with homemade rach",
                image = "item3",
                calories = 85,
                price = 106,
                rating = 4.9,
                favorite = true
            }
        };

        private static Group[] _groups = new[]
        {
            new Group()
            {
                description = "All",
                image = "brigadeiro",
                groupType = GroupType.All,
                selected = true,
                backgroundColor = Color.FromHex("#FF8920")
            },
            new Group()
            {
                description = "Pizza",
                image = "pizza",
                groupType = GroupType.Pizza,
                selected = false,
                backgroundColor = Color.FromHex("#FFFFFF")
            },
            new Group()
            {
                description = "Burgers",
                image = "burger",
                groupType = GroupType.Burgers,
                selected = false,
                backgroundColor = Color.FromHex("#FFFFFF")
            },
            new Group()
            {
                description = "Asian",
                image = "junk_food",
                groupType = GroupType.Asian,
                selected = false,
                backgroundColor = Color.FromHex("#FFFFFF")
            }
        };

        private static ObservableCollection<Item> _shoppingCart = new ObservableCollection<Item>();

        public static ObservableCollection<Group> GetGroups()
        {
            return new ObservableCollection<Group>(_groups);
        }

        public static ObservableCollection<Item> GetItems()
        {
            return new ObservableCollection<Item>(_items);
        }

        public static void AddToShoppingCart(Item item)
        {
            _shoppingCart.Add(item);
        }

        public static void RemoveFromShoppingCart(Item item)
        {
            _shoppingCart.Remove(item);
        }
    }
}
