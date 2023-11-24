using System;

Random random = new Random();
int numeroAleatorio = random.Next(1, 101);
int? numeroDoUsuario = null;

Console.WriteLine(@"
▄▀█ █▀▄ █ █░█ █ █▄░█ █░█ █▀▀   █▀█   █▄░█ █░█ █▀▄▀█ █▀▀ █▀█ █▀█
█▀█ █▄▀ █ ▀▄▀ █ █░▀█ █▀█ ██▄   █▄█   █░▀█ █▄█ █░▀░█ ██▄ █▀▄ █▄█");

Console.WriteLine("\nSeja bem-vindo(a) ao Adivinhe o Número, tente adivinhar o número gerado aleatóriamente.\n");

do
{
    Console.Write("Digite um número de 0 a 100: ");
    string valorUsuario = Console.ReadLine()!;

    if(int.TryParse(valorUsuario, out _))
    {
        numeroDoUsuario = int.Parse(valorUsuario);

        if(numeroDoUsuario == numeroAleatorio)
        {
            Console.WriteLine("Parabéns, você acertou o número!");
        }
        else
        {
            switch (numeroDoUsuario > numeroAleatorio )
            {
                case true: Console.WriteLine("\nO valor digitado é maior que o valor a ser adivinhado.\n"); break;
                case false: Console.WriteLine("\nO valor digitado é menor que o valor a ser adivinhado.\n"); break;
            }
        }
    }

}while(numeroAleatorio != numeroDoUsuario);
