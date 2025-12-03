using System.Text.RegularExpressions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TrafficTracer.Database;
using TrafficTracer.Models;

namespace TrafficTracer.ViewModels;

public partial class CreateViewModel : ObservableObject
{
    private readonly DatabaseService _databaseService;
    public IEnumerable<PlateType> PlateTypes { get; } = Enum.GetValues<PlateType>();

    [ObservableProperty]
    private string plate;

    [ObservableProperty]
    private PlateType selectedPlateType;

    [ObservableProperty]
    private DateTime selectedDate = DateTime.Now;

    public CreateViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
    }
    
    [RelayCommand]
    private void Create()
    {
        var plateRegex = SelectedPlateType == PlateType.FNI
            ? new Regex(@"^[A-Z]{2}\d{3}[A-Z]{2}$", RegexOptions.IgnoreCase)
            : new Regex(@"^[A-Z]{2}-\d{3}-[A-Z]{2}$", RegexOptions.IgnoreCase);
        
        if (!plateRegex.IsMatch(Plate))
        {
            Application.Current.MainPage.DisplayAlert("Erreur", "Le format de la plaque est invalide.", "OK");
            return;
        }

        _databaseService.AddImmatricuation(Plate, SelectedPlateType, SelectedDate);
        Shell.Current.Navigation.PopAsync();
    }
}