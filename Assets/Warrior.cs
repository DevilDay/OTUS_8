using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    Enemy _warrior = new Enemy();
    private float _healthpoint = 200;
    private float _hithpoint = 50;
    private float _allhithpoint = 0;
    void Start()
    {
        Enemy _warrior = new Enemy();

        _warrior._healthpoint = _healthpoint;
        _warrior._hithpoint = _hithpoint;
    }
    
    void Update()
    {
        _warrior.EnemyMove(transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyMakeDamage(_hithpoint);
        _warrior.EnemyTakeDamage(_hithpoint);
    }
    
    public void EnemyMakeDamage(float _hithpoint) //нанести урон
    {
        _allhithpoint += _hithpoint;
        Debug.Log("Нанесено " + _hithpoint + " урона. Общий урон " + _allhithpoint);
    }
    
}
