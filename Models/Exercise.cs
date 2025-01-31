using SQLite;

namespace FitnessTracker.Models
{
    public class Exercise
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }


        [MaxLength(100), Unique]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Category { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

    }
}
