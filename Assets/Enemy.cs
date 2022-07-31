
using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    private NavMeshAgent _agent;
    
    private float _x;
    private float _y;
    private float _z;
    public float _healthpoint;
    public float _hithpoint;
    private float _allhitpoint;
    private float _allhealth = 300;
    public bool _goRight;
   
    public void PlayerMove(float _x, float _y, float _z)
    {
        Debug.Log("Переместился по координатам " + _x + _y + _z);        
    }

    public void EnemyMakeDamage(float _hithpoint) //нанести урон
    {
        _allhitpoint += _hithpoint;
        Debug.Log("Нанесено " + _hithpoint + " урона. Общий урон " + _allhitpoint);
    }

    public void EnemyTakeDamage(float _healthpoint) // получить урон
    {
        _allhealth -= _healthpoint;
        Debug.Log("Осталось очков жизни " + _allhealth);
        if (_allhealth <= 0)
        {
            Death();
        }
    }

    public void EnemyMove(Transform transform)
    {
        
        if (transform.position.x < -8)
        {
            _goRight = true;
        }
        else if (transform.position.x > 8)
        {
            _goRight = false;   
        }
        
        if (_goRight)
        {
            transform.Translate(Vector3.right * 5 * Time.deltaTime);    
        }
        else
        {
            transform.Translate(Vector3.left * 5 * Time.deltaTime);    
        }
    }
    void Death()
    {
        Debug.Log("Красиво умираю с анимацией!");
    }
    void Start()
    {
        _allhealth = 500; //при старте не присвоило значение.
        _hithpoint = 0;
        _agent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit _raycastHit;
        
        //принимает команду перемещения по клику
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_ray, out _raycastHit, 100)) ;
            _agent.SetDestination(_raycastHit.point);
            if (!_agent.hasPath)
            {
                PlayerMove(_agent.transform.position.x, _agent.transform.position.y, _agent.transform.position.z);
            }
        }
    }
}

public class warrior : Enemy
{
    private float _x;
    private float _y;
    private float _z;
    public float _healthpoint = 200;
    public float _hithpoint = 50;
    private float _radiusattack = 10;


    void Move(float _x, float _y, float _z)
    {
        Debug.Log("Перешел по координатам " + _x + _y + _z);            
    }

    void Atack(float _hithpoint, float _radiusattack)
    {
        Debug.Log("Наносит урон " + _hithpoint + " в радиусе " + _radiusattack);    
    }
    
}

public class archer : Enemy
{
    private float _x;
    private float _y;
    private float _z;
    public float _healthpoint = 100;
    public float _hithpoint = 20;
    private float _radiusattack = 50;


    void Move(float _x, float _y, float _z)
    {
        Debug.Log("Перешел по координатам " + _x + _y + _z);            
    }

    void Atack(float _hithpoint, float _radiusattack)
    {
        Debug.Log("Наносит урон " + _hithpoint + " в радиусе " + _radiusattack);    
    }
    
}