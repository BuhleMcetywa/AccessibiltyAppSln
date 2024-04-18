using AccessibiltyAppSln.Services;
using AccessibiltyAppSln.ViewModels;
using AccessibiltyAppSln.Views;
using Microsoft.Extensions.Logging;

namespace AccessibilityAppSln
{
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

#if DEBUG
			builder.Logging.AddDebug();
#endif

			builder.Services.AddTransient<MainPage>();

			builder.Services.AddSingleton<MainPageViewModel>();

			builder.Services.AddTransient<ComputerVisionServices>();

			return builder.Build();
		}
	}
}
