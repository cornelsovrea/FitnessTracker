using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FitnessTracker.Models
{
    public class ExerciseLog
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int Duration { get; set; }

        public int CaloriesBurned { get; set; }

        [ForeignKey(typeof(Exercise)), NotNull]
        public int ExerciseID { get; set; }

        public Exercise Exercise;

        public string ExerciseDetails
        {
            get
            {
                if (null != Exercise)
                {
                    return Exercise.Name + " (" + CaloriesBurned + " Calories)";
                }
                else
                {
                    return "Exercise N/A";
                }
            }
        }


        [ForeignKey(typeof(Workout))]
        public int WorkoutID { get; set; }
    }
}