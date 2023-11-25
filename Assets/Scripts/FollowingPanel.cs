using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform targetObject; // ������, �� ������� ������ ��������� ������
    public Vector3 offset; // �������� ������������ �������

    void Update()
    {
        if (targetObject != null)
        {
            // ��������� ������� ������, ����� ��� ���������� ����� � ��������
            transform.position = targetObject.position + offset;

            // �����������: ����� �������� ��� ��� ���������� ������ � ������ ��� � ������������ �����������
            // transform.LookAt(Camera.main.transform);
        }
    }
}
