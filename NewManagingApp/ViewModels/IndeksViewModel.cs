namespace NewManagingApp.ViewModels;

internal class IndeksViewModel : BaseViewModel
{
    public ObservableCollection<Indeks> ListOfIndeks { get; set; } = new();

    private ICommand? showListOfIndeks = null;
    public string? FilterText { get; set; }

    public bool IsFindByNameChecked { get; set; }
    public int NumberOfIndeks { get; set; }

    public ICommand ShowListOfIndeks
    {
        get
        {
            showListOfIndeks ??= new RelayCommand(
                (o) =>
                {
                    ListOfIndeks = FindingCollectionService<Indeks>.FindList(FilterText!, Lists.ListOfIndeks ,IsFindByNameChecked);
                    NumberOfIndeks = ListOfIndeks.Count;
                    OnPropertyChanged(nameof(NumberOfIndeks));
                    OnPropertyChanged(nameof(ListOfIndeks));
                });

            return showListOfIndeks;
        }
    }

    private ICommand? saveAsPlatform = null;

    public ICommand SaveAsPlatform
    {
        get
        {
            saveAsPlatform ??= new RelayCommand(
                (o) =>
                {
                    ListOfIndeks.SaveListToExcelPlatform();
                });
            return saveAsPlatform;
        }
    }

    private ICommand? saveAsPriceList = null;
    public ICommand SaveAsPriceList
    {
        get
        {
            saveAsPriceList ??= new RelayCommand(
                (o) =>
                {
                    ListOfIndeks.SaveListToExcelAsPriceList();
                });
            return saveAsPriceList;
        }
    }


}
