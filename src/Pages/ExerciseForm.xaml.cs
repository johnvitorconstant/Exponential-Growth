using ExponentialGrowth.Models;

namespace ExponentialGrowth.Pages;

public partial class ExerciseForm : ContentPage
{
    public ExerciseForm()
    {
        InitializeComponent();
    }

    void btnGetOnClick(object sender, EventArgs e)
    {

        var exercises = App.ExerciseRepository.GetAll();

        foreach (var exercise in exercises)
        {
            Console.WriteLine($"{exercise} \n");
        }
    }

    void btnAddOnClick(object sender, EventArgs e)
    {
        try
        {
            var exercicio = new Exercise
            {
                Name = formName.Text,
                Category = formCategory.Text,
                MinimumLoad = Convert.ToDouble(formMinimumLoad.Text),
                MaximumLoad = Convert.ToDouble(formMaximumLoad.Text),

            };
            App.ExerciseRepository.Add(exercicio);
        }
        catch
        {
            statusMessage.Text = "Dados inválidos";
        }
    }
}