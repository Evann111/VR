using UnityEngine;


public class PinchInteractorBridge : MonoBehaviour
{
    public SimplePinchGrab pinch;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRDirectInteractor interactor;

    void Update()
    {
        if (pinch == null || interactor == null) return;

        interactor.enabled = pinch.IsPinching();
    }
}