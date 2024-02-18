using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ShaderEditor : MonoBehaviour
{
    [SerializeField] private Renderer[] objectRenderer;

    private float sidewaysStrength = 0;
    private float backwardsStrength = 0;
    private float duration = 30f;

    private bool isIncreasing = true;
    private bool isEqual = true;

    private int randomRange = 0;
    private int temp = 0;


    private void Start()
    {
        InvokeRepeating("RandomNum", 0, 25);
    }


    private void Update()
    {
        if (isIncreasing)
        {
            StartCoroutine(IncreaseStrength());
        }

        for (int i = 0; i < objectRenderer.Length; i++)
        {
            for (int j = 0; j < objectRenderer[i].materials.Length; j++)
            {
                objectRenderer[i].materials[j].SetFloat("_Sideways_Strength", sidewaysStrength);

                objectRenderer[i].materials[j].SetFloat("_Backwards_Strength", backwardsStrength);
            }
        }

        if (isEqual)
        {
            if (randomRange == temp || temp == 1 && randomRange == 3 || temp == 3 && randomRange == 1 || temp == 1 && randomRange == 4 || temp == 4 && randomRange == 1 || temp == 3 && randomRange == 2 || temp == 2 && randomRange == 3)
            {
                randomRange = Random.Range(1, 5);
            }
            else { isEqual = false; }
        }
    }


    private void RandomNum()
    {
        temp = randomRange;

        randomRange = Random.Range(1, 5);

        isEqual = true;
    }


    IEnumerator IncreaseStrength()
    {
         if (randomRange == 1 && sidewaysStrength < 0.0025f && backwardsStrength < 0.0015f && !isEqual)         // Increase the strength in the right side.
         {
            float sidewaysTargetStrength = 0.0025f;
            float backwardsTargetStrength = 0.0015f;
            float elapsed = 0f;

            if (elapsed < duration)
            {
                isIncreasing = false;

                elapsed += Time.deltaTime;
                sidewaysStrength = Mathf.Lerp(sidewaysStrength, sidewaysTargetStrength, elapsed / duration);        // Duration over which to change the strength
                backwardsStrength = Mathf.Lerp(backwardsStrength, backwardsTargetStrength, elapsed / duration);        // Duration over which to change the strength
                yield return null;
            }

            isIncreasing = true;
         }

         else if (randomRange == 2 && sidewaysStrength < 0.0025f && backwardsStrength > -0.0015f && !isEqual)         // Increase the strength in the right side.
         {
            float sidewaysTargetStrength = 0.0025f;
            float backwardsTargetStrength = -0.0015f;
            float elapsed = 0f;

            if (elapsed < duration)
            {
                isIncreasing = false;

                elapsed += Time.deltaTime;
                sidewaysStrength = Mathf.Lerp(sidewaysStrength, sidewaysTargetStrength, elapsed / duration);        // Duration over which to change the strength
                backwardsStrength = Mathf.Lerp(backwardsStrength, backwardsTargetStrength, elapsed / duration);        // Duration over which to change the strength
                yield return null;
            }

            isIncreasing = true;
         }

         else if (randomRange == 3 && sidewaysStrength > -0.0025f && backwardsStrength < 0.0015f && !isEqual)        // Increase the strength in the left side.
         {
            float sidewaysTargetStrength = -0.0025f;
            float backwardsTargetStrength = 0.0015f;
            float elapsed = 0f;

            if (elapsed < duration)
            {
                isIncreasing = false;

                elapsed += Time.deltaTime;
                sidewaysStrength = Mathf.Lerp(sidewaysStrength, sidewaysTargetStrength, elapsed / duration);
                backwardsStrength = Mathf.Lerp(backwardsStrength, backwardsTargetStrength, elapsed / duration);
                yield return null;
            }

             isIncreasing = true;
         }

         else if (randomRange == 4 && sidewaysStrength > -0.0025f && backwardsStrength > -0.0015f && !isEqual)        // Increase the strength in the left side.
         {
            float sidewaysTargetStrength = -0.0025f;
            float backwardsTargetStrength = -0.0015f;
            float elapsed = 0f;

            if (elapsed < duration)
            {
                isIncreasing = false;

                elapsed += Time.deltaTime;
                sidewaysStrength = Mathf.Lerp(sidewaysStrength, sidewaysTargetStrength, elapsed / duration);
                backwardsStrength = Mathf.Lerp(backwardsStrength, backwardsTargetStrength, elapsed / duration);
                yield return null;
            }

             isIncreasing = true;
         }
    }
}
