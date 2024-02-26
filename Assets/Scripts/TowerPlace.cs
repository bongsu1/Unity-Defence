using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TowerPlace : MonoBehaviour
    , IPointerClickHandler
    , IPointerEnterHandler
    , IPointerExitHandler
{
    [SerializeField] Renderer render;
    [SerializeField] Color normalColor;
    [SerializeField] Color hihglightColor;

    [SerializeField] BuildUI buildUI;

    [Header("Tower")]
    [SerializeField] TowerData archorTower;
    [SerializeField] TowerData cannonTower;

    public void OnPointerClick(PointerEventData eventData)
    {
        BuildUI ui = Manager.UI.ShowInGameUI(buildUI);
        ui.SetTarget(transform);
        ui.SetOffset(new Vector3(200, 0, 0));
        ui.SetTowerPlace(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        render.material.color = hihglightColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        render.material.color = normalColor;
    }

    public void BuildTower(string name)
    {
        if (name == "Archor")
        {
            gameObject.SetActive(false);
            Tower tower = Instantiate(archorTower.prefab, transform.position, transform.rotation);
            tower.SetTowerPlace(this);
        }
        else if(name == "Cannon")
        {
            gameObject.SetActive(false);
            Tower tower = Instantiate(cannonTower.prefab, transform.position, transform.rotation);
            tower.SetTowerPlace(this);
        }
    }
}
