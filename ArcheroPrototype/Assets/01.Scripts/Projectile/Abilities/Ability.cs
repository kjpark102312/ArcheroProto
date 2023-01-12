using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{

    public int level = 0;
    public abstract void AbilityMerge(AbilityManager manager);
}
