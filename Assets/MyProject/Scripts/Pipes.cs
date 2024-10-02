using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Pipes : MonoBehaviour
{
    public float minY, maxY;

    private void Awake()
    {
        
        SetPipesPositionY();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       // Debug.Log(collision);
    }
    public void SetPipesPositionY()
    {
        var pipes = GameObject.FindGameObjectsWithTag("Pipes");

        foreach (var pipe in pipes)
        {
            Vector2 pos = pipe.transform.position;
            pos.y = Random.Range(minY, maxY);
            pipe.transform.position = pos;
        }
    }
}
