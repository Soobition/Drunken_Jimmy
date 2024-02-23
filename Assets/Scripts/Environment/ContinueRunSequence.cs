using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueRunSequence : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject skin;
    [SerializeField] private GameObject continueScreen;
    [SerializeField] private GameObject mainCam;

    public static int coins = 100;

    public static bool invisible = false;


    public void No()
    {
        this.gameObject.GetComponent<EndRunSequence>().enabled = true;

        continueScreen.SetActive(false);
    }
    
    
    public void Yes()
    {
        player.GetComponent<PlayerMovement>().enabled = true;

        mainCam.GetComponent<Animator>().Play("Continue");

        this.gameObject.GetComponent<LevelDistance>().enabled = true;

        CollectableControl.coinCount = CollectableControl.coinCount - coins;

        StartCoroutine(BlinkingChar());

        continueScreen.SetActive(false);

        this.gameObject.GetComponent<GenerateLevel>().enabled = true;

        PlayerMovement.isPaused = false;

    }
    
    
    IEnumerator BlinkingChar()
    {
        invisible = true;


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


        invisible = false;
    }

}
