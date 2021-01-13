using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsCounter : MonoBehaviour
{
    public GameObject pointsView;

    int points = 0;
    TextMeshProUGUI text;

    void Start()
    {
        text = pointsView.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        
    }

    public int GetPoints()
    {
        return points;
    }

    public void AddPoints(int newPoints)
    {
        points += newPoints;
        text.text = ""+points;
    }

}
