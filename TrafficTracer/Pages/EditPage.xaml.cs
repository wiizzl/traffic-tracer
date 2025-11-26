using TrafficTracer.ViewModels;

namespace TrafficTracer.Pages;

public partial class EditPage : ContentPage
{
    public EditPage(EditViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}