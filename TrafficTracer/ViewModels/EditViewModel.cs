using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TrafficTracer.Database;
using TrafficTracer.Models;

namespace TrafficTracer.ViewModels;

public partial class EditViewModel : ObservableObject, IQueryAttributable
{
    private readonly DatabaseService _databaseService;
    public IEnumerable<PlateType> PlateTypes { get; } = Enum.GetValues<PlateType>();
    
    [ObservableProperty]
    private Immatriculation _immatriculation;
    
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Immatriculation = (Immatriculation)query["Immatriculation"];
    }

    public EditViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
    }
    
    [RelayCommand]
    private void Edit(Immatriculation immatriculation)
    {
        var plateRegex = immatriculation.Type == PlateType.FNI
            ? new Regex(@"^[A-Z]{2}\d{3}[A-Z]{2}$", RegexOptions.IgnoreCase)
            : new Regex(@"^[A-Z]{2}-\d{3}-[A-Z]{2}$", RegexOptions.IgnoreCase);
        
        if (!plateRegex.IsMatch(immatriculation.Plate))
        {
            Application.Current.MainPage.DisplayAlert("Erreur", "Le format de la plaque est invalide.", "OK");
            return;
        }
        
        _databaseService.UpdateImmatriculation(immatriculation.Id, immatriculation.Plate, immatriculation.Type, immatriculation.ReadDate);
        Shell.Current.Navigation.PopAsync();
    }
    
    [RelayCommand]
    private void Delete(Immatriculation immatriculation)
    {
        _databaseService.DeleteImmatriculation(immatriculation.Id);
        Shell.Current.Navigation.PopAsync();
    }
}