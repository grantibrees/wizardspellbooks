using System.ComponentModel.DataAnnotations;

namespace burgershack.Models
{
  public class Spell
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
  }

  public class SpellbookViewModel : Spell
  {
    public int SpellbookId { get; set; }
    public string SpellbookName { get; set; }

    public string SchoolName { get; set; }
  }
}
