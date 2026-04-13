using UnityEngine;
using UnityEngine.InputSystem;

public class MOBACamera : MonoBehaviour
{

    // PUBLIC
    public Transform camTarget;
    public Vector3 offset = new(0f, 10f, -5);
    public float zoomSpeedY = 1f;
    public float zoomSpeedZ = 0.5f;
    public float minZoomY = 4f;
    public float maxZoomY = 16f;
    public float minZoomZ = -8f;
    public float maxZoomZ = -2f;

    void LateUpdate()
    {
        // Follow the target without rotating
        transform.position = camTarget.position + offset;

        // TODO: fix zoom, currently it doesnt zoom in and out centered correctly
        // Zoom in and out with scroll wheel
        float scrollY = Mouse.current.scroll.ReadValue().y;
        // float scrollZ = Mouse.current.scroll.ReadValue().z;
        offset.y -= scrollY * zoomSpeedY;
        offset.z += scrollY * zoomSpeedZ;
        offset.y = Mathf.Clamp(offset.y, minZoomY, maxZoomY);
        offset.z = Mathf.Clamp(offset.z, minZoomZ, maxZoomZ);
    }
}
