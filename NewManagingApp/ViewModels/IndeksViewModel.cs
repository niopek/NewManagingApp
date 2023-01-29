using NewManagingApp.Classes;
using NewManagingApp.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NewManagingApp.ViewModels
{
    internal class IndeksViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<Indeks> listOfIndeks = new();

        private ICommand? showListOfIndeks = null;
        public IndeksViewModel()
        {
            
        }


        public ICommand ShowListOfIndeks()
        {
            if (showListOfIndeks == null) showListOfIndeks = new RelayCommand(
                (object o)=>
                {
                    listOfIndeks = Lists.ListOfIndeks;
                    OnPropertyChanged(nameof(listOfIndeks));
                },
                (object o) =>
                {
                    return true;
                });
            return showListOfIndeks;
        }


        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
