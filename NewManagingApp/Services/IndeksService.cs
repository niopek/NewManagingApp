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
    internal static class IndeksService<T> where T: IIndeksIdName
    {
        public static ObservableCollection<T> FindList(string text, ObservableCollection<T> Collection, bool isFindByNameChecked = false)
        {
            ObservableCollection<T> listOfFoundIndeks;

            if (Utils.IsTextBoxEmpty(text))
            {
                listOfFoundIndeks = Collection.ToObservableCollection()!;
            }
            else if (isFindByNameChecked)
            {
                listOfFoundIndeks = MakeCollectionByName<T>.GetCollectionByName(text, Collection);
            }
            else
            {
                List<int> indeksToFind = Utils.FindIndeksFromText(text);
                listOfFoundIndeks = MakeCollectionById<T>.GetGetCollectionById(indeksToFind, Collection);
            }
            
            return listOfFoundIndeks!;
        }




    }


}
