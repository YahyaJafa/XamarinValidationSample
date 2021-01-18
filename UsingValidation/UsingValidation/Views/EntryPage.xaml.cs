using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingValidation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UsingValidation.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryPage : ContentPage
    {
        EntryViewModel viewModel => BindingContext as EntryViewModel;

        public EntryPage()
        {
            InitializeComponent();
            BindingContextChanged += EntryPage_BindingContextChanged;
            BindingContext = new EntryViewModel();
        }

        private void EntryPage_BindingContextChanged(object sender, EventArgs e)
        {
            viewModel.ErrorsChanged += ViewModel_ErrorsChanged;
        }

        private void ViewModel_ErrorsChanged(object sender, System.ComponentModel.DataErrorsChangedEventArgs e)
        {
            var propHasErrors = (viewModel.GetErrors(e.PropertyName) as List<string>)?.Any() == true;

            switch (e.PropertyName)
            {
                case nameof(viewModel.Title):
                    title.LabelColor = propHasErrors ? Color.Red : Color.Black;
                    break;

                case nameof(viewModel.Rating):
                    rating.LabelColor = propHasErrors ? Color.Red : Color.Black;
                    break;

                default:
                    break;
            }

        }
    }
}