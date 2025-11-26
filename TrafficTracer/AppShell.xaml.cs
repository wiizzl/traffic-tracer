using TrafficTracer.Pages;

namespace TrafficTracer;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute("MainPage", typeof(MainPage));
        Routing.RegisterRoute("EditPage", typeof(EditPage));
        Routing.RegisterRoute("CreatePage", typeof(CreatePage));
    }
}