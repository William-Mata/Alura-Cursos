namespace bytebank_Modelos.bytebank.Modelos.ADM.Utilitario;

internal class AutenticacaoUtil
{
    public bool ValidarSeha(string senha, string senhaValidar)
    {
        return senha.Equals(senhaValidar);
    }
}
