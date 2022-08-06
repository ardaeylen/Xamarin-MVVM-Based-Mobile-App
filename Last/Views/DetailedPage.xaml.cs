using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Last.ViewModels;
using Last.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Last.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailedPage : ContentPage
    {
        public DetailedPage(Policy policy,User user)
        {
            InitializeComponent();
            BindingContext = new DetailedPageViewModel(policy,user);
        }
    }
}