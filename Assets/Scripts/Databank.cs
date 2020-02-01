using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Databank
{
    public const int TOTAL_REPAIR_PROGRESS_NEEDED = 5;

    public static int levelNumber = 1;
    public static int repairProgress = 0;
    public static int latestPartFound = 0; 

    public static void Reset() {
        levelNumber = 1;
        repairProgress = 0;
        latestPartFound = 0;
    }
}
