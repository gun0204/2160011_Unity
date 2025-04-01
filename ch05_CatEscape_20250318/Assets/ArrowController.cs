using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    //������� ����
    GameObject gPlayer = null; // Player Object�� ������ GameObject ����, GameObject ������ �ʱ갪�� null

    Vector2 vArrowCirclePoint = Vector2.zero;  // ȭ�츦 �ѷ��� ���� �߽� ��ǥ
    Vector2 vPlayerCirclePoint = Vector2.zero; // �÷��̾ �ѷ��� ���� �߽�
    Vector2 vArrowPlayerDir = Vector2.zero;    // ȭ�쿡�� �÷��̾������ ���Ͱ�

    float fArrowRadius = 0.5f;         // ȭ���� ������ 0.5
    float fPlayerRadius = 1.0f;        // �÷��̾��� ������ 1.0
    float fArrowPlayerDistance = 0.0f; // ȭ���� �߽�(vArrowCirclePoint)���� �÷��̾ �ѷ��� ���� �߽�(vPlayerCirclePoint)���� �Ÿ� 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /* �� �ȿ��� ������Ʈ�� ã�� �޼��� : Find
         * Find �޼���� ������Ʈ �̸��� �μ��� �����ϰ� �μ� �̸��� ���� �����ϸ� �ش� ������Ʈ�� ��ȯ
         * �÷��̾��� ��ǥ�� ���ϱ� ���ؼ� �÷��̾ �˻��Ͽ� ������Ʈ ������ ����
         * �� ������Ʈ ���ڿ� �����ϴ� ������Ʈ�� �� �ȿ��� ã�� �־�� ��
         */
        gPlayer = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * ȭ���� ������ �Ʒ��� 1�ʿ� �ϳ��� �������� ��� transform.Translate()
         * �޸𸮰� ������� �ʵ��� ȭ���� ȭ�� ������ ������ ������Ʈ�� �Ҹ���Ѿ� ��
         * �Ű������� �ڽ��� ����Ű�� gameObject ������ �����ϹǷ� ȭ���� ȭ�� ������ ������ �ڱ� �ڽ��� �Ҹ��Ŵ
         * ȭ���� ������ �Ʒ��� 1�ʿ� �ϳ��� �������� ��� transform.Translate()
         * �޸𸮰� ������� �ʵ��� ȭ���� ȭ�� ������ ������ ������Ʈ�� �Ҹ���Ѿ� ��
         * �Ű������� �ڽ��� ����Ű�� gameObject ������ �����ϹǷ� ȭ���� ȭ�� ������ ������ �ڱ� �ڽ��� �Ҹ��Ŵ
         */

        //�����Ӹ��� ������� ���Ͻ�Ų��.
        transform.Translate(0, -0.1f, 0);

        //ȭ�� ������ ������ ������Ʈ�� �Ҹ��Ų��.
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        //�浹 ����
        Vector2 p1 = transform.position;             //ȭ���� �߽� ��ǥ
        Vector2 p2 = this.gPlayer.transform.position; //�÷��̾��� �߽� ��ǥ
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;                            //ȭ���� ������
        float r2 = 1.0f;                            //�÷��̾��� ������

        if (d < r1 + r2)
        {
            //�浹�� ���� ȭ���� �����.
            Destroy(gameObject);
        }

        vArrowCirclePoint = transform.position;
        vPlayerCirclePoint = gPlayer.transform.position;
        vArrowPlayerDir = vArrowCirclePoint - vPlayerCirclePoint;
        /*
         * �� ���Ͱ��� ���̸� ���ϴ� �޼��� : magnitude
         * - �޼��� ���� : pubilc float Magnitude(Vector3 vector);
         * - ��Ʈ�� ũ��� ������ ���� ������, ������(Initial Point)�� ����(Terminal Point)���� �����Ǹ�, �� �� ������ �Ÿ��� �� ������ ũ�Ⱑ �ȴ�.
         * - �Ϲ������� �������� ������ ����, ������ ������ �Ӹ���� �θ���.
         * - ���ʹ� �������� ������ ��ġ�� ���� ����, �� ������ ũ��� ������ ���ٸ� ���� ���� ���ͷ� ����Ѵ�.
         * - ���ʹ� ���� ��ġ�� ��Ÿ���� ��ġ ����(Position Vector)�� �̿��� ǥ���Ѵ�.
         * - ȭ���� �߽�(vArrowCirclePoint)���� �÷��̾ �ѷ��� ���� �߽�(vPlayerCirclePoint)������ �Ÿ�
         */

        fArrowPlayerDistance = vArrowPlayerDir.magnitude;
        /*
         * �÷��̾ ȭ�쿡 �¾ƴ��� ����, �� ȭ��� �÷��̾��� �浹 ���� 
         * -���� �߽� ��ǥ�� �ݰ��� ����� �浹 ����
         * -r1 : ȭ�츦 �ѷ��� ���� ������, r2 : �÷��̾ �ѷ��� ���� ������, d : ȭ��� �߽ɿ��� �÷��̾�� �߽ɱ��� �Ÿ� 
         * -�浹 : �� ���� �߽� �� �Ÿ� d��(r1 + r2)  ���� ������ �浹(d > r1 + r2)
         * -���浹 : �� ���� �߽� �� �Ÿ� d�� (r1 + r2) ���� ũ�� �� ���� �浹���� ����(d > r1 + r2)
         * -�浹(fArrowPlayerDistance < ( fArrowRadius + fPlayerRadius))�̸� ȭ�� ������Ʈ �Ҹ�
         */

        if (fArrowPlayerDistance < fArrowRadius + fPlayerRadius)
        {
            Destroy(gameObject); // ȭ��� �÷��̾� �浹. ȭ�� ������Ʈ�� �Ҹ�
        }

        /*
         * �浹���� : ���� �߽� ��ǥ�� �ݰ��� ����� �浹 ���� �˰���
         * ȭ���� �߽�(vArrowCirclePoint)���� �÷��̾ �ѷ��� ���� �߽�(vPlayerCirclePoint)���� �Ÿ�(fArrowPlayerDistance)�� ��Ÿ��� ������ �̿��Ͽ� ���Ѵ�.
         * fArrowRadius : ȭ�츦 �ѷ��� ���� ������. fPlayerRadius : �÷��̾ �ѷ��� ���� ������
         * �� ���� �߽ɰ��� �Ÿ� fArrowPlayerDistance > fArrowRadius + fPlayerRadius : �浹���� ����
         * �� ���� �߽ɰ��� �Ÿ� fArrowPlayerDistance < fArrowRadius + fPlayerRadius : �浹���� ����
         */
    }
}
