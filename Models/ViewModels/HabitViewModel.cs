using HabitTracker.Models.Entites;
using System.ComponentModel.DataAnnotations.Schema;

namespace HabitTracker.Models.ViewModels
{
    public class HabitViewModel
    {
        public string Name { get; set; }
        public DateTime Hdate { get; set; }
        public int Userid { get; set; }
        public int Catid { get; set; }

        public IEnumerable<User> users { get; set; }
        public IEnumerable<Category> Category { get; set; } 
    }
}
