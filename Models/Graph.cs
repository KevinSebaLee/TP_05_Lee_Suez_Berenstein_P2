public class RoomGraph
{
    private int numRooms;
    private List<int>[] connections;
    public bool SeCompleto;

    public RoomGraph(int numRooms)
    {
        connections = new List<int>[numRooms];

        for (int i = 0; i < numRooms; ++i)
        {
            connections[i] = new List<int>();
        }
    }

    public bool seIngresa(int sala){
        if(Escape.salasEscapadas[sala]){
            return true;
        }
        else{
            return false;
        }
    }

    public void AddConnection(int room1, int room2)
    {
        connections[room1].Add(room2);
        connections[room2].Add(room1);
    }
}