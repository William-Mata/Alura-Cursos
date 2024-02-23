namespace Alura.Adopet.Console.Modelos;

public class Cliente
{
    public Cliente(Guid id, string nome, string email, string? cpf)
    {
        Id = id;
        Nome = nome;
        Email = email;
        CPF = cpf;
    }

    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string? CPF { get; set; }

    public override string? ToString()
    {
        return $"{Id} - {Nome} - {Email} - {CPF}";
    }
}