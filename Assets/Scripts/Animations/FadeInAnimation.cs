using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInAnimation : MonoBehaviour
{
    void Start()
    {
        
    }

    public void FadeInComplete()
    {
        GameObject.Destroy(gameObject);
    }
}
