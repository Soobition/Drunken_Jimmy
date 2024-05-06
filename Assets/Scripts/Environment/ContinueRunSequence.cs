using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueRunSequence : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject skin;
    [SerializeField] private GameObject continueScreen;
    [SerializeField] private GameObject mainCam;
    [SerializeField] private GameObject pauseButton;

    private float moveSpeedTemp = 0;

    public static int coins;

    public static bool isInvisible = false;

    private void Awake()
    {
        coins = 100;
    }


    public void Yes()
    {
        player.GetComponent<PlayerMovement>().enabled = true;

        mainCam.GetComponent<Animator>().Play("Continue");

        this.gameObject.GetComponent<LevelDistance>().enabled = true;

        CollectableControl.coinCount = CollectableControl.coinCount - coins;

        StartCoroutine(BlinkingChar());

        continueScreen.SetActive(false);
        pauseButton.SetActive(true);

        PlayerMovement.isPaused = false;

        StartCoroutine(Continue());

    }

    public void No()
    {
        this.gameObject.GetComponent<EndRunSequence>().enabled = true;
    }

    public void Retry()
    {
        SceneManager.LoadScene(1);

        PlayerMovement.canMove = false;

        PlayerMovement.isPaused = false;

        PlayerMovement.startAgain = false;
    }


    IEnumerator Continue()
    {
        PlayerMovement.startAgain = true;


        if (PlayerMovement.moveSpeed > moveSpeedTemp)
        {
            moveSpeedTemp = PlayerMovement.moveSpeed;
        }

        PlayerMovement.moveSpeed = 10;

        float moveSpeedUnit = moveSpeedTemp - 10;

        int disTemp = 10;

        for (int i = 1; i <= 100; i++)
        {

            if (PlayerMovement.isPaused)
            {
                yield return null;
            }
            else
            {
                yield return new WaitForSeconds(.1f);

                PlayerMovement.moveSpeed += moveSpeedUnit / 100;

                if (i == disTemp)
                {
                    if (Convert.ToInt32(Mathf.Floor(LevelDistance.disRunTemp / 10)) < 1)
                    {
                        LevelDistance.disRunContinue += 1;
                    }
                    else
                    {
                        LevelDistance.disRunContinue += Convert.ToInt32(Mathf.Floor(LevelDistance.disRunTemp / 10));
                    }

                    disTemp += 10;
                }
            }
            
        }


        LevelDistance.disRunContinue = 0;

        PlayerMovement.startAgain = false;
    }


    IEnumerator BlinkingChar()
    {
        isInvisible = true;


        yield return new WaitForSeconds(.2f);

        skin.SetActive(false);

        yield return new WaitForSeconds(.2f);

        skin.SetActive(true);

        yield return new WaitForSeconds(.2f);

        skin.SetActive(false);

        yield return new WaitForSeconds(.2f);

        skin.SetActive(true);

        yield return new WaitForSeconds(.2f);

        skin.SetActive(false);

        yield return new WaitForSeconds(.2f);

        skin.SetActive(true);

        yield return new WaitForSeconds(.2f);

        skin.SetActive(false);

        yield return new WaitForSeconds(.2f);

        skin.SetActive(true);

        yield return new WaitForSeconds(.2f);

        skin.SetActive(false);

        yield return new WaitForSeconds(.2f);

        skin.SetActive(true);


        isInvisible = false;
    }

}
