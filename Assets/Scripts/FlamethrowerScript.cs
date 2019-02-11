using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerScript : MonoBehaviour
{
    public float timeBtwn;
    private float _timerBtwn;
    public float flameTime;
    private float _fTimer;

    public SpriteRenderer warning;
    public GameObject fire;
    //Collider2D fireCol;

    // Start is called before the first frame update
    void Start()
    {
        //fireCol = GetComponentInChildren<Collider2D>();
        warning.enabled = false;
        fire.SetActive(false);

        _timerBtwn = timeBtwn;
        _fTimer = flameTime;
    }

    // Update is called once per frame
    void Update()
    {
        _timerBtwn -= Time.deltaTime;
        /*
        if (_timerBtwn <= 2f)
        {
            warning.enabled = true;
        } 
        */

        if (_timerBtwn <= 0f)
        {
            warning.enabled = false;
            _fTimer -= Time.deltaTime;
            if (_fTimer > 0f)
            {
                fire.SetActive(true);
            } else
            {
                fire.SetActive(false);
                _fTimer = flameTime;
                _timerBtwn = timeBtwn;
            }
        } else if (_timerBtwn <= 2f)
        {
            warning.enabled = true;
        }
        else
        {
            warning.enabled = false;
            fire.SetActive(false);
        }

        //Debug.Log(_fTimer + " " + _timerBtwn);
    }
}
