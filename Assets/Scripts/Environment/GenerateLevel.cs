using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    [SerializeField] private GameObject[] section;
    [SerializeField] private int zPos = 70;

    public static int levels;


    private void Start()
    {
        levels = 0;
    }


    private void LateUpdate()
    {
        if (levels < 10)
        {
            int secNum = Random.Range(0, 5);
            Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
            zPos += 70;
            levels++;
        }
    }
}
