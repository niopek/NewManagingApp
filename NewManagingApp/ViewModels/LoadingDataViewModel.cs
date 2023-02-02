using NewManagingApp.Services;
using NewManagingApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Data;
using NewManagingApp.Repository;
using NewManagingApp.Classes;

namespace NewManagingApp.ViewModels
{
    internal class LoadingDataViewModel : BaseViewModel
    {
        public int NumberOfIndeks { get; set; }
        public int NumberOfOrders { get; set; }
        public int NumberOfIndeksDetails { get; set; }
        private decimal _valueOfAllOrders { get; set; }
        public decimal ValueOfOrders
        {
            get
            {
                _valueOfAllOrders = 0;
                foreach (IndeksDetails i in Lists.ListsOfIndeksDetails)
                {
                    _valueOfAllOrders += i.TotalPrice;
                }
                return _valueOfAllOrders;
            }
        }

        public string? Path { get; set; }
        public bool IsFindByRaportChecked { get; set; }


        private ICommand? LoadFilePath = null;

        public ICommand LoadFilePathCommand
        {
            get
            {
                LoadFilePath ??= new RelayCommand(
                    async (o) =>
                    {
                        Path = await FileNameToString.GetString();
                        OnPropertyChanged(nameof(Path));
                        //MessageBox.Show(Path);
                    });

                return LoadFilePath;
            }
        }
        private ICommand? LoadExcel = null;

        public ICommand LoadExcelCommand
        {
            get
            {
                LoadExcel ??= new RelayCommand(
                    async (o) =>
                    {
                        DataTable dataTable = await LoadingExcelService.GetDataTableFromExcel(Path!);

                        if (!IsFindByRaportChecked)
                        {
                            Lists.ListOfIndeks = await LoadingExcelService.DataTableToListOfBaseIndeks(dataTable);
                            NumberOfIndeks = Lists.ListOfIndeks.Count;
                            OnPropertyChanged(nameof(NumberOfIndeks));
                            MessageBox.Show($"Wczytano {NumberOfIndeks} Indeksow");
                        }
                        else
                        {
                            Lists.ListOfOrders = await LoadingExcelService.DataTableToListOfOrders(dataTable);
                            NumberOfOrders = Lists.ListOfOrders.Count;
                            Lists.ListsOfIndeksDetails = Lists.ListOfOrders.OrdersToListOfIndeks();
                            NumberOfIndeksDetails = Lists.ListsOfIndeksDetails.Count;
                            OnPropertyChanged(nameof(NumberOfOrders));
                            OnPropertyChanged(nameof(ValueOfOrders));
                            OnPropertyChanged(nameof(NumberOfIndeksDetails));
                            MessageBox.Show($"Wczytano {NumberOfOrders} zamowien");
                        }
                        
                    });

                return LoadExcel;
            }
        }
    }


}
