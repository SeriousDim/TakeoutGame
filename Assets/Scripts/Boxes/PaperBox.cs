using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperBox : MonoBehaviour
{
    public string rubbishType;
    public int pointsPerItem;

    private InventorySelector inventory;
    private PointsCounter counter;
    private GameObject mainCollider;

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
        Debug.Log("RubbishBox: tag = "+collision.gameObject.tag);
        GameObject rubbish = inventory.GetSelectedItem();
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (collision.gameObject.name == "MainCollider" && rubbish != null)
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
