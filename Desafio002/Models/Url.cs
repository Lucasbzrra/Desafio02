using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Desafio002.Models;

public class Url
{
    [Key]
    public int Id { get; set; }
    public string url { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string UrlEncurtada { get; set; }

    public DateTime DateRegistre { get; } = DateTime.Now;
}
