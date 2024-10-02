using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform player;

    private void Update()
    {
        Vector3 posCamera = transform.position;
        
        posCamera.x = player.position.x;

        transform.position = posCamera;
    }
    
}
