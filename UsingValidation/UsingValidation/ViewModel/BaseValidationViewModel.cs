using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace UsingValidation.ViewModel
{
    /// <summary>
    /// A standard implementation of INotifyDataErrorInfo.
    /// This class and example are based on Ed Snider book "Mastering Xamarin Forms.., 3rd", Website:
    /// https://hub.packtpub.com/how-to-implement-data-validation-with-xamarin-forms/
    /// </summary>
    public class BaseValidationViewModel : BaseViewModel, INotifyDataErrorInfo
    {
        Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        /// <summary>
        /// The actual validation method wich is exposed to the
        /// implementing classes.
        /// </summary>
        /// <param name="rule">The Validation rule delegate for property.</param>
        /// <param name="error">The error sentence</param>
        /// <param name="propertyName">The name of property which is validated.</param>
        protected void Validate(Func<bool> rule, string error, 
                                [CallerMemberName] string propertyName = "")
        {
            if (string.IsNullOrWhiteSpace(propertyName)) return;

            if (_errors.ContainsKey(propertyName))
            {
                _errors.Remove(propertyName);
            }

            if (rule() == false)
            {
                _errors.Add(propertyName, new List<string> { error });
            }

            OnPropertyChanged(nameof(HasErrors));

            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        /// <summary>
        /// The standard implementation of INotifyDataErrorInfo interface:
        /// </summary>
        #region INotifyDataErroInfo

        // return true if the view model has any errors
        public bool HasErrors => _errors.Any(x => x.Value.Any());

        // event to notify that errors have changed:
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;


        public IEnumerable GetErrors(string propertyName)
        {
            if (!String.IsNullOrWhiteSpace(propertyName))
            {
                // If error(s) had been registered for this property then return it:
                if (_errors.ContainsKey(propertyName) && _errors[propertyName].Any())
                {
                    return _errors[propertyName].ToList();
                }
                else
                {
                    // If no error had been registered then return empty list:
                    return new List<string>();
                }
            }
            else
            {
                //if propertyName not defined return all registered errors:
                return _errors.SelectMany(err => err.Value.ToList()).ToList();
            }
        }
        #endregion
    }
}
