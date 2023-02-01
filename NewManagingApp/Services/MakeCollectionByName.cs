using NewManagingApp.Interfaces;
using NewManagingApp.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace NewManagingApp.Services
{
    internal class MakeCollectionByName<T> where T: IName
    {
        public static ObservableCollection<T> GetCollectionByName(string text, ObservableCollection<T> listWithData) 
        {
            var collection = new ObservableCollection<T>();

            text = text.ToUpper();

            if (text.Contains('*'))
            {
                string[] textSplitted = text.Split('*');

                for (int j = 0; j < textSplitted.Length; j++)
                {
                    if (j == 0)
                    {
                        collection = listWithData.Where(i => i.Name.Contains(textSplitted[0])).ToObservableCollection();
                    }
                    else
                    {
                        collection = collection!.Where(i => i.Name.Contains(textSplitted[j])).ToObservableCollection();
                    }
                }

            }
            else
            {
                collection = listWithData.Where(i => i.Name.Contains(text)).ToObservableCollection();
            }

            if (!collection!.Any())
            {
                MessageBox.Show("Brak");
            }

            return collection!;
        }
    }
}
