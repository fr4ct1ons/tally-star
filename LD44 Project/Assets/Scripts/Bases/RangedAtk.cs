using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAtk : BaseAct
{
    [SerializeField] GameObject projectileToShoot;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public override void DoAction()
    {
        Debug.Log("Base ranged attack");
        float x = (float)GetComponent<PlayerController>().GetHorizontalLook();
        float y = (float)GetComponent<PlayerController>().GetVerticalLook();
        Instantiate(projectileToShoot, transform.position, Quaternion.identity).GetComponent<Projectile>().SetDirection(x, y);
    }
}
