using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class TunaMController : MonoBehaviour
{
    // ������� ����
    GameObject gPlayer2 = null;                  // �÷��̾�2 GameObject
    GameObject playerController3;                  //  ��ũ��Ʈ ����

    Vector2 vTunaMCirclePoint = Vector2.zero;   // ��ġM�� �߽� ��ǥ
    Vector2 vPlayer2CirclePoint = Vector2.zero;  // �÷��̾��� �߽� ��ǥ
    Vector2 vTunaMPlayerDir = Vector2.zero;     // ��ġM �� �÷��̾� ���� ����

    float fTunaMRadius = 0.3f;                  // ��ġM�� ������ (�浹 ������)
    float fPlayerRadius2 = 0.3f;                 // �÷��̾��� ������ (�浹 ������)
    float fTunaMPlayerDistance = 0.0f;          // ��ġM�� �÷��̾� �߽� �� �Ÿ�


    public int scoreTunaMValue = -100; // �༺ ���� ���� �ο�

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // �÷��̾�2 ������Ʈ ã��
        gPlayer2 = GameObject.Find("cat 2_0");

        // GameDirector ������Ʈ ����
        playerController3 = GameObject.Find("PlayerController3");

       
    }

    // Update is called once per frame
    void Update()
    {
        // �����Ӹ��� ������� ���Ͻ�Ų��.
        transform.Translate(0, -0.1f, 0);

        // ȭ�� ������ ������ ������Ʈ�� �Ҹ��Ų��.
        if (transform.position.y < -3.0f)
        {
            Destroy(gameObject);
        }

        // ��ġM�� �÷��̾��� �߽� ��ġ ���
        vTunaMCirclePoint = transform.position;
        vPlayer2CirclePoint = gPlayer2.transform.position;

        // �� �߽� ��ǥ ���� ���� ���ϱ�
        vTunaMPlayerDir = vTunaMCirclePoint - vPlayer2CirclePoint;

         // �� ������Ʈ �߽� �� �Ÿ� ��� (������ ũ��)
        fTunaMPlayerDistance = vTunaMPlayerDir.magnitude;

        // �浹 ����: �Ÿ� < �� �������� �� �� ���� �浹 ����
        if (fTunaMPlayerDistance < fTunaMRadius + fPlayerRadius2)
        {
            // ��ġM ����
            Destroy(gameObject);
        }

        // �浹 ����: �Ÿ� < �� �������� �� �� ���� �浹 ����

        if (fTunaMPlayerDistance < fTunaMRadius + fPlayerRadius2)
        {
            PlayerController3 playerController3 = gPlayer2.GetComponent<PlayerController3>();

            // �浹 �� ���� ����
            if (playerController3 != null)
            {
                playerController3.SubScore(scoreTunaMValue);
            }
            // ��ġM ����
            Destroy(gameObject);
        }
    }

}
