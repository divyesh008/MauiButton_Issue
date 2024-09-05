#if ANDROID
using MauiButtonBug.Platforms.Android.Handlers;
# elif IOS
using MauiButtonBug.Platforms.iOS.Handlers;
#endif
using Microsoft.Extensions.Logging;

namespace MauiButtonBug;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
             .ConfigureMauiHandlers(handlers =>
             {
                 // The handler will only be called for the specific paltform. 
#if IOS
                 handlers.AddHandler<Button, CustomButtonHandler>();
#elif ANDROID
                 handlers.AddHandler<Button, CustomButtonHandler>();
#endif
             })
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

