namespace DonDuSang.ViewModel;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private string titre;

    [ObservableProperty]
    [NotifyPropertyChangedFor("NEstPasOccupé")]
    private bool estOccupé;
    public bool NEstPasOccupé => !EstOccupé;

}
