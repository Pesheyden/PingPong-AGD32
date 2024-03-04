using UnityEngine;

public class BallBounceHandler : MonoBehaviour
{
    private BallController ballController;

    private void Start()
    {
        ballController = FindObjectOfType<BallController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         
    }
}
