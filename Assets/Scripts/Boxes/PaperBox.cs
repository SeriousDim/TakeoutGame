using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperBox : MonoBehaviour
{
    public string rubbishType;
    public int pointsPerItem;

    private InventorySelector inventory;
    private PointsCounter counter;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<InventorySelector>();
        counter = player.GetComponent<PointsCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject rubbish = inventory.GetSelectedItem();
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (collision.gameObject.tag == "Player" && rubbish != null)
            {
                if (rubbish.tag == rubbishType)
                {
                    inventory.ThrowIntoBox();
                    counter.SetPoints(pointsPerItem);
                    Debug.Log("Points: " + counter.GetPoints());
                }
            }
        }
    }

}
