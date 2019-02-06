using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this one only has one destination
public class MovingPlatform : MonoBehaviour
{
    public float speed;
    //public float endPosX;
    //public float endPosY;
    public float waitAtEdgeTimer;
    private float _timer;

    public Vector3 endPos;
    Vector3 startPos;
    Vector3 dir;

    private void Start()
    {
        //endPos = new Vector3(endPosX, endPosY, 0f);
        startPos = transform.position;
        dir = transform.position - endPos;
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
                endPos = startPos;
                startPos = transform.position;
                _timer = waitAtEdgeTimer;
            }
        } else
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, step);
        }
    }
}
