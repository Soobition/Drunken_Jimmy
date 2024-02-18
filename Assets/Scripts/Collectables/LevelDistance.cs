using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDistance : MonoBehaviour
{
    [SerializeField] private GameObject disDisplay;
    [SerializeField] private GameObject disEndDisplay;

    private int disRun;
    private int disRunTemp = 1;

    private float disDelay = .35f;

    private bool addingDis = false;

    private void Start()
    {
        StartCoroutine(IncreaseDis());
    }

    void Update()
    {
        if(!addingDis)
        {
            addingDis = true;
            StartCoroutine(AddingDis());
        }

        if (MainMenuFunction.dis < disRun)
        {
            MainMenuFunction.dis = disRun;

            MainMenuFunction.Save();
        }
    }

    IEnumerator AddingDis()
    {
        disRun += disRunTemp;
        disDisplay.GetComponent<Text>().text = "" + disRun;
        disEndDisplay.GetComponent<Text>().text = "" + disRun;
        yield return new WaitForSeconds(disDelay);
        addingDis = false;
    }

    IEnumerator IncreaseDis()
    {
        while (true)
        {
            yield return new WaitForSeconds(4.5f);
            disRunTemp++;
        }
    }
}
