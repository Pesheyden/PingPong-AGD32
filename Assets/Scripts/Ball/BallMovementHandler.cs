using System.Collections;
using UnityEngine;

public class BallMovementHandler : MonoBehaviour
{
    private BallController _ballController;
    private Rigidbody2D _rigidbody;
    private Vector2 _currentSpeed;

    private void Start()
    {
        _ballController = GetComponent<BallController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (_rigidbody.velocity != Vector2.zero)
        {
            _currentSpeed = _rigidbody.velocity * (1 + _ballController.Acceleration * Time.deltaTime);
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
        _rigidbody.velocity = Vector2.zero;
    }
    public void UnBlockBall()
    {
        _rigidbody.velocity = _currentSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(1);
        var speed = _currentSpeed.magnitude;
        var direction = Vector2.Reflect(_currentSpeed.normalized, collision.contacts[0].normal);
        _rigidbody.velocity = direction * Mathf.Max(speed,0f);
        _ballController.BounceSide = transform.position.x > 0 ? BallController.Side.Right : BallController.Side.Left;
    }
}
