using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableControl : MonoBehaviour
{
    [SerializeField] private GameObject coinCountDisplay;

    public static int coinCount;

    private void Start()
    {
        coinCount = 0;
    }

    void Update()
    {
        coinCountDisplay.GetComponent<Text>().text = "" + coinCount;
    }
}
