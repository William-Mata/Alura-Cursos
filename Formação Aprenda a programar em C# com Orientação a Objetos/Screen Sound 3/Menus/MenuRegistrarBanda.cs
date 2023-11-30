using Screen_Sound_3.Client;
using Screen_Sound_3.Models;

namespace Screen_Sound_3.Menus;

public class MenuRegistrarBanda : Menu
{
    #region Atributos/Propriedades
    private MenuOpcoes menuOpcoes = new();
    #endregion

    #region Métodos/Construtores
    public override void Executar()
    {
        base.Executar();

        FormatarTitulo("# Registro de Banda #");
        Console.Write("\nDigite o nome da banda: ");
        var nomeDaBanda = Console.ReadLine()!;
        var descricao = ChatGPT.PerguntarChatGPTAsync($"Resuma a banda {nomeDaBanda}! Em 1 parágrafo. Adote um estilo informal.").Result;
        Banda banda = new Banda(nomeDaBanda, descricao);
        bandas.Add(banda);
        Console.WriteLine($"A banda \"{nomeDaBanda}\" foi cadastrada com sucesso!");
        menuOpcoes.VoltarAoMenuDeOpcoes();
    }
    #endregion
}
