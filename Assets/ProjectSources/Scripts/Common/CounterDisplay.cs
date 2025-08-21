using UnityEngine;
using TMPro;
using System.Collections;

public class CounterDisplay : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    private int count = 0;

    void Start()
    {
        // Start updating the counter every second
        StartCoroutine(UpdateCounter());
    }

    IEnumerator UpdateCounter()
    {
        while (true)
        {
            count++;
            counterText.text = "Counter: " + count;

            yield return new WaitForSeconds(1f); // wait 1 second
        }
    }
}
