using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITestDemo.MarkupExtensions;
using Xamarin.Forms;

namespace UITestDemo
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string username;

        public string Username {
            get => username;
            set {
                username = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Username)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = new MainPageViewModel();
            InitializeComponent();
        }

        private void ToggleTestModeButton_Clicked(object sender, EventArgs e)
        {
            UITestModeExtension.IsInUiTestMode = !UITestModeExtension.IsInUiTestMode;
            Application.Current.MainPage = new MainPage();
        }
    }
}
