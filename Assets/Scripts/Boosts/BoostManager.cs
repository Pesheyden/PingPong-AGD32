using System;
using Common;
using UnityEngine;
using UnityEngine.UI;

public class BoostManager : MonoBehaviour
{
    [SerializeField] 
    private BoostSpavner _boostSpavner;
    
    [SerializeField]
    private BallController _ballController;

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
    private float _boostEffectLength = 10f;
    
    private GameObject _currentPlatform;

    private Slider _currentSlider;

    private Countdown _countdown;

    private GameObject _platformWithBoost;

    private bool _speedBoostUsed;

    private bool _platformSizeBoostUsed;
    
    private bool _ballSizeBoostUsed;
    
    private void Awake()
    {
        _countdown = new Countdown(_boostEffectLength);
        
        _speedBoostUsed = false;
        _platformSizeBoostUsed = false;
        _ballSizeBoostUsed = false;
    }

    private void Update()
    {
        if (_countdown.IsPlaying())
            _countdown.Tick(Time.deltaTime);

        else
        {
            ResetValues();
        }
        
        Debug.Log(_platformWithBoost);
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

    private void OnTriggerEnter2D(Collider2D other) // giving boost for smth
    {
        if (other.gameObject.tag == "PlatformSizeUp")
        {
            _platformWithBoost = _currentPlatform;
            _currentPlatform.transform.localScale = new Vector3(0.5f, 2.8f, 1);
            _platformSizeBoostUsed = true;
            Destroy(other.gameObject);
            _countdown.Reset();
            _boostSpavner.Countdown.Reset();
        }

        if (other.gameObject.tag == "PlatformSizeDown")
        {
            _platformWithBoost = _currentPlatform;
            _currentPlatform.transform.localScale = new Vector3(0.5f, 1.2f, 1);
            _platformSizeBoostUsed = true;
            Destroy(other.gameObject);
            _countdown.Reset();
            _boostSpavner.Countdown.Reset();
        }

        if (other.gameObject.tag == "BallSpeedUp")
        {
            _ballController.BaseSpeed += 10;
            _speedBoostUsed = true;
            Destroy(other.gameObject);
            _countdown.Reset();
            _boostSpavner.Countdown.Reset();
        }

        if (other.gameObject.tag == "BallSizeUp")
        {
            _ball.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            _ballSizeBoostUsed = true;
            Destroy(other.gameObject);
            _countdown.Reset();
            _boostSpavner.Countdown.Reset();
        }
        
        if (other.gameObject.tag == "BallSizeDown")
        {
            _ball.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            _ballSizeBoostUsed = true;
            Destroy(other.gameObject);
            _countdown.Reset();
            _boostSpavner.Countdown.Reset();
        }

        if (other.gameObject.tag == "Health")
        {
            _currentSlider.value++;
            Destroy(other.gameObject);
            _countdown.Reset();
            _boostSpavner.Countdown.Reset();
        }
    }

    private void ResetValues()
    {
        if (_platformSizeBoostUsed == true && _platformWithBoost != null)
        {
            _platformWithBoost.transform.localScale = new Vector3(0.5f, 2f, 1);
            _countdown.Reset();
            _platformSizeBoostUsed = false;
        }

        if (_ballSizeBoostUsed == true)
        {
            _ball.transform.localScale = new Vector3(1f, 1f, 1f);
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
