using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager instance = null;
    bool pullBook;

    // TODO : flashlight ���� �� �̹� ���ͷ��� ���� ������Ʈ�� ���̴� ���ܾ���
    //public bool PullBook
    //{
    //    get { return pullBook; }
    //    set { this.pullBook = value; }
    //}

    public bool PullBookComplete
    {
        get
        {
            if (GameObject.Find("BookItem").transform.position == new Vector3(-2.873f, 3.6356f, -3.2f))
                return true;
            else
                return false;
        }
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
