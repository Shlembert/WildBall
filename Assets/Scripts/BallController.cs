using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Transform cameraTransform;

    private Rigidbody _rb;
    private bool _isGrounded;
    private Vector3 _moveDirection;
    private bool _jump;

    private void Start() { _rb = GetComponent<Rigidbody>(); }
    private void Update() { ProcessInputs(); }

    private void FixedUpdate()
    {
        Move();
        if (_jump) Jump();
    }

    private void ProcessInputs()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        _moveDirection = (forward * moveVertical + right * moveHorizontal).normalized;

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded) _jump = true;
    }

    private void Move()
    {
        Vector3 velocity = _moveDirection * moveSpeed;
        velocity.y = _rb.velocity.y;
        _rb.velocity = velocity;
    }

    private void Jump()
    {
        _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        _jump = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) _isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) _isGrounded = false;
    }
}
