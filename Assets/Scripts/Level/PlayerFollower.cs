using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : Follower
{
    protected override void UpdateTarget()
    {
        if (target)
            return;

        target = PlayerBase.PlayerInstance.transform;
    }
}
