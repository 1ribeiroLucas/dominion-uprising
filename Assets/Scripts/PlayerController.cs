using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
// [RequireComponent] directive make it required for the GameObject it is attached to have a component of the type specified.
// In this case, the type is NavMeshAgent. It can be added as many as needed.
[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    // PUBLIC VARIABLES
    public float speed = 0;
    
    // PRIVATE VARIABLES
    private NavMeshAgent navMeshAgent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // void OnMove(Input input)
    // {
        

    //     // Vector2 moveVector = movementValue.Get<Vector2>();
    //     // moveX = moveVector.x;
    //     // moveY = moveVector.y;
    // }

    void FixedUpdate()
    {
        if (Mouse.current.rightButton.isPressed)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                navMeshAgent.SetDestination(raycastHit.point);
            }
        }
    }
}
