using FitnessTracker.Models;

namespace FitnessTracker;

public partial class WorkoutListPage : ContentPage
{
    public WorkoutListPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        workoutListView.ItemsSource = await App.Database.GetWorkoutsAsync();
    }

    private async void OnAddWorkoutClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddWorkoutPage());
    }

    private async void OnWorkoutSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Workout selectedWorkout)
        {
            await Navigation.PushAsync(new AddWorkoutPage(selectedWorkout));
        }

        workoutListView.SelectedItem = null;
    }
}