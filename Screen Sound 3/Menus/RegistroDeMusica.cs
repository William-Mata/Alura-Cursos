using Screen_Sound_3.Models;

namespace Screen_Sound_3.Menus;

public class RegistroDeMusica : Menu
{
    public List<Musica> RegistrarMusica(Banda banda)
    {
        List<Musica> musicas = new List<Musica>();
        var opcao = "1";
        Console.WriteLine();
        FormatarTitulo("# Registro de Música #");

        do
        {
            Console.Write($"\nDigite o nome da Música: ");
            var nomeDaMusica = Console.ReadLine()!;

            Console.Write($"Digite o tempo de duração da Música: ");
            var duracaoDaMusica = Console.ReadLine()!;

            Console.Write($"Digite o ano de lançamento da Música: ");
            var anoLancamentoDaMusica = Console.ReadLine()!;

            Console.Write($"Digite o gênero da Música: ");
            var generoDaMusica = Console.ReadLine()!;

            if (!string.IsNullOrEmpty(nomeDaMusica))
            {
                var musica = new Musica(nomeDaMusica, banda);
                musica.Duracao = float.Parse(duracaoDaMusica);
                musica.AnoDeLancamento = int.Parse(anoLancamentoDaMusica);
                musica.Genero = new Genero(generoDaMusica);

                musicas.Add(musica);
                Console.WriteLine($"A música {musica.Nome} foi cadastrada com sucesso!");
            }

            Console.WriteLine($"\nDigite 1 para cadastrar outra música: ");
            Console.WriteLine($"Digite 0 para sair: ");
            Console.Write($"Digite a opção: ");
            opcao = Console.ReadLine()!;

        } while (opcao != "0");

        return musicas;
    }
}
