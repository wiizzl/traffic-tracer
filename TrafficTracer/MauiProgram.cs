using Microsoft.Extensions.Logging;
using TrafficTracer.Database;
using TrafficTracer.Pages;
using TrafficTracer.ViewModels;

namespace TrafficTracer;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<DatabaseService>();
        builder.Services.AddSingleton<AppShell>();
        
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<EditViewModel>();
        builder.Services.AddSingleton<CreateViewModel>();
        
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<EditPage>();
        builder.Services.AddSingleton<CreatePage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}