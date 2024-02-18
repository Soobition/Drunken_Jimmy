using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStarter : MonoBehaviour
{
    [SerializeField] private GameObject[] countDown;

    [SerializeField] private AudioSource readyFX;
    [SerializeField] private AudioSource goFX;


    private void Awake()
    {
        Application.targetFrameRate = 60;
    }


    private void Start()
    {
        Cursor.visible = false;

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
    }

}
