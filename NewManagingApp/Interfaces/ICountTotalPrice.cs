namespace NewManagingApp.Interfaces;

internal interface ICountTotalPrice
{
    decimal TotalPrice { get; set; }
    public int OrdersCount { get; }
}
