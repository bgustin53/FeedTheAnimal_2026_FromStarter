// GameObject: Player
// Description: Manages player movement, boundary constraints, and animation states based on Player Input callback contexts.
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
[SerializeField] private float playerSpeed;
private float centerToEdge = 22.0f;
private Vector2 movementDirection;
private Animator animator;

private void Start()
{
    animator = GetComponent<Animator>();
}

private void Update()
{
    Move();
}

// Called by: Player Input
public void OnMovementInput(InputAction.CallbackContext ctx)
{
    movementDirection = ctx.ReadValue<Vector2>();
}

private void Move()
{
    if (movementDirection.x != 0)
    {
        float nextX = transform.position.x + movementDirection.x * playerSpeed * Time.deltaTime;
        
        if (nextX >= -centerToEdge && nextX <= centerToEdge)
        {
            transform.position = new Vector3(nextX, transform.position.y, transform.position.z);
        }
        // Tells the animator to start the walking animation
        animator.SetBool("IsRunning", true);
    }
    else
    {
        // Tells the animator to start the idle animation
        animator.SetBool("IsRunning", false);
    }
}
}