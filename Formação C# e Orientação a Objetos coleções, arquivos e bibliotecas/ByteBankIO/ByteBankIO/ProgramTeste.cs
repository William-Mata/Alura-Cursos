using ByteBankIO.Enums;

partial class Program
{
    static void ProgramaTeste()
    {
        #region ENUM
        Console.WriteLine(Cores.Azul == (Cores)0); // escreve True
        Console.WriteLine(Cores.Vermelho == (Cores)1); // escreve True
        Console.WriteLine(Cores.Verde == (Cores)2); // escreve True
        #endregion
    }
}