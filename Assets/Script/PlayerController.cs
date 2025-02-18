using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera mainCamera;
    private BoxCollider2D cameraBounds; // ī�޶� �̵��� ������ Collider


    private float minX, maxX, minY, maxY;

    protected override void Start()
    {
        base.Start();
        mainCamera = Camera.main;
        movementDirection = Vector2.zero;

        // ���� ��踦 ������ BoxCollider2D ã��
        cameraBounds = GameObject.Find("CameraBounds").GetComponent<BoxCollider2D>();

        if (cameraBounds != null)
        {
            // BoxCollider2D�� ũ�⸦ �̿��� ��踦 ����
            minX = cameraBounds.bounds.min.x;
            maxX = cameraBounds.bounds.max.x;
            minY = cameraBounds.bounds.min.y;
            maxY = cameraBounds.bounds.max.y;
        }
        else
        {
            Debug.LogError("CameraBounds ������Ʈ�� �������� �ʽ��ϴ�. ��踦 �����Ϸ��� �߰����ּ���.");
        }
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Debug.Log($"Before Update - Movement: {movementDirection}, Input: ({horizontal}, {vertical})");

        if (horizontal != 0 || vertical != 0)
        {
            movementDirection = new Vector2(horizontal, vertical).normalized;
        }
        else
        {
            movementDirection = Vector2.zero; // ���ʿ��� �̵� ����
        }

        Debug.Log($"After Update - Movement: {movementDirection}");

        if (movementDirection != Vector2.zero)
        {
            lookDirection = movementDirection;
        }
    }

    private void LateUpdate()
    {
        if (mainCamera != null)
        {
            Vector3 cameraPosition = transform.position;
            cameraPosition.z = -10f; // 2D ȯ�濡�� ī�޶� ���� ����

            if (cameraBounds != null)
            {
                // ī�޶� �̵� ������ BoxCollider2D�� ���� ����
                float cameraHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;
                float cameraHalfHeight = mainCamera.orthographicSize;

                cameraPosition.x = Mathf.Clamp(cameraPosition.x, minX + cameraHalfWidth, maxX - cameraHalfWidth);
                cameraPosition.y = Mathf.Clamp(cameraPosition.y, minY + cameraHalfHeight, maxY - cameraHalfHeight);
            }

            mainCamera.transform.position = cameraPosition;
        }
    }
}