using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] int hp;
    [SerializeField] Slider hpBar;

    public int HP { get { return hp; } set { hp = value; OnChangeHP?.Invoke(value); } }
    public event UnityAction<int> OnChangeHP;

    public event UnityAction OnDied;
    public UnityEvent OnEndPointArrvived;

    private void Update()
    {
        CheckEndPoint();
        hpBar.value = HP;
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            OnDied?.Invoke();
            Destroy(gameObject);
        }
    }

    public void SetDestination(Vector3 destination)
    {
        agent.destination = destination;
    }

    void CheckEndPoint()
    {
        if ((transform.position - agent.destination).sqrMagnitude < 0.01f)
        {
            //Debug.Log("¸ó½ºÅÍ°¡ µµÂøÁö¿¡ µµÂø");
            OnEndPointArrvived?.Invoke();
            Destroy(gameObject);
        }
    }
}
