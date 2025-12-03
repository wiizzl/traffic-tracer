using System.Collections.ObjectModel;
using TrafficTracer.Models;
using TrafficTracer.ViewModels;

namespace TrafficTracer.Pages;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
    
    protected override void OnAppearing()
    {
        base.OnAppearing();
        ((MainViewModel)BindingContext).OnAppearing();
    }
}