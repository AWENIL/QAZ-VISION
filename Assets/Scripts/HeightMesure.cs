using UnityEngine;

public class HeightMesure : MonoBehaviour
{
    public GameObject objectToMeasure;

    void Update()
    {
        if (objectToMeasure != null)
        {
            float height = MeasureHeight(objectToMeasure);
            Debug.Log("Высота объекта в метрах: " + height);
        }
        else
        {
            Debug.LogError("Объект для измерения не назначен!");
        }
    }

    float MeasureHeight(GameObject obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();

        if (renderer != null)
        {
            float heightInMeters = renderer.bounds.size.y;
            float scaledHeight = heightInMeters * obj.transform.localScale.y;
            return scaledHeight;
        }
        else
        {
            Debug.LogError("Компонент Renderer не найден на объекте!");
            return 0;
        }
    }
}
