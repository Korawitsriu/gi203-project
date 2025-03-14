using UnityEngine;
using UnityEngine.SceneManagement;

public class Bot : MonoBehaviour
{
    public float speed = 3f;
    public float visionDistance = 10f;
    public Transform player;

    void Update()
    {
        // �ӹǳ������ҧ�����ҧ�ͷ�Ѻ������
        float distance = Vector3.Distance(transform.position, player.position);

        // ��Ǩ�ͺ��Ҽ�������������С���ͧ����������
        if (distance <= visionDistance)
        {
            // ��觵��������
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            transform.LookAt(player); // ��ع�ͷ����ѹ˹���Ҽ�����
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Caught! Restarting...");
            RestartGame();
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // �������ҹ����
    }
}
