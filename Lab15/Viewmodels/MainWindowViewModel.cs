using FluentValidation;
using Lab15.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab15.Viewmodels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            Model = new RegisterViewModel();
            RegisterCommand = new RegisterCommand();
        }

        public RegisterViewModel Model { get; set; }
        public ICommand RegisterCommand { get; set; }
    }

    public class RegisterViewModelValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterViewModelValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(6)
            .Must(x => x != x.ToUpper())
            .WithMessage("haslo musi zawierac co najmniej jedną wielką litere")
            .Matches(@".\d.");

            RuleFor(x => x.IsChecked)
                .Must(x => x);
        }
    }

    public class RegisterViewModel : INotifyPropertyChanged
    {
        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Email"));
                }
            }
        }

        private string _password; 
        public string Password   
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Password"));
                }
            }
        }

        private bool _ischecked;
        public bool IsChecked
        {
            get { return _ischecked; }
            set
            {
                if (_ischecked != value)
                {
                    _ischecked = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("IsChecked"));
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
