using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Monster : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;

    public UnityEvent OnEndPointArrvived;

    private void Update()
    {
        CheckEndPoint();
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
