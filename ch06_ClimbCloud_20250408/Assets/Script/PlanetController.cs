using UnityEngine;

public class PlanetController : MonoBehaviour
{
    // ������� ����
    GameObject gPlayer = null;                  // �÷��̾� GameObject
    GameObject playerController;                  //  ��ũ��Ʈ ����

    GameObject gPlayer1 = null;                  // �÷��̾�1 GameObject
    GameObject playerController2;                  // ��ũ��Ʈ ����


    Vector2 vPlanetCirclePoint = Vector2.zero;   // �༺ �߽� ��ǥ
    Vector2 vPlayerCirclePoint = Vector2.zero;  // �÷��̾��� �߽� ��ǥ
    Vector2 vPlanetPlayerDir = Vector2.zero;     // �༺ �� �÷��̾� ���� ����

    Vector2 vPlayer1CirclePoint = Vector2.zero;  // �÷��̾��� �߽� ��ǥ
    Vector2 vPlanetPlayer1Dir = Vector2.zero;     // ȭ�� �� �÷��̾� ���� ����

  

    float fPlanetRadius = 0.3f;                  // �༺ ������ (�浹 ������)
    float fPlayerRadius = 0.3f;                 // �÷��̾��� ������ (�浹 ������)
    float fPlanetPlayerDistance = 0.0f;          // �༺�� �÷��̾� �߽� �� �Ÿ�
    float fPlayer1Radius = 0.3f;                 // �÷��̾��� ������ (�浹 ������)
    float fPlanetPlayer1Distance = 0.0f;          // �༺�� �÷��̾� �߽� �� �Ÿ�


    public int scoreplanetValue = -100; // �༺ ���� ���� �ο�

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // �÷��̾� ������Ʈ ã��
        gPlayer = GameObject.Find("cat_0");

        // GameDirector ������Ʈ ����
        playerController = GameObject.Find("PlayerController");

        // �÷��̾� ������Ʈ ã��
        gPlayer1 = GameObject.Find("cat 1_0");

        // GameDirector ������Ʈ ����
        playerController = GameObject.Find("PlayerController2");

      
    }

    // Update is called once per frame
    void Update()
    {
        /*
       * �༺�� ������ �Ʒ��� 1�ʿ� �ϳ��� �������� ��� --> transform.Translate()
       * Translate �޼��� : ������Ʈ�� ���� ��ǥ���� �μ� ����ŭ �̵���Ű�� �޼���
       *    Y ��ǥ�� -0.1f�� �����ϸ� ������Ʈ�� ���ݾ� ������ �Ʒ��� �����δ�
       *    �����Ӹ��� ������� ���Ͻ�Ų��.
       */



        // �����Ӹ��� ������� ���Ͻ�Ų��.
        transform.Translate(0, -0.1f, 0);

        /*
        *   �༺�� ����ȭ�� ������ ������ �༺ ������Ʈ�� �Ҹ��Ű�� ��� --> Destroy()
        *   ȭ�� ������ ���� �༺ �Ҹ��Ű��
        *   �༺�� ������ �θ� ȭ�� ������ ������ �ǰ�, ���� �������� ������ ��� ������
        *   �༺�� ������ �ʴ� ������ ��� �������� ��ǻ�� ���� ����� �ؾ��ϹǷ� �޸� ����
        *   �޸𸮰� ������� �ʵ��� �༺�� ȭ�� ������ ������ ������Ʈ�� �Ҹ���Ѿ� ��
        *   Destroy �޼��� : �Ű������� ������ ������Ʈ�� ����
        *   �Ű������� �ڽ�(�༺ ������Ʈ)�� ����Ű�� gameObject ������ �����ϹǷ� �༺��
        *   ȭ�� ������ ������ �� �ڱ� �ڽ��� �Ҹ��Ŵ
        */

        // ȭ�� ������ ������ ������Ʈ�� �Ҹ��Ų��.
        if (transform.position.y < -3.0f)
        {
            Destroy(gameObject);
        }
        // �浹 ���� ó�� ----------------------------

        // �༺�� �÷��̾��� �߽� ��ġ ���
        vPlanetCirclePoint = transform.position;
        vPlayerCirclePoint = gPlayer.transform.position;
        vPlayer1CirclePoint = gPlayer1.transform.position;
   

        // �� �߽� ��ǥ ���� ���� ���ϱ�
        vPlanetPlayerDir = vPlanetCirclePoint - vPlayerCirclePoint;
        vPlanetPlayer1Dir = vPlanetCirclePoint - vPlayer1CirclePoint;
       

        // �� ������Ʈ �߽� �� �Ÿ� ��� (������ ũ��)
        fPlanetPlayerDistance = vPlanetPlayerDir.magnitude;
        fPlanetPlayer1Distance = vPlanetPlayer1Dir.magnitude;
    

        // �浹 ����: �Ÿ� < �� �������� �� �� ���� �浹 ����
        if (fPlanetPlayerDistance < fPlanetRadius + fPlayerRadius)
        {
            // �༺ ����
            Destroy(gameObject);
        }

        if (fPlanetPlayer1Distance < fPlanetRadius + fPlayer1Radius)
        {
            // �༺ ����
            Destroy(gameObject);
        }


        // �浹 ����: �Ÿ� < �� �������� �� �� ���� �浹 ����

        if (fPlanetPlayerDistance < fPlanetRadius + fPlayerRadius)
        {
            PlayerController playerController = gPlayer.GetComponent<PlayerController>();

            // �浹 �� ���� ����
            if (playerController != null)
            {
                playerController.SubScore(scoreplanetValue);
            }
            // �� ����
            Destroy(gameObject);
        }

        if (fPlanetPlayer1Distance < fPlanetRadius + fPlayer1Radius)
        {
            PlayerController2 playerController2 = gPlayer1.GetComponent<PlayerController2>();

            // �浹 �� ���� ����
            if (playerController2 != null)
            {
                playerController2.SubScore(scoreplanetValue);
            }
            // �� ����
            Destroy(gameObject);
        }

      
    }
}