using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    GameObject player;
    Vector3 bufferVector;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(player)
            bufferVector.Set(player.transform.position.x, player.transform.position.y, -10);
        transform.position = bufferVector;
    }
}
