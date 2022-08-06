using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Last.Views;
using Last.Services;
namespace Last
{
    public partial class App : Application
    {
        public static UserRestService Userservice;
        public static PolicyRestService PolicyService;
        public static CarPolicyRestService CarPolicyRestService;
        public App()
        {
            InitializeComponent();
            Userservice = new UserRestService();
            PolicyService = new PolicyRestService();
            CarPolicyRestService = new CarPolicyRestService();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
