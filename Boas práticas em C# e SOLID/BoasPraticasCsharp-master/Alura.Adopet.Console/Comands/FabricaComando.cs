using Alura.Adopet.Console.Comands.Interfaces;
using Alura.Adopet.Console.Extensions;
using System.Reflection;
namespace Alura.Adopet.Console.Comands
{
    public static class FabricaComando
    {
        public static IComando? FabricarComando(string[] args)
        {
            var comando = args[0];
            Type? type = Assembly.GetExecutingAssembly().GetTipoComando(comando);
            var listFabricas = Assembly.GetExecutingAssembly().GetComandos();

            var fabrica = listFabricas.Where(x => x.ConsegueCriarComando(type)).FirstOrDefault();

            if(fabrica is not null)
            {
                return fabrica.CriarComando(args);
            }

            return null;
        }
    }
}
