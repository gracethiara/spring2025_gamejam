using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _movementSpeed = 10f;
    [SerializeField] private float _bounceSpeed = 1f;
    [SerializeField] private KeyCode _rightMoveKey;
    [SerializeField] private KeyCode _leftMoveKey;

    private float _horizontalDirection;
    private bool _isFacingRight = true;

    void Update()
    {
        if (Input.GetKeyDown(_rightMoveKey))
            _horizontalDirection = 1;
        else if (Input.GetKeyDown(_leftMoveKey))
            _horizontalDirection = -1;

        //Flip();
    }

    private void FixedUpdate()
    {
        SetVelocity();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
            _rb.velocity = new(_rb.velocity.x, _bounceSpeed);
    }

    private void SetVelocity()
    {
        Vector2 v_targetVelocity;

        if (GameStateManager.IsPlayingGame)
            v_targetVelocity = new Vector2(_horizontalDirection * _movementSpeed, _rb.velocity.y);
        else
        {
            v_targetVelocity = Vector2.zero;
            _rb.gravityScale = 0;
        }

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
