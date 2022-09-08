using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float Speed;
    void Update()
    {
        transform.Rotate(0f, Speed, 0f);
    }

}
