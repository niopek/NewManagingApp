namespace NewManagingApp.Classes;

internal class Order
{
    public long OrderId { get; set; }
    public int IndeksId { get; set; }
    public string IndeksName { get; set; }
    public string? IndeksDescription { get; set; }
    public int SupplierId { get; set; }
    public string SupplierName { get; set; }
    public decimal Amount { get; set; }
    public string UnitOfMeasure { get; set; }
    public decimal TotalPrice { get; set; }
    public string Currency { get; set; }
    public string Date { get; set; }
    public Plant Plant { get; set; }
    public long PKUIW { get; set; }
    public int MaterialMoveNumber { get; set; }
    public string MaterialCategory { get; set; }
    public int OrdersCount { get { return 1; } }

    public Order(long orderId, int indeksId, string indeksName, string indeksDescription, int supplierId, string supplierName, decimal amount, string unitOfMeasure, decimal totalPrice, string currency, string date, Plant plant, long pkuiw, int materialMoveNumber, string materialCategory)
    {
        OrderId = orderId;
        IndeksId = indeksId;
        IndeksName = indeksName;
        IndeksDescription = indeksDescription;
        SupplierId = supplierId;
        SupplierName = supplierName;
        Amount = amount;
        UnitOfMeasure = unitOfMeasure;
        TotalPrice = totalPrice;
        Currency = currency;
        Date = date;
        Plant = plant;
        PKUIW = pkuiw;
        MaterialMoveNumber = materialMoveNumber;
        MaterialCategory = materialCategory;
    }
    public Order(long orderId, int indeksId, string indeksName, int supplierId, string supplierName, decimal amount, string unitOfMeasure, decimal totalPrice, string currency, string date, Plant plant, long pkuiw, int materialMoveNumber, string materialCategory)
    {
        OrderId = orderId;
        IndeksId = indeksId;
        IndeksName = indeksName;
        SupplierId = supplierId;
        SupplierName = supplierName;
        Amount = amount;
        UnitOfMeasure = unitOfMeasure;
        TotalPrice = totalPrice;
        Currency = currency;
        Date = date;
        Plant = plant;
        PKUIW = pkuiw;
        MaterialMoveNumber = materialMoveNumber;
        MaterialCategory = materialCategory;
    }
}
