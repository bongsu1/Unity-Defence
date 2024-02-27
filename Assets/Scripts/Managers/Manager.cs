using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private static Manager instance;
    public static Manager Inst { get { return instance; } }

    [SerializeField] UIManager uiManager;
    public static UIManager UI { get { return instance.uiManager; } }

    [SerializeField] ResourceManager resourceManager;
    public static ResourceManager Resource { get { return instance.resourceManager; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
