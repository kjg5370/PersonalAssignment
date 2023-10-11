using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public Transform topPosition;  
    public Transform bottomPosition;  
    public float moveSpeed = 2.0f;
    public float delayAtTop = 3.0f;

    private bool movingUp = true;
    private float topYPosition;   // 상단 위치의 y좌표
    private float bottomYPosition;   // 하단 위치의 y좌표

    private void Start()
    {
        if (topPosition != null)
        {
            topYPosition = topPosition.position.y;
        }
        if (bottomPosition != null)
        {
            bottomYPosition = bottomPosition.position.y;
        }
    }

    private void Update()
    {
        if (topPosition == null || bottomPosition == null)
        {
            return;
        }

        // 엘리베이터가 위 아래로 이동하도록 업데이트 함수를 사용합니다.
        if (movingUp)
        {
            float newY = Mathf.MoveTowards(transform.position.y, topYPosition, moveSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            // 상단 y좌표에 도달하면 반대 방향으로 이동합니다.
            if (newY == topYPosition)
            {
                Invoke("StartMovingDown", delayAtTop);
            }
        }
        else
        {
            float newY = Mathf.MoveTowards(transform.position.y, bottomYPosition, moveSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            // 하단 y좌표에 도달하면 다시 위로 이동합니다.
            if (newY == bottomYPosition)
            {
                movingUp = true;
            }
        }
    }

    private void StartMovingDown()
    {
        movingUp = false;
    }
}
