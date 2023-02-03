namespace NewManagingApp.Services;

internal static class FindingCollectionService<T> where T: IIndeksIdName
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
            listOfFoundIndeks = GetCollectionByName(text, Collection);
        }
        else
        {
            List<int> indeksToFind = Utils.FindIndeksFromText(text);
            listOfFoundIndeks = GetGetCollectionById(indeksToFind, Collection);
        }
        
        return listOfFoundIndeks!;
    }


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
                    collection = listWithData.Where(i => i.IndeksName.Contains(textSplitted[0])).ToObservableCollection();
                }
                else
                {
                    collection = collection!.Where(i => i.IndeksName.Contains(textSplitted[j])).ToObservableCollection();
                }
            }

        }
        else
        {
            collection = listWithData.Where(i => i.IndeksName.Contains(text)).ToObservableCollection();
        }

        if (!collection!.Any())
        {
            MessageBox.Show("Brak");
        }

        return collection!;
    }



}
