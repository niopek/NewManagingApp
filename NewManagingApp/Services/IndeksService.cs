using NewManagingApp.Classes;
using NewManagingApp.Interfaces;
using NewManagingApp.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace NewManagingApp.Services
{
    internal static class IndeksService
    {
        public static ObservableCollection<Indeks> FindList(string text, bool isFindByNameChecked = false)
        {
            ObservableCollection<Indeks> listOfFoundIndeks;

            if (Utils.IsTextBoxEmpty(text))
            {
                listOfFoundIndeks = Lists.ListOfIndeks.ToObservableCollection()!;
            }
            else if (isFindByNameChecked)
            {
                listOfFoundIndeks = MakeCollectionByName<Indeks>.GetCollectionByName(text, Lists.ListOfIndeks);
            }
            else
            {
                List<int> indeksToFind = Utils.FindIndeksFromText(text);
                listOfFoundIndeks = MakeCollectionById<Indeks>.GetGetCollectionById(indeksToFind, Lists.ListOfIndeks);
            }
            
            return listOfFoundIndeks!;
        }




    }


}
