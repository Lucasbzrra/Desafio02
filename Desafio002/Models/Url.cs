using Microsoft.EntityFrameworkCore.Query.Internal;
using System.ComponentModel.DataAnnotations;

namespace Desafio002.Models;

public class Url
{
    [Key]
    public string Id { get; set; } 
    [MaxLength(50)]
    public string URL { get; set; }
    public string UrlEncurtada { get; set; }

    public DateTime DataAtual { get; set; }

    public Url( string uRL, string urlEncurtada, DateTime dataAtual)
    {
        Id=Guid.NewGuid().ToString();
        URL = uRL;
        UrlEncurtada = urlEncurtada;
        DataAtual = dataAtual;
    }
    protected Url()
    {

    }
}
