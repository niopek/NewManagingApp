namespace NewManagingApp.Classes;

internal class Indeks : IIndeksIdName
{
    public long Pkuiw { get; set; }
    public int IndeksId { get; set; }
    public string IndeksName { get; set; }
    public string? IndeksDescription { get; set; }
    public string UnitOfMeasure { get; set; }
    public int GroupOfMaterial { get; set; }
    public int ClassOfMaterial { get; set; }
    public string Tc { get; set; }
    public Indeks(long pkuiw, int id, string name, string unitOfMeasure, int groupOfMaterial, int classOfMaterial, string tc)
    {
        Pkuiw = pkuiw;
        IndeksId = id;
        IndeksName = name;
        UnitOfMeasure = unitOfMeasure;
        GroupOfMaterial = groupOfMaterial;
        ClassOfMaterial = classOfMaterial;
        Tc = tc;

    }
    public Indeks(long pkuiw, int id, string name, string indeksDescription, string unitOfMeasure, int groupOfMaterial, int classOfMaterial, string tc)
    {
        Pkuiw = pkuiw;
        IndeksId = id;
        IndeksName = name;
        IndeksDescription = indeksDescription;
        UnitOfMeasure = unitOfMeasure;
        GroupOfMaterial = groupOfMaterial;
        ClassOfMaterial = classOfMaterial;
        Tc = tc;
    }
}
