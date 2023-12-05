namespace bytebank_GeradorChavePix;

/// <summary>
/// Classe que gera chave pix utilizando Guid
/// </summary>
public static class GeradorPix
{

    /// <summary>
    /// Método que gera a chave pix utilizando o Guid
    /// </summary>
    /// <returns>O método retorna uma string</returns>
    public static string GerarChavePix()
    {
        return Guid.NewGuid().ToString();
    }

    /// <summary>
    /// Método que gera varias chaves pix's
    /// </summary>
    /// <param name="quantidadeChaves">quantidade de chaves pix's a serem geradas</param>
    /// <returns>retorna uma List de string</returns>
    public static List<string>? GerarChavesPix(int quantidadeChaves)
    {
        if(quantidadeChaves > 0)
        {
            List<string> listChaves = new List<string>();

            for (int i = 0; i < quantidadeChaves; i++)
            {
                var chave = GerarChavePix();
                listChaves.Add(chave);
            }

            return listChaves;
        }

        return null;
    } 
}
