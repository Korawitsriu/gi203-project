using UnityEngine;

public class TapTrigger : MonoBehaviour
{
    public CannonController cannonController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("����º Tap ����! ��Ǩ�ͺ����­...");
            cannonController.FireProjectile();
        }
    }
}
