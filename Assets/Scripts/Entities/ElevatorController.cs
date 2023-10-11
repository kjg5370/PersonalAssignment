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
    private float topYPosition;   // ��� ��ġ�� y��ǥ
    private float bottomYPosition;   // �ϴ� ��ġ�� y��ǥ

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

        // ���������Ͱ� �� �Ʒ��� �̵��ϵ��� ������Ʈ �Լ��� ����մϴ�.
        if (movingUp)
        {
            float newY = Mathf.MoveTowards(transform.position.y, topYPosition, moveSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            // ��� y��ǥ�� �����ϸ� �ݴ� �������� �̵��մϴ�.
            if (newY == topYPosition)
            {
                Invoke("StartMovingDown", delayAtTop);
            }
        }
        else
        {
            float newY = Mathf.MoveTowards(transform.position.y, bottomYPosition, moveSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            // �ϴ� y��ǥ�� �����ϸ� �ٽ� ���� �̵��մϴ�.
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
