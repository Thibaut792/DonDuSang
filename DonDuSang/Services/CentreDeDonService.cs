using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace DonDuSang.Services;

public class CentreDeDonService
{
    List<CentreDeDon> centresList = new();
    HttpClient httpClient;

    public CentreDeDonService()
    {
        httpClient = new HttpClient();
    }

    public async Task<List<CentreDeDon>> GetCentresDeDon()
    {
        if (centresList?.Count > 0)
            return centresList;

        string url = "https://raw.githubusercontent.com/rose-line/cda-2023/main/centresdedon.json";
        var reponse = await httpClient.GetAsync(url);

        if (reponse.IsSuccessStatusCode)
        {
            centresList = await reponse.Content.ReadFromJsonAsync<List<CentreDeDon>>();    
        }
        return centresList;

    }
}