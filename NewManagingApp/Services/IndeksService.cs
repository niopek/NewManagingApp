using NewManagingApp.Classes;
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
            var listOfFoundIndeks = new ObservableCollection<Indeks>();

            if (Utils.IsTextBoxEmpty(text))
            {
                listOfFoundIndeks = Lists.ListOfIndeks.ToObservableCollection()!;
            }
            else if (isFindByNameChecked)
            {


                text = text.ToUpper();

                if (text.Contains('*'))
                {
                    string[] textSplitted = text.Split('*');

                    for (int j = 0; j < textSplitted.Length; j++)
                    {
                        if (j == 0)
                        {
                            listOfFoundIndeks = Lists.ListOfIndeks.Where(i => i.Name.Contains(textSplitted[0])).ToObservableCollection();
                        }
                        else
                        {
                            listOfFoundIndeks = listOfFoundIndeks!.Where(i => i.Name.Contains(textSplitted[j])).ToObservableCollection();
                        }
                    }

                }
                else
                {
                    listOfFoundIndeks = Lists.ListOfIndeks.Where(i => i.Name.Contains(text)).ToObservableCollection();
                }



            }
            else
            {
                List<int> indeksToFind = Utils.FindIndeksFromText(text);

                foreach (int indeks in indeksToFind)
                {
                    Indeks? i = Lists.ListOfIndeks.FirstOrDefault(i => i.Id == indeks);
                    if (i != null)
                    {
                        listOfFoundIndeks.Add(i);
                    }
                }

                if (!listOfFoundIndeks.Any()) { MessageBox.Show("Brak"); }
            }
            
            return listOfFoundIndeks!;
        }




    }


}
