using SQLite;

namespace FitnessTracker.Models
{
    public class Exercise
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public int Duration { get; set; }

        public DateTime Date { get; set; }

        public int CaloriesBurned { get; set; }
    }
}
