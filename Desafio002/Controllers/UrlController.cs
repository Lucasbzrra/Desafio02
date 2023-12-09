using Dapper;
using Desafio002.Data.Dtos;
using Desafio002.Models;
using Desafio002.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Desafio002.Controllers;

[ApiController]
[Route("/Controller")]
public class UrlController : ControllerBase
{
    private readonly string _connectionstring; 
    public UrlController(IConfiguration configuration)
    {

        _connectionstring = configuration.GetConnectionString("UrlConnection");

    }
    [HttpPost("/post/url")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Post(CreateUrlDto url)
    {
        string encurtado = EncurtadorDeUrl.Encurtador();
        Url URL = new Url(url.URL,encurtado,url.DataAtual);
        var paramenter = new
        {
            urlparamaterid=URL.Id,
            urlparameter = URL.URL,
            urlparameterencurtada = URL.UrlEncurtada,
            urlparameterdata=url.DataAtual
        };
        using (var sqlconnection= new SqlConnection(_connectionstring))
        {
            string query = "insert into url (Id,URL,UrlEncurtada,DataAtual) values (@urlparamaterid,@urlparameter, @urlparameterencurtada, @urlparameterdata)";
            var INSERT= await sqlconnection.ExecuteAsync(query, paramenter);
            return Ok();
        }
       

    }
    [HttpGet("/get-{url}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUrl(string url)
    {
        var parameter = new
        {
            url,
        };
        using (var sqlconnection = new SqlConnection(_connectionstring))
        {
           string sql = "select * from url where URL=@url";
            var geturl=await sqlconnection.QuerySingleAsync<Url>(sql,parameter);
            return Ok(geturl.UrlEncurtada);
        }
        
    }
    [HttpGet("/get/list")]
    public async Task<IActionResult> GetList()
    {
        using (var sqlconncection = new SqlConnection(_connectionstring))
        {
             string query = "select * from url";
            var list=await sqlconncection.QueryAsync<Url>(query);
            return Ok(list);
        }
    }
    [HttpPut("/put/url/{id}")]
    public async Task<IActionResult> Puturl(string id,[FromBody] UpdateUrlDto updateUrlDto)
    {
        string encurtado = EncurtadorDeUrl.Encurtador();
        Url URL = new Url(updateUrlDto.URL, encurtado, updateUrlDto.DataAtual);
        var parameter = new
        {
            parameterurl = URL.URL,
            parameterurlencurtada = URL.UrlEncurtada,
            parameterdata = URL.DataAtual,
            parameterid = id
        };
        using (var sqlconnecntion = new SqlConnection(_connectionstring))
        {
            var query = "update url set URL = @parameterurl, UrlEncurtada=@parameterurlencurtada, DataAtual=@parameterdata where id=@parameterid";
            var put=await sqlconnecntion.ExecuteAsync(query,parameter);
            return NoContent();
        }
    }
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [HttpDelete("/Delete/expired/url/{id?}")]
    public async Task<IActionResult> delete([FromQuery] string? id )
    {
        if(id is null)
        {
            using (var sqlconnection = new SqlConnection(_connectionstring))
            {
                var query = "delete  from url where DATEDIFF(day,DataAtual,GETDATE())>=1;";
                var delete=await sqlconnection.ExecuteAsync(query);
                return Accepted();
            }

        }
        using (var sqlconnection = new SqlConnection(_connectionstring))
        {
            var paramenter = new {Id= id};
            var query = "delete  from url where id=@Id";
            var delete= await sqlconnection.ExecuteAsync(query,paramenter);
            return Accepted();
        }
       
    } 
   
}