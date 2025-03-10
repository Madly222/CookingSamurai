using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INPC
{
    public void WalkTo(string pointType, Transform pointTransform);
    public void PlayAnimation(int animationName, bool animationState);
}
