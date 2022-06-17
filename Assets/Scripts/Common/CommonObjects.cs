using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonObjects : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
