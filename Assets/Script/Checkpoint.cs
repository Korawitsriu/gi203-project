using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // �ѹ�֡���˹��社�µ�����ش
            PlayerRespawn.lastCheckpointPosition = transform.position;
            Debug.Log("Checkpoint Updated: " + transform.position);
        }
    }
}