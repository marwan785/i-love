using System.ComponentModel.DataAnnotations;

namespace HabitTracker.Models.Entites
{
    public class Category
    {
        [Key]
        public int CId { get; set; }
        public string CName { get; set; }
        public ICollection<Habit>? Habits { get; set; }
    }
}
