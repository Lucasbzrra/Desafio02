using Desafio002.Models;

namespace Desafio002.Services;

public interface IUrlService
{
    Task<int> Create(Url url);

    Task<Url> GetUrl(string url);
    Task<int> DeleteUrl(string url);
    Task<int>  DeleteExpired();
    Task<int> Update(string id,Url url);
    Task<IEnumerable<Url>> GetList();
}
