namespace Desafio002.Services;

public class EncurtadorDeUrl
{
    /// <summary>
    /// Método que realizar o encurtado de URL
    /// </summary>
    /// <returns> retorna os caracteres</returns>
    public static string Encurtador()
    {
         string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random=new Random();
        return new string(Enumerable.Repeat(letras, 6).Select(s => s[random.Next(s.Length)]).ToArray()); ;

    }
    /// Este méotodo seria utilizado caso não tivesse utilizado a biblioteca DAPPER

    //public async Task<IEnumerable<Url>> RemoveExpired()
    //{
    //    var list = _context.url.FromSqlRaw($"select *  from url where DATEDIFF(day,DataAtual,GETDATE())>=1;");
    //    return  await list.ToListAsync();
    //}
}
