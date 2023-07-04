using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed = 5f; // Speed of player movement

    [SerializeField]
    private float _jumpForce = 5f; // Force applied when jumping

    [SerializeField]
    private float _fallMultiplier = 2f; // Multiplier for controlling fall speed

    private Rigidbody _rb;

    private bool _isJumping = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Horizontal Movement
        float moveInputHorizontal = Input.GetAxis("Horizontal");
        float moveInputVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveInputHorizontal * _movementSpeed,
                                _rb.velocity.y,
                                moveInputVertical * _movementSpeed);
        _rb.velocity = movement;

        // Apply fall multiplier to accelerate fall speed
        if (_rb.velocity.y < 0)
        {
            _rb.velocity += Vector3.up * Physics.gravity.y *
                (_fallMultiplier + 1) * Time.deltaTime;
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && !_isJumping)
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isJumping = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Reset jumping when the player lands on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Player reached the ground");
            _isJumping = false;
        }
    }
}