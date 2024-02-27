using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTower : Tower
{
    [SerializeField] CannonBall cannonBallPrefab;
    [SerializeField] Transform CannonPoint;

    protected override void OnEnable()
    {
        base.OnEnable();

        attackRoutine = StartCoroutine(AttackRoutine());
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }

    public void Attack(Vector3 position)
    {
        CannonBall cannonBall = Instantiate(cannonBallPrefab, CannonPoint.position, CannonPoint.rotation);
        cannonBall.SetTargetPos(position);
        cannonBall.SetDamage(data.towers[level - 1].damage);
    }

    Coroutine attackRoutine;
    IEnumerator AttackRoutine()
    {
        while (true)
        {
            if (monsterList.Count > 0)
            {
                Attack(monsterList[0].transform.position);
                yield return new WaitForSeconds(data.towers[level - 1].coolTime);
            }
            else
            {
                yield return null;
            }
        }
    }
}
