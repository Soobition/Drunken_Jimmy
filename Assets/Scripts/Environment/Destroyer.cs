using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private string parentName;

    private void Start()
    {
        parentName = transform.name;

        StartCoroutine(DestroyClone());
    }


    IEnumerator DestroyClone()
    {
        for (int i = 1; i <= 120; i++)
        {
            if (PlayerMovement.isPaused)
            {
                yield return new WaitWhile(() => PlayerMovement.isPaused);
            }
            else { yield return new WaitForSeconds(1); }
        }

        if (parentName == "Section (1)(Clone)" || parentName == "Section (2)(Clone)" || parentName == "Section (3)(Clone)" || parentName == "Section (4)(Clone)" || parentName == "Section (5)(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
