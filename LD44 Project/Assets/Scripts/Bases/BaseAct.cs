using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAct : MonoBehaviour
{

    [SerializeField] protected int damage;
    [SerializeField] protected int cooldown;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void DoAction()
    {
        Debug.Log("Base action!");
    }
}
