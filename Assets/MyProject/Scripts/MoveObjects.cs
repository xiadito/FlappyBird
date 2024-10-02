using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    [SerializeField] float objQuantity;
    [SerializeField] float objDistance;
    [SerializeField] string tagTarget;

    [SerializeField] bool changeY;
    [SerializeField] float minY;
    [SerializeField] float maxY;

    private void Awake()
    {
        //Pipes scr does this code
        /*if (changeY == false) return;

        var pipes = GameObject.FindGameObjectsWithTag(tagTarget);

        foreach (var pipe in pipes)
        {
            Vector2 pos = pipe.transform.position;
            pos.y = Random.Range(minY, maxY);
            pipe.transform.position = pos;
        }
        */
    }

    private void OnTriggerExit2D(Collider2D _other)
    {
        
        if (tagTarget == "Pipes")
        {
            float min = _other.gameObject.GetComponent<Pipes>().minY;
            float max = _other.gameObject.GetComponent<Pipes>().maxY;

            Vector2 newPos = _other.transform.position;
            newPos.y = Random.Range(min, max);
            _other.transform.position = newPos;
        }
        

        if (_other.CompareTag(tagTarget))
        {
            
            Debug.Log(_other.name);

            Vector2 _newPosition = _other.transform.position;
            _newPosition.x += objQuantity * objDistance;
            
            
            if (changeY)
            {
                _newPosition.y = Random.Range(minY, maxY);
            }

            _other.transform.position = _newPosition;
            
        }

        
        
    }
}
