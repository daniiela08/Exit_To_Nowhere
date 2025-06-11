using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public static int LevelSelected { get; private set; }

    public static void SelectLevel(int level)
    {
        LevelSelected = level;
    }
}
