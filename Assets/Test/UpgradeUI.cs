using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : InGameUI
{
    private Tower tower;
    private Button upgradeButton;
    private TextMeshProUGUI upInfo;
    private TextMeshProUGUI sellInfo;

    protected override void Awake()
    {
        base.Awake();

        upgradeButton = GetUI<Button>("UpgradeButton");
        upgradeButton.onClick.AddListener(() => { tower.Upgrade(); CloseUI(); });
        GetUI<Button>("SellButton").onClick.AddListener(() => { tower.Sell(); CloseUI(); });
        upInfo = GetUI<TextMeshProUGUI>("UpgradeInfo");
        sellInfo = GetUI<TextMeshProUGUI>("SellInfo");
    }

    public void SetTower(Tower tower)
    {
        this.tower = tower;
    }

    public void SetInfo(TowerData data, int level)
    {
        if (data.towers.Length == level)
        {
            upgradeButton.gameObject.SetActive(false);
        }
        else
        {
            upInfo.text = string.Format(upInfo.text, data.towers[level].buildCost, data.towers[level].buildTime);
        }

        sellInfo.text = string.Format(sellInfo.text, data.towers[level - 1].sellCost);
    }
}
