using UnityEngine;
using TMPro;


public class GravityPlanetsGravity : MonoBehaviour
{
    public GameObject EarthVisual, MarsVisual, MoonVisual, JupiterVisual;
   
    private float earthGravityScale = 1.0f, marsGravityScale = 0.38f, moonGravityScale = 0.16f, jupiterGravityScale = 2.36f;
    public TextMeshProUGUI infoText;

    
    public static float gravityScale = 1.0f;
    public static string planetName = "Earth";



    void Start()
    {
        Physics.gravity = new Vector3(0, -9.81f, 0) * gravityScale;
    }
  

  

    void OnTriggerEnter(Collider other)
    {
      
            if (other.gameObject.name == EarthVisual.name)
            {
                gravityScale = earthGravityScale;
                UpdateGravity(earthGravityScale);
                UpdateInfoText("EARTH", earthGravityScale);
                planetName = "Earth";
            }
            else if (other.gameObject.name == MarsVisual.name)
            {
                gravityScale = marsGravityScale;
                UpdateGravity(marsGravityScale);
                UpdateInfoText("MARS", marsGravityScale);
                planetName = "Mars";
            }   
            else if (other.gameObject.name == MoonVisual.name)
            {
                gravityScale = moonGravityScale;
                UpdateGravity(moonGravityScale);
                UpdateInfoText("MOON", moonGravityScale);
                planetName = "Moon";
            }
            else if (other.gameObject.name == JupiterVisual.name)
            {
                gravityScale = jupiterGravityScale;
                UpdateGravity(jupiterGravityScale);
                UpdateInfoText("JUPITER", jupiterGravityScale);
                planetName = "Jupiter";
            }
        
    }

    void UpdateGravity(float newGravityScale)
    {
        gravityScale = newGravityScale;
        Physics.gravity = new Vector3(0, -9.81f, 0) * gravityScale;
    }

    void UpdateInfoText(string planetName, float gravityScale)
    {
        infoText.text = $"{planetName}\n g = {9.81f * gravityScale} m/s²";
    }
}


