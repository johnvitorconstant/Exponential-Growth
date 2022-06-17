using ExponentialGrowth.Repositories;

namespace ExponentialGrowth;

public partial class App : Application
{
	public static ExerciseRepository ExerciseRepository { get; private set; }
	public App(ExerciseRepository exerciseRepository)
	{
		InitializeComponent();

		MainPage = new AppShell();
        ExerciseRepository = exerciseRepository;
    }
}
