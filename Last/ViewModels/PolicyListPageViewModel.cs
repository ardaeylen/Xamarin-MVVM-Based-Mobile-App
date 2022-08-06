using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Last.Models;
using Last.Views;
using Xamarin.Forms;

namespace Last.ViewModels
{
    public class PolicyListPageViewModel : BaseViewModel
    {
        private User user;
        private ObservableCollection<Policy> policies;
        public PolicyListPageViewModel(User u)
        {
            user = u;
            GetPolicyList();
        }

        public User User { get => user; set => user = value; }
        public ObservableCollection<Policy> Policies { get => policies; set 
            {
                if(policies != value)
                {
                    policies = value;
                    OnPropertyChanged("Policies");
                }
            } 
        }

        public async void GetPolicyList()
        {
            Policies = new ObservableCollection<Policy>(await App.PolicyService.GetPoliciesAsync(User.UserId));
        }
    }
}
