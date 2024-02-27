using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] Monster target;
    [SerializeField] float speed;
    [SerializeField] int damage;

    public void SetTarget(Monster target)
    {
        this.target = target;
        StartCoroutine(ArrowRoutine(transform.position, target));
    }

    IEnumerator ArrowRoutine(Vector3 startPos, Monster target)
    {
        Vector3 endPos = target.transform.position;
        float time = Vector3.Distance(startPos, endPos) / speed;

        float rate = 0f;
        while (rate < 1f)
        {
            rate += Time.deltaTime / time;
            if (rate > 1f)
            {
                rate = 1f;
            }
            transform.position = Vector3.Lerp(startPos, endPos, rate);
            if (target != null)
            {
                endPos = target.transform.position;
                transform.LookAt(endPos);
            }

            yield return null;
        }

        if (target != null)
        {
            target.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
}
