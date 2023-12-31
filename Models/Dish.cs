using System.ComponentModel.DataAnnotations;
namespace ChefsNDishes.Models;


public class Dish{
    [Key]
    public int DishId{ get; set; }
    [Required]
    public string Name{ get; set;}
    [Required]
    [Range(1,5)]
    public int Tastiness {get; set;}
    [Required]
    [Range(1,int.MaxValue)]
    public int Calories{ get; set; }
    public DateTime Fecha_Creacion { get; set; } = DateTime.Now;
    public DateTime Fecha_Actualizacion { get; set; } = DateTime.Now;
    [Required]
    public int ChefId { get; set; }
    public Chef? Creador { get; set; }
}