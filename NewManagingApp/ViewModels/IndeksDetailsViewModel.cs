namespace NewManagingApp.ViewModels;

internal class IndeksDetailsViewModel : BaseViewModel
{
    public ObservableCollection<IndeksDetails> ListOfIndeksDetails { get; set; } = new();

    private ICommand? showListOfIndeksDetails = null;
    public string? FilterText { get; set; }

    public bool IsFindByNameChecked { get; set; }
    private int _numberOfOrders { get; set; }
    public int NumberOfOrders { 
        get 
        {
            _numberOfOrders = 0;
            foreach (IndeksDetails i in ListOfIndeksDetails) 
            {
                _numberOfOrders += i.OrdersCount;
            } 
            return _numberOfOrders;
        }
    }
    public int NumberOfIndeksDetails { get; set; }
    private decimal _valueOfAllOrders { get; set; }
    public decimal ValueOfOrders
    {
        get
        {
            _valueOfAllOrders = 0;
            foreach (IndeksDetails i in ListOfIndeksDetails)
            {
                _valueOfAllOrders += i.TotalPrice;
            }
            return _valueOfAllOrders;
        }
    }

    public ICommand ShowListOfIndeksDetails
    {
        get
        {
            showListOfIndeksDetails ??= new RelayCommand(
                (o) =>
                {
                    ListOfIndeksDetails = FindingCollectionService<IndeksDetails>.FindList(FilterText!, Lists.ListsOfIndeksDetails, IsFindByNameChecked);
                    NumberOfIndeksDetails = ListOfIndeksDetails.Count;
                    OnPropertyChanged(nameof(ListOfIndeksDetails));
                    OnPropertyChanged(nameof(NumberOfIndeksDetails));
                    OnPropertyChanged(nameof(NumberOfOrders));
                    OnPropertyChanged(nameof(ValueOfOrders));
                });

            return showListOfIndeksDetails;
        }
    }

    private ICommand? saveAsPlatform = null;

    public ICommand SaveAsPlatform { get
        {
            saveAsPlatform ??= new RelayCommand(
                (o) =>
                {
                    ListOfIndeksDetails.SaveListToExcelPlatform();
                });
            return saveAsPlatform;
        } }

    private ICommand? saveAsPriceList = null;
    public ICommand SaveAsPriceList { get
        {
            saveAsPriceList ??= new RelayCommand(
                (o) =>
                {
                    ListOfIndeksDetails.SaveListToExcelAsPriceList();
                });
            return saveAsPriceList;
        } }
}
