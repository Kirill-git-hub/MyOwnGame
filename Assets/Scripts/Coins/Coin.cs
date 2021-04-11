using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private const int ROTATION_SPEED = 150;

    private void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * ROTATION_SPEED);
    }

}
