namespace FilmesApi.Dtos;

public class ReadCinemaDto
{
    public string Nome { get; set; }
    public ReadEnderecoDto Endereco { get; set; }
    public ICollection<ReadSessaoDto> Sessoes { get; set; }
}
