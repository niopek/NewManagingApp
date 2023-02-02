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

namespace NewManagingApp.Services
{
    internal class MakeCollectionById<T> where T: IIndeksIdName
    {
        public static ObservableCollection<T> GetGetCollectionById(List<int> indeksToFind, ObservableCollection<T> listWithData)
        {
            var collection = new ObservableCollection<T>();

            foreach (int indeks in indeksToFind)
            {
                T? i = listWithData.FirstOrDefault(i => i.IndeksId == indeks);
                if (i != null)
                {
                    collection.Add(i);
                }
            }

            if (!collection.Any()) { MessageBox.Show("Brak"); }

            return collection;

        }
    }
}
