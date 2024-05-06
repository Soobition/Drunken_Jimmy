using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private string parentName;

    public static bool isWall = false;

    private void Start()
    {
        parentName = transform.name;

        StartCoroutine(DestroyClone());
    }


    IEnumerator DestroyClone()
    {
        yield return new WaitWhile(() => !isWall);


        if (parentName == "Section (1)(Clone)" || parentName == "Section (2)(Clone)" || parentName == "Section (3)(Clone)" || parentName == "Section (4)(Clone)" || parentName == "Section (5)(Clone)")
        {
            isWall = false;

            yield return new WaitForSeconds(.5f);

            Destroy(gameObject);
        }
    }
}
