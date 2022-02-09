using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Portal : MonoBehaviour
{
    TextMeshPro storyText;
    public GameObject player;

    public GameObject Effect;
    public GameObject GateCollider;

    // Start is called before the first frame update
    void Start()
    {
        storyText = gameObject.GetComponentInChildren<TextMeshPro>();
        //storyText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (InteractionManager.instance.getSuccessMissionCount() == 0)
        {
            SetMessage("�޼� - �ķ��� \n ������ - ������ \n" +
                "�޼� Ʈ���� - ��ȣ�ۿ� \n ������ Ʈ���� - ������ ����ϱ� \n ������ 'A' - ������ ��ü \n ������ 'B' - ������ ȹ��" +
                "\n\n HINT. ���������� ������ ã�ƺ���");
        }
        
        if (Vector3.Distance(transform.position, player.transform.position) < 1.6f)
        {
            SetMessage("������ �ö�� �� ����..");
            StartCoroutine("WaitForSeconds");
        }
    }

    private void SetMessage(string message)
    {
        storyText.text = message;
        storyText.enabled = true;
        //TODO : ����

    }

    bool isGateOpen = false;
    void GateOpen()
    {
        if (isGateOpen == true)
        {
            Effect.gameObject.SetActive(false);
            //soundCheck = true;
            //SoundManager.instance.GateSound();
            GateCollider.GetComponent<BoxCollider>().enabled = false;

        }
        else
        {
            Effect.gameObject.SetActive(true);
            //soundCheck = false;
            //SoundManager.instance.GateSound();
            GateCollider.GetComponent<BoxCollider>().enabled = true;
        }
    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(3);
        storyText.enabled = false;
    }
}
