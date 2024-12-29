using System.ComponentModel.DataAnnotations.Schema;

namespace HabitTracker.Models.Entites
{
    public class Habit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Cdate { get; set; }
        public int UserId { get; set; } // FK
        [ForeignKey("UserId")]
        public User User { get; set; } // NP
        public int CatId { get; set; } // FK
        [ForeignKey("CatId")]
        public Category Category { get; set; } // NP
    }
}
