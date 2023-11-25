using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform targetObject; // Объект, за которым должна следовать панель
    public Vector3 offset; // Смещение относительно объекта

    void Update()
    {
        if (targetObject != null)
        {
            // Обновляем позицию панели, чтобы она находилась рядом с объектом
            transform.position = targetObject.position + offset;

            // Опционально: можно добавить код для ориентации панели к игроку или в определенном направлении
            // transform.LookAt(Camera.main.transform);
        }
    }
}
