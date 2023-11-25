using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MassChanger : MonoBehaviour
{

    public Scrollbar scrollbar; // ������ �� ��� Scrollbar
    public TextMeshProUGUI massDisplay; // ������ �� ��� Text ������� ��� ����������� �����
    public Rigidbody[] objectsArray; // ������ ��������, ����� ������� �� ������ ��������
    private float minMass = 0.2f; // ����������� ����� � �� (200 �)
    private float maxMass = 1000.0f; // ������������ ����� � �� (2000 �)

    // ����� ��� ���������� ����� ��������
    private void UpdateMass(float mass)
    {
        foreach (Rigidbody obj in objectsArray)
        {
           
                obj.mass = mass;
            
        }
    }

    // ����� ��� ���������� ������������ ����� �� ������
    private void UpdateMassDisplay(float mass)
    {
        massDisplay.text = $"Mass: {mass} kg";
    }

    // �����, ���������� ��� ��������� �������� Scrollbar
    public void OnScrollbarValueChanged()
    {
        float massValue = minMass + scrollbar.value * (maxMass - minMass); // �������������� �������� Scrollbar � �����
        UpdateMass(massValue); // ���������� ����� ��������
        UpdateMassDisplay(massValue); // ���������� ������������ ����� �� ������
    }
}
