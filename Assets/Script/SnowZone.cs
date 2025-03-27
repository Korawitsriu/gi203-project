using UnityEngine;
using UnityEngine.AI;

public class SnowZone : MonoBehaviour
{
    public float moveSpeed = 5f; // �������ǻ���
    public float jumpForce = 7f; // �ç���ⴴ����
    private float defaultSpeed; // �纤�Ҥ����������
    private float defaultJump; // �纤���ç���ⴴ���

    private Rigidbody rb;
    private NavMeshAgent agent; // ����Ѻ Bot

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>(); // ������Ѻ Bot

        // �ѹ�֡��һ���
        defaultSpeed = moveSpeed;
        defaultJump = jumpForce;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Snow")) // ��������ʾ�鹷������
        {
            moveSpeed -= 2; // Ŵ�������� 2 ˹���
            jumpForce -= 2; // Ŵ�ç���ⴴ 2 ˹���

            if (agent != null) // ����� Bot (�� NavMeshAgent)
            {
                agent.speed -= 2; // Ŵ�������Ǣͧ Bot ����
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Snow")) // ����͡�ҡ��鹷������
        {
            moveSpeed = defaultSpeed; // �׹��Ҥ����������
            jumpForce = defaultJump; // �׹����ç���ⴴ���

            if (agent != null) // ����� Bot
            {
                agent.speed = defaultSpeed; // �׹��Ҥ�����������ͧ Bot
            }
        }
    }
}

