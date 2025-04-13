using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 21f;

    private Rigidbody2D _rb;

    private float _horizontalDirection;
    private bool _isFacingRight = true;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _horizontalDirection = Input.GetAxisRaw("Horizontal");
        Flip();
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_horizontalDirection * _movementSpeed, _rb.velocity.y);
    }

    private void Flip()
    {
        if (_isFacingRight && _horizontalDirection < 0f || !_isFacingRight && _horizontalDirection > 0f)
        {
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
