using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildUI : InGameUI
{
    private TowerPlace towerPlace;

    protected override void Awake()
    {
        base.Awake();

        GetUI<Button>("ArchorButton").onClick.AddListener(() => BuildTower("Archor"));
        GetUI<Button>("CannonButton").onClick.AddListener(() => BuildTower("Cannon"));
        GetUI<Button>("MageButton").onClick.AddListener(() => BuildTower("Mage"));
        GetUI<Button>("BarrackButton").onClick.AddListener(() => BuildTower("Barrack"));
    }

    public void BuildTower(string name)
    {
        towerPlace.BuildTower(name);
        CloseUI();
    }

    public void SetTowerPlace(TowerPlace towerPlace)
    {
        this.towerPlace = towerPlace;
    }
}
