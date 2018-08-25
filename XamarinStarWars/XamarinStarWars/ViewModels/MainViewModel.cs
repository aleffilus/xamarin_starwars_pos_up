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
using System.Linq;

namespace XamarinStarWars.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<People> Peoples { get; set; } = new ObservableCollection<People>();
        public String Next { get; set; }
        bool isShowMore = true;
        public bool IsShowMore
        {
            get { return isShowMore; }
            set { isShowMore = value; OnPropertyChanged(); }
        }

        public String search = "";
        public String Search {
            get { return search; }
            set { search = value; OnPropertyChanged(); }
        }

        public ICommand ShowMoreComand { get; set; }
        public ICommand SearchPeopleComand { get; set; }
        public List<People> peoplesOriginal = new List<People>();

        public MainViewModel() : base("Peoples Star Wars")
        {
            RefreshCommand = new Command(async () => await LoadData(null), () => !IsBusy);
            ItemClickCommand = new Command<People>(async (item) => await ItemClickCommandExecuteAsync(item));
            ShowMoreComand = new Command(async () => await LoadData(Next), () => !IsBusy);
            SearchPeopleComand = new Command(async () => await SeachPeople());
        }

        public override async Task Initialize(object parameters = null) => await LoadData(null);

        async Task SeachPeople ()
        {
            Peoples.Clear();
            var listaFiltrada = new List<People>();
            if (Search.Equals(""))
            {
                listaFiltrada = peoplesOriginal;
            } else
            {
                listaFiltrada = peoplesOriginal.Where(people => people.Name.ToLower().Contains(Search.ToLower())).ToList();
            }

            foreach (var people in listaFiltrada)
            {
                Peoples.Add(people);
            }
        }

        async Task ItemClickCommandExecuteAsync(People people)
        {
            Exception error = null;

            try
            {
                var peoplePage = new PeoplePage();
                await peoplePage.ViewModel.Initialize(people);
                await Navigation.PushAsync(peoplePage);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error when click people: " + ex);
                error = ex;
            }
            finally
            {
                IsBusy = false;
            }

            if (error != null)
                await ShowAlertAsync($"Error when show {people.Name}!", error.Message, "OK");
        }

        async Task LoadData(String url)
        {
            if (IsBusy)
                return;

            Exception error = null;

            try
            {
                IsBusy = true;

                var resultPeoples = await Api.GetAllPeopleAsync(url);
                Next = resultPeoples.Next;
                if (url == null)
                {
                    peoplesOriginal.Clear();
                    IsShowMore = true;
                }
                if (resultPeoples.Next == null)
                {
                    IsShowMore = false;
                }

                peoplesOriginal.AddRange(resultPeoples.Peoples);
                Peoples.Clear();

                foreach (var people in peoplesOriginal) { 
                    Peoples.Add(people);
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
