using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
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
        // �Ѻ��ҡ������͹���ҡ���� WASD
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        // ���ҧ�ǡ�����ȷҧ�������͹���
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