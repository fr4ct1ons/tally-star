using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] GameObject myRoom;
    [SerializeField] float timeBetweenJumps;

    Vector2 bottomL, topR, bufferVector;
    bool canJump = true;

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
            StartCoroutine(Teleport());
        }
    }

    private IEnumerator Teleport()
    {
        canJump = false;
        yield return new WaitForSeconds(timeBetweenJumps);
        bufferVector.Set(UnityEngine.Random.Range(bottomL.x, topR.x), UnityEngine.Random.Range(bottomL.y, topR.y));
        transform.position = bufferVector;
        canJump = true;
    }
}
