using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float turnSpeed = 180f;

    private CharacterController controller;
    private Animator animator;
    private Vector2 moveInput;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void Update()
    {
        float turn = moveInput.x;
        float forward = moveInput.y;

        transform.Rotate(0f, turn * turnSpeed * Time.deltaTime, 0f);

        Vector3 move = transform.forward * forward;
        controller.Move(move * moveSpeed * Time.deltaTime);

        if (animator != null)
        {
            animator.SetBool("isWalking", Mathf.Abs(forward) > 0.01f || Mathf.Abs(turn) > 0.01f);
        }
    }
}