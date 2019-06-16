using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
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
        topR = GameObject.FindGameObjectWithTag("TopRight").gameObject.transform.position;
        bottomL = GameObject.FindGameObjectWithTag("BottomLeft").gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (canJump)
        {
            canJump = false;
            bufferVector.Set(UnityEngine.Random.Range(bottomL.x, topR.x), UnityEngine.Random.Range(bottomL.y, topR.y), 0);
            //Debug.Log(bufferVector);
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
