namespace NewManagingApp.Util;

internal static class PriceFilter
{
    public static ObservableCollection<IndeksDetails> FilterByTotalPrice(this ObservableCollection<IndeksDetails> thisList, string textbox)
    {
        ObservableCollection<IndeksDetails> list = new();
        if (decimal.TryParse(textbox, out decimal value))
        {
            list = thisList.Where(i => i.TotalPrice >= value).ToObservableCollection()!;
        }
        if (list.Count == 0)
            MessageBox.Show("Na liscie nie ma pozycji z tego przedziału cenowego");

        return list;
    }
}
