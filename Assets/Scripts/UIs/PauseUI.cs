using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : PopUpUI
{
    [SerializeField] SettingUI settingUIPrefab;

    protected override void Awake()
    {
        base.Awake();

        GetUI<Button>("SettingButton").onClick.AddListener(Setting);
        GetUI<Button>("CloseButton").onClick.AddListener(Close);
    }

    public void Setting()
    {
        Manager.UI.ShowPopUpUI(settingUIPrefab);
    }
}
