using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDistance : MonoBehaviour
{
    [SerializeField] private GameObject disDisplay;
    [SerializeField] private GameObject disEndDisplay;

    private int disRun = 0;

    private float disDelay = .35f;

    private bool addingDis = false;

    public static int latestRecord;
    public static int disRunContinue;
    public static int disRunTemp;

    private void Start()
    {
        disRunTemp = 1;

        StartCoroutine(IncreaseDis());
    }

    void Update()
    {
        if(!addingDis)
        {
            addingDis = true;
            StartCoroutine(AddingDis());
        }

        latestRecord = disRun;

        if (MainMenuFunction.dis < disRun)
        {
            MainMenuFunction.dis = disRun;

            MainMenuFunction.Save();
        }
    }

    IEnumerator AddingDis()
    {
        if (!PlayerMovement.startAgain)
        {
            disRun += disRunTemp;
        }
        else
        {
            disRun += disRunContinue;
        }

        disDisplay.GetComponent<Text>().text = "" + disRun;
        disEndDisplay.GetComponent<Text>().text = "" + disRun;

        yield return new WaitForSeconds(disDelay);

        addingDis = false;
    }

    IEnumerator IncreaseDis()
    {
        while (true)
        {
            if (!PlayerMovement.isPaused && !PlayerMovement.startAgain)
            {
                yield return new WaitForSeconds(4.5f);

                disRunTemp++;
            }
            else { yield return null; }
        }
    }
}
