using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumper : MonoBehaviour
{
    [SerializeField] GameObject myRoom;
    [SerializeField] float speed;
    [SerializeField] float timeBetweenJumps;

    Vector2 bottomL, topR;
    Vector3 bufferVector;
    bool canJump = true, dontCount = true;

    // Start is called before the first frame update
    void Start()
    {
        topR = myRoom.GetComponent<Room>().GetTopR();
        bottomL = myRoom.GetComponent<Room>().GetBottomL();
    }

    // Update is called once per frame
    void Update()
    {
        if (canJump)
        {
            canJump = false;
            if(FindObjectOfType<PlayerController>())
            bufferVector = FindObjectOfType<PlayerController>().gameObject.transform.position;
            Debug.Log(bufferVector);
        }
        else if (transform.position == bufferVector && dontCount)
        {
            StartCoroutine(Wait());
        }
        else
            transform.position = Vector3.MoveTowards(transform.position, bufferVector, speed * Time.deltaTime);
    }


    private IEnumerator Wait()
    {
        dontCount = false;
        yield return new WaitForSeconds(timeBetweenJumps);
        dontCount = true;
        canJump = true;
    }
}
