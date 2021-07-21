using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Takeout.DataWrappers;

public class PropCollision : MonoBehaviour
{
    public ColRubbish colRubObj;

    private InventorySelector inventory;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<InventorySelector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("PropCollision: tag = "+collision.gameObject.tag);
        if (collision.gameObject.tag == "Player" && inventory.interact)
        {
            inventory.AddItem(gameObject);
        }
    }

}
