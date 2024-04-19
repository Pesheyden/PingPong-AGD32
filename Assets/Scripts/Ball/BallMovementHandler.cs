using System.Collections;
using UnityEngine;

public class BallMovementHandler : MonoBehaviour
{
    private BallController _ballController;
    private Rigidbody2D _rigidbody;
    private Vector2 _currentSpeed;
    private bool _isBlocked;

    private void Start()
    {
        _ballController = GetComponent<BallController>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _isBlocked = false;
    }
    private void FixedUpdate()
    {
        if (!_isBlocked)
        {
            _currentSpeed = _rigidbody.velocity * (1 + _ballController.Acceleration * Time.deltaTime);
            if (_currentSpeed.magnitude < _ballController.BaseSpeed) _currentSpeed *= _ballController.BaseSpeed / 2;
            _rigidbody.velocity = _currentSpeed;
        }
    }
    public void SetBallSpeed(Vector2 speed)
    {
        _rigidbody.velocity = speed;
        _currentSpeed = speed;
        _ballController.BounceSide = speed.x > 0 ? BallController.Side.Right : BallController.Side.Left;
    }

    public void BlockBall()
    {
        _isBlocked = true;
        _rigidbody.velocity = Vector2.zero;
    }
    public void UnBlockBall()
    {
        _isBlocked = false;
        _rigidbody.velocity = _currentSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = _currentSpeed.magnitude;
        var direction = Vector2.Reflect(_currentSpeed.normalized, collision.contacts[0].normal);
        _rigidbody.velocity = direction * Mathf.Max(speed,0f);
        _ballController.BounceSide = transform.position.x > 0 ? BallController.Side.Right : BallController.Side.Left;
    }
}
