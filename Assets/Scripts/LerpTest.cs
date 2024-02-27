using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class LerpTest : MonoBehaviour
{
    [SerializeField] Transform start;
    [SerializeField] Transform end;

    [Range(0f, 1f)] public float rate;

    private void Update()
    {
        //transform.position = Vector3.Lerp(start.position, end.position, rate);
        transform.Translate(moveDir * 2f * Time.deltaTime, Space.World);
        if (moveDir.magnitude != 0f)
        {
            Quaternion curRot = transform.rotation;
            Quaternion desRot = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Lerp(curRot, desRot, rate);
        }
    }

    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        moveDir.x = input.x;
        moveDir.z = input.y;
    }
    Vector3 moveDir;
}
