using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tower : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] TowerData data;
    [SerializeField] MeshFilter meshFilter;

    private TowerPlace towerPlace;
    private int level;
    private bool isUpgrading;

    // Test
    [SerializeField] private UpgradeUI upgradeUI;

    private void Start()
    {
        Upgrade();
    }

    public void SetTowerPlace(TowerPlace towerPlace)
    {
        this.towerPlace = towerPlace;
    }

    public void Sell()
    {
        Destroy(gameObject);
        towerPlace.gameObject.SetActive(true);
    }

    public void Upgrade()
    {
        if (level == data.towers.Length)
            return;

        if (isUpgrading)
            return;

        StartCoroutine(UpgradeRoutine(level));
    }

    Coroutine upgradeRoutine;

    IEnumerator UpgradeRoutine(int level)
    {
        meshFilter.mesh = data.towers[level].cons;
        isUpgrading = true;
        yield return new WaitForSeconds(data.towers[level].buildTime);
        meshFilter.mesh = data.towers[level].build;
        isUpgrading = false;
        this.level++;
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        if (level > 0)
        {
            Gizmos.DrawWireSphere(transform.position, data.towers[level- 1].range);
        }
    }
}
