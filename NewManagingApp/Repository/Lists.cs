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
        public static ObservableCollection<Indeks> ListOfIndeks = new() { new() { Id = 7000001, Name= "TEST1", Description = "TEST1" }, new() { Id = 7000002, Name = "TEST2", Description = "TEST2" }, new() { Id = 7000003, Name = "TEST3", Description = "TEST3" } };
    }
}
