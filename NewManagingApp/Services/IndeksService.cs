using NewManagingApp.Classes;
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
    internal static class IndeksService
    {
        public static ObservableCollection<Indeks> FindList(string text)
        {
            ObservableCollection<Indeks> list = new();

            if (text == null || text == "")
            {
                list = Lists.ListOfIndeks.ToObservableCollection()!;
            }
            else
            {
                var listOfFoundIndeks = new List<Indeks>();
                List<int> indeksToFind = Utils.FindIndeksFromText(text);

                foreach(int indeks in indeksToFind)
                {
                    Indeks? i = Lists.ListOfIndeks.FirstOrDefault(i => i.Id == indeks);
                    if (i != null)
                    {
                        listOfFoundIndeks.Add(i);
                    }
                }
                if (listOfFoundIndeks.Any())
                {
                    list = listOfFoundIndeks.ToObservableCollection()!; 
                }
            }
            if (!list.Any())
            {
                MessageBox.Show("Brak");
            }
            return list;
        }

    }


}
