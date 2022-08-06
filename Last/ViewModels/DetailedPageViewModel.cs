using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Last.Models;
namespace Last.ViewModels
{
    public class DetailedPageViewModel : BaseViewModel
    {
        public Policy Policy { get; set; }
        public CarPolicy CarPolicy { get; set; }
        public User User { get; set; }
   
        public DetailedPageViewModel(Policy policy,User user)
        {
            Policy = policy;
            User = user;
            GetCarPolicy(Policy.PoliceNo);
        }
        public async void GetCarPolicy(int policeno)
        {
            CarPolicy = await App.CarPolicyRestService.GetCarPolicy(policeno);
        }
    }
}
