using Microsoft.Data.SqlClient;

namespace WebApplication1.Models
{
    public class SE
    {
        public int Id { get; set; }
        public int Weight { get; set; }
        public int NumOfSeries { get; set; }
        public int NumOfReps { get; set; }
        public int? ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set; }
        public int? SessionId { get; set; }
        public virtual Session Session { get; set; }

    }
}