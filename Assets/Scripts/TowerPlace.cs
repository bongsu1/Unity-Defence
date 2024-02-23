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

    [SerializeField] InGameUI buildUI;

    public UnityEvent OnPointerEntered;
    public UnityEvent OnPointerExited;

    public void OnPointerClick(PointerEventData eventData)
    {
        InGameUI ui = Manager.UI.ShowInGameUI(buildUI);
        ui.SetTarget(transform);
        ui.SetOffset(new Vector3(0, 150, 0));
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnPointerEntered?.Invoke();
        render.material.color = hihglightColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnPointerExited?.Invoke();
        render.material.color = normalColor;
    }
}
