using Screen_Sound_3.Models;

namespace Screen_Sound_3.Menus;

public class MenuSair : Menu
{
    public override void Executar()
    {
        base.Executar();

        Console.WriteLine("Até Logo!");
    }
}
