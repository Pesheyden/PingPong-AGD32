using System;
using Boosts;
using Common;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BoostManager : MonoBehaviour
{
    [FormerlySerializedAs("_boostSpavner")] [SerializeField] 
    private BoostSpawner _boostSpawner;
    
    [SerializeField]
    private BallController _ballController;

    [SerializeField]
    private BoostsStats _boostsStats;

    [SerializeField]
    private BallMovementHandler _ballMovementHandler;

    [SerializeField] 
    private GameObject _rightPlatform;
    
    [SerializeField] 
    private GameObject _leftPlatform;
    
    [SerializeField] 
    private Slider _rightSlider;
    
    [SerializeField] 
    private Slider _leftSlider;
        
    [SerializeField] 
    private GameObject _ball;
    
    [SerializeField]
    private Rigidbody2D _ballRigidbody;

    private Vector2 _speedWithBoost;
    
    private GameObject _currentPlatform;

    private Slider _currentSlider;

    private Countdown _countdown;

    private GameObject _platformWithBoost;

    private bool _speedBoostUsed;

    private bool _platformSizeBoostUsed;
    
    private bool _ballSizeBoostUsed;

    private Vector3 _platformBaseSize;

    private Vector3 _ballBaseSize;
    
    private void Awake()
    {
        _countdown = new Countdown(_boostsStats.BoostEffectLength);

        _platformBaseSize = _leftPlatform.transform.localScale;
        _ballBaseSize = transform.localScale;
    }

    private void Start()
    {
        _speedBoostUsed = false;
        _platformSizeBoostUsed = false;
        _ballSizeBoostUsed = false;
    }

    private void Update()
    {
        _speedWithBoost = _ballRigidbody.velocity + new Vector2(3, 3);
        
        if (_countdown.IsPlaying())
            _countdown.Tick(Time.deltaTime);

        else
        {
            ResetValues();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) // checking from which platform ball bounced
    { 
        if (other.gameObject.tag == "RightPlatform")
        {
            _currentPlatform = _rightPlatform;
            _currentSlider = _rightSlider;
        }
        
        if (other.gameObject.tag == "LeftPlatform")
        {
            _currentPlatform = _leftPlatform;
            _currentSlider = _leftSlider;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "PlatformSizeUp":
                _platformWithBoost = _currentPlatform;
                _currentPlatform.transform.localScale *= _boostsStats.PlatformSizeUp;
                _platformSizeBoostUsed = true;
                break;

            case "PlatformSizeDown":
                _platformWithBoost = _currentPlatform;
                _currentPlatform.transform.localScale *= _boostsStats.PlatformSizeDown;
                _platformSizeBoostUsed = true;
                break;

            case "BallSpeedUp":
                _ballMovementHandler.SetBallSpeed(_speedWithBoost);
                break;

            case "BallSizeUp":
                _ball.transform.localScale *= _boostsStats.BallSizeUp;
                _ballSizeBoostUsed = true;
                break;

            case "BallSizeDown":
                _ball.transform.localScale *= _boostsStats.BallSizeDown;
                _ballSizeBoostUsed = true;
                break;

            case "Health":
                _currentSlider.value++;
                break;
        }

        Destroy(other.gameObject);
        _countdown.Reset();
        _boostSpawner.Countdown.Reset();
    }

    private void ResetValues()
    {
        if (_platformSizeBoostUsed == true && _platformWithBoost != null)
        {
            _platformWithBoost.transform.localScale = _platformBaseSize;
            _countdown.Reset();
            _platformSizeBoostUsed = false;
        }

        if (_ballSizeBoostUsed == true)
        {
            _ball.transform.localScale = _ballBaseSize;
            _countdown.Reset();
            _ballSizeBoostUsed = false;
        }

        if (_speedBoostUsed == true)
        {
            _ballController.BaseSpeed -= 10;
            _countdown.Reset();
            _speedBoostUsed = false;
        }
    }
}
