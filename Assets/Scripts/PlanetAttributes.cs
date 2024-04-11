using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[System.Serializable]
public class PlanetAttributes : MonoBehaviour
{
    public string planetName;
    public string[] facts;
    public Transform planetBody;
    //public CinemachineVirtualCamera planetCam;
    public float orbitSpeed;
    public float rotationSpeed;
    public bool isClockwise;
}
