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
        public static ObservableCollection<Indeks> ListOfIndeks = new() { new() { Id = 7000001, Name= "test1", Description = "test1"}, new() { Id = 7000002, Name = "test2", Description = "test2" }, new() { Id = 7000003, Name = "test3", Description = "test3" } };
    }
}
