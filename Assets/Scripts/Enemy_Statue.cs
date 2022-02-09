using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Statue : MonoBehaviour
{
    public Transform[] pos_List;
    public float posMoveTime = 1.5f;
    public GameObject player;
    public bool isStatueCameraShot;

    private float currentTime;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = pos_List[0].position;
        player = GameObject.Find("OVRPlayerController");
        i = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //player �����ϰ� ȭ��ǹ��� ������ �̺�Ʈ bool��ȣ�Ǹ� �����̱� ���� ���߿� &&�� ���Ǵ޾��ֱ�
        if ((player != null)&&(FlashLight.instance.isStatueOnFlash==false))
        {
            currentTime += Time.deltaTime;

            if (currentTime >= posMoveTime)
            {
                transform.position = pos_List[i].position;
                currentTime = 0;
                if (i< (pos_List.Length-1))
                {
                i++;
                }
            }
        }
        //Enemy�״°� ������ ray�� Statue�����鼭&&��������(Flash)�϶� Enemy destroy �߰���!!
        else if (MyCamera.instance.isHit==true)
        {
            Destroy(gameObject, 1.0f);
        }

        //������ Pos�������� i++�� �Ǹ� ������ ����.
        if (i == (pos_List.Length-1))
        {
            ////Gameoverscene �̵� �߰��ϱ�
            //SceneManager.LoadScene("GameoverScene");

            Destroy(gameObject,3f);
        }
    }
}
