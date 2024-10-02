namespace ExercicioRandon;

public static class Valores
{
    public static Random _rand = new Random();
    public static void CustomGenareted(int[] lenghts, int length, int min = 1, int max = 51)
    {
        var soma = lenghts.Sum(x => x);
        if (soma > length || soma == 0)
        {
            Console.WriteLine("Tamando da soma dos numeros absolutos não pode superar o tamanho total de item esperado");
            return;
        }
        if (length > 50)
        {
            Console.WriteLine("Tamanho nao suportado!");
            return;
        }
        var list = new int[length];
        int count = 0;
        for (int i = 0; lenghts.Length > i; i++)
        {
            if (lenghts[i] != 0)
            {
                list[count] = GerarNumeroValido(new Random().Next(min, max), list, min, max);
                count++;
                for (int j = 1; j < lenghts[i]; j++)
                {
                    list[count] = list[count - 1];
                    count++;

                }
            }
        }

        for (int i = count; i < length; i++)
        {
            list[count] = GerarNumeroValido(_rand.Next(min, max), list, min, max);
            count++;
        }

        Console.WriteLine($"[ {string.Join(" ,", list)}]");
    }
    public static int GerarNumeroValido(int valor, int[] listExists, int min = 1, int max = 51)
            => listExists.Any(x => x == valor || valor == 0) ? GerarNumeroValido(_rand.Next(min, max), listExists, min, max) : valor;
}
