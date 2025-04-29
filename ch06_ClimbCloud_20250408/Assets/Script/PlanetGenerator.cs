using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour
{
    public GameObject gPlanetPrefab = null; // �༺ Prefab�� ���� �������Ʈ ���� ����(�߿�)

    GameObject gPlanetInstance = null; //�༺ �ν��Ͻ� ���� ����

    float fPlanetCreateSpan = 1.5f;// �༺ ���� ���� : �༺�� 1�ʸ��� ���� ���� 
    float fDeltaTime = 0.0f;    //�� �����Ӱ� ���� ������ ������ �ð� ���̸� �����ϴ� ����


    int nPlanetPositionRange = 0; // �༺�� X ��ǥ Range ���� ���� 
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

        // �༺�� 1��(fArrowCreateSpan = 1.0f)���� �� ���� ����
        // �����Ӵ� ���� �ð��� 1�ʰ� ������, �༺ ����
        if (fDeltaTime > fPlanetCreateSpan)
        {
            fDeltaTime = 0.0f;  // �����Ӱ� ������ ������ �ð� ���� ���� ���� �ʱ�ȭ

            /*
             * Instantiate �޼��� : �༺ �������� �̿��Ͽ�, �༺ �ν��Ͻ��� �����ϴ� �޼��� 
             * - �Ű������� �������� �����ϸ�, ��ȯ������ ������ �ν��Ͻ��� �����ش�
             * - Instantiate �޼��带 ����ϸ� ������ �����ϴ� ���߿� ���ӿ�����Ʈ�� ������ �� ����
             * - RPG �����̶�� ������ ������, ĳ����, ��� �� ���͵��� ��� �̸� �������� �� ������?
             *      �׷��Ƿ� ���ӿ�����Ʈ�� �������� ����
             * - Instantiate(GameObject original, Vector3 position, Quaternion rotation)
             *  -- GameObject original : �����ϰ��� �ϴ� ���ӿ�����Ʈ��, ���� ���� �ִ� ���ӿ�����Ʈ�� Prefab���� ����� ��ü�� �ǹ���
             *  -- Vector3 position : Vector3���� ������ ��ġ�� ������
             *  -- Quaternion rotation : ������ ���ӿ�����Ʈ�� ȸ������ ����
             */

            gPlanetInstance = Instantiate(gPlanetPrefab);

            /*
             * Random Ŭ������ ���� �䱸�Ǵ� �پ��� Ÿ���� ���� ���� ���� ������ �� �ִ� ����� ����
             * Random.Range �޼��� : ����ڰ� ������ �ּڰ��� �ְ��� ������ ������ ���ڸ� ������
             * - ������ �ּڰ��� �ִ밪�� �������� �Ǽ������� ���� ���� �Ǵ� �Ǽ��� ��ȯ��
             * - ù ��° �Ű��������� ũ�ų� ����, �� ��° �Ű��������� ���� �������� ������ ���� ������ ��ȯ
             * - ȭ���� X ��ǥ�� -6 ~ 7 ���̿� �ұ�Ģ�ϰ� ��ġ
             */

            nPlanetPositionRange = Random.Range(-3, 3);

            gPlanetInstance.transform.position = new Vector3(nPlanetPositionRange, 20, 0);

        }
    }
}
