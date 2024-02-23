namespace Alura.Adopet.Console.Services;
public static class ProcessaProgresso
{
    public static void ProgressChanged(int progresso, int total)
    {
        System.Console.CursorLeft = 0;
        System.Console.Write("["); // Início da barra de progresso

        int progressBarWidth = System.Console.WindowWidth - 2; // A largura da barra de progresso é o tamanho da janela menos os caracteres [ e ]
        int completedWidth = (int)((double)progresso / total * progressBarWidth);

        System.Console.BackgroundColor = ConsoleColor.Green; // Cor da parte concluída
        System.Console.Write(new string(' ', completedWidth)); // Preencher a parte concluída
        System.Console.ResetColor(); // Resetar a cor de fundo

        System.Console.Write(new string(' ', progressBarWidth - completedWidth)); // Preencher a parte restante
        System.Console.Write("]"); // Fim da barra de progresso

        System.Console.WriteLine($" {((double)progresso / (double)total) * 100}%"); // Exibir a porcentagem de progresso
    }
}