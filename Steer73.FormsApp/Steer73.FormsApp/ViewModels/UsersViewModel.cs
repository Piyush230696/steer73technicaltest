using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Steer73.FormsApp.Framework;
using Steer73.FormsApp.Model;

namespace Steer73.FormsApp.ViewModels
{
    public class UsersViewModel : ViewModel
    {
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;

        public UsersViewModel(
            IUserService userService,
            IMessageService messageService)
        {
            _userService = userService;
            _messageService = messageService;
        }

        public async Task Initialize()
        {
            IsBusy = true;
            try
            {
                

                var users = await _userService.GetUsers();

                foreach (var user in users)
                {
                    Users.Add(user);
                }
                
            }
            catch (Exception ex)
            {
                await _messageService.ShowError(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private bool _isbusy;
        public bool IsBusy
        {
            get => _isbusy;

            set => SetProperty(ref _isbusy, value);
           
        }
        

        public ICollection<User> Users { get; } = new ObservableCollection<User>();
    }
}
