using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class S3Controller : MonoBehaviour
{
    public List<PlanetAttributes> planets;

    private S3View _view;
    private S3Model _model;

    public static Vector2 MousePosition;

    public CinemachineVirtualCamera activeCamera;
    public float cameraSpeed;

    public bool WasMouseButtonPressed;
    public bool WasMouseButtonReleased;
    public bool IsMouseButtonDown;

    void Start()
    {
        _view = GetComponent<S3View>();
        _model = GetComponent<S3Model>();

        _view.Init();
        _model.Init();

        planets = _model.planets;

        for (int i = 0; i <= 9; i++)
        {
            SetRotation(planets[i].transform, planets[i].orbitSpeed);
            if (planets[i].planetBody.tag == "Planet") SetRotation(planets[i].planetBody, planets[i].rotationSpeed, planets[i].isClockwise);
        }

    }

    private void Update()
    {
        MousePosition = _view.mousePositionAction.ReadValue<Vector2>();

        WasMouseButtonPressed = _view.mouseAction.WasPressedThisFrame();
        WasMouseButtonReleased = _view.mouseAction.WasReleasedThisFrame();
        IsMouseButtonDown = _view.mouseAction.IsPressed();

        if (WasMouseButtonPressed)
        {
            CinemachineBrain cinemachineBrain = FindObjectOfType<CinemachineBrain>();
            if (cinemachineBrain != null)
            {
                activeCamera = cinemachineBrain.ActiveVirtualCamera as CinemachineVirtualCamera;
                //Debug.Log(activeCamera);
            }
            if (activeCamera != null)
            {
                //Debug.Log(activeCamera.VirtualCameraGameObject);
                activeCamera.GetCinemachineComponent<CinemachineOrbitalTransposer>().m_XAxis.m_MaxSpeed = 200;
                //activeCamera.GetCinemachineComponent<CinemachineOrbitalTransposer>().m_XAxis.m_DecelTime = 1;
                //Debug.Log("Max speed = 100");
            }
        }

        if (WasMouseButtonReleased && activeCamera != null)
        {
            activeCamera.GetCinemachineComponent<CinemachineOrbitalTransposer>().m_XAxis.m_MaxSpeed = 0;
            //Debug.Log("Max speed = 0");
        }
    }

    void SetRotation(Transform gameObj, float speed, bool isClockwise = false)
    {
        _view.SetRotation(gameObj, speed, isClockwise);
  
    }

    public void UpdateDetails(PlanetAttributes planet)
    {
        TMP_Text textDisplay = _view.textDisplay;

        _model.FocusOnPlanet(planet);
        //cameraSpeed = _model.focusedPlanet.GetComponentInChildren<CinemachineOrbitalTransposer>().m_XAxis.m_MaxSpeed;

        if (_model.focusedPlanet != planet)
        {
            textDisplay.text = "Click on a planet name to learn about it!";
        }
        else
        {
            textDisplay.text = planet.facts[0];
            //Debug.Log(planet.facts[0]);
        }
    }
}
