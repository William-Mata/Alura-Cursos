using FluentResults;

namespace Alura.Adopet.Console.Utils;

public class SucessDocs : Success
{

    public IEnumerable<string> Documentacao { get; }

    public SucessDocs(IEnumerable<string> documentacao)
    {
        Documentacao = documentacao;
    }
}