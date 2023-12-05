using System.Xml.Serialization;

namespace bytebank_GeradorArquivo.bytebank.Util;

/// <summary>
/// Classe que gera arquivos JSON e XML
/// </summary>
/// <typeparam name="T"></typeparam>
public static class Arquivo<T> where T : class
{
    public static string caminhoArquivo = "../../../../Arquivos/";

    /// <summary>
    /// Método que gera arquivo JSON, o método espera uma List de informação
    /// </summary>
    /// <param name="objetos"></param>
    public static void GerarArquivoJSON(List<T> objetos)
    {
        var arquivo = caminhoArquivo + "arquivoJson.json";

        using(var fileStream =  new FileStream(arquivo, FileMode.Create))
        {
            using(var streamWriter = new StreamWriter(fileStream))
            {
                var jsonConvertido =  System.Text.Json.JsonSerializer.Serialize(objetos);
                streamWriter.Write(jsonConvertido);
            }
            Console.WriteLine($"Arquivo gerado com sucesso no seguinte caminho: {arquivo}");
        }
    }

    /// <summary>
    /// Método que gera arquivo XML, o método espera uma List de informação
    /// </summary>
    /// <param name="objetos"></param>
    public static void GerarArquivoXML(List<T> objetos)
    {
        var arquivo = caminhoArquivo + "arquivoXML.xml";
        using (var fileStream = new FileStream(arquivo, FileMode.Create))
        {
            using (var streamWriter = new StreamWriter(fileStream))
            {
                var xml = new XmlSerializer(typeof(List<T>));
                xml.Serialize(streamWriter, objetos);
            }
            Console.WriteLine($"Arquivo gerado com sucesso no seguinte caminho: {arquivo}");
        }
    }
}
