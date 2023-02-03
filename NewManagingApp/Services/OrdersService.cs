namespace NewManagingApp.Services;

internal static class OrdersService
{
    public static ObservableCollection<IndeksDetails> OrdersToListOfIndeks(this ObservableCollection<Order> listOfOrders)
    {
        ObservableCollection<IndeksDetails> listOfIndeksDetails = new();
        foreach (Order o in listOfOrders)
        {
            bool contains = Utils.IsIndeksCreated(o, listOfIndeksDetails);
            if (contains == true)
            {
                IndeksDetails indeks = listOfIndeksDetails.Where(l => l.IndeksId == o.IndeksId).First();
                indeks.TotalPrice += o.TotalPrice;
                indeks.TotalAmount += o.Amount;
                indeks.Orders.Add(o);
                if (Utils.IsNumberInList(o.Plant, indeks.Plants) == false)
                {
                    indeks.Plants.Add(o.Plant);
                }
            }
            else
            {
                if (o.IndeksDescription != null)
                {
                    IndeksDetails indeks = new(o.IndeksId, o.IndeksName, o.IndeksDescription!);
                    indeks.TotalPrice += o.TotalPrice;
                    indeks.TotalAmount += o.Amount;
                    indeks.Orders.Add(o);
                    indeks.Plants.Add(o.Plant);
                    listOfIndeksDetails.Add(indeks);
                }
                else
                {
                    IndeksDetails indeks = new(o.IndeksId, o.IndeksName);
                    indeks.TotalPrice += o.TotalPrice;
                    indeks.TotalAmount += o.Amount;
                    indeks.Orders.Add(o);
                    indeks.Plants.Add(o.Plant);
                    listOfIndeksDetails.Add(indeks);
                }
            }

        }

        return listOfIndeksDetails;

    }



}
