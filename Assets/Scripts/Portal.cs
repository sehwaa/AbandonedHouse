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

    string guide;
    // Start is called before the first frame update
    void Start()
    {
        storyText = gameObject.GetComponentInChildren<TextMeshPro>();
        guide = "�޼� - �ķ��� \n ������ - ������ \n" +
                "�޼� Ʈ���� - ��ȣ�ۿ� \n ������ Ʈ���� - ������ ����ϱ� \n ������ 'A' - ������ ��ü \n ������ 'B' - ������ ȹ��" +
                "\n\n HINT. ���������� ������ ã�ƺ���";
    }

    // Update is called once per frame
    void Update()
    {
        if (InteractionManager.instance.getSuccessMissionCount() == 0)
        {
            SetMessage(guide);
        }
        
        if (Vector3.Distance(transform.position, player.transform.position) < 1.6f)
        {
            SetMessage("������ �ö� �� ����.");
            StartCoroutine("WaitForSeconds");
            SetMessage(guide);
        }

        if (ItemManager.instance.score >= 5)
        {
            isGateOpen = true;
            GateOpen();
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
            GateCollider.GetComponent<BoxCollider>().enabled = false;
            storyText.enabled = false;
            AudioSource audioPlayer = gameObject.GetComponent<AudioSource>();
            audioPlayer.Play();

        }
        else
        {
            Effect.gameObject.SetActive(true);
            GateCollider.GetComponent<BoxCollider>().enabled = true;
        }
    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(3);
        storyText.enabled = false;
    }
}
