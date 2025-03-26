using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class InputScript : MonoBehaviour
{

    Rigidbody2D rb;
    InputScript inputScript;

    Vector3 target;

    public float moveSpeed;
    private bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.started || context.performed)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            mousePos.z = 0;
            target = mousePos;
            isMoving = true;
        }
        else if (context.canceled)
        {
            isMoving = false;
        }

        if (isMoving)
        {
            rb.position = Vector3.MoveTowards(rb.position, target, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(rb.position, target) < .1f)
            {
                isMoving = false;
            }
        }
    }
}
