using TMPro;
using UnityEngine;

public class HeightCounter : MonoBehaviour
{
    public Transform apple;
    public Transform polygon;
    public TextMeshProUGUI distanceText;

    void Update()
    {
        // ��������� ���������� ������ �� �������������� (XZ) ���������
        float distanceXZ = Vector2.Distance(new Vector2(apple.position.x, apple.position.z), new Vector2(polygon.position.x, polygon.position.z));

        // �������� ������� (���� apple ���� polygon � ���������� ������)
        if (apple.position.y > polygon.position.y && distanceXZ < 1.0f)
        {
            // ��������� ���������� ������ �� ��� Y
            float distanceY = Mathf.Abs(apple.position.y - polygon.position.y);

            // �������������� ���������� � ����� (������������, ��� 1 ���� = 1 ����)
            float distanceInMeters = distanceY;

            // �������� ����� �� UI
            distanceText.text = "Height\n" + distanceInMeters.ToString("F2") + " meters";
        }
        else
        {
            // ���� ������� �� �����������, �������� ����� �� UI
            distanceText.text = "";
        }
    }
}
