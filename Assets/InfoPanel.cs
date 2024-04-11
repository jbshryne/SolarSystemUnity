using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    private Text infoText;

    //[System.Serializable]
    //public class PlanetDetails
    //{
    //    public string planetName;
    //    public string[] facts;
    //}

    public class SolarSystem : MonoBehaviour
    {
        public Dictionary<string, string[]> planetFacts;

        // Start is called before the first frame update
        void Start()
        {
            planetFacts = new Dictionary<string, string[]>
            {
                {"Mercury", new string[] {
                    "Mercury is the smallest planet in our solar system",
                    "Mercury's temperature can range from 800°F to -300°F, but is only the second-hottest planet (Venus is first!)",
                    "Mercruy's poles have water-ice"

                } },
                {"Venus", new string[]
                {
                    "Venus is the hottest planet in our solar system",
                    "Venus rotates in the opposite direction of Earth or most other planets",
                    "Venus is a rocky planet with an active surface, featuring mountains and volcanoes"
                }

                }
            };
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}