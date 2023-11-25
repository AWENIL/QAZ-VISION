using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassIncreaseButton : MonoBehaviour
{

    public GameObject [] apples;
    public GameObject Trigger;
    public float massIncreaseValue = 1.0f;
    private void Start()
    {
     
        
    }   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == Trigger.name) 
        {
            
            foreach (var obj in apples)
            {
                var applesMass = obj.GetComponent<Rigidbody>().mass;
                obj.GetComponent<Rigidbody>().mass = applesMass + massIncreaseValue;
            }
          
        }

    }

}
