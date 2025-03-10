using UnityEngine;

public class Bot : MonoBehaviour
{
    public GameObject bulletPrefab;    // ����ع����ԧ�͡��
    public Transform firePoint;        // ���˹��ԧ
    public float bulletSpeed = 10f;    // �������ǡ���ع
    public float shootInterval = 0.5f; // ���������ҧ����ԧ (0.5 �Թҷ�)

    void Start()
    {
        // ���¡�ѧ��ѹ Shoot ��� � �ء 0.5 �Թҷ�
        InvokeRepeating("Shoot", 0f, shootInterval);
    }

    void Shoot()
    {
        // ���ҧ����ع�����˹��ԧ
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed;
        }

        Debug.Log("Bot �ԧ����ع!");
    }
}
