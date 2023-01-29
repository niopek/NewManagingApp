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
        public static ObservableCollection<Indeks> ListOfIndeks = new() { new() { Id = 1, Name= "test1", Description = "test1"}, new() { Id = 2, Name = "test2", Description = "test2" }, new() { Id = 3, Name = "test3", Description = "test3" } };
    }
}
