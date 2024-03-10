using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("Movement")]
    public float BaseSpeed;
    public float Acceleration;
    public enum Side { Left, Right };
    public Side BounceSide;

    [Header("Spawn")]
    [SerializeField] private Vector3 _spawnPosition;
    [SerializeField] private float _spawnMovementDelay;

    [SerializeField] float excludeAngle = 45;
    [SerializeField] float excludeAngleThrough = 135;

    [SerializeField] float firstRegionMinAngle = 0; 
    [SerializeField] float firstRegionMaxAngle = 45;
    [SerializeField] float secondRegionMinAngle = 135;
    [SerializeField] float secondRegionMaxAngle = 180;
    [SerializeField] float thirdRegionMinAngle = 180;
    [SerializeField] float thirdRegionMaxAngle = 225;
    [SerializeField] float fourthRegionMinAngle = 315;
    [SerializeField] float fourthRegionMaxAngle = 360;



    private bool _isBallInGame;
    private BallMovementHandler _movementHandler;


    private void Start()
    {
        _movementHandler = GetComponent<BallMovementHandler>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isBallInGame)
        {
            SpawnBall();
        }
    }
    public void PauseBallStatusChange(bool value)
    {
        if (value)
            _movementHandler.BlockBall();
        else
            _movementHandler.UnBlockBall();
    }
    public void SpawnBall()
    {
        transform.position = _spawnPosition;
        _movementHandler.SetBallSpeed(Vector2.zero);
        StartCoroutine(Delay());
        _isBallInGame = true;
    }
    public void StartBallMovement()
    {
        float angle;

        int spawnDirection = Random.Range(0, 3);

        if (spawnDirection == 0)
        {
            angle = Random.Range(firstRegionMinAngle, firstRegionMaxAngle);
        }
        else if (spawnDirection == 1)
        {
            angle = Random.Range(secondRegionMinAngle, secondRegionMaxAngle);
        }
        else if (spawnDirection == 2)
        {
            angle = Random.Range(thirdRegionMinAngle, thirdRegionMaxAngle);
        }
        else
        {
            angle = Random.Range(fourthRegionMinAngle, fourthRegionMaxAngle);
        }

        float radians = angle * Mathf.Deg2Rad;


        float xSpeed = Mathf.Cos(radians) * BaseSpeed;
        float ySpeed = Mathf.Sin(radians) * BaseSpeed;

        _movementHandler.SetBallSpeed(new Vector2(xSpeed, ySpeed));
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(_spawnMovementDelay);
        StartBallMovement();
    }

    public void SetPreviousBounceSide(Side side)
    {
        BounceSide = side;
    }

    public void BallBounceHandler(Side side)
    {
        SetPreviousBounceSide(side);
    }
}
