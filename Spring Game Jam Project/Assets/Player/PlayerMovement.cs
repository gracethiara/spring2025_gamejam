using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _gravityScale = 5;
    [SerializeField] private float _movementSpeed = 10f;
    [SerializeField] private float _bounceSpeed = 1f;
    [SerializeField] private KeyCode _leftMoveKey;
    [SerializeField] private KeyCode _rightMoveKey;

    private float _horizontalDirection;
    private Vector2 _pausedVelocity;
    private bool _isFacingRight = true;

    private void Awake()
    {
        GameStateManager.OnPauseGame += PauseMovement;

        _rb.gravityScale = _gravityScale;
    }

    void Update()
    {
        if (Input.GetKeyDown(_leftMoveKey))
            _horizontalDirection = -1;
        else if (Input.GetKeyDown(_rightMoveKey))
            _horizontalDirection = 1;

        //Flip();
    }

    private void FixedUpdate()
    {
        if (!GameStateManager.IsPaused)
            SetVelocity();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
            _rb.velocity = new(_rb.velocity.x, _bounceSpeed);
    }

    private void SetVelocity()
    {
        _rb.velocity = new Vector2(_horizontalDirection * _movementSpeed, _rb.velocity.y);
    }

    private void PauseMovement()
    {
        float v_targetGravityScale;
        Vector2 v_targetVelocity;

        if (GameStateManager.IsPaused)
        {
            _pausedVelocity = _rb.velocity;
            v_targetGravityScale = 0;
            v_targetVelocity = Vector2.zero;
        }

        else
        {
            v_targetGravityScale = _gravityScale;
            v_targetVelocity = _pausedVelocity;
        }

        _rb.gravityScale = v_targetGravityScale;
        _rb.velocity = v_targetVelocity;
    }

    //private void Flip()
    //{
    //    if (_isFacingRight && _horizontalDirection < 0f || !_isFacingRight && _horizontalDirection > 0f)
    //    {
    //        _isFacingRight = !_isFacingRight;
    //        Vector3 localScale = transform.localScale;
    //        localScale.x *= -1f;
    //        transform.localScale = localScale;
    //    }
    //}
}
