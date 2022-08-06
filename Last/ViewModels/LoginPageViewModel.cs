using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Last.Views;
using Xamarin.Forms;
using Last.Models;
namespace Last.ViewModels
{
    class LoginPageViewModel : BaseViewModel
    {
        private string username;
        private string password;
        private string loginstatus;
        private ICommand logincommand;
        private ICommand signUpCommand;
        public LoginPageViewModel()
        {

            Logincommand = new Command(LoginFunction);
            SignUpCommand = new Command(GoToSignUpPage);
        }
        public async void LoginFunction()
        {
            User loggedInUser = await App.Userservice.GetUserByUsernameAndPasswordAsync(Username, Password);
            if (loggedInUser != null)
            {
                await App.Current.MainPage.Navigation.PushAsync(new PolicyListPage(loggedInUser));

            }
            else
            {
                loginstatus = "Oturum açma işlemi başarısız.";
            }
            OnPropertyChanged("Loginstatus");
        }
        public async void GoToSignUpPage()
        {
            await App.Current.MainPage.Navigation.PushAsync(new SignUpPage());
        }
        public string Username
        {
            get => username; set
            {
                if (username != value)
                {
                    username = value;
                }
            }
        }
        public string Password
        {
            get => password; set
            {
                if (password != value)
                {
                    password = value;
                }
            }
        }

        public string Loginstatus
        {
            get => loginstatus; set
            {
                if (loginstatus != value)
                {
                    loginstatus = value;

                }
            }
        }

        public ICommand Logincommand { get => logincommand; set => logincommand = value; }
        public ICommand SignUpCommand { get => signUpCommand; set => signUpCommand = value; }
    }
}
