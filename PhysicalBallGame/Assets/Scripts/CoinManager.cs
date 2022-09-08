using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public GameObject CoinPrefab;
    public List<Coin> CoinsList = new List<Coin>();
    public Text CoinTest;

    public int AmountCoins = 30;
    void Start()
    {
        for (int i = 0; i < AmountCoins; i++)
        {
            Vector3 coinPosition = new Vector3(Random.Range(-10f, 10f), transform.position.y, Random.Range(-10f, 10f));
            GameObject newCoinPrefab = Instantiate(CoinPrefab, coinPosition, Quaternion.identity);
            CoinsList.Add(newCoinPrefab.GetComponent<Coin>());
        }
        UpdateText();
    }
    void UpdateText() => CoinTest.text = "Coins left " + CoinsList.Count.ToString();
    
    public void CollectedCoin(Coin coin)
    {
        CoinsList.Remove(coin);
        Destroy(coin.gameObject);

        UpdateText();
    }

    public Coin GetClosest(Vector3 point)
    {
        float minDistance = Mathf.Infinity;
        Coin closestCoin = null;
        for (int i = 0; i < CoinsList.Count; i++)
        {
            float distance = Vector3.Distance(point, CoinsList[i].transform.position);
            if(distance < minDistance)
            {
                minDistance = distance;
                closestCoin = CoinsList[i];
            }
        }
        return closestCoin;
    }
}
