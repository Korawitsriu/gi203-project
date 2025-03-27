using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // ����Ф÷���ͧ��������ͧ���
    public Vector3 offset = new Vector3(1, 5, -10); // ��Ѻ���˹觡��ͧ�����ҧ�ҡ Player

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.position + offset; // ���˹觡��ͧ�������Ф�
            transform.LookAt(player); // �������ͧ�ͧ价�� Player
        }
    }
}