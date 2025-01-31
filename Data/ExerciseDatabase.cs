using FitnessTracker.Models;
using SQLite;

namespace FitnessTracker.Data
{
    public class ExerciseDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public ExerciseDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Exercise>().Wait();
            _database.CreateTableAsync<ExerciseLog>().Wait();
            _database.CreateTableAsync<Workout>().Wait();
        }

        public Task<List<Exercise>> GetExercisesAsync()
        {
            return _database.Table<Exercise>()
                .ToListAsync();
        }

        public Task<int> SaveExerciseAsync(Exercise exercise)
        {
            if (exercise.ID != 0)
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

        public Task<List<Workout>> GetWorkoutsAsync()
        {
            return _database.Table<Workout>().ToListAsync();
        }

        public Task<int> SaveWorkoutAsync(Workout workout)
        {
            if (workout.ID != 0)
            {
                return _database.UpdateAsync(workout);
            }
            else
            {
                return _database.InsertAsync(workout);
            }
        }

        public Task<int> DeleteWorkoutAsync(Workout workout)
        {
            return _database.DeleteAsync(workout);
        }

        public Task<int> SaveExerciseLogAsync(ExerciseLog exerciseLog)
        {
            if (exerciseLog.ID != 0)
            {
                return _database.UpdateAsync(exerciseLog);
            }
            else
            {
                return _database.InsertAsync(exerciseLog);
            }
        }

        public Task<int> DeleteExerciseLogAsync(ExerciseLog exerciseLog)
        {
            return _database.DeleteAsync(exerciseLog);
        }

        public Task<List<ExerciseLog>> GetExerciseLogList(int workoutId)
        {
            return _database.Table<ExerciseLog>()
                .Where(p => p.WorkoutID == workoutId)
                .ToListAsync();
        }

        public Task<List<Exercise>> GetExerciseItemsList(int workoutId)
        {
            return _database.QueryAsync<Exercise>(
            "select E.ID, E.Name from Exercise E"
            + " inner join ExerciseLog EL"
            + " on E.ID = EL.ExerciseID where EL.WorkoutID = ?",
            workoutId);
        }

    }
}