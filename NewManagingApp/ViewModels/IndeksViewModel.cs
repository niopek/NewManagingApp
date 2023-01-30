using NewManagingApp.Classes;
using NewManagingApp.Repository;
using NewManagingApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NewManagingApp.ViewModels
{
    internal class IndeksViewModel : INotifyPropertyChanged
    {
        private string? FilterText { get; set; }
        public string? FilterTextSetter
        {
            get
            {
                return FilterText;
            }
            set
            {
                FilterText = value;
                OnPropertyChanged(nameof(FilterTextSetter));
            }
        }
        public ObservableCollection<Indeks> ListOfIndeks { get; set; } = new();

        private ICommand? showListOfIndeks = null;
        public ICommand ShowListOfIndeks
        {
            get
            {
                if (showListOfIndeks == null) showListOfIndeks = new RelayCommand(
                    (o) =>
                    {
                        ListOfIndeks = IndeksService.FindList(FilterText!);
                        OnPropertyChanged(nameof(ListOfIndeks));
                    });
                return showListOfIndeks;
            }
        }





        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
