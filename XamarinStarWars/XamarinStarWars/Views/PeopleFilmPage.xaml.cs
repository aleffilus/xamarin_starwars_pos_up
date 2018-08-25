using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinStarWars.ViewModels;

namespace XamarinStarWars.Views
{
	public partial class PeopleFilmPage : ContentPage
	{
        public PeopleFilmViewModel ViewModel
        {
            get
            {
                if (BindingContext == null)
                    BindingContext = new PeopleFilmViewModel();

                return (BindingContext as PeopleFilmViewModel);
            }
        }

        public PeopleFilmPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}