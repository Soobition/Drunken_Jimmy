using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject charModel;
    [SerializeField] private GameObject mainCam;
    [SerializeField] private GameObject levelControl;

    [SerializeField] private AudioSource crashThud;

    private void OnTriggerEnter(Collider other)
    {
        if (ContinueRunSequence.invisible)
        {
            this.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
        else
        {
            this.gameObject.GetComponent<BoxCollider>().isTrigger = true;

            this.gameObject.GetComponent<BoxCollider>().enabled = false;

            player.GetComponent<PlayerMovement>().enabled = false;

            levelControl.GetComponent<LevelDistance>().enabled = false;

            charModel.GetComponent<Animator>().Play("Stumble Backwards");
            mainCam.GetComponent<Animator>().Play("MainCam");

            crashThud.Play();
        }

    }

}
