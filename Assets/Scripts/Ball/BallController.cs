using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private static BallController instance;
    public static BallController Instance { get { return instance; } }

    [Header("Movement")]
    public float BaseSpeed;
    public float Acceleration;
    [SerializeField] private float _maxMovementDistance;
    public enum Side { Left, Right };

    public Side BounceSide;

    [Header("Spawn")]
    [SerializeField] private Vector3 _spawnPosition;
    [SerializeField] private float _spawnMovementDelay;

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

    private void Awake()
    {
        instance = this;
        _isBallInGame = false;
    }
    private void Start()
    {
        _movementHandler = GetComponent<BallMovementHandler>();
    }

    public void ImplementSettings(GameDifficulty gameDifficulty)
    {
        switch (gameDifficulty)
        {
            case GameDifficulty.Easy:
                DifficultyStats.EasyDifficulty easyDifficultyStats = new();
                transform.localScale *= easyDifficultyStats.BallSizeMultiplier;
                BaseSpeed *= easyDifficultyStats.BallStartSpeedMultiplier;
                Acceleration *= easyDifficultyStats.BallAccelerationMultiplier;
                break;

            case GameDifficulty.Medium:
                DifficultyStats.MediumDifficulty mediumDifficultyStats = new();
                transform.localScale *= mediumDifficultyStats.BallSizeMultiplier;
                BaseSpeed *= mediumDifficultyStats.BallStartSpeedMultiplier;
                Acceleration *= mediumDifficultyStats.BallAccelerationMultiplier;
                break;

            case GameDifficulty.Hard:
                DifficultyStats.HardDifficulty hardDifficultyStats = new();
                transform.localScale *= hardDifficultyStats.BallSizeMultiplier;
                BaseSpeed *= hardDifficultyStats.BallStartSpeedMultiplier;
                Acceleration *= hardDifficultyStats.BallAccelerationMultiplier;
                break;

        }
    }
    private void Update()
    {
        if (Vector2.Distance(Vector2.zero, transform.position) > _maxMovementDistance)
        {
            GameManager.Instance.RespawnBall();
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
}
