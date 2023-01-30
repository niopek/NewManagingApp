using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NewManagingApp
{
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
}
