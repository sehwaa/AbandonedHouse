using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointer3 : MonoBehaviour
{
    public LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    GameObject Button = null;
    public Transform hand;
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        // 1. ���� Ű������ T ��ư�� ������ ���̶��
        if (ControllerManager3.instance.TeleportKey3())
        {
            lr.enabled = true;
            // 1-1. ���� ��ġ���� ���� �Փ������� Ray�� ��� �ε������� Tower��� ����ϰ�ʹ�.
            Ray ray = new Ray(hand.position, hand.forward);
            lr.SetPosition(0, hand.position);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                // �ٶ󺻰��� �ִ� ��Ȳ
                lr.SetPosition(1, hitInfo.point);

                if (hitInfo.transform.tag == "Button")
                {
                    hitInfo.transform.GetComponent<Button>().onClick.Invoke();
                }
            }
            else
            {
                // ����� �����ִ� ��Ȳ
                lr.SetPosition(1, ray.origin + ray.direction * 100);
            }
        }
        // 2. �׷����ʰ� ���� ���� ������
        else if (ControllerManager3.instance.TeleportKeyUp3())
        {
            lr.enabled = false;

            // 2-1. Tower�� ����ϰ� �־��ٸ� �װ����� �̵��ϰ�ʹ�.
            if (Button != null)
            {

            }
        }
    }
}
