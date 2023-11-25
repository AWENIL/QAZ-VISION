using System;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    private Vector3[] initialPositions;
    private Quaternion[] initialRotations;
    public GameObject[] apples;
    public GameObject Trigger;

    void Start()
    {
        SaveInitialPositions();
        SaveInitialRotations();
    }

    void SaveInitialRotations()
    {
        initialRotations = new Quaternion[apples.Length];

        for (int i = 0; i < apples.Length; i++)
        {
            initialRotations[i] = apples[i].transform.rotation;
        }
    }

    void SaveInitialPositions()
    {
        initialPositions = new Vector3[apples.Length];

        for (int i = 0; i < apples.Length; i++)
        {
            initialPositions[i] = apples[i].transform.position;
        }
    }

    // Вызывается при соприкосновении объектов
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == Trigger.name)
        {
            for (int i = 0; i < apples.Length; i++)
            {
                Debug.Log("Respawning apple...");
                apples[i].transform.position = initialPositions[i];
                apples[i].transform.rotation = initialRotations[i];
            }
        }
    }

    bool IsApple(GameObject obj)
    {
        return Array.IndexOf(apples, obj) != -1;
    }
}
