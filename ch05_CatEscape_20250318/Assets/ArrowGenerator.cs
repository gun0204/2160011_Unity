/*
 * ȭ�� ������Ʈ�� 1�ʿ� �� ���� �����ϴ� �˰��� (�߿�)
 * - Update �޼���� �����Ӹ��� ����ǰ� �� �����Ӱ� ���� ������ ������ �ð� ���̴� Time,deltaTime�� ����
 * - �����Ӱ� �÷��� ������ �ð� ���̸� �볪�� ��(delta����)�� ������ (�հ�) 1�� �̻��� �Ǹ� �볪�� ���� ���
 * - �볪�� ���� ���� ������ 1�ʿ� �� ���� ȭ���� ������
 * - Instantiate �޼���
 *  -- ������ �����ϴ� ���߿� ���ӿ�����Ʈ�� ������ �� ����
 *  -- ȭ�� �������� �̿��Ͽ�, ȭ�� �ν��Ͻ��� �����ϴ� �޼���
 * - Random.Range �޼��� : ���� ���� ���� ������ �� �ִ� ���
 *  -- Random Ŭ������ ���� �䱸�Ǵ� �پ��� Ÿ���� ���� ���� ���� ���� �� �� �ִ� ����� ���� 
 *  -- ����ڰ� ������ �ּڰ��� �ִ밪 ������ ������ ���ڸ� ������
 *      -- ù ��° �Ű��������� ũ�ų� ����, �� ��° �Ű��������� ���� �������� ������ ���� �����ϰ� ��ȯ
 */

using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    /*
     * ���׷����� ��ũ��Ʈ�� ������ ���� ���
     *  - arrowPrefab ������ ������ ��ü�� �����ϱ� ���ؼ� public ���� ������
     *  - ������� ����� public���� �����ϸ� Inspecter â���� Prefab ���赵 ������ �� �ֵ��� ����
     *  - ȭ�� �뷮 ������ ���ؼ� �����(���׷����ͽ�ũ��Ʈ)�� �Ѱ� �� Prefab ���赵�� �Ѱ��־����.
     */

    public GameObject gArrowPrefab = null; // ȭ�� Prefab�� ���� �������Ʈ ���� ����(�߿�)

    GameObject gArrowInstance = null; //ȭ�� �ν��Ͻ� ���� ����

    float fArrowCreateSpan = 1.0f;// ȭ�� ���� ���� : ȭ���� 1�ʸ��� ���� ���� 
    float fDeltaTime = 0.0f;    //�� �����Ӱ� ���� ������ ������ �ð� ���̸� �����ϴ� ����

    int nArrowPositionRange = 0; // ȭ���� X ��ǥ Range ���� ���� 



    private void Start()
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
        // �����Ӵ� ���� �ð��� 1�ʰ� ������, ȭ�� ����
        if(fDeltaTime > fArrowCreateSpan)
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

            gArrowInstance = Instantiate(gArrowPrefab);

            /*
             * Random Ŭ������ ���� �䱸�Ǵ� �پ��� Ÿ���� ���� ���� ���� ������ �� �ִ� ����� ����
             * Random.Range �޼��� : ����ڰ� ������ �ּڰ��� �ְ��� ������ ������ ���ڸ� ������
             * - ������ �ּڰ��� �ִ밪�� �������� �Ǽ������� ���� ���� �Ǵ� �Ǽ��� ��ȯ��
             * - ù ��° �Ű��������� ũ�ų� ����, �� ��° �Ű��������� ���� �������� ������ ���� ������ ��ȯ
             * - ȭ���� X ��ǥ�� -6 ~ 6 ���̿� �ұ�Ģ�ϰ� ��ġ
             */

            nArrowPositionRange = Random.Range(-6, 7);

            gArrowInstance.transform.position = new Vector3(nArrowPositionRange, 7, 0);
        }
    }
}
