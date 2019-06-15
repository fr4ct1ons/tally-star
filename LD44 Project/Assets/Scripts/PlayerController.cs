using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Fields that vary from character to character
    [SerializeField] float movementSpeed;
    [SerializeField] GameObject meleeCollider;
    [SerializeField] float deadZone = 0.2f;

    // Cache variables
    Vector2 bufferVector;
    HorizontalDirection horizontalLook = HorizontalDirection.MID;
    VerticalDirection verticalLook = VerticalDirection.SOUTH;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //bufferVector.Set(transform.position.x, transform.position.y);
        animator = GetComponent<Animator>();
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

        if (Input.GetAxis("Horizontal") > deadZone)
        {
            bufferVector.Set(transform.position.x + 1, bufferVector.y);
        }
        else if (Input.GetAxis("Horizontal") < -deadZone)
        {
            bufferVector.Set(transform.position.x - 1, bufferVector.y);
        }

        if (Input.GetAxis("Vertical") > deadZone)
        {
            bufferVector.Set(bufferVector.x, transform.position.y + 1);
        }
        else if (Input.GetAxis("Vertical") < -deadZone)
        {
            bufferVector.Set(bufferVector.x, transform.position.y - 1);
        }

        

        if(Input.GetAxisRaw("Vertical") > 0.1f && Input.GetAxisRaw("Horizontal") > 0.1f)
        {
            horizontalLook = HorizontalDirection.EAST;
            verticalLook = VerticalDirection.NORTH;
        }
        else if (Input.GetAxisRaw("Vertical") < -0.1f && Input.GetAxisRaw("Horizontal") > 0.1f)
        {
            horizontalLook = HorizontalDirection.EAST;
            verticalLook = VerticalDirection.SOUTH;
        }
        else if (Input.GetAxisRaw("Vertical") > 0.1f && Input.GetAxisRaw("Horizontal") < -0.1f)
        {
            horizontalLook = HorizontalDirection.WEST;
            verticalLook = VerticalDirection.NORTH;
        }
        else if (Input.GetAxisRaw("Vertical") < -0.1f && Input.GetAxisRaw("Horizontal") < -0.1f)
        {
            horizontalLook = HorizontalDirection.WEST;
            verticalLook = VerticalDirection.SOUTH;
        }// FIM DIAGONAIS
        else if (Input.GetAxisRaw("Vertical") == 0.0f && Input.GetAxisRaw("Horizontal") < -0.1f)
        {
            horizontalLook = HorizontalDirection.WEST;
            verticalLook = VerticalDirection.MID;
        }
        else if (Input.GetAxisRaw("Vertical") > 0.1f && Input.GetAxisRaw("Horizontal") == 0.0f)
        {
            horizontalLook = HorizontalDirection.MID;
            verticalLook = VerticalDirection.NORTH;
        }
        else if (Input.GetAxisRaw("Vertical") < -0.1f && Input.GetAxisRaw("Horizontal") == 0.0f)
        {
            horizontalLook = HorizontalDirection.MID;
            verticalLook = VerticalDirection.SOUTH;
        }
        else if (Input.GetAxisRaw("Vertical") == 0.0f && Input.GetAxisRaw("Horizontal") > 0.1f)
        {
            horizontalLook = HorizontalDirection.EAST;
            verticalLook = VerticalDirection.MID;
        }

        
        if(animator.GetInteger("verticalLook") != (int)verticalLook || animator.GetInteger("horizontalLook") != (int)horizontalLook)
        {
            animator.SetTrigger("goToStart");
        }
        
        //if (animator.GetInteger("verticalLook") != (int)verticalLook)
            animator.SetInteger("verticalLook", (int)verticalLook);
        //if(animator.GetInteger("horizontalLook") != (int)horizontalLook)
            animator.SetInteger("horizontalLook", (int)horizontalLook);

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
        else if (Input.GetButton("AttackSkl"))
        {
            GetComponent<AttackSkl>().DoAction();
        }
    }

    public HorizontalDirection GetHorizontalLook() { return horizontalLook; }
    public VerticalDirection GetVerticalLook() { return verticalLook; }

}
