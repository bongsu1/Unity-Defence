using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoardUI : BaseUI
{
    private void LateUpdate()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
