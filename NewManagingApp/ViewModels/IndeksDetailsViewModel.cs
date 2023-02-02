using NewManagingApp.Classes;
using NewManagingApp.Repository;
using NewManagingApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NewManagingApp.ViewModels
{
    internal class IndeksDetailsViewModel : BaseViewModel
    {
        public ObservableCollection<IndeksDetails> ListOfIndeksDetails { get; set; } = new();

        private ICommand? showListOfIndeksDetails = null;
        public string? FilterText { get; set; }

        public bool IsFindByNameChecked { get; set; }
        private int _numberOfOrders { get; set; }
        public int NumberOfOrders { 
            get 
            {
                _numberOfOrders = 0;
                foreach (IndeksDetails i in ListOfIndeksDetails) 
                {
                    _numberOfOrders += i.OrdersCount;
                } 
                return _numberOfOrders;
            }
        }
        public int NumberOfIndeksDetails { get; set; }
        private decimal _valueOfAllOrders { get; set; }
        public decimal ValueOfOrders
        {
            get
            {
                _valueOfAllOrders = 0;
                foreach (IndeksDetails i in ListOfIndeksDetails)
                {
                    _valueOfAllOrders += i.TotalPrice;
                }
                return _valueOfAllOrders;
            }
        }

        public ICommand ShowListOfIndeksDetails
        {
            get
            {
                showListOfIndeksDetails ??= new RelayCommand(
                    (o) =>
                    {
                        ListOfIndeksDetails = IndeksService<IndeksDetails>.FindList(FilterText!, Lists.ListsOfIndeksDetails, IsFindByNameChecked);
                        NumberOfIndeksDetails = ListOfIndeksDetails.Count;
                        OnPropertyChanged(nameof(ListOfIndeksDetails));
                        OnPropertyChanged(nameof(NumberOfIndeksDetails));
                        OnPropertyChanged(nameof(NumberOfOrders));
                        OnPropertyChanged(nameof(ValueOfOrders));
                    });

                return showListOfIndeksDetails;
            }
        }
    }
}
