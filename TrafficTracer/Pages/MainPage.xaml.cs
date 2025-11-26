using TrafficTracer.ViewModels;

namespace TrafficTracer.Pages;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}