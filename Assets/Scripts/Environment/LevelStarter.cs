using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStarter : MonoBehaviour
{
    [SerializeField] private GameObject[] countDown;

    [SerializeField] private GameObject pauseButton;

    [SerializeField] private AudioSource readyFX;
    [SerializeField] private AudioSource goFX;


    private void Start()
    {
        StartCoroutine(countSquence());
    }

    IEnumerator countSquence()
    {
        yield return new WaitForSeconds(1.5f);

        foreach (var item in countDown)
        {
            item.SetActive(true);
            readyFX.Play();
            if (item.name == "GoText")
            {
                goFX.Play();
            }
            yield return new WaitForSeconds(1f);
        }

        PlayerMovement.canMove = true;

        pauseButton.SetActive(true);
    }

}
