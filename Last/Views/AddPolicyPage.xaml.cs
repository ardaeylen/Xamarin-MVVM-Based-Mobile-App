using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Last.Models;
using Last.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Last.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPolicyPage : ContentPage
    {
        public Policy Policy { get; set; }
        public User User { get; set; }
        public AddPolicyPage(User u)
        {
            InitializeComponent();
            User = u;
            Policy = new Policy();
            BindingContext = new AddPolicyPageViewModel(u);
        }
    }
}