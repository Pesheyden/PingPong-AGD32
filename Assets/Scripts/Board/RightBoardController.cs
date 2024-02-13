using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RightBoardController : MonoBehaviour
{
    [SerializeField] private float _boardSpeed;
    [SerializeField] private float _borders;

    private void FixedUpdate()
    {
        float ver = Input.GetAxis("VerticalArrows");
        if (((transform.position.y <= _borders && ver >= 0) ||
            (transform.position.y >= -_borders && ver <= 0)) &&
            !BoardPause.IsPaused)
        {
            Movement(ver);
        }
    }
    private void Movement(float axis)
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.position + Vector3.up * axis, _boardSpeed);
    }
}