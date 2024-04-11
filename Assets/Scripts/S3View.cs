//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//using UnityEngine.UI;
using DG.Tweening;
using Cinemachine;
using TMPro;

public class S3View : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera[] focusCameras;
    [SerializeField] Camera mainCamera;
    [SerializeField] public TMP_Text textDisplay;

    public PlayerInput PlayerInput;
    public InputAction mousePositionAction;
    public InputAction mouseAction;

    //private Button prevButton;
    //private Button nextButton;

    public void Init()
    {
        PlayerInput = GetComponent<PlayerInput>();
        mousePositionAction = PlayerInput.actions["MousePosition"];
        mouseAction = PlayerInput.actions["Mouse"];

        //prevButton = factsDisplay.GetComponentsInChildren<Button>()[0];
        //nextButton = factsDisplay.GetComponentsInChildren<Button>()[1];

        //prevButton.gameObject.SetActive(false);
        //nextButton.gameObject.SetActive(false);
    }

    public void SetRotation(Transform gameObj, float speed, bool isClockwise)
    {
        if (gameObj.tag != "Planet")
        {
            float randomRotationY = Random.Range(0f, 360f);
            gameObj.rotation = Quaternion.Euler(0f, randomRotationY, 0f);
        }

        float ytarget = isClockwise ? 360 : -360;

        gameObj.DORotate(new Vector3(0, ytarget, 0), speed, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Incremental);
    }

    public void SwitchToCamera(CinemachineVirtualCamera targetCamera)
    {
        ICinemachineCamera activeCamera = mainCamera.GetComponent<CinemachineBrain>().ActiveVirtualCamera;

        if ((Object)activeCamera == targetCamera)
        {
            targetCamera.enabled = false;
            //cameraIsFocused = false;
            //prevButton.gameObject.SetActive(false);
            //nextButton.gameObject.SetActive(false);
        }
        else
        {
            foreach (CinemachineVirtualCamera camera in focusCameras)
            {
                camera.enabled = camera == targetCamera;
                //cameraIsFocused = true;

            }
            //nextButton.gameObject.SetActive(true);
        }
    }

    public void ToggleCameraOrbiting()
    {

    }
}