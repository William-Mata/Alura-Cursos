List<int> numeros = new List<int>();

Console.WriteLine("------------------------");
Console.WriteLine("| Apenas Números Pares |");
Console.WriteLine("------------------------");


for(int i = 1; i <= 10; i++)
{
    numeros.Add(i);
}

Console.WriteLine("\n-------");
Console.WriteLine("| For |");
Console.WriteLine("-------");
for(int i = 0 ; i < numeros.Count; i++)
{
    var teste = numeros[i] % 2;
    if(numeros[i] %  2 == 0)
    {
        Console.WriteLine(numeros[i]);
    }
}

Console.WriteLine("\n-----------");
Console.WriteLine("| Foreach |");
Console.WriteLine("-----------");
foreach (int i in numeros.Where(x => x % 2 == 0))
{
    Console.WriteLine(i);
}
