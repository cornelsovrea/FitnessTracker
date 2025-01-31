using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FitnessTracker.Models
{
    public class Workout
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        [OneToMany]
        public List<ExerciseLog> ExerciseLogs { get; set; }
    }
}
