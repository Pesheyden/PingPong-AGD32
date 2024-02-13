using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBoardController : MonoBehaviour
{
    [SerializeField] private float _boardSpeed;
    [SerializeField] private float _borders;

    private float ver;

    private void FixedUpdate()
    {
        ver = Input.GetAxis("VerticalWASD");
        if (((transform.position.y <= _borders && ver >= 0) ||
            (transform.position.y >= -_borders && ver <= 0)) &&
            !BoardPause.IsPaused)
        {
            Movement();
        }
    }
    private void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.position + Vector3.up * ver, _boardSpeed);
    }
}
