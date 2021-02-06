using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LikecoinCollector : MonoBehaviour
{
    public int multiplier = 2;
    public int adder = 0;
    public float applyMultiplierDuringSeconds = 0.5f;

    private PointsCounter counter;
    private int currentPrice;

    void Start()
    {
        counter = gameObject.GetComponent<PointsCounter>();

        currentPrice = -1;
    }

    void Update()
    {
        
    }

    public void AddScore(int price)
    {
        if (currentPrice == -1)
            currentPrice = price;
        else
        {
            currentPrice *= multiplier;
            currentPrice += adder;
        }

        Debug.Log("LikecoinCollector.AddScore - current price = "+currentPrice);
        counter.AddPoints(currentPrice);
        StopCoroutine(WaitNextLikecoin());
        StartCoroutine(WaitNextLikecoin());
    }

    IEnumerator WaitNextLikecoin()
    {
        yield return new WaitForSeconds(applyMultiplierDuringSeconds);
        currentPrice = -1;
    }
}
