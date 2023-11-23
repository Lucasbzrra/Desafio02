namespace Desafio002.Services;

public class EncurtadorDeUrl
{
    public static string Encurtador()
    {
         string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random=new Random();
        return new string(Enumerable.Repeat(letras, 6).Select(s => s[random.Next(s.Length)]).ToArray()); ;

    }
}
