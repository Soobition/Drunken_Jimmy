using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private string parentName;

    void Start()
    {
        parentName = transform.name;

        StartCoroutine(DestroyClone());
    }

    IEnumerator DestroyClone()
    {
        yield return new WaitForSeconds(120f);

        if (parentName == "Section (1)(Clone)" || parentName == "Section (2)(Clone)" || parentName == "Section (3)(Clone)" || parentName == "Section (4)(Clone)" || parentName == "Section (5)(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
