using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public CoinManager CoinManager;
    private Coin _closestCoin;
    void Update()
    {
        if (CoinManager.CoinsList.Count > 0)
        {
            _closestCoin = CoinManager.GetClosest(transform.position);
            Debug.DrawLine(transform.position, _closestCoin.transform.position);

            Vector3 toCoin = _closestCoin.transform.position - transform.position;
            Vector3 toCoinXZ = new Vector3(toCoin.x, 0f, toCoin.z);
            transform.rotation = Quaternion.LookRotation(toCoinXZ);
        }
        else Destroy(gameObject);
        
    }
}
