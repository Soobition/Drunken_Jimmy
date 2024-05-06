using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contact : MonoBehaviour
{
    public void Linkedin()
    {
        Application.OpenURL("https://www.linkedin.com/in/sobhan-karami/");
    }

    public void Instagram()
    {
        Application.OpenURL("https://www.instagram.com/soobition/");
    }

    public void Email()
    {
        Application.OpenURL("mailto:soobition@protonmail.com");
    }
}
