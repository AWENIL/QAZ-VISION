using UnityEngine;
using System.Collections.Generic;


public class AppleBehavior : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        // �������� ��������� Rigidbody
        rb = GetComponent<Rigidbody>();

        // ������������� ����� ��� ������� "apple"
        rb.mass = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        // �������������� ������ ��� ������� "apple"
    }
}
