using DonDuSang.Services;
using System.Collections.ObjectModel;

namespace DonDuSang.ViewModel;

public partial class CentreDeDonDetailsViewModel : BaseViewModel
{
    CentreDeDonService service;
    ObservableCollection<CentreDeDon> Centres { get; } = new();
    public CentreDeDonDetailsViewModel(CentreDeDonService service)
    {
        Titre = "Don du sang";
        this.service = service ;
        GetCentresDeDonCommand = new Command(async () => await GetCentresDeDon());
    }

    public Command GetCentresDeDonCommand { get; }

    async Task GetCentresDeDon()
    {
        if (EstOccupé)
            return;

        EstOccupé= true;
        var centres = await service.GetCentresDeDon();
        if(Centres.Count !=0)
           Centres.Clear();
        foreach (var centre in centres)
        {
            Centres.Add(centre);
        }
        EstOccupé = false;
    }
}
