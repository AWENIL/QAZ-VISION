using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class AppearPanel : MonoBehaviour
{
    public Transform objectToFollow;
    public Transform interactionObject;

    public float tolerance = 1f;
    public GameObject apple;
    private CanvasGroup canvasGroup;
    
    private bool isFalling = true;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            Debug.LogError("CanvasGroup component not found!");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == apple.name)
        {
            isFalling = false;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == apple.name)
        {
            isFalling = true;

           
        }
    }
    void Update()
    {
        bool overInteractionObject = IsOverInteractionObject();
      
        ManageCanvasGroupVisibility(overInteractionObject);
    }
 
    bool IsOverInteractionObject()
    {
        bool isOverX = Mathf.Abs(objectToFollow.position.x - interactionObject.position.x) <= tolerance;
        bool isOverZ = Mathf.Abs(objectToFollow.position.z - interactionObject.position.z) <= tolerance;

        return isOverX && isOverZ;
    }

    public void StartFalling()
    {
        isFalling = true;
    }

    private void ManageCanvasGroupVisibility(bool isVisible)
    {
        if (isVisible)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        else
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }
}
