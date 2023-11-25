using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassDecreaseButton : MonoBehaviour
{
    public GameObject[] apples;
    public GameObject Trigger;
    public float MassDecreaseValue = 1.0f;
    private void OnTriggerEnter(Collider other)
    {
        
        foreach (var obj in apples)
        {
            var objectMass = obj.GetComponent<Rigidbody>().mass;
            if(objectMass > MassDecreaseValue)
            {
                obj.GetComponent<Rigidbody>().mass = objectMass - MassDecreaseValue;
            }
            else
            {
                Debug.Log("Mass will be zero");
                break;
            }
            
        }
    }

}
