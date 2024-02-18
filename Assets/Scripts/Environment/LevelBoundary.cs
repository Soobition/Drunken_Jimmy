using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    private float internalLeft;
    private float internalRight;

    public static float leftSide = -2f;
    public static float rightSide = 2f;

    private void Update()
    {
        internalLeft = leftSide;
        internalRight = rightSide;
    }
}
