using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] PauseUI pauseUIPrefab;

    public void Click()
    {
        Manager.UI.ShowPopUpUI(pauseUIPrefab);
    }
}
