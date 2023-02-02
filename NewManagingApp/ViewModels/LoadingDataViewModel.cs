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

namespace NewManagingApp.ViewModels
{
    internal class LoadingDataViewModel : BaseViewModel
    {
        public string? Path { get; set; }


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
                        MessageBox.Show(Path);
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
                        
                        Lists.ListOfIndeks = await LoadingExcelService.DataTableToListOfBaseIndeks(dataTable);
                        

                    });

                return LoadExcel;
            }
        }
    }


}
