using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoostSpavner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _boostsPrafabs;
    
    private float _timeSinceLastCall;
        
    private GameObject _boostOnScene;
    
    private Coroutine _spawnCoroutine;

    private readonly float spawnTimeDelay = 10f;  


    private void Start()
    {
        _spawnCoroutine = StartCoroutine(SpawnDelay());
    }

    private IEnumerator SpawnDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            if (_boostOnScene == null)
            {
                _spawnCoroutine = StartCoroutine(SpawnBoost());
            }
        }
    }

    private IEnumerator SpawnBoost()
    {
        int index = Random.Range(0, _boostsPrafabs.Length);
        _boostOnScene = Instantiate(_boostsPrafabs[index], new Vector2(Random.Range(-4, 4), Random.Range(-3, 4)), quaternion.identity);
        
        while (_boostOnScene != null)
        {
            yield return null;
        }
    }
}
