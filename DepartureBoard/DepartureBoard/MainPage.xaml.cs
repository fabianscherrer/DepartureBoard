using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DepartureBoard
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel _vm;
        public MainPage()
        {
            InitializeComponent();
            var apiDataConnector = new ApiDataConnector();
            _vm = new MainPageViewModel(apiDataConnector);
            this.BindingContext = _vm;
        }
    }
}
