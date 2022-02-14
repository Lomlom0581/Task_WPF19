using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Task_WPF19.Models;

namespace Task_WPF19.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnProprtyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private double radius;
        public double Radius
        {
            get => radius;
            set
            {
                radius = value;
                OnProprtyChanged();
            }
        }

        private double cicleLenth;
        public double CicleLength
        {
            get => cicleLenth;
            set
            {
                cicleLenth = value;
                OnProprtyChanged();
            }
        }

        public ICommand CicleCommand { get; }
        private void OnCicleCommandExecute(object p)
        {
            CicleLength = Calculation.Calculate(Radius);
        }

        private bool CanCicleCommandExecute(object p)
        {
            return Radius >= 0;
        }

        public MainWindowViewModel()
        {
            CicleCommand = new RelayCommand(OnCicleCommandExecute, CanCicleCommandExecute);
        }
    }
}
