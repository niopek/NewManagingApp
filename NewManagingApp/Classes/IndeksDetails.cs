namespace NewManagingApp.Classes;

internal class IndeksDetails : ICountTotalPrice, IIndeksIdName
{
    public int IndeksId { get; set; }
    public string IndeksName { get; set; }
    public string IndeksDescription { get; set; } = "";

    public ObservableCollection<Plant> Plants { get; set; }
    public int PlantsCount { get { return Plants.Count; } }
    public int OrdersCount { get { return Orders.Count; } }

    public ObservableCollection<Order> Orders { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal AvaragePrice { get { return TotalPrice / TotalAmount; } }

    public IndeksDetails(int indeksId, string indeksName)
    {
        IndeksId = indeksId;
        IndeksName = indeksName;
        Plants = new();
        Orders = new();

    }
    public IndeksDetails(int indeksId, string indeksName, string indeksDescription)
    {
        IndeksId = indeksId;
        IndeksName = indeksName;
        IndeksDescription = indeksDescription;
        Plants = new();
        Orders = new();
    }
}
