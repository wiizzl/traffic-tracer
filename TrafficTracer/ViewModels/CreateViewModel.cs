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
        _databaseService.AddImmatricuation(Plate, SelectedPlateType, SelectedDate);
        Shell.Current.Navigation.PopAsync();
    }
}