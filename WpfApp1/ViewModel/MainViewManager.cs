using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModel.Command;
namespace WpfApp1.ViewModel
{
    public class MainViewManager : INotifyPropertyChanged
    {

        private double celsia;

        private double farengate;

        private double kelvin;



        public double Celsia
        {
            get { return celsia; }
            set
            {
                celsia = value;
                OnPropertyChanged("Celsia");
            }
        }
        public double Farengate
        {
            get { return farengate; }
            set
            {
                farengate = value;
                OnPropertyChanged("Farengate");
            }
        }
        public double Kelvin
        {
            get { return kelvin; }
            set
            {
                kelvin = value;
                OnPropertyChanged("Kelvin");
            }
        }

        private RelayCommand _ConvertFromC;
        public RelayCommand ConvertFromC
        {
            get { return _ConvertFromC ?? (_ConvertFromC = new RelayCommand(o => ConvertCtoFandK())); }
        }

        private RelayCommand _convertFormF;
        public RelayCommand ConvertFormF
        {
            get { return _convertFormF ?? (_convertFormF = new RelayCommand(o => ConvertFtoCandK())); }
        }
        private RelayCommand _convertFormK;
        public RelayCommand ConvertFormK
        {
            get { return _convertFormK ?? (_convertFormK = new RelayCommand(o => ConvertKtoCandF())); }
        }

        public void ConvertCtoFandK()
        {
            Kelvin = Celsia + 273;
            Farengate = Celsia * 1.8f + 32;
        }
        private void ConvertKtoCandF()
        {
            Celsia = Kelvin - 273;
            Farengate = Kelvin * 1.8 - 459;
        }
        private void ConvertFtoCandK()
        {
            Kelvin = (Farengate + 459) / 1.8;
            Celsia = (Farengate - 32) / 1.8;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
