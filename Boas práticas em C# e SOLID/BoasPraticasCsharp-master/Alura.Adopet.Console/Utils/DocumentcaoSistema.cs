using Alura.Adopet.Console.Comands;
using System.Reflection;

namespace Alura.Adopet.Console.Utils;

public class DocumentcaoSistema
{
    public static Dictionary<string, DocComando> ToDictionary(Assembly assemblytDocComando)
    {
        return assemblytDocComando.GetTypes()
          .Where(t => t.GetCustomAttributes<DocComando>().Any())
          .Select(t => t.GetCustomAttribute<DocComando>()!)
          .ToDictionary(d => d.Instrucao);
    }
}
