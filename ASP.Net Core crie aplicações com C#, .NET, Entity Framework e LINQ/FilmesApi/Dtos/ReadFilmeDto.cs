﻿namespace FilmesApi.Dtos;

public class ReadFilmeDto
{
    public string Titulo { get; set; }

    public string Descricao { get; set; }

    public string Genero { get; set; }

    public float Duracao { get; set; }
    public ICollection<ReadSessaoDto> Sessoes { get; set; }
}
