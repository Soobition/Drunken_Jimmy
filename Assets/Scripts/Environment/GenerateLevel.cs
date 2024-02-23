using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    [SerializeField] private GameObject[] section;
    [SerializeField] private int zPos = 70;

    private bool creatingSection = false;
    private bool isIncreasing = true;

    private int secNum;

    private float generatorSpeed = 0;

    private void LateUpdate()
    {
        if (!creatingSection)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }

        if (isIncreasing)
        {
            StartCoroutine(IncreaseSpeed());
        }
    }

    IEnumerator GenerateSection()
    {
        secNum = Random.Range(0, 5);
        Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 70;
        yield return new WaitForSeconds(generatorSpeed);
        creatingSection = false;
    }

    IEnumerator IncreaseSpeed()
    {
        if (generatorSpeed <= 1f)
        {
            yield return new WaitForSeconds(.1f);
            generatorSpeed += .1f;
        }
        else { isIncreasing = false; }
    }
}
