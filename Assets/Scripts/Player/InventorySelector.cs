using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class InventorySelector : MonoBehaviour
{
    public GameObject[] items;

    int INVENTORY_SIZE = 5;
    int selected = 0;
    InventoryUpdate[] managers;
    GameObject[] inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new GameObject[INVENTORY_SIZE];
        managers = new InventoryUpdate[INVENTORY_SIZE];

        for (int i=0; i<items.Length; i++)
        {
            managers[i] = items[i].GetComponent<InventoryUpdate>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SelectInventoryItem(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SelectInventoryItem(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            SelectInventoryItem(2);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            SelectInventoryItem(3);
        if (Input.GetKeyDown(KeyCode.Alpha5))
            SelectInventoryItem(4);

        if (Input.GetKeyDown(KeyCode.R))
            RemoveItem();
    }

    void SelectInventoryItem(int index)
    {
        if (index != selected)
        {
            managers[selected].Select(false);
            managers[index].Select(true);
            selected = index;
        }
    }

    int GetFreeCell()
    {
        for (int i = 0; i < INVENTORY_SIZE; i++)
        {
            if (inventory[i] == null)
                return i;
        }
        return -1;
    }

    public void AddItem(GameObject obj)
    {
        int index = GetFreeCell();
        if (index != -1)
        {
            inventory[index] = obj;
            managers[index].SetItem(obj);
            obj.SetActive(false);
        }
    }

    public void RemoveItem()
    {
        if (selected < INVENTORY_SIZE && inventory[selected] != null)
        {
            GameObject obj = inventory[selected];
            inventory[selected] = null;
            obj.SetActive(true);
            obj.transform.position = gameObject.transform.position + new Vector3(0, 2, 0);
            managers[selected].RemoveItem();
        }
    }

    public GameObject GetSelectedItem()
    {
        return inventory[selected];
    }

    public void ThrowIntoBox()
    {
        if (selected < INVENTORY_SIZE && inventory[selected] != null)
        {
            GameObject obj = inventory[selected];
            inventory[selected] = null;
            managers[selected].RemoveItem();
            Destroy(obj);
        }
    }

}
