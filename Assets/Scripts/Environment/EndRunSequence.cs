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
    [SerializeField] private GameObject highScore;

    private void Start()
    {
        StartCoroutine(EndSequence());

        if (MainMenuFunction.dis <= LevelDistance.latestRecord)
        {
            highScore.SetActive(true);
        }
    }

    IEnumerator EndSequence()
    {
        liveCoins.SetActive(false);
        liveDis.SetActive(false);

        if (ContinueRunSequence.coins > CollectableControl.coinCount)
        {
            yield return new WaitForSeconds(1.5f);

            endScreen.SetActive(true);
        }
        else { endScreen.SetActive(true); }
    }

    IEnumerator MainMenu()
    {

        endScreen.SetActive(false);

        yield return new WaitForSeconds(.1f);

        fadeOut.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        ContinueRunSequence.coins = 100;

        SceneManager.LoadScene(0);

    }

    public void Menu()
    {
        StartCoroutine(MainMenu());

        PlayerMovement.isPaused = false;
    }
}
