namespace Desafio002.Data.Dtos;

public class CreateUrlDto
{
    public string URL { get; set; }
    public DateTime DataAtual { get; }= DateTime.Now;
}
