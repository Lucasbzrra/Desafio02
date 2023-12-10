namespace Desafio002.Services;

public class EncurtadorDeUrl : IEncurtadorUrl
{
    /// <summary>
    /// Método que realizar o encurtador de URL
    /// </summary>
    /// <returns> retorna os caracteres</returns>
    public  string Encurtador()
    {
         string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random=new Random();
        return new string(Enumerable.Repeat(letras, 6).Select(s => s[random.Next(s.Length)]).ToArray()); ;

    }

}
