static class Escape
{
    private static string[] incognitasSalas { get; set; }
    public static bool[] salasEscapadas { get; set; }
    public static int[] DigitosHall2 {get; set;}
    public static int[] DigitosHall1 {get; set;}
    private static int hall2Codigo, hall1Codigo;
    public static int vidas;
    public static RoomGraph Graph;
    public static int estadoJuego = 1;

    public static void InicializarJuego()
    {
        Random rnd = new Random();

        DigitosHall1 = new int[3];
        DigitosHall2 = new int[4];
        Array.Fill(DigitosHall1, 0);
        Array.Fill(DigitosHall2, 0);

        do{
            hall2Codigo = rnd.Next(1000, 9999);
            DigitosHall2 = hall2Codigo.ToString().Select(digit => int.Parse(digit.ToString())).ToArray();
        }while(!(DigitosHall2[0] < DigitosHall2[1] && DigitosHall2[0] < DigitosHall2[2] && DigitosHall2[0] < DigitosHall2[3] && DigitosHall2[2] > DigitosHall2[1] && DigitosHall2[2] > DigitosHall2[3]));

        do{
            hall1Codigo = rnd.Next(100, 999);
            DigitosHall1 = hall1Codigo.ToString().Select(digit => int.Parse(digit.ToString())).ToArray();
        }while(!(DigitosHall1[0] < DigitosHall1[1] && DigitosHall1[0] < DigitosHall1[2] && DigitosHall1[2] > DigitosHall1[1]));

        incognitasSalas = new string[17] {"2", "rombo", "5", "cerilla", hall2Codigo.ToString(), hall1Codigo.ToString(), "caja de cerillas", "4", "derecha", "", "", "", "", "", "", "", ""};

        salasEscapadas = new bool[16];
        Array.Fill(salasEscapadas, false);
        
        vidas = 5;

        Graph = new RoomGraph(17);

        Graph.AddConnection(1, 2); Graph.AddConnection(1, 3); Graph.AddConnection(1, 4); Graph.AddConnection(1, 5);
        Graph.AddConnection(5, 6);
        Graph.AddConnection(6, 7); Graph.AddConnection(6, 8); Graph.AddConnection(6, 9); Graph.AddConnection(6, 10);
        Graph.AddConnection(10, 11); Graph.AddConnection(10, 12); Graph.AddConnection(10, 13); Graph.AddConnection(10, 14); Graph.AddConnection(10, 15); Graph.AddConnection(10, 16);
    }

    public static int GetEstadoJuego()
    {
        int siEscapo = estadoJuego;

        return siEscapo;
    }

    public static bool ResolverSala(string Incognita)
    {
        int SalaEstado;

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

    public static bool perdioJuego(){
        if(vidas == 0){
            return false;
        }
        else{
            return true;
        }
    }
}