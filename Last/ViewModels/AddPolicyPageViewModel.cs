using Last.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Last.Views;
namespace Last.ViewModels
{
   public class AddPolicyPageViewModel : BaseViewModel
    {
        private User user;
        private Policy policy;
        private CarPolicy carPolicy;
        public ICommand AddPolicyCommand { get; set; }
        public List<string> Cars { get; set; }
        public List<string> InsuranceCompanies { get; set; }
        public AddPolicyPageViewModel(User u)
        {
            User = u;
            Policy = new Policy();
            CarPolicy = new CarPolicy();
            AddPolicyCommand = new Command(AddPolicyFunction);
            Cars = new List<string>()
            {
                "Mercedes",
                "Bmw",
                "Jeep",
                "Chevrolet",
                "Ford",
                "Opel",
                "Renault",
                "Pegouet"
            };
            InsuranceCompanies = new List<string>()
            {
                "Axa Sigorta",
                "Anadolu Sigorta",

            };
            
               
        }

        public User User { get => user; set => user = value; }
        public Policy Policy { get => policy; set => policy = value; }
        public CarPolicy CarPolicy { get => carPolicy; set => carPolicy = value; }
        public async void AddPolicyFunction()
        {

            Random random = new Random();
            Policy.Borc = random.NextDouble() * 2000 + 500;
            Policy.PoliceUrunGrubu = "Kasko";
            Policy.PrimTutari = Policy.Borc * 15 / 100;
            Policy.SirketAdi = "Axa Sigorta";
            Policy.TanzimTarihi = DateTime.Now;
            Policy.VadeTarihi = new DateTime(Policy.TanzimTarihi.Year + 3, Policy.TanzimTarihi.Month, Policy.TanzimTarihi.Day);
            Policy.UserId = User.UserId;
            Policy.Tip = "Araç";
            Policy.Teminatlar = "Araç Güvenliği";
            var response = await App.PolicyService.AddPolicy(Policy);
            if (response == "1")
            {
                await App.Current.MainPage.DisplayAlert("Bilgilendirme", "Teklif: " + Policy.Borc.ToString() + "TL", "ok");
                await App.Current.MainPage.Navigation.PopAsync();
                await App.Current.MainPage.Navigation.PopAsync();
                await App.Current.MainPage.Navigation.PushAsync(new PolicyListPage(User));
            }

        }
    }
}
