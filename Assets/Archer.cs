using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    Enemy _archer = new Enemy();
    private float _healthpoint = 100;
    private float _hithpoint = 20;
    private float _allhithpoint = 0;
    
    // Start is called before the first frame update
    void Start()
    {
         Enemy _archer = new Enemy();
        _archer._healthpoint = _healthpoint;
        _archer._hithpoint = _hithpoint;
    }

    // Update is called once per frame
    void Update()
    {
        _archer.EnemyMove(transform); 
    }
    
    private void OnTriggerEnter(Collider other)
    {
        EnemyMakeDamage(_hithpoint);
        _archer.EnemyTakeDamage(_hithpoint);
    }
    
    public void EnemyMakeDamage(float _hithpoint) //нанести урон
    {
        _allhithpoint += _hithpoint;
        Debug.Log("Нанесено " + _hithpoint + " урона. Общий урон " + _allhithpoint);
    }
}
