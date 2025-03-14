using UnityEngine;

public class BotCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ���¡�ѧ��ѹ Respawn � PlayerRespawn.cs
            collision.gameObject.GetComponent<PlayerRespawn>().Respawn();
            Debug.Log("Bot hit player! Respawning...");
        }
    }
}
