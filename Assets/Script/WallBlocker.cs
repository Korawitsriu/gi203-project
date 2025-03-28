using UnityEngine;

public class WallBlocker : MonoBehaviour
{
    public Player player; // ��ҧ�ԧ价�� Player ���ʹ٨ӹǹ����­�������
    public int requiredCoins = 5; // �ӹǹ����­����ͧ�������Դ��ᾧ

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (player.coinCount >= requiredCoins)
            {
                Debug.Log("�Դ�ҧ��ҹ!");
                Destroy(gameObject); // ����¡�ᾧ (�Դ�ҧ)
            }
            else
            {
                Debug.Log("�ѧ������­���ú! ��ͧ��� " + requiredCoins + " ����­");
            }
        }
    }
}
