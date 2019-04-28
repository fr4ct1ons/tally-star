using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VerticalDirection
{
    SOUTH = -1,
    MID,
    NORTH
}

public enum HorizontalDirection
{
    WEST = -1,
    MID,
    EAST
}

public enum RoomEntrances
{
    NORTH, SOUTH, EAST, WEST
}

public class GameController : MonoBehaviour
{

    [SerializeField] GameObject[] rooms;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateRoom(Vector2 whereToSpawn, RoomEntrances entranceDoor)
    {
        int roomToSpawn = UnityEngine.Random.Range(0, rooms.Length - 1);
        GameObject newRoom = Instantiate(rooms[roomToSpawn], whereToSpawn, Quaternion.identity);
        Vector2 bufferVector = transform.position;
        newRoom.GetComponent<Room>().SetPosition(entranceDoor);
        
        
    }
}
