using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePlayButton : MonoBehaviour
{
    [SerializeField] private GameObject[] playCountDown;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject pauseButton;


    public void Pause()
    {
        Time.timeScale = 0;

        PlayerMovement.canMove = false;
    }

    public void Play()
    {
        StartCoroutine(TimeScale());
    }

    IEnumerator TimeScale()
    {
        foreach (var item in playCountDown)
        {
            item.SetActive(true);

            yield return new WaitForSecondsRealtime(1f);

            item.SetActive(false);
        }

        PlayerMovement.canMove = true;

        Time.timeScale = 1;

        pauseButton.SetActive(true);
    }

}
