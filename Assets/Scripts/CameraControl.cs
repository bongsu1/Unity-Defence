using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float padding;


    Vector3 moveDir;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);
    }

    void OnMove(InputValue value)
    {
        Vector2 inputDir = value.Get<Vector2>();
        moveDir.x = inputDir.x;
        moveDir.z = inputDir.y;
    }

    /*void OnPointer(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();

        // 왼쪽이동
        if (input.x < padding)
        {
            moveDir.x = -1f;
        }
        // 오른쪽이동
        else if (input.x > Screen.width - padding)
        {
            moveDir.x = 1f;
        }
        else
        {
            moveDir.x = 0;
        }


        // 아래쪽이동
        if (input.y < padding)
        {
            moveDir.z = -1f;
        }
        // 위쪽이동
        else if (input.y > Screen.height - padding)
        {
            moveDir.z = 1f;
        }
        else
        {
            moveDir.z = 0;
        }
    }*/
}
