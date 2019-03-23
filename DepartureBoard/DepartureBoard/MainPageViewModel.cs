using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DepartureBoard
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        private IDataConnector _conn;
        public MainPageViewModel(IDataConnector conn)
        {
            this._conn = conn;
            DepartureEntries = new ObservableCollection<Departure>();
            this.LoadData();
            ReloadCommand = new Command(() => LoadData());
        }

        private async Task LoadData()
        {
            var departures = await this._conn.GetDepartures();
            DepartureEntries = new ObservableCollection<Departure>(departures);
        }
        public ICommand ReloadCommand { private set; get; }


        private ObservableCollection<Departure> _departureEntries;
        public ObservableCollection<Departure> DepartureEntries
        {
            get => _departureEntries;
            set
            {
                _departureEntries = value;
                OnPropertyChanged(nameof(DepartureEntries));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                this.PropertyChanged(this, e);
            }
        }
    }
}
