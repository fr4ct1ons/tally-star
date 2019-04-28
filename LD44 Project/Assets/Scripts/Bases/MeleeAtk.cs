using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAtk : BaseAct
{
    [SerializeField] GameObject weaponObject;

    Animator animator;
    bool canAttack = true;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void DoAction()
    {
        if (canAttack)
        {
            MeleeAction();
        }
    }
    
    public virtual void MeleeAction()
    {
        Debug.Log("Base melee attack");
        canAttack = false;
        weaponObject.SetActive(true);
        animator.SetBool("attack", true);
    }

    public virtual void MeleeStopAction()
    {
        weaponObject.SetActive(false);
        canAttack = true;
        animator.SetBool("attack", false);
    }
}
