using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsButton : MonoBehaviour
{
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;

    public UnityEvent onPressed, onReleased;
    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;

    void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isPressed && GetValue() + threshold >= 1)
        {
            Pressed();
        }
        if (_isPressed && GetValue() - threshold <= 0)
        {
            Released();
        }

    }

    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;
        if (Mathf.Abs(value) < deadZone)
        {
            value = 0;
        }
        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()
    {
        _isPressed = true;
        onPressed.Invoke();
        Debug.Log("pressed");

        GameObject apple = GameObject.Find("apple");
        if (apple != null)
        {
            Rigidbody rb = apple.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.mass += 5f; 
                Debug.Log("Mass of apple changed to: " + rb.mass);
            }
        }
    }

    private void Released()
    {
        _isPressed = false;
        onReleased.Invoke();
        Debug.Log("released");
    }
}

