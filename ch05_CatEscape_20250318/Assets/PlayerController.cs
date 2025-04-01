using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    // ��� ���� ����
    float fMaxPositionX = 10.0f; //�÷��̾ ��, �� �̵��� ����â�� ����� �ʵ��� Vector �ִ밪 ���� ���� 
    float fMinPositionX = -10.0f; //�÷��̾ ��, �� �̵��� ����â�� ����� �ʵ��� Vector �ּҰ� ���� ���� 
    float fPositionX = 0.0f;    //�÷��̾ ��, �� �̵��� �� �ִ� X ��ǥ ���� ���� 


    /*
     * Start �޼ҵ�
     *  �̸� ���ǵ� Ư�� �Լ�(�޼ҵ�)�ν�, �� Ư�� �Լ����� C#������ �Լ��� �޼ҵ��� ��
     *  MonoBehaviour Ŭ������ �ʱ�ȭ �� �� ȣ�� �Ǵ� �̺�Ʈ �Լ� 
     *  ���α׷��� ������ �� �� ���� ȣ���� �Ǵ� �Լ��� ���� ������Ʈ�� �޾ƿ��ų� ������Ʈ�� �ٸ� �Լ����� ����ϱ� �ʱ�ȭ ���ִ� ���
     *  ��, Start() �޼���� ��ũ��Ʈ �ν��Ͻ��� Ȱ��ȭ�� ��쿡�� ù ��° ������ ������Ʈ ���� ȣ���ϹǷ� �ѹ��� ����
     *  �� ���¿� ���Ե� ��� ������Ʈ�� ���� Update �� ������ ȣ��� ��� ��ũ��Ʈ�� ���� Start �Լ��� ȣ��
     *  ���� �����÷��� ���� ������Ʈ�� �ν��Ͻ�ȭ�� ���� ������� ����
     */

    void Start()
    {
        /*
         * ����̽� ���ɿ� ���� ���� ����� ���� ���ֱ�
         * � ������ ��ǻ�Ϳ��� �����ص� ���� �ӵ��� �����̵��� �ϴ� ó��
         * ����Ʈ���� 60, ����� PC�� 300�� �� �� �ִ� ����̽� ���ɿ� ���� ���� ���ۿ� ������ ��ĥ �� ����
         * �����ӷ���Ʈ�� 60���� ����
         */
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * Ű�� ���ȴ��� �����ϱ� ���ؼ��� Input Ŭ������ GetKeyDown �޼��带 �����
         * �� �޼��� �Ű������� ������ Ű�� ������ ���� true�� �� �� ��ȯ
         * GetKeyDown �޼���� ���ݱ��� ����ϴ� GetMouseButtonDown �޼���� ��������� ����
         *
         */


        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // �������� �̵��ϱ� ���� ��踦 ����� �ʵ��� Ȯ��
                transform.Translate(-2, 0, 0);  // �������� '3'��ŭ �̵�
        }

        // ������ ȭ��ǥ�� ������ ��-> GetKeyDown(KeyCode.RightArrow)
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // ���������� �̵��ϱ� ���� ��踦 ����� �ʵ��� Ȯ��
                transform.Translate(2, 0, 0);   // ���������� '3'��ŭ �̵�
        }

        /*
         *  Mathf.Clamp(value, min, max) �޼���
         *  Ư�� ���� ��� ������ ���ѽ�Ű���� �� �� ����ϴ� �޼���
         *  value ���� ���� : min <= value <= max
         *  �ּ�/�ִ밪�� �����Ͽ� ������ ���� �̿ܿ� ���� ���� �ʵ��� �� �� ���
         *  �÷��̾ ������ �� �ִ� �ּ�(fMinPositionX)/�ִ�(fMaxPositionX)�������� �����Ͽ� �� ������ ����� �ʵ����Ѵ�.
         */
        fPositionX = Mathf.Clamp(transform.position.x, fMinPositionX, fMaxPositionX);
        transform.position = new Vector3(fPositionX, transform.position.y, transform.position.z);
    }
}
