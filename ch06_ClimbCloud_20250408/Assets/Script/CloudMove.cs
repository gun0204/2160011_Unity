using UnityEngine;

public class CloudMove : MonoBehaviour
{
    int nCloudMove = 1;     // ������ �̵� ������ ǥ��
    float moveSpeed = 2.0f;// �̵� �ӵ�
    private Vector3 startPos;
    private bool movingRight = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ������ �̵� ���
        transform.Translate(nCloudMove * moveSpeed * Time.deltaTime, 0, 0);

        // x �������� 1.7�̻�, -1.7���ϰ� �Ǹ� �ݴ�������� �ٲٰ� ����
        if (transform.position.x > 1.6 || transform.position.x < -1.6)
        {
            nCloudMove *= -1;
        }
    }
}