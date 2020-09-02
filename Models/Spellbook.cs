using System.ComponentModel.DataAnnotations;


namespace burgershack.Models
{
  public class Spellbook
  {
    public int Id { get; set; }
    [Required]
    public int WizardId { get; set; }
    [Required]
    public int SpellId { get; set; }
    [Required]
    public int SchoolId { get; set; }
  }
}