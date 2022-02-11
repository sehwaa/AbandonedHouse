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
        if (!FlashLight.instance.IsStatueOnFlash)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= posMoveTime)
            {
                transform.position = pos_List[i].position;
                SoundPlay();
                currentTime = 0;
                if (i < (pos_List.Length - 1))
                {
                    i++;
                }
            }
        }

        //Enemy�״°� ������ ray�� Statue�����鼭&&��������(Flash)�϶� Enemy destroy �߰���!!
        if (MyCamera.instance.isHit==true)
        {
            Instantiate(Resources.Load("Prefabs/StoneBaby_Red"), transform.position + Vector3.up * 1.2f, transform.rotation);
            //Destroy(gameObject, 1.0f);
            gameObject.SetActive(false);
            //Invoke("GetItem", 1f);
        }
    }

    private void GetItem()
    {
        Destroy(gameObject);

    }

    private void SoundPlay()
    {
        AudioSource audioPlayer = GetComponent<AudioSource>();
        audioPlayer.Play();
    }
}
