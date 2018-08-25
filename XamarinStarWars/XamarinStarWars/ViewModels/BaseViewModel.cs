using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinStarWars.Services;

namespace XamarinStarWars.Views
{   
   public abstract class BaseViewModel : BindableObject
    {
        public StarWarsService Api => new StarWarsService();
        public INavigation Navigation => Application.Current.MainPage.Navigation;

        public ICommand RefreshCommand { get; set; }
        public ICommand ItemClickCommand { get; set; }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; IsNotBusy = !value; OnPropertyChanged(); }
        }
        bool isNotBusy = true;
        public bool IsNotBusy
        {
            get { return isNotBusy; }
            set { isNotBusy = value; OnPropertyChanged(); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }

        public BaseViewModel(string title)
        {
            Title = title;
        }
        
        public async Task ShowAlertAsync(string title, string msg, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, msg, cancel);
        }

        public virtual Task Initialize(object parameters = null) => Task.FromResult(true);
    }   
}
