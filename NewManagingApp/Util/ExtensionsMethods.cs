namespace NewManagingApp.Util;

internal static class ExtensionsMethods
{
    public static ObservableCollection<T>? ToObservableCollection<T>(this IEnumerable<T> enumerableList)
    {
        if (enumerableList != null)
        {
            var observableCollection = new ObservableCollection<T>(enumerableList);

            return observableCollection;
        }
        return null;
    }
}
