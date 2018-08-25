using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinStarWars.Models;
using XamarinStarWars.Views;

namespace XamarinStarWars.ViewModels
{
    public class PeopleViewModel : BaseViewModel
    {
        private People _People = new People();
        public People People
        {
            get
            {
                return _People;
            }
            set
            {
                _People = value; OnPropertyChanged();
            }
        }
        public ICommand ShowFilmsComand { get; set; }

        public PeopleViewModel() : base("Show Poeple")
        {
            RefreshCommand = new Command(async () => await LoadData(), () => !IsBusy);
            ItemClickCommand = new Command<People>(async (item) => await ItemClickCommandExecuteAsync(item));
            ShowFilmsComand = new Command(async () => await ShowFilmsExecuteAsync());
        
        }

        async Task ShowFilmsExecuteAsync()
        {
            IsBusy = true;
            var peopleFilmPage = new PeopleFilmPage();
            await peopleFilmPage.ViewModel.Initialize(People);
            await Navigation.PushAsync(peopleFilmPage);
            IsBusy = false;
        }

        public override async Task Initialize(object parameters)
        {
            People = parameters as People;
            Title = People.Name;

            await LoadData();
        }
        async Task ItemClickCommandExecuteAsync(People people)
        {
            
        }

        async Task LoadData()
        {
            
        }
    }
}
