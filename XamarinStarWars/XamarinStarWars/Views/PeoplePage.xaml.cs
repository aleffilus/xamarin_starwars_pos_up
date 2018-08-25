using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinStarWars.Models;
using XamarinStarWars.ViewModels;

namespace XamarinStarWars.Views
{
	public partial class PeoplePage : ContentPage
	{
        public PeopleViewModel ViewModel
        {
            get
            {
                if (BindingContext == null)
                    BindingContext = new PeopleViewModel();

                return (BindingContext as PeopleViewModel);
            }
        }

        public PeoplePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}