using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUpdate : MonoBehaviour
{
    public Sprite[] states;

    Image bg;
    Image sprite;

    // bool selected = false;

    private void Awake()
    {
        GameObject t = transform.Find("bg").gameObject;
        bg = t.GetComponent<Image>();
        t = transform.Find("sprite").gameObject;
        sprite = t.GetComponent<Image>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    /*bool isSelected()
    {
        return selected;
    }*/

    public void Select(bool b)
    {
        // selected = b;
        if (b)
        {
            bg.sprite = states[0];
        }
        else
        {
            bg.sprite = states[1];
        }
    }

    public void SetItem(GameObject obj)
    {
        gameObject.SetActive(true);
        sprite.sprite = obj.GetComponent<SpriteRenderer>().sprite;
        sprite.enabled = true;
    }

    public void RemoveItem()
    {
        sprite.sprite = null;
        sprite.enabled = false;
    }

}
