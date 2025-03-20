using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // �Ѻ��Ҩҡ���� WASD
        float moveX = 0;
        float moveZ = 0;

        // ��˹���ȷҧ���������
        if (Input.GetKey(KeyCode.W)) moveX = -1;   // W 价ҧ -X (���)
        if (Input.GetKey(KeyCode.S)) moveX = 1;    // S 价ҧ +X (ŧ)
        if (Input.GetKey(KeyCode.A)) moveZ = -1;   // A 价ҧ -Z (����)
        if (Input.GetKey(KeyCode.D)) moveZ = 1;    // D 价ҧ +Z (���)

        // ���ҧ�ǡ����������͹���
        Vector3 movement = new Vector3(moveX, 0, moveZ).normalized;

        // ����ա������͹��������ع����Фõ����ȷҧ
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }

        // ���ⴴ
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        // ���絩ҡ����ͪ��ͷ
        if (collision.gameObject.CompareTag("Bot"))
        {
            Debug.Log("Hit by Bot! Restarting...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public int coinCount = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCount++;
            Debug.Log("Coin Collected! Total: " + coinCount);
            Destroy(other.gameObject);
        }
    }
}
