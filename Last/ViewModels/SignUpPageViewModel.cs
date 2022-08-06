using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Last.Models;
namespace Last.ViewModels
{
    public class SignUpPageViewModel : BaseViewModel
    {
        private string name;
        private string surname;
        private string username;
        private string password;
        public ICommand SignUpCommand { get; set; }
        public SignUpPageViewModel()
        {
            SignUpCommand = new Command(SignUpFunction);
        }
        public async void SignUpFunction()
        {
            User newUser = new User();
            newUser.Name = Name;
            newUser.Surname = Surname;
            newUser.Password = Password;
            newUser.UserName = Username;
            string status = await App.Userservice.AddUser(newUser);
            if(status != "0")
            {
             await App.Current.MainPage.DisplayAlert("Success", "Registration successful", "ok");
             await App.Current.MainPage.Navigation.PopToRootAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Failed", "Registration failed", "try again");
            }
          

        }
        public string Name
        {
            get => name; set
            {
                if (name != value)
                {
                    name = value;
                }
            }
        }
        public string Surname
        {
            get => surname; set
            {
                if (surname != value)
                {
                    surname = value;
                }
            }
        }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
       
    }
}
