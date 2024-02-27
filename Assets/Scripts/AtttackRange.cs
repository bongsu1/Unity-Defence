using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtttackRange : MonoBehaviour
{
    public List<Monster> monsterList = new List<Monster>();
    public LayerMask monsterMask;

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & monsterMask) != 0)
        {
            Monster monster = other.gameObject.GetComponent<Monster>();
            monster.OnDied += () => monsterList.Remove(monster);
            monsterList.Add(monster);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (((1 << other.gameObject.layer) & monsterMask) != 0)
        {
            Monster monster = other.gameObject.GetComponent<Monster>();
            monsterList.Remove(monster);
        }
    }
}