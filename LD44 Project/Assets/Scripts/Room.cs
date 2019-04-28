using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [Tooltip("Respectively: North, South, East, West")]
    [SerializeField] public GameObject[] doors = new GameObject[4];
    [SerializeField] public float[] distances = new float[4];

    private void Start()
    {
        distances[0] = Vector2.Distance(transform.position, doors[0].transform.position);
        distances[1] = Vector2.Distance(transform.position, doors[1].transform.position);
    }

    public GameObject GetRoom(RoomEntrances whichRoom)
    {
        return doors[(int)whichRoom];
    }
}
