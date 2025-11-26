namespace TrafficTracer;

public partial class App : Application
{
    private AppShell _shell { get; set; }
    
    public App(AppShell shell)
    {
        InitializeComponent();
        _shell = shell;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var window = new Window(_shell)
        {
            Width = 500,
            Height = 400,
        };

        return window;
    }
}