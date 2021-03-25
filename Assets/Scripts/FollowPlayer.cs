using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    
    private float offsetZ = 5;
    private float offsetY = 2;

    // Update is called once per frame
    void Update()
    {
        if(GameController.instance.playerObject != null)
        {
            transform.position = new Vector3(GameController.instance.playerObject.transform.position.x, 
                GameController.instance.playerObject.transform.position.y + offsetY, GameController.instance.playerObject.transform.position.z - offsetZ);
        }
    }
    
}
