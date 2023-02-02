using NewManagingApp.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewManagingApp.Repository
{
    internal static class Lists
    {
        public static ObservableCollection<Indeks> ListOfIndeks = new();
        public static ObservableCollection<Order> ListOfOrders = new();
        public static ObservableCollection<IndeksDetails> ListsOfIndeksDetails = new();
    }
}
