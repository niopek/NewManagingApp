using NewManagingApp.Classes;
using NewManagingApp.Interfaces;
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
    internal class IndeksViewModel : BaseViewModel
    {
        public ObservableCollection<Indeks> ListOfIndeks { get; set; } = new();

        private ICommand? showListOfIndeks = null;
        public string? FilterText { get; set; }

        public bool IsFindByNameChecked { get; set; }

        public ICommand ShowListOfIndeks
        {
            get
            {
                showListOfIndeks ??= new RelayCommand(
                    (o) =>
                    {
                        ListOfIndeks = IndeksService<Indeks>.FindList(FilterText!, Lists.ListOfIndeks ,IsFindByNameChecked);
                        OnPropertyChanged(nameof(ListOfIndeks));
                    });

                return showListOfIndeks;
            }
        }

        

       
    }
}
