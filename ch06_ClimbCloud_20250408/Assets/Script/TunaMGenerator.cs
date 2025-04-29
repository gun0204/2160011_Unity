using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class TunaMGenerator : MonoBehaviour
{
    public GameObject gTunaMPrefab = null; // ���׿� Prefab�� ���� �������Ʈ ���� ����(�߿�)

    GameObject gTunaMInstance = null; //���׿� �ν��Ͻ� ���� ����

    float fTunaMCreateSpan = 1.5f;// ���׿� ���� ���� : ȭ���� 1�ʸ��� ���� ���� 
    float fDeltaTime = 0.0f;    //�� �����Ӱ� ���� ������ ������ �ð� ���̸� �����ϴ� ����


    int nTunaMPositionRange = 0; // ���׿��� X ��ǥ Range ���� ���� 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Updte �޼���� �����Ӹ��� ����ǰ� �� �����Ӱ� ���� ������ ������ ���̴� Time.deltaTime�� ���Ե�
        // Time.deltaTime�� �� ������ �� �����ϴ� �ð� �� ���ϴµ� ���� float ���·� ��ȯ�ϰ�, ������ �ʸ� �����
        // ��, �����Ӱ� ������ ������ �ð� ���̸� fDeltaTime ������ ����
        fDeltaTime += Time.deltaTime;

        // ȭ���� 1��(fArrowCreateSpan = 1.0f)���� �� ���� ����
        // �����Ӵ� ���� �ð��� 1�ʰ� ������, ���׿� ����
        if (fDeltaTime > fTunaMCreateSpan)
        {
            fDeltaTime = 0.0f;  // �����Ӱ� ������ ������ �ð� ���� ���� ���� �ʱ�ȭ

            /*
             * Instantiate �޼��� : ȭ�� �������� �̿��Ͽ�, ȭ�� �ν��Ͻ��� �����ϴ� �޼��� 
             * - �Ű������� �������� �����ϸ�, ��ȯ������ ������ �ν��Ͻ��� �����ش�
             * - Instantiate �޼��带 ����ϸ� ������ �����ϴ� ���߿� ���ӿ�����Ʈ�� ������ �� ����
             * - RPG �����̶�� ������ ������, ĳ����, ��� �� ���͵��� ��� �̸� �������� �� ������?
             *      �׷��Ƿ� ���ӿ�����Ʈ�� �������� ����
             * - Instantiate(GameObject original, Vector3 position, Quaternion rotation)
             *  -- GameObject original : �����ϰ��� �ϴ� ���ӿ�����Ʈ��, ���� ���� �ִ� ���ӿ�����Ʈ�� Prefab���� ����� ��ü�� �ǹ���
             *  -- Vector3 position : Vector3���� ������ ��ġ�� ������
             *  -- Quaternion rotation : ������ ���ӿ�����Ʈ�� ȸ������ ����
             */

            gTunaMInstance = Instantiate(gTunaMPrefab);

            /*
             * Random Ŭ������ ���� �䱸�Ǵ� �پ��� Ÿ���� ���� ���� ���� ������ �� �ִ� ����� ����
             * Random.Range �޼��� : ����ڰ� ������ �ּڰ��� �ְ��� ������ ������ ���ڸ� ������
             * - ������ �ּڰ��� �ִ밪�� �������� �Ǽ������� ���� ���� �Ǵ� �Ǽ��� ��ȯ��
             * - ù ��° �Ű��������� ũ�ų� ����, �� ��° �Ű��������� ���� �������� ������ ���� ������ ��ȯ
             * - ���׿��� X ��ǥ�� -6 ~ 7 ���̿� �ұ�Ģ�ϰ� ��ġ
             */

            nTunaMPositionRange = Random.Range(-3, 3);

            gTunaMInstance.transform.position = new Vector3(nTunaMPositionRange, 20, 0);

        }
    }
}