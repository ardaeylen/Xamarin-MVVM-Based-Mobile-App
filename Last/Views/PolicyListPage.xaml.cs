using Last.Models;
using Last.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Last.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PolicyListPage : ContentPage
    {
        public User User { get; set; }
        public PolicyListPage(User user)
        {
            InitializeComponent();
            BindingContext = new PolicyListPageViewModel(user);
            User = user;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Policy policy = ((ListView)sender).SelectedItem as Policy;
            if(policy == null)
            {
                return;
            }
            else
            {
                await App.Current.MainPage.Navigation.PushAsync(new DetailedPage(policy, User));
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new AddPolicyPage(User));
        }
    }
}