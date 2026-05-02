using UnityEngine;

public class SimplePinchGrab : MonoBehaviour
{
    public Transform thumbTip;
    public Transform indexTip;

    public float pinchThreshold = 0.03f;

    public bool IsPinching()
    {
        if (thumbTip == null || indexTip == null) return false;

        float dist = Vector3.Distance(thumbTip.position, indexTip.position);
        return dist < pinchThreshold;
    }
}