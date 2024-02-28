using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tower : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] protected TowerData data;
    [SerializeField] MeshFilter meshFilter;

    public List<Monster> monsterList = new List<Monster>(10);
    [SerializeField] LayerMask monsterMask;

    private TowerPlace towerPlace;
    protected int level;
    private bool isUpgrading;

    protected virtual void OnEnable()
    {
        Upgrade();
        checkRangeRoutine = StartCoroutine(CheckRangeRoutine());
    }

    private void Start()
    {
        
    }

    protected virtual void OnDisable()
    {
        StopCoroutine(checkRangeRoutine);
    }

    Coroutine checkRangeRoutine;
    IEnumerator CheckRangeRoutine()
    {
        Collider[] colliders = new Collider[20];
        while (true)
        {
            if (!isUpgrading)
            {
                monsterList.Clear();
                int size = Physics.OverlapSphereNonAlloc(transform.position, data.towers[level - 1].range, colliders, monsterMask);
                for (int i = 0; i < size; i++)
                {
                    Monster monster = colliders[i].GetComponent<Monster>();
                    monsterList.Add(monster);
                }
            }
            yield return new WaitForSeconds(data.towers[level - 1].coolTime);
        }
    }

    // Test
    [SerializeField] private UpgradeUI upgradeUI;

    public void SetTowerPlace(TowerPlace towerPlace)
    {
        this.towerPlace = towerPlace;
    }

    public void Sell()
    {
        Destroy(gameObject);
        towerPlace.gameObject.SetActive(true);

        if (isUpgrading)
        {
            StopCoroutine(upgradeRoutine);
        }
    }

    public void Upgrade()
    {
        if (level == data.towers.Length)
            return;

        if (isUpgrading)
            return;

        upgradeRoutine = StartCoroutine(UpgradeRoutine(level));
    }

    Coroutine upgradeRoutine;

    IEnumerator UpgradeRoutine(int level)
    {
        this.level++;
        meshFilter.mesh = data.towers[level].cons;
        isUpgrading = true;
        yield return new WaitForSeconds(data.towers[level].buildTime);
        meshFilter.mesh = data.towers[level].build;
        isUpgrading = false;
    }

    // Test
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isUpgrading)
            return;

        UpgradeUI ui = Manager.UI.ShowInGameUI(upgradeUI);
        ui.SetTarget(gameObject.transform);
        ui.SetOffset(new Vector3(250, 0, 0));
        ui.SetTower(this);
        ui.SetInfo(data, level);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        if (level > 0)
        {
            Gizmos.DrawWireSphere(transform.position, data.towers[level- 1].range);
        }
    }
}
