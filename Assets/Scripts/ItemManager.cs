using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance = null;
    public GameObject player;

    public GameObject[] items;
    public GameObject[] doorObjects;

    public GameObject battery;
    public GameObject killCamera;
    public GameObject doll;

    public int score = 0;
    //public List<GameObject> gainItems = new List<GameObject>();

    public Dictionary<GameObject, bool> gainItems = new Dictionary<GameObject, bool>();
    List<GameObject> gainitems2 = new List<GameObject>();

    public GameObject[] inventory;

    public int Score
    {
        get { return score; }
        set { this.score = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        items = GameObject.FindGameObjectsWithTag("GripObject");
        doorObjects = GameObject.FindGameObjectsWithTag("Door");

        battery.SetActive(false);
        killCamera.SetActive(false);

        inventory = GameObject.FindGameObjectsWithTag("Inventory");

        for (int i = 0; i < inventory.Length; i++)
        {
            inventory[i].SetActive(false);
            gainItems.Add(inventory[i], false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddGainItems(string Itemname)
    {
        foreach (GameObject item in gainItems.Keys)
        {
            if (item.name.Contains(Itemname))
            {
                gainItems[item] = true;
                gainitems2.Add(item);
                break;
            }
        }
    }

    public void ActiveItem(string Itemname)
    {
        foreach (GameObject item in gainItems.Keys)
        {
            if (item.name.Contains(Itemname) && gainItems[item])
                item.SetActive(true);
            else
                item.SetActive(false);
        }
    }

    public void ActiveItem()
    {
        for (int i = 0; i < gainitems2.Count; i++)
        {
            if (gainitems2[i].activeInHierarchy)
            {
                gainitems2[i].SetActive(false);
                if (i == gainitems2.Count -1)
                {
                    gainitems2[0].SetActive(true);
                }
                else
                {
                    gainitems2[i + 1].SetActive(true);
                }
                break;
            }
        }
    }

    public int GainItemCount()
    {
        int cnt = 0;
        foreach (GameObject item in gainItems.Keys)
        {
            if (gainItems[item]) cnt++;
        }

        return cnt;
    }

    public bool GetActiveGameObject(string Itemname)
    {
        foreach (GameObject item in gainItems.Keys)
        {
            if (item.name.Contains(Itemname) && gainItems[item] && item.activeInHierarchy)
            {
                return true;
            }
        }
        return false;
    }

    public GameObject GetDollObject()
    {
        foreach (GameObject obj in gainitems2)
        {
            if (obj.name.Contains("Doll"))
                return obj;
        }
        return null;
    }
}
