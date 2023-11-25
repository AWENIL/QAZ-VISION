using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimatedHandOnInput : MonoBehaviour
{
    public InputActionProperty indexAnimationAction;
    public InputActionProperty gripAnimationAction;
    public Animator handAnimator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue = indexAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);
        
        float gripValue = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);

    }
}
