using brickey_maui.Pages;
using CommunityToolkit.Maui;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace brickey_maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Playfair_9pt-Black.ttf", "Playfair_Black");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<MainPage>();
        //builder.Services.AddTransient<QueryPage>();
		return builder.Build();
	}

	public static void SaveUserLoginData(string username, string password, string apiKey)
	{
		SecureStorage.Default.SetAsync(nameof(AppStoredDataModel.username), username);
        SecureStorage.Default.SetAsync(nameof(AppStoredDataModel.password), password);
        SecureStorage.Default.SetAsync(nameof(AppStoredDataModel.apiKey), apiKey);
    }
}
