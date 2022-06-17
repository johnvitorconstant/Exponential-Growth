using ExponentialGrowth.Repositories;

namespace ExponentialGrowth;

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

        string dbPath = FileAccessHelper.GetLocalFilePath("exercises_v1.db3");
        builder.Services.AddSingleton<ExerciseRepository>(s => ActivatorUtilities.CreateInstance<ExerciseRepository>(s, dbPath));

        return builder.Build();
	}
}
