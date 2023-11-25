using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MassChanger : MonoBehaviour
{

    public Scrollbar scrollbar; // Ссылка на ваш Scrollbar
    public TextMeshProUGUI massDisplay; // Ссылка на ваш Text элемент для отображения массы
    public Rigidbody[] objectsArray; // Массив объектов, массу которых вы хотите изменить
    private float minMass = 0.2f; // Минимальная масса в кг (200 г)
    private float maxMass = 1000.0f; // Максимальная масса в кг (2000 г)

    // Метод для обновления массы объектов
    private void UpdateMass(float mass)
    {
        foreach (Rigidbody obj in objectsArray)
        {
           
                obj.mass = mass;
            
        }
    }

    // Метод для обновления отображаемой массы на панели
    private void UpdateMassDisplay(float mass)
    {
        massDisplay.text = $"Mass: {mass} kg";
    }

    // Метод, вызываемый при изменении значения Scrollbar
    public void OnScrollbarValueChanged()
    {
        float massValue = minMass + scrollbar.value * (maxMass - minMass); // Преобразование значения Scrollbar в массу
        UpdateMass(massValue); // Обновление массы объектов
        UpdateMassDisplay(massValue); // Обновление отображаемой массы на панели
    }
}
