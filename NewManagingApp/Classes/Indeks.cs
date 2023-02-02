using NewManagingApp.Interfaces;
using NewManagingApp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NewManagingApp.Classes
{
    internal class Indeks : IName, IId
    {
        public long Pkuiw { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string UnitOfMeasure { get; set; }
        public int GroupOfMaterial { get; set; }
        public int ClassOfMaterial { get; set; }
        public string Tc { get; set; }

        public Indeks() 
        {
            Name = "";
            Description = "";
        }

        public Indeks(long pkuiw, int id, string name, string unitOfMeasure, int groupOfMaterial, int classOfMaterial, string tc)
        {
            Pkuiw = pkuiw;
            Id = id;
            Name = name;
            UnitOfMeasure = unitOfMeasure;
            GroupOfMaterial = groupOfMaterial;
            ClassOfMaterial = classOfMaterial;
            Tc = tc;

        }
        public Indeks(long pkuiw, int id, string name, string indeksDescription, string unitOfMeasure, int groupOfMaterial, int classOfMaterial, string tc)
        {
            Pkuiw = pkuiw;
            Id = id;
            Name = name;
            Description = indeksDescription;
            UnitOfMeasure = unitOfMeasure;
            GroupOfMaterial = groupOfMaterial;
            ClassOfMaterial = classOfMaterial;
            Tc = tc;
        }
    }
}
