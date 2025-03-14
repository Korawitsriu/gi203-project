using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public static Vector3 lastCheckpointPosition;

    private void Start()
    {
        // ������鹷����˹��á (�ó��������)
        lastCheckpointPosition = transform.position;
    }

    public void Respawn()
    {
        transform.position = lastCheckpointPosition;
        Debug.Log("Respawn at: " + lastCheckpointPosition);
    }

    private void Update()
    {
        // ���ͺ���»��� R ���͵����С�Ѻ��ѧ�社�µ�
        if (Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }
    }
}
