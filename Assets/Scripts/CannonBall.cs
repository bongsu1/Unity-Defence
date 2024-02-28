using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] Vector3 targetPos;
    [SerializeField] int damage;
    [SerializeField] float time;
    [SerializeField] float range;
    [SerializeField] LayerMask monsterMask;

    public void SetTargetPos(Vector3 targetPos)
    {
        this.targetPos = targetPos;
        StartCoroutine(CannonRoutine(transform.position, targetPos));
    }

    IEnumerator CannonRoutine(Vector3 startPos, Vector3 endPos)
    {
        float ySpeed = -1 * (0.5f * Physics.gravity.y * time * time + startPos.y) / time;

        float rate = 0f;
        while (rate < 1f)
        {
            rate += Time.deltaTime / time;
            Vector3 vec3 = Vector3.Lerp(startPos, endPos, rate);
            transform.position = new Vector3(vec3.x, transform.position.y, vec3.z);

            ySpeed += Physics.gravity.y * Time.deltaTime;
            transform.Translate(Vector3.up * ySpeed * Time.deltaTime);

            yield return null;
        }

        Explosion();
    }

    private void Explosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range, monsterMask);
        for (int i = 0; i < colliders.Length; i++)
        {
            Monster monster = colliders[i].gameObject.GetComponent<Monster>();
            monster.TakeDamage(damage);
        }

        Destroy(gameObject);
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
