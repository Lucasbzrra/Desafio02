using Desafio002.Data;
using Desafio002.Data.Dtos;
using Desafio002.Models;
using Desafio002.Services;
using Microsoft.AspNetCore.Mvc;

namespace Desafio002.Controllers;

[ApiController]
[Route("/Controller")]
public class UrlController : ControllerBase
{
    private UrlDbContext _context { get; set; }
    public UrlController(UrlDbContext urlContext)
    {
        _context = urlContext;
    }
    [HttpPost("/EncurtadorUrl")]
    public IActionResult EncurtarUrl(CreateUrlDto url)
    {
        var UrlEncurtada = EncurtadorDeUrl.Encurtador();
        var teste = EncurtadorDeUrl.Encurtador();
        bool urlEncontrada = _context.url.Any(x => x.url.Equals(url.Url));
        bool UrlEncurtadaEncontrada = _context.url.Any(x => x.UrlEncurtada.Equals(UrlEncurtada));
        if (urlEncontrada) { BadRequest("Este url já se encontra na nossa base de dados"); }
        Console.WriteLine(UrlEncurtada);
        Console.WriteLine(teste);
        return Ok();
    }
    [HttpDelete("/Deletar")]
    public IActionResult RemoverExpirados()
    {
        DateTime day= DateTime.Now;
        var tabela=_context.url;
        var ListaDeExpirados = 
            from x in tabela 
            where  (x.DateRegistre.Hour - day.Hour)>=0 
            select x;
        foreach (var item in ListaDeExpirados)
        {
            _context.Remove(item);
        }
        return Ok();
        
    }
}