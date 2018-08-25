using Xamarin.Forms;
using XamarinStarWars.ViewModels;

namespace XamarinStarWars
{
    public partial class MainPage : ContentPage
	{
        public MainViewModel ViewModel
        {
            get
            {
                if (BindingContext == null)
                    BindingContext = new MainViewModel();

                return (BindingContext as MainViewModel);
            }
        }

        public MainPage()
        {
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.Initialize(null);
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {

        }
    }
}
