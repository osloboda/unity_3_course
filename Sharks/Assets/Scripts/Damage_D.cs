using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Damage_D : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _timeDelay;
    private Player _player;
    private DateTime _lastincounter;
    private void OnTriggerEnter2D(Collider2D info)
    {


        _player = info.GetComponent<Player>();

        if (_player != null)
        {
            _player.ChangeHP(-_damage);
        }


    }

    private void OnTriggerExit2D(Collider2D info)
    {
        if (_player == info.GetComponent<Player>())
            _player = null;
    }

    private void Update()
    {
        if (_player != null && (DateTime.Now - _lastincounter).TotalSeconds > _timeDelay)
        {
            _player.ChangeHP(-_damage);
            _lastincounter = DateTime.Now;
        }
    }
}
