using System.ComponentModel.DataAnnotations;


namespace burgershack.Models
{
  public class Wizard
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]

    public string userId { get; set; }
  }
}