using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] float openX, openY;
    [SerializeField] RoomEntrances location;
    bool isClosed = true;

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
