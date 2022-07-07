using ExponentialGrowth.ViewModels;

namespace ExponentialGrowth.Pages;

public partial class ExerciseView : ContentPage
{
	public ExerciseView()
	{
       
        InitializeComponent();
       BindingContext = new ExerciseViewModel();
	}
}