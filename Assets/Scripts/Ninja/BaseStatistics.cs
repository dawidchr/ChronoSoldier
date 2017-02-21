using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStatistics : MonoBehaviour {

    public string characterName { get; protected set; }
    public int health { get; protected set; }
    public int shield { get; protected set; }

    public float movingSpeed { get; protected set; }

    protected float teleportReleaseTime;
    protected float teleportCapability;

    protected float teleportCastingTime;
    public bool attackOrTeleport { get; private set; }

    public void SwitchTeleportAndMove()
    {
        attackOrTeleport = !attackOrTeleport;
    }
}
