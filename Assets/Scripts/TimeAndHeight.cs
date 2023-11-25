using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit;
public class TimeAndHeight : MonoBehaviour
{
    public GameObject polygon;

    public Transform objectToFollow; 
    public Transform interactionObject; 
    public float tolerance = 1f; 

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI currentDistanceText;
    public TextMeshProUGUI frozenDistanceText;
    private TextMeshProUGUI planetNameText;
    private bool isFalling = true; 
    private bool isColliding = false;
       
    private float currentDistance = 0f;
    private float frozenDistance = 0f;

    private string planet;
    private float asd;
    private float time;

    public XRGrabInteractable grabInteractable;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Подписка на события захвата и отпускания с использованием новых методов
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
        planet = GravityPlanetsGravity.planetName;
    }
    public void OnGrab(SelectEnterEventArgs args)
    {
     
        isFalling = false;
    }

    public void OnRelease(SelectExitEventArgs args)
    {
        isFalling = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == polygon.name)
        {
            isColliding = true;
        }
        

    }
    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.name == polygon.name)
        {
            isColliding = false;
        }
    }
    void Update()
    {
        
        if (IsOverInteractionObject())
        {
            
            currentDistance = Mathf.Abs(objectToFollow.position.y - interactionObject.position.y);

            
            
            if (isFalling==false)
            {
                
                frozenDistance = currentDistance;
                
            }
            
            if (isColliding==true)
            {
                
               
                
                UpdateUiTime(time);
            }
            if (isColliding == false)
            {
                planet = GravityPlanetsGravity.planetName;
                time = Mathf.Sqrt(2 * frozenDistance / (9.81f * GravityPlanetsGravity.gravityScale));
                UpdateUiTimeZero();
            }



          
            UpdateUIDistance(currentDistance, frozenDistance, planet);
        }
    }

    void UpdateUiTime(float time)
    {
        
        
        timeText.text = "Time: " + time.ToString("F4") + "s";
    }
    void UpdateUiTimeZero()
    {
        
        
        timeText.text = "";
    }
    void UpdateUIDistance(float currentDistance, float frozenDistance, string planet )
    {

        //Debug.Log($"CURRENT DISTANCE{currentDistance.ToString("F2")} ");
        float roundedValue = Mathf.Floor(currentDistance * 10f) / 10f;
        currentDistanceText.text = "Height: " + roundedValue.ToString("F1") + " meters";
        float roundedFrozenDistance = Mathf.Floor(frozenDistance * 10f) / 10f;
        frozenDistanceText.text = "Planet:" + planet +"\nLast Height: " + roundedFrozenDistance.ToString("F1") + " meters";
    }



    bool IsOverInteractionObject()
    {
        bool isOverX = Mathf.Abs(objectToFollow.position.x - interactionObject.position.x) <= tolerance;
        bool isOverZ = Mathf.Abs(objectToFollow.position.z - interactionObject.position.z) <= tolerance;
        return isOverX && isOverZ;
    }

}
