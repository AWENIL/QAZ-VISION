using UnityEngine;

public class HeightMesure : MonoBehaviour
{
    public GameObject objectToMeasure;

    void Update()
    {
        if (objectToMeasure != null)
        {
            float height = MeasureHeight(objectToMeasure);
            Debug.Log("������ ������� � ������: " + height);
        }
        else
        {
            Debug.LogError("������ ��� ��������� �� ��������!");
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
            Debug.LogError("��������� Renderer �� ������ �� �������!");
            return 0;
        }
    }
}
