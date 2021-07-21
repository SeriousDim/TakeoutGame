using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class InventorySelector : MonoBehaviour
{
    [Header("Objects")]
    public GameObject[] items;
    public GameObject[] colItems;
    public GameObject lvlManagerObj;

    [Header("Values")]
    public bool interact = true;
    public int INVENTORY_SIZE = 5;
    public int COLLECTION_INVENTORY_SIZE = 1;

    int selected = 0;
    InventoryUpdate[] managers;
    GameObject[] inventory;

    InventoryUpdate[] colManagers;
    public GameObject[] colInventory;

    LeftRubbishNotifier notifier;

    private Level1Manager lvlManager;

    void Start()
    {
        INVENTORY_SIZE = items.Length;
        COLLECTION_INVENTORY_SIZE = colItems.Length;

        inventory = new GameObject[INVENTORY_SIZE];
        managers = new InventoryUpdate[INVENTORY_SIZE];

        for (int i=0; i<INVENTORY_SIZE; i++)
        {
            managers[i] = items[i].GetComponent<InventoryUpdate>();
        }

        colInventory = new GameObject[COLLECTION_INVENTORY_SIZE];
        colManagers = new InventoryUpdate[COLLECTION_INVENTORY_SIZE];

        for (int i = 0; i < COLLECTION_INVENTORY_SIZE; i++)
        {
            colManagers[i] = colItems[i].GetComponent<InventoryUpdate>();
        }

        notifier = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<LeftRubbishNotifier>();

        lvlManager = lvlManagerObj.GetComponent<Level1Manager>();
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

    int GetFreeColCell()
    {
        for (int i = 0; i < COLLECTION_INVENTORY_SIZE; i++)
        {
            if (colInventory[i] == null)
                return i;
        }
        return -1;
    }

    public void AddItem(GameObject obj)
    {
        Debug.Log("InventorySelector.AddItem : object added to inventory = "+obj.name);

        if (obj.tag == "Collection")
        {
            int ind = GetFreeColCell();
            colItems[ind].SetActive(true);

            colInventory[ind] = obj;
            colManagers[ind].SetItem(obj);
            Destroy(obj);

            lvlManager.ConfirmCollectionRubbish();
            return;
        }

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
            notifier.Show(); // именно так: сначала оповещаем, потом удаляем (так как Destroy выполняется в другом потоке)
            Destroy(obj);
        }
    }

}
