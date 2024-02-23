using Alura.Adopet.Console.Comands.Interfaces;
using Alura.Adopet.Console.Services.Abstracoes;
using Alura.Adopet.Console.Services.Arquivos;
using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Comands;

public class FabricaShow : IFabricaComando
{
    public IComando? CriarComando(string[] argumentos)
    {
        ILeitorArquivos<Pet> leitorArquivoShow = FabricaArquivo.FabricarArquivoPet(arquivo: argumentos.Length > 1 ? argumentos[1] : "")!;
        return new Show(leitorArquivoShow);
    }

    public bool ConsegueCriarComando(Type tipoComando)
    {
        return Type.Equals(tipoComando, typeof(Show));
    }
}