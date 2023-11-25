using UnityEngine;
using System.Collections.Generic;


public class AppleBehavior : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        // Получаем компонент Rigidbody
        rb = GetComponent<Rigidbody>();

        // Устанавливаем массу для объекта "apple"
        rb.mass = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        // Дополнительная логика для объекта "apple"
    }
}
