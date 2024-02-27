using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchorTower : Tower
{
    [SerializeField] Arrow arrowPrefab;
    [SerializeField] Transform archor;
    [SerializeField] Transform arrowPoint;

    private void Update()
    {
        Look();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        attackRoutine = StartCoroutine(AttackRoutine());
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        StopCoroutine(attackRoutine);
    }

    private void Look()
    {
        if (monsterList.Count == 0)
            return;

        if (monsterList[0] != null)
        {
            Vector3 dir = (monsterList[0].transform.position - transform.position).normalized;
            archor.rotation = Quaternion.LookRotation(dir);
        }
    }

    private void Attack(Monster monster)
    {
        Arrow arrow = Instantiate(arrowPrefab, arrowPoint.position, arrowPoint.rotation);
        arrow.SetTarget(monster);
        arrow.SetDamage(data.towers[level - 1].damage);
    }

    Coroutine attackRoutine;
    IEnumerator AttackRoutine()
    {
        while (true)
        {
            if (monsterList.Count > 0)
            {
                Attack(monsterList[0]);
                yield return new WaitForSeconds(data.towers[level - 1].coolTime);
            }
            else
            {
                yield return null;
            }
        }
    }
}
