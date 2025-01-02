using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XFDelivery.Models;
using XFDelivery.Service;
using XFDelivery.ViewModel;
using XFDelivery.Views;

namespace XFDelivery.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            NavigateToDetailPageCommand = new Command<Item>(async (model) => await ExecuteNavigateToDetailPageCommand(model));
            SelectGroupCommand = new Command<Group>((model) => ExecuteSelectGroupCommand(model));
            GetGroups();
            GetItems();
        }

        public Command SelectGroupCommand { get; }
        public Command NavigateToDetailPageCommand { get; }
        public ObservableCollection<Group> Groups { get; set; }
        public ObservableCollection<Item> Items { get; set; }

        void GetGroups()
        {
            Groups = DataService.GetGroups();
        }

        void GetItems()
        {
            Items = DataService.GetItems();
        }

        private async Task ExecuteNavigateToDetailPageCommand(Item item)
        {
            await Navigation.PushAsync(new DetailPage(item));
        }

        private void ExecuteSelectGroupCommand(Group group)
        {
            var index = Groups
                .ToList()
                .FindIndex(g => g.description == group.description);

            if (index > -1)
            {
                UnselectGroupItems();

                Groups[index].selected = true;
                Groups[index].backgroundColor = Color.FromHex("#FF8920");
            }

            DataService.GetItems().ForEach(item =>
            {
                if (item.groups.Contains(group.description) && !Items.Contains(item))
                {
                    Items.Add(item);
                }
                if (!item.groups.Contains(group.description) && Items.Contains(item))
                {
                    Items.Remove(item);
                }
            });
        }

        private void UnselectGroupItems()
        {
            Groups.ForEach(group =>
            {
                group.selected = false;
                group.backgroundColor = Color.FromHex("#FFFFFF");
            });
        }
    }
}
