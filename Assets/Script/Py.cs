using UnityEngine;

public class Py : MonoBehaviour
{

    
        public float moveSpeed = 5f; // ��������㹡���Թ
        public int maxHealth = 100;  // ��� HP �٧�ش
        private int currentHealth;   // ��� HP �Ѩ�غѹ

        private Rigidbody rb;
        private Vector3 moveDirection;
        private Vector3 spawnPoint;  // �ش�Դ

        void Start()
        {
            rb = GetComponent<Rigidbody>();

            // ��ͧ�ѹ������ Rigidbody ���
            rb.freezeRotation = true;

            // ��駤�� HP �������
            currentHealth = maxHealth;

            // �ѹ�֡���˹觨ش�Դ
            spawnPoint = transform.position;

            Debug.Log("HP: " + currentHealth);
        }

        void Update()
        {
            // �Ѻ�����š������͹���ҡ���� WASD
            float moveX = Input.GetAxisRaw("Horizontal"); // A, D ���� �١�ë���, ���
            float moveZ = Input.GetAxisRaw("Vertical");   // W, S ���� �١�â��, ŧ

            moveDirection = new Vector3(moveX, 0f, moveZ).normalized;

            // ���ͺŴ HP ����͡����� "H"
            if (Input.GetKeyDown(KeyCode.H))
            {
                TakeDamage(10); // Ŵ 10 HP
            }

            // ���ͺ���� HP ����͡����� "J"
            if (Input.GetKeyDown(KeyCode.J))
            {
                Heal(20); // ���� 20 HP
            }
        }

        void FixedUpdate()
        {
            // ����͹�������ȷҧ������Ѻ
            rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
        }

        // �ѧ��ѹŴ���ʹ
        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // �ӡѴ��������ҧ 0 �֧ maxHealth
            Debug.Log("HP: " + currentHealth);

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        // �ѧ��ѹ�������ʹ
        public void Heal(int healAmount)
        {
            currentHealth += healAmount;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // �ӡѴ��������ҧ 0 �֧ maxHealth
            Debug.Log("HP: " + currentHealth);
        }

        // �ѧ��ѹ����͵��
        void Die()
        {
            Debug.Log("Player Died!");
            Respawn();
        }

        // �ѧ��ѹ�Դ����
        void Respawn()
        {
            transform.position = spawnPoint;  // ���µ���Ф���ѧ�ش�Դ
            currentHealth = maxHealth;        // ��鹿� HP ���
            Debug.Log("Respawned! HP: " + currentHealth);
        }
    }


