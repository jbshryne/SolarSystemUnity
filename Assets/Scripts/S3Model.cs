//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class S3Model : MonoBehaviour
{
    public List<PlanetAttributes> planets = new();
    [HideInInspector] public PlanetAttributes focusedPlanet; 

    // Initialization and other methods
    //}


    public void Init()
    {
        //Debug.Log(planets[4]);
    }

    public void FocusOnPlanet(PlanetAttributes planet)
    {
        if (focusedPlanet == planet)
        {
            focusedPlanet = null;
            //Debug.Log(focusedPlanet);
        }
        else
        {
            focusedPlanet = planet;
            //Debug.Log(focusedPlanet);
        }
    }
}