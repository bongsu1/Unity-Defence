using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "Data/Tower")]

public class TowerData : ScriptableObject
{
    public Tower prefab;
    public TowerInfo[] towers;

    [Serializable]
    public struct TowerInfo
    {
        public string name;

        public Mesh cons;
        public Mesh build;

        public int damage;
        public float range;

        public float buildTime;
        public int buildCost;
        public int sellCost;
    }
}
