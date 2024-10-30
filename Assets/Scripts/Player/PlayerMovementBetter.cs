using UnityEngine;

public class PlayerMovementBetter : MonoBehaviour
{
    public float moveSmoothTime;
    public float gravityStrength;
    public float jumpStrength;
    public float walkSpeed;
    public float runSpeed;
    public float velocityDown;

    private CharacterController controller;
    private Vector3 currentMoveVelocity;
    private Vector3 moveDampVelocity;
    private Vector3 currentForceVelocity;

    private float groundedBufferTime = 0.1f;
    private float lastGroundedTime;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 PlayerInput = new Vector3
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = 0f,
            z = Input.GetAxisRaw("Vertical")
        };

        if (PlayerInput.magnitude > 1f)
        {
            PlayerInput.Normalize();
        }

        Vector3 MoveVector = transform.TransformDirection(PlayerInput);
        float CurrentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        currentMoveVelocity = Vector3.SmoothDamp(
            currentMoveVelocity,
            MoveVector * CurrentSpeed,
            ref moveDampVelocity,
            moveSmoothTime
        );

        Vector3 horizontalMovement = currentMoveVelocity * Time.deltaTime;

        if (controller.isGrounded)
        {
            lastGroundedTime = Time.time;
            currentForceVelocity.y = -velocityDown;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentForceVelocity.y = jumpStrength;
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Space) && Time.time - lastGroundedTime < groundedBufferTime)
            {
                currentForceVelocity.y = jumpStrength;
            }
            currentForceVelocity.y -= gravityStrength * Time.deltaTime;
        }
        
        Vector3 verticalMovement = currentForceVelocity * Time.deltaTime;

        controller.Move(horizontalMovement + verticalMovement);
    }
}
