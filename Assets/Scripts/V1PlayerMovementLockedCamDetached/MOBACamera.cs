using UnityEngine;
using UnityEngine.InputSystem;

public class MOBACamera : MonoBehaviour
{

    // PUBLIC
    public Transform camTarget;
    public Vector3 offset = new(0f, 10f, -5);
    public float zoomSpeed = 2f;
    public float minZoom = 4f;
    public float maxZoom = 20f;

    void LateUpdate()
    {
        // Follow the target without rotating
        transform.position = camTarget.position + offset;

        // Zoom in and out with scroll wheel
        float scroll = Mouse.current.scroll.ReadValue().y;
        offset.y -= scroll * zoomSpeed;
        offset.y = Mathf.Clamp(offset.y, minZoom, maxZoom);
    }
}
