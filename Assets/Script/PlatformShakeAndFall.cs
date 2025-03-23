using UnityEngine;

public class PlatformShakeAndFall : MonoBehaviour
{
    public float shakeDuration = 2f;      // �������ҡ����� (�Թҷ�)
    public float shakeIntensity = 0.1f;   // �����ع�ç�ͧ������
    public float fallDelay = 0.5f;        // ���ҷ���鹨���ǧ��ѧ�ҡ��� (�Թҷ�)

    private Vector3 initialPosition;      // ���˹��������
    private bool isShaking = false;       // ʶҹС�����

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isShaking)
        {
            StartCoroutine(ShakeAndFall());
        }
    }

    private System.Collections.IEnumerator ShakeAndFall()
    {
        isShaking = true;

        // ��蹾��
        float elapsedTime = 0f;
        while (elapsedTime < shakeDuration)
        {
            Vector3 randomOffset = Random.insideUnitSphere * shakeIntensity;
            randomOffset.y = 0; // ����������᡹ Y
            transform.position = initialPosition + randomOffset;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // ���ա�Դ��͹��ǧ
        yield return new WaitForSeconds(fallDelay);

        // �Ŵ Physics (�������ǧ)
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = true;
        rb.isKinematic = false;

        // �Դ��ê��ѹ��ѧ��ǧ
        GetComponent<Collider>().enabled = false;

        // ������ͺ�硵��������ǧŧ
        Destroy(gameObject, 5f);
    }
}
