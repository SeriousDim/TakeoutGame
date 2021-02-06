using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperBox : MonoBehaviour
{
    public string rubbishType;
    public int pointsPerItem;

    private InventorySelector inventory;
    private PointsCounter counter;
    private GameObject mainCollider;

    private GameObject buttonObj;
    private bool possibleToThorw = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<InventorySelector>();
        counter = player.GetComponent<PointsCounter>();

        buttonObj = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ThrowOnClick()
    {
        if (possibleToThorw)
        {
            inventory.ThrowIntoBox();
            counter.AddPoints(pointsPerItem);
            Debug.Log("Points: " + counter.GetPoints());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("RubbishBox: tag = "+collision.gameObject.tag);

        GameObject rubbish = inventory.GetSelectedItem();
        if (collision.gameObject.name == "MainCollider" && rubbish != null)
        {
            if (rubbish.tag == rubbishType)
            {
                buttonObj.SetActive(true);
                possibleToThorw = true;
            }
        } else
        {
            buttonObj.SetActive(false);
            possibleToThorw = false;
        }

        /*if (Input.GetKeyDown(KeyCode.E))
        {
            if (collision.gameObject.name == "MainCollider" && rubbish != null)
            {
                if (rubbish.tag == rubbishType)
                {
                    inventory.ThrowIntoBox();
                    counter.AddPoints(pointsPerItem);
                    Debug.Log("Points: " + counter.GetPoints());
                }
            }
        }*/
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        buttonObj.SetActive(false);
        possibleToThorw = false;
    }

}
