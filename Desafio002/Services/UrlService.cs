using Dapper;
using Desafio002.Models;
using Microsoft.Data.SqlClient;

namespace Desafio002.Services;

public class UrlService : IUrlService
{
    private readonly string _connectionString;
    public UrlService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("UrlConnection");
    }
    public async Task<IEnumerable<Url>> GetList()
    {
        using (var sqlconnection= new SqlConnection(_connectionString))
        {
            string query = "select * from url";
            var list = sqlconnection.QueryAsync<Url>(query);
            return await list;
        }
    }

    public async Task<Url> GetUrl(string url)
    {
        var parameter = new
        {
           parameterurl= url,
        };
        using (var sqlconnection = new SqlConnection(_connectionString))
        {
            string sql = "select * from url where URL=@parameterurl";
            var geturl =  sqlconnection.QuerySingleAsync<Url>(sql, parameter);
            return  await geturl;
        }
    }

    public async Task<int> Create(Url url)
    {
        var parameter = new
        {
            parameterId = url.Id,
            parameterUrl = url.URL,
            parameterUrlEcurtada = url.UrlEncurtada,
            parameterDataAtual = url.DataAtual
        };

        using (var sqlconnection = new SqlConnection(_connectionString))
        {
            string query = "insert into url (Id,URL,UrlEncurtada,DataAtual) values (@parameterId,@parameterUrl, @parameterUrlEcurtada, @parameterDataAtual)";
            var insert = await sqlconnection.ExecuteAsync(query, parameter);
            return  insert;
        }
    }

    public async Task<int> Update(string Id,Url url)
    {
        var parameterupdate = new
        {
            parameterUrl = url.URL,
            parameterUrlEncurtada = url.UrlEncurtada,
            parameterUrlDataAtual = url.DataAtual,
            parameterId = Id
        };
        using (var sqlconnection = new SqlConnection((_connectionString)))
        {
            var query = "update url set URL= @parameterUrl, UrlEncurtada=@parameterUrlEncurtada, DataAtual=@parameterUrlDataAtual where Id=@parameterId";
            var put=await sqlconnection.ExecuteAsync(query, parameterupdate);
            return put;
        }
    }
    public async Task<int> DeleteExpired()
    {
      
        using (var sqlconnection = new SqlConnection(_connectionString))
        {
            var query = "delete  from url where DATEDIFF(day,DataAtual,GETDATE())>=1;";
            var delete = await sqlconnection.ExecuteAsync(query);
            return delete;
        }
    }

    public async Task<int> DeleteUrl(string id)
    {
        using (var sqlconnection = new SqlConnection(_connectionString))
        {
            var paramenter = new { Id = id };
            var query = "delete  from url where id=@Id";
            var delete = await sqlconnection.ExecuteAsync(query, paramenter);
            return delete;
        }
    }


}
