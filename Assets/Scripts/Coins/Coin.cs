using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private const int ROTATION_SPEED = 3;

    private void Update()
    {
        transform.Rotate(Vector3.up * ROTATION_SPEED);
    }

}
