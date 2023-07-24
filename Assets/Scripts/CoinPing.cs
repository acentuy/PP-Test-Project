using UnityEngine.UI;
using UnityEngine;

public class CoinPing : MonoBehaviour
{
    [SerializeField] private Text coinCountText;
    [SerializeField] private ObjectGenerator objectGenerator;

    private int coinCountInt;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Coin"))
        {
            CountUpdate();
            objectGenerator.ReleaseObject(other.gameObject);
        }
    }

    private void CountUpdate()
    {
        coinCountInt++;
        coinCountText.text = coinCountInt.ToString();
    }
}
