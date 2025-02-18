using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera mainCamera;
    private BoxCollider2D cameraBounds; // 카메라 이동을 제한할 Collider


    private float minX, maxX, minY, maxY;

    protected override void Start()
    {
        base.Start();
        mainCamera = Camera.main;
        movementDirection = Vector2.zero;

        // 맵의 경계를 감지할 BoxCollider2D 찾기
        cameraBounds = GameObject.Find("CameraBounds").GetComponent<BoxCollider2D>();

        if (cameraBounds != null)
        {
            // BoxCollider2D의 크기를 이용해 경계를 설정
            minX = cameraBounds.bounds.min.x;
            maxX = cameraBounds.bounds.max.x;
            minY = cameraBounds.bounds.min.y;
            maxY = cameraBounds.bounds.max.y;
        }
        else
        {
            Debug.LogError("CameraBounds 오브젝트가 존재하지 않습니다. 경계를 설정하려면 추가해주세요.");
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
            movementDirection = Vector2.zero; // 불필요한 이동 방지
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
            cameraPosition.z = -10f; // 2D 환경에서 카메라 깊이 고정

            if (cameraBounds != null)
            {
                // 카메라 이동 범위를 BoxCollider2D의 경계로 제한
                float cameraHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;
                float cameraHalfHeight = mainCamera.orthographicSize;

                cameraPosition.x = Mathf.Clamp(cameraPosition.x, minX + cameraHalfWidth, maxX - cameraHalfWidth);
                cameraPosition.y = Mathf.Clamp(cameraPosition.y, minY + cameraHalfHeight, maxY - cameraHalfHeight);
            }

            mainCamera.transform.position = cameraPosition;
        }
    }
}