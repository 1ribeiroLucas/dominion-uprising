using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerControllerDetachedCam : MonoBehaviour
{
    // PUBLIC
    public float speed = 0;

    // PRIVATE
    private NavMeshAgent navMeshAgent;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.rightButton.isPressed)
        {
            Ray raycast = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            // "RaycastHit raycastHit" is an inline declaration
            if (Physics.Raycast(raycast, out RaycastHit raycastHit))
            {
                navMeshAgent.SetDestination(raycastHit.point);
            }
        }
    }
}
