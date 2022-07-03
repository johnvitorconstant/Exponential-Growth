using ExponentialGrowth.Models;

namespace ExponentialGrowth.Pages;

public partial class ExerciseForm : ContentPage
{
    public ExerciseForm()
    {
        InitializeComponent();
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
        catch(Exception ex)
        {
            statusMessage.Text = ex.ToString();
        }
    }

}