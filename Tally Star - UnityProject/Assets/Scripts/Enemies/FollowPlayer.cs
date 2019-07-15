using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] float movementSpeed;

    GameObject target;
    bool follow = true;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(target)
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, movementSpeed * Time.deltaTime);
    }
}
