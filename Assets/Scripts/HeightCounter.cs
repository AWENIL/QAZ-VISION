using TMPro;
using UnityEngine;

public class HeightCounter : MonoBehaviour
{
    public Transform apple;
    public Transform polygon;
    public TextMeshProUGUI distanceText;

    void Update()
    {
        // Вычислить расстояние только по горизонтальной (XZ) плоскости
        float distanceXZ = Vector2.Distance(new Vector2(apple.position.x, apple.position.z), new Vector2(polygon.position.x, polygon.position.z));

        // Проверка условия (если apple выше polygon и достаточно близко)
        if (apple.position.y > polygon.position.y && distanceXZ < 1.0f)
        {
            // Вычислить расстояние только по оси Y
            float distanceY = Mathf.Abs(apple.position.y - polygon.position.y);

            // Конвертировать расстояние в метры (предполагаем, что 1 юнит = 1 метр)
            float distanceInMeters = distanceY;

            // Обновить текст на UI
            distanceText.text = "Height\n" + distanceInMeters.ToString("F2") + " meters";
        }
        else
        {
            // Если условие не выполняется, очистите текст на UI
            distanceText.text = "";
        }
    }
}
