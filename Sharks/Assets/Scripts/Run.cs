using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Run : MonoBehaviour
{
    public float speed;
    public Vector2 dir;
    
    [SerializeField] private int heal;
    
    private Player _player;
    private DateTime _lastincounter;

    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        transform.Translate(speed * dir * Time.deltaTime, Space.World);
        
    }

    private void OnTriggerEnter2D(Collider2D info)
    {


        _player = info.GetComponent<Player>();

        if (_player != null)
        {
            _player.ChangeHP(+heal);
        }


    }

    private void OnTriggerExit2D(Collider2D info)
    {
        if (_player == info.GetComponent<Player>())
            _player = null;
    }

    
}
