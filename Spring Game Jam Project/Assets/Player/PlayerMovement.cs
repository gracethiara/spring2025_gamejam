using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _movementSpeed = 21f;
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

        // Note: See Task List document for Flip() issues
        //Flip();
    }

    private void FixedUpdate()
    {
        if(GameStateManager.IsPlayingGame)
            _rb.velocity = new Vector2(_horizontalDirection * _movementSpeed, _rb.velocity.y);
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
