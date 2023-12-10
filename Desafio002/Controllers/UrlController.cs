using Desafio002.Data.Dtos;
using Desafio002.Models;
using Desafio002.Services;
using Microsoft.AspNetCore.Mvc;

namespace Desafio002.Controllers;

[ApiController]
[Route("/Controller")]
public class UrlController : ControllerBase
{
    private readonly IUrlService _urlService;
    private readonly IEncurtadorUrl _encurtadorUrl;
    public UrlController( IUrlService urlService, IEncurtadorUrl encurtadorUrl)
    {

        _urlService = urlService;
        _encurtadorUrl = encurtadorUrl;
    }

    [HttpPost("/post/url")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(CreateUrlDto url)
    {
        string encurtado = _encurtadorUrl.Encurtador();
        Url URL = new Url(url.URL,encurtado,url.DataAtual);
        if(_urlService.Create(URL).Result==1)
        {
            return Ok(URL);
        }
        return BadRequest();
      
    }

    [HttpGet("/get-{url}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public  async Task<IActionResult> GetUrl(string url)
    {
       var result = await _urlService.GetUrl(url);
        return Ok(result);

    }

    [HttpGet("/get/list")]
    public async Task<IActionResult> GetList()
    {
        var result = await _urlService.GetList();
        return Ok(result);
    }

    [HttpPut("/put/url/{id}")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async Task<IActionResult> Puturl(string id,[FromBody] UpdateUrlDto updateUrlDto)
    {
        string encurtado = _encurtadorUrl.Encurtador();
        Url url = new Url(updateUrlDto.URL, encurtado, updateUrlDto.DataAtual);
        await _urlService.Update(id, url);
        return Accepted( url);
    }

    
    [HttpDelete("/Delete/expired/url/{id?}")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async Task<IActionResult> delete( string? id )
    {
        if(id is null)
        {
          await  _urlService.DeleteExpired();
            return Accepted();
        }
        await _urlService.DeleteUrl(id);
        return Accepted();
        
       
    } 
   
}