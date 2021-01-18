using System;
using System.Collections.Generic;
using System.Text;
using UsingValidation.Models;
using Xamarin.Forms;

namespace UsingValidation.ViewModel
{
    public class EntryViewModel : BaseValidationViewModel
    {
        private string _Title;

        public string Title
        {
            get => _Title;
            set
            {
                if (_Title == value) return;
                _Title = value;
                
                // Anonymous method:
                //Validate(() => !string.IsNullOrWhiteSpace(_Title), "Title must be provided");

                //the same as defining outer method:
                Validate(NotEmptyTitle, "Title must be provided");

                OnPropertyChanged();
                SaveCommand.ChangeCanExecute();

            }
        }

        private bool NotEmptyTitle()
        {
            return string.IsNullOrWhiteSpace(_Title);
        }

        private DateTime _Date;

        public DateTime Date
        {
            get => _Date;
            set
            {
                if (_Date == value) return;
                _Date = value;
                OnPropertyChanged();
            }
        }

        int _Rating;
        public int Rating
        {
            get => _Rating;
            set
            {
                if (_Rating == value) return;
                _Rating = value;

                //another validation example:
                Validate(() => _Rating >= 1 && _Rating <= 5, "Rating must be between 1 and 5");
                OnPropertyChanged();
                SaveCommand.ChangeCanExecute();
            }
        }

        Command saveCommand;
        public Command SaveCommand => saveCommand ?? (saveCommand = new Command(Save, CanSave));

        private bool CanSave() => !string.IsNullOrWhiteSpace(Title) && !HasErrors;

        private void Save()
        {
            EntryModel entry = new EntryModel
            {
                Title = Title
            };
        }
    }
}
