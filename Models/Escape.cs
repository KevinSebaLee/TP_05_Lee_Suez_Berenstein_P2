static class Escape
{
    private static string[] incognitasSalas { get; set; }
    public static bool[] salasEscapadas { get; set; }
    public static int[] DigitosHall2 {get; set;}
    private static int hall2Codigo;
    public static int vidas;
    public static RoomGraph Graph;
    public static int estadoJuego = 1;

    public static void InicializarJuego()
    {
        Random rnd = new Random();

        hall2Codigo = rnd.Next(9999);

        DigitosHall2 = hall2Codigo.ToString().Select(digit => int.Parse(digit.ToString())).ToArray();

        incognitasSalas = new string[9] { "2", "rombo", "5", "cerilla", hall2Codigo.ToString(), "Intercambiar Caballos", "55+5", "Criada", "Ciego" };

        salasEscapadas = new bool[16];
        Array.Fill(salasEscapadas, false);

        vidas = 5;

        Graph = new RoomGraph(17);

        Graph.AddConnection(1, 2); Graph.AddConnection(1, 3); Graph.AddConnection(1, 4);
        Graph.AddConnection(4, 5); Graph.AddConnection(4, 6);
        Graph.AddConnection(6, 7); Graph.AddConnection(6, 8); Graph.AddConnection(6, 9); Graph.AddConnection(6, 15);
        Graph.AddConnection(15, 10); Graph.AddConnection(15, 11); Graph.AddConnection(15, 12); Graph.AddConnection(15, 16); Graph.AddConnection(15, 14); Graph.AddConnection(15, 13);
    }

    public static int GetEstadoJuego()
    {
        int siEscapo = estadoJuego;

        return siEscapo;
    }

    public static bool TerminoSala()
    {
        if (GetEstadoJuego() == incognitasSalas.Count())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool ResolverSala(string Incognita)
    {
        int SalaEstado;

        Console.WriteLine(GetEstadoJuego());
        Console.WriteLine(Incognita);
        Console.WriteLine(incognitasSalas[GetEstadoJuego() - 1]);

        if (incognitasSalas != null)
        {
            if (incognitasSalas[GetEstadoJuego() - 1] == Incognita)
            {
                SalaEstado = GetEstadoJuego();
                salasEscapadas[SalaEstado] = true;

                return true;
            }
            else
                return false;
        }
        else
        {
            InicializarJuego();

            return false;
        }
    }
}