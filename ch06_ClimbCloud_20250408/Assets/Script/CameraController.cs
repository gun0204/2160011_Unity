using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾ ȭ�鿡 ������ �ʴ� �� ���� ���� �̵��ϸ�, ī�޶� ���� �� �� ���� ������ �߻�
// �̹������� �ذ��ϱ� ���ؼ���, ī�޶� �÷��̾ ����ٴϸ� ������ �� �ֵ��� ��ũ��Ʈ �ۼ�

public class CameraController : MonoBehaviour
{
    GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //�÷��̾� ������Ʈ�� ã�Ƽ� ��� ������ ����
        this.player = GameObject.Find("cat_0");

    }

   
    // Update is called once per frame
    void Update()
    {
        //�÷��̾ ���� �̵��� ������ ī�޶� ����ٴϵ��� �����Ӹ��� �÷��̾� ��ǥ�� ���ؼ� ����
        Vector3 playerPos = this.player.transform.position;

        //�÷��̾� �̵��� ī�޶� ���󰡴� ���� Y�� ����(���� ����)�� ��ȭ�̹Ƿ� ������ ���� Y��ǥ���� �ݿ��Ѵ�.
        // X��ǥ�� Z��ǥ�� ������ �����Ƿ� ī�޶��� ���� ��ǥ�� �״�� ��� 
        transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);
    }
}
