using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this one only has one destination
//will always move to endpos before coming back to startingpos
public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public float waitAtEdgeTimer;
    private float _timer;
    
    [Tooltip("Starting position will be current position unless this is checked")]
    public bool difStartPos;
    public Vector3 startingPos;
    private Vector3 _startPos;
    public Vector3 endPos;

    private void Start()
    {
        
        if (difStartPos)
            _startPos = startingPos;
        else
            _startPos = transform.position;
            
        _timer = waitAtEdgeTimer;
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;
        float distance = Vector3.Distance(transform.position, endPos);
        if (distance <= 0.1)
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
            } else 
            {
                endPos = _startPos;
                _startPos = transform.position;
                _timer = waitAtEdgeTimer;
            }
        } else
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, step);
        }
    }
}
