using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuFunction : MonoBehaviour
{
    [SerializeField] private GameObject coinDisplay;
    [SerializeField] private GameObject disDisplay;

    public static int dis;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        Cursor.visible = true;

        if (!PlayerPrefs.HasKey("Coin") && PlayerPrefs.HasKey("Dis"))
        {
            PlayerPrefs.SetInt("Coin", 0);
            PlayerPrefs.SetInt("Dis", 0);

            Load();
        }
        else { Load(); }

        disDisplay.GetComponent<Text>().text = "" + dis;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);

        PlayerMovement.canMove = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public static void Save()
    {
        PlayerPrefs.SetInt("Dis", dis);
    }

    private void Load()
    {
        dis = PlayerPrefs.GetInt("Dis");
    }
}
