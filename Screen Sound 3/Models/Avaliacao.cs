namespace Screen_Sound_3.Models;

public class Avaliacao
{
    #region Atributos/Propriedades
    public float Nota { get; }
    #endregion

    #region Métodos/Construtores
    public Avaliacao(float nota)
    {
        if (nota < 0)
        {
            nota = 0;
        }
        else if (nota > 10)
        {
            nota = 10;
        }

        Nota = nota;
    }

    public static Avaliacao Parse(string nota)
    {
        var notaApoio = float.Parse(nota);
        return new Avaliacao(notaApoio);
    }

    #endregion  

}
