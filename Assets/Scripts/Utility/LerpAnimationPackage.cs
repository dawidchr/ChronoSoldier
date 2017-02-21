using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class LerpAnimationPackage {
    /// <summary>
    /// Create instance to hold informations about animation move
    /// Then add to LerpAnimationScript.AnimateObject
    /// </summary>

    public GameObject obj;
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float startScale;
    public float endScale;
    public Vector3 rotate;
    public float rotateSpeed;
    public float lerpTime;
    public float singleWait;
    public Action action;

    public LerpAnimationPackage(GameObject obj, Vector3 startPosition, Vector3 endPosition, float lerpTime, Action actionAfterAnim = null, float startScale = 1f, float endScale = 1f, Vector3 rotate = new Vector3(), float rotateSpeed = 0, float singleTime = 0.005f)
    {
        this.obj = obj;
        this.startPosition = startPosition;
        this.endPosition = endPosition;
        this.lerpTime = lerpTime;
        this.startScale = startScale;
        this.endScale = endScale;
        this.rotate = rotate;
        this.rotateSpeed = rotateSpeed;
        this.singleWait = singleTime;
        action = actionAfterAnim;
    }
}
