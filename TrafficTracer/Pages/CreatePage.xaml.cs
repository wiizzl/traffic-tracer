using TrafficTracer.ViewModels;

namespace TrafficTracer.Pages;

public partial class CreatePage : ContentPage
{
    public CreatePage(CreateViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}