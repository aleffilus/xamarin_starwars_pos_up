using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinStarWars.Models;
using XamarinStarWars.Views;

namespace XamarinStarWars.ViewModels
{
    public class PeopleFilmViewModel : BaseViewModel
    {

        public ObservableCollection<Film> Films { get; set; } = new ObservableCollection<Film>();

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

        public PeopleFilmViewModel() : base("Film Poeple")
        {
            RefreshCommand = new Command(async () => await LoadData(), () => !IsBusy);
            ItemClickCommand = new Command<People>(async (item) => await ItemClickCommandExecuteAsync(item));
        }

        public override async Task Initialize(object parameters)
        {
            People = parameters as People;
            Title = $"Films of {People.Name}";

            await LoadData();
        }
        async Task ItemClickCommandExecuteAsync(People people)
        {

        }

        async Task LoadData()
        {
            if (IsBusy)
                return;

            Exception error = null;

            try
            {
                IsBusy = true;
                Films.Clear();
                var resulFilms = await Api.GetFilmsByListUrl(People.Films);

                foreach (var film in resulFilms)
                {
                    Films.Add(film);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error when load data: " + ex);
                error = ex;
            }
            finally
            {
                IsBusy = false;
            }

            if (error != null)
                await ShowAlertAsync("Error when load data!", error.Message, "OK");
        }
    }
}
