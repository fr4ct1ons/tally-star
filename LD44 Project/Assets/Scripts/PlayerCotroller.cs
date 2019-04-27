using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCotroller : MonoBehaviour
{
    // Fields that vary from character to character
    [SerializeField] float movementSpeed;
    [SerializeField] GameObject meleeCollider;

    // Cache variables
    Vector2 bufferVector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetMovementInput();
        GetAttackInput();
    }

    private void GetMovementInput()
    {
        bufferVector.Set(transform.position.x, transform.position.y);

        if (Input.GetAxisRaw("Horizontal") > 0.1f)
        {
            bufferVector.Set(transform.position.x + 1, bufferVector.y);
        }
        else if (Input.GetAxisRaw("Horizontal") < -0.1f)
        {
            bufferVector.Set(transform.position.x - 1, bufferVector.y);
        }

        if (Input.GetAxisRaw("Vertical") > 0.1f)
        {
            bufferVector.Set(bufferVector.x, transform.position.y + 1);
        }
        else if (Input.GetAxisRaw("Vertical") < -0.1f)
        {
            bufferVector.Set(bufferVector.x, transform.position.y - 1);
        }
        print("Input2: " + Input.GetAxis("Horizontal"));
        print("Input2: " + Input.GetAxis("Vertical"));

        transform.position = Vector2.MoveTowards(transform.position, bufferVector, Time.deltaTime * movementSpeed);
    }

    private void GetAttackInput()
    {
        if (Input.GetButton("MeleeAtk"))
        {
            GetComponent<MeleeAtk>().DoAction();
        }
        else if (Input.GetButton("RangedAtk"))
        {
            GetComponent<RangedAtk>().DoAction();
        }
    }

}
