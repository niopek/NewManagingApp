namespace NewManagingApp.ViewModels;

internal class IndeksViewModel : BaseViewModel
{
    public ObservableCollection<Indeks> ListOfIndeks { get; set; } = new();

    private ICommand? showListOfIndeks = null;
    public string? FilterText { get; set; }

    public bool IsFindByNameChecked { get; set; }

    public ICommand ShowListOfIndeks
    {
        get
        {
            showListOfIndeks ??= new RelayCommand(
                (o) =>
                {
                    ListOfIndeks = FindingCollectionService<Indeks>.FindList(FilterText!, Lists.ListOfIndeks ,IsFindByNameChecked);
                    OnPropertyChanged(nameof(ListOfIndeks));
                });

            return showListOfIndeks;
        }
    }

    

   
}
