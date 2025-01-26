using SQLite;
using FitnessTracker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessTracker.Data
{
    public class ExerciseDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public ExerciseDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Exercise>().Wait();
        }

        public Task<List<Exercise>> GetExercisesAsync()
        {
            return _database.Table<Exercise>().ToListAsync();
        }

        public Task<int> SaveExerciseAsync(Exercise exercise)
        {
            if (exercise.Id != 0)
            {
                return _database.UpdateAsync(exercise);
            }
            else
            {
                return _database.InsertAsync(exercise);
            }
        }

        public Task<int> DeleteExerciseAsync(Exercise exercise)
        {
            return _database.DeleteAsync(exercise);
        }
    }
}

