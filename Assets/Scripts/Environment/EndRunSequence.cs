using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRunSequence : MonoBehaviour
{
    [SerializeField] private GameObject liveCoins;
    [SerializeField] private GameObject liveDis;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject fadeOut;

    private void Start()
    {
        StartCoroutine(EndSequence());
    }

    IEnumerator EndSequence()
    {
        liveCoins.SetActive(false);
        liveDis.SetActive(false);

        if (ContinueRunSequence.coins > CollectableControl.coinCount)
        {
            yield return new WaitForSeconds(2f);

            endScreen.SetActive(true);
        }
        else { endScreen.SetActive(true); }

        yield return new WaitForSeconds(3f);

        fadeOut.SetActive(true);

        yield return new WaitForSeconds(2f);

        ContinueRunSequence.coins = 100;

        SceneManager.LoadScene(0);
    }

}
