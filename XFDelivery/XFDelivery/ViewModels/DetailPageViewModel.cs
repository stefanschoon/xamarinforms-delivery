using System.Threading.Tasks;
using Xamarin.Forms;
using XFDelivery.Models;
using XFDelivery.Service;
using XFDelivery.ViewModel;

namespace XFDelivery.ViewModels
{
    public class DetailPageViewModel : BaseViewModel
    {
        public DetailPageViewModel(INavigation navigation, Item item)
        {
            Navigation = navigation;
            PopDetailPageCommand = new Command(async () => await ExecutePopDetailPageCommand());
            AddQuantCommand = new Command(ExecuteAddQuantCommand);
            DeleteQuantCommand = new Command(ExecuteDeleteQuantCommand);
            SetFavoriteCommand = new Command(ExecuteSetFavoriteCommand);
            Item = item;
            Quant = 1;
        }

        public Command PopDetailPageCommand { get; }
        public Command AddQuantCommand { get; }
        public Command DeleteQuantCommand { get; }
        public Command SetFavoriteCommand { get; }
        public Item Item { get; set; }

        private int _quant;
        public int Quant
        {
            get { return _quant; }
            set { SetProperty(ref _quant, value); }
        }

        private bool _favorite;
        public bool Favorite
        {
            get { return _favorite; }
            set { SetProperty(ref _favorite, value); }
        }

        private async Task ExecutePopDetailPageCommand()
        {
            await Navigation.PopAsync();
        }

        private void ExecuteAddQuantCommand()
        {
            Quant += 1;
        }

        private void ExecuteDeleteQuantCommand()
        {
            if (Quant > 1)
                Quant -= 1;
        }

        private void ExecuteSetFavoriteCommand()
        {
            if (Favorite)
            {
                Favorite = false;
            }
            else
            {
                Favorite = true;
            }
        }

        private void ExecuteAddToShoppingCartCommand(Item item)
        {
            DataService.AddToShoppingCart(item);
        }

        private void ExecuteRemoveFromShoppingCartCommand(Item item)
        {
            DataService.RemoveFromShoppingCart(item);
        }
    }
}
