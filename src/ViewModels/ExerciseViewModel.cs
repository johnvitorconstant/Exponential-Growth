using ExponentialGrowth.Models;
using ExponentialGrowth.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExponentialGrowth.ViewModels
{
    public class ExerciseViewModel : INotifyPropertyChanged
    {

       
       // private ExerciseRepository _exerciseRepository;

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                if (_isRefreshing == value) return;
                _isRefreshing = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsRefreshing)));
            }
        }

        private bool _isBusy = false;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy == value) return;
                _isBusy = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBusy)));
            }
        }

        private Exercise _selectedExercise;
        public Exercise SelectedExercise
        {
            get => _selectedExercise;
            set
            {
                if (_selectedExercise == value) return;
                _selectedExercise = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedExercise)));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;


        public ExerciseViewModel()
        {
            _exercises = new ObservableCollection<Exercise>();
            LoadDataCommand = new Command( () =>  LoadData());
            ExerciseSelectedCommand = new Command(async () =>await ExerciseSelected());
            AddNewExerciseCommand = new Command(async () => await Shell.Current.GoToAsync("exerciseform"));

            Task.Run(LoadData);

        }

        private async Task ExerciseSelected()
        {
            if (SelectedExercise == null) return;

            var navigationParameter = new Dictionary<string, object>()
            {
                {"exercise", SelectedExercise }
            };

            await Shell.Current.GoToAsync("exerciseform", navigationParameter);

            MainThread.BeginInvokeOnMainThread(() => SelectedExercise = null);

        }

        private ObservableCollection<Exercise> _exercises;
        public ObservableCollection<Exercise> Exercises
        {
            get => _exercises;
            set => _exercises = value;
        }

        public ICommand LoadDataCommand { get; private set; }

        public ICommand ExerciseSelectedCommand { get; private set; }

        public ICommand AddNewExerciseCommand { get; private set; }

        public async Task LoadData()
        {
            if (IsBusy) return;

            try
            {
                IsRefreshing = true;
                IsBusy = true;

                
                var exercisesCollection =await App.ExerciseRepository.GetAll();

                MainThread.BeginInvokeOnMainThread(() =>
                {
                   Exercises.Clear();
                    foreach (var exercise in exercisesCollection)
                    {
                        Exercises.Add(exercise);
                    }

                });

            }
            finally
            {
                IsRefreshing = false;
                IsBusy = false;
            }
        }

    }
}
