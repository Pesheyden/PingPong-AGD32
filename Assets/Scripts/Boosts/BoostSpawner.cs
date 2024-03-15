using Common;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoostSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _boostsPrafabs;
        
    [SerializeField]
    private float SpawnTimeDelay = 15.0f;
    
    public Countdown Countdown;
    
    private GameObject _boostOnScene;

    private float _xx = -4f;
    private float _xy = 4f;

    private float _yx = -3f;
    private float _yy = 4f;

    private void Awake() //starting countdown (for timer)
    {
        Countdown = new Countdown(SpawnTimeDelay);
    }

    private void Update() //check if boost isn`t on scene & counting time 
    {
        if (Countdown.IsPlaying())
            Countdown.Tick(Time.deltaTime);
        else
        {
            if (_boostOnScene != null) return;
            
            SpawnBoost();
            Countdown.Reset();
        }
    }
    
    private void SpawnBoost() // spawn random boost on scene
    {
        int randomIndex = Random.Range(0, _boostsPrafabs.Length);

        float x = Random.Range(_xx, _xy);
        float y = Random.Range(_yx, _yy);

        Vector2 spawnPosition = new Vector2(x, y);
        
        _boostOnScene = Instantiate(_boostsPrafabs[randomIndex], spawnPosition, Quaternion.identity);
    }
}
