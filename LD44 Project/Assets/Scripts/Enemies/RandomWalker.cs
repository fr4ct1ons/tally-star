using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalker : MonoBehaviour
{

    [SerializeField] GameObject myRoom;
    [SerializeField] float speed;
    [SerializeField] float timeBetweenJumps;

    Vector2 topR, bottomL;
    Vector3 bufferVector;
    bool canWalk = true;

    // Start is called before the first frame update
    void Start()
    {
        topR = myRoom.GetComponent<Room>().GetTopR();
        bottomL = myRoom.GetComponent<Room>().GetBottomL();
    }

    // Update is called once per frame
    void Update()
    {
        if (canWalk)
        {
            StartCoroutine(WalkAround());
        }

        //Debug.Log(bufferVector);
        transform.position = Vector3.MoveTowards(transform.position, bufferVector, speed * Time.deltaTime);
    }

    IEnumerator WalkAround()
    {
        canWalk = false;
        bufferVector.Set(UnityEngine.Random.Range(bottomL.x, topR.x), UnityEngine.Random.Range(bottomL.y, topR.y), 0);
        //Debug.Log("Enter cooldown");
        yield return new WaitForSeconds(timeBetweenJumps);
        canWalk = true;
    }
}
