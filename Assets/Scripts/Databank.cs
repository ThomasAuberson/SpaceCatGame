using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Databank
{
    public const int TOTAL_REPAIR_PROGRESS_NEEDED = 5;
    public const int LEVEL_SIZE_INCREMENT = 3;

    public static int levelNumber = 1;
    public static int levelSize = 6;
    public static int repairProgress = 0;
    public static int latestPartFound = 0; 

    public static void Reset() {
        levelNumber = 1;
        repairProgress = 0;
        latestPartFound = 0;
    }

    public static void IncrementLevel() {
        levelNumber++;
        levelSize += LEVEL_SIZE_INCREMENT;
    }
}
