using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSkl : BaseAct
{
    [SerializeField] private GameObject projectileToCast;

    float countdown = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown > 0)
            countdown -= Time.deltaTime;
    }

    public override void DoAction()
    {
        if (countdown <= 0)
        {
            float x = (float)GetComponent<PlayerController>().GetHorizontalLook();
            float y = (float)GetComponent<PlayerController>().GetVerticalLook();
            Instantiate(projectileToCast, transform.position, Quaternion.identity).GetComponent<Projectile>().SetDirection(x, y);
            countdown = cooldown;
        }
    }
}
