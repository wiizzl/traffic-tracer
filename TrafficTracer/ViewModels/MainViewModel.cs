using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TrafficTracer.Database;
using TrafficTracer.Models;

namespace TrafficTracer.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly DatabaseService _databaseService;
    
    [ObservableProperty]
    private ObservableCollection<Immatriculation> _immatriculations;
    
    public MainViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
        Immatriculations = new ObservableCollection<Immatriculation>(_databaseService.GetImmatriculations());
    }
    
    public void OnAppearing()
    {
        Immatriculations = new ObservableCollection<Immatriculation>(_databaseService.GetImmatriculations());
    }
    
    [RelayCommand]
    private void OpenCreate()
    {
        Shell.Current.GoToAsync("CreatePage", true);
    }
    
    [RelayCommand]
    private void OpenEdit(Immatriculation immatriculation)
    {
        Shell.Current.GoToAsync("EditPage", true, new Dictionary<string, object>
        {
            { "Immatriculation", immatriculation }
        });
    }
}