using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 500f;
    public float bounceSpeed = 2f;
    public float bounceHeight = 0.25f;

    private Vector3 startPos;

    void Start()
    {
        // �纵��˹�������鹢ͧ����­
        startPos = transform.position;
    }

    void Update()
    {
        // �����ع����­�ͺ᡹ Y
        Debug.Log("Coin is rotating");
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // ��á���駢��ŧ (�������ժ��Ե����)
        float newY = startPos.y + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
