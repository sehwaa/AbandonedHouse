using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager instance = null;
    public bool pullBook;

    // TODO : flashlight ���� �� �̹� ���ͷ��� ���� ������Ʈ�� ���̴� ���ܾ���
    public bool PullBook
    {
        get { return pullBook; }
        set { this.pullBook = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
