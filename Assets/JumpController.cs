using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpController : MonoBehaviour
{
    [SerializeField] private InputActionReference jumpActionReference;
    [SerializeField] private float jumpForce = 500.0f;

    private Rigidbody _body;

    private bool IsGrounded => Physics.Raycast(
            new Vector2(transform.position.magnitude, transform.position.y + 3.0f),
            Vector3.down,
            3.0f
        );

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody>();
        jumpActionReference.action.performed += OnJump;
    }

    private void OnJump(InputAction.CallbackContext obj)
    {
        if (!IsGrounded) return;
        _body.AddForce(Vector3.up * jumpForce);
    }
}