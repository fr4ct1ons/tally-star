using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    float openX = 0, openY = 0;
    [SerializeField] RoomEntrances location;
    bool isClosed = true;

    private void Awake()
    {
        switch (location)
        {
            case RoomEntrances.NORTH:
                openY = 1;
                break;
            case RoomEntrances.SOUTH:
                openY = -1;
                break;
            case RoomEntrances.EAST:
                openX = 1;
                break;
            case RoomEntrances.WEST:
                openX = -1;
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isClosed)
        {
            isClosed = false;
            Vector2 whereToSpawn = new Vector2(transform.position.x + openX, transform.position.y + openY);
            FindObjectOfType<GameController>().GenerateRoom(whereToSpawn, location);
            Destroy(gameObject);
        }
    }
}
