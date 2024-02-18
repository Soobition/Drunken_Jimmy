using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PitchController : MonoBehaviour
{
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            PlayMusic.bgm.pitch = .75f;
        }
        else { PlayMusic.bgm.pitch = 1; }
    }
}
