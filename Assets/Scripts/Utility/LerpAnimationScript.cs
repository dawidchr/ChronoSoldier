using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class LerpAnimationScript : MonoBehaviour
{

    public static IEnumerator WaitForSecondsThenExecute(Action p, float v)
    {
        yield return new WaitForSecondsRealtime(v);
        p();
        yield return null;
    }

    public virtual IEnumerator LerpSliderValue(Slider slider, float startValue, float endValue, float lerpTime, Action callback = null, float singleWait = 0.005f)
    {
        float deltaLerpTime = 0f;
        float perc;

        while (deltaLerpTime < lerpTime)
        {
            if (ConditionActionsScript.StopAnimation)
                yield break;

            yield return new WaitForSeconds(singleWait);

            if (ConditionActionsScript.GameplayEnabled)
            {
                deltaLerpTime += Time.fixedDeltaTime;
                if (deltaLerpTime > lerpTime)
                {
                    deltaLerpTime = lerpTime;
                }
            }
            perc = deltaLerpTime / lerpTime;
            slider.value = Mathf.Lerp(startValue, endValue, perc);
        }

        if (callback != null)
            callback();
        yield return null;
    }

    public virtual IEnumerator LerpColor(GameObject currObj, float startValue, float endValue, Vector3 endPosition, float lerpTime, float singleWait = 0.005f)
    {
        float deltaLerpTime = 0f;
        float perc;
        SpriteRenderer spriteRenderer = currObj.GetComponent<SpriteRenderer>();
        while (deltaLerpTime < lerpTime)
        {
            if (ConditionActionsScript.StopAnimation)
                yield break;

            yield return null;


            if (ConditionActionsScript.GameplayEnabled)
            {
                deltaLerpTime += Time.fixedDeltaTime;
                if (deltaLerpTime > lerpTime)
                {
                    deltaLerpTime = lerpTime;
                }
            }
            perc = deltaLerpTime / lerpTime;

            spriteRenderer.color = new Color(Mathf.Lerp(startValue, endValue, perc), Mathf.Lerp(startValue, endValue, perc), Mathf.Lerp(startValue, endValue, perc));
        }

        while (deltaLerpTime > 0)
        {
            if (ConditionActionsScript.StopAnimation)
                yield break;

            yield return new WaitForSeconds(singleWait);

            deltaLerpTime -= Time.fixedDeltaTime;
            if (deltaLerpTime < 0)
            {
                deltaLerpTime = 0;
            }
            perc = deltaLerpTime / lerpTime;
            spriteRenderer.color = new Color(Mathf.Lerp(startValue, endValue, perc), Mathf.Lerp(startValue, endValue, perc), Mathf.Lerp(startValue, endValue, perc));
        }
        yield return null;
    }

    public virtual IEnumerator LerpRotation(Vector3 startRotation, Vector3 endRotation, float lerpTime, float singleWait = 0.005f)
    {
        float deltaLerpTime = 0f;
        float perc;

        while (deltaLerpTime < lerpTime)
        {
            if (ConditionActionsScript.StopAnimation)
                yield break;

            yield return new WaitForSeconds(singleWait);

            if (ConditionActionsScript.GameplayEnabled)
            {
                deltaLerpTime += Time.fixedDeltaTime;
                if (deltaLerpTime > lerpTime)
                {
                    deltaLerpTime = lerpTime;
                }
            }
            perc = deltaLerpTime / lerpTime;
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(startRotation), Quaternion.Euler(endRotation), perc);
        }
        yield return null;
    }

    public virtual IEnumerator LerpRotateZ(float angle, float lerpTime, float singleWait = 0.005f)
    {
        float deltaLerpTime = 0f;
        float perc;
        float startRotation = transform.rotation.eulerAngles.z % 360;
        float currentRotation;

        while (deltaLerpTime < lerpTime)
        {
            if (ConditionActionsScript.StopAnimation)
                break;

            yield return null;

            if (ConditionActionsScript.GameplayEnabled)
            {
                deltaLerpTime += Time.fixedDeltaTime;
                if (deltaLerpTime > lerpTime)
                {
                    deltaLerpTime = lerpTime;
                }
            }
            perc = deltaLerpTime / lerpTime;
            currentRotation = (angle * perc) + startRotation;
            transform.eulerAngles = new Vector3(0, 0, currentRotation);
            yield return null;

        }
        yield return null;
    }

    public virtual IEnumerator LerpRotateZWithCallback(Action callback, float angle, float lerpTime, float singleWait = 0.005f)
    {
        float deltaLerpTime = 0f;
        float perc;
        float startRotation = transform.rotation.eulerAngles.z % 360;
        float currentRotation;

        while (deltaLerpTime < lerpTime)
        {
            if (ConditionActionsScript.StopAnimation)
                yield break;

            yield return new WaitForSeconds(singleWait);
            if (ConditionActionsScript.GameplayEnabled)
            {
                deltaLerpTime += Time.fixedDeltaTime;
                if (deltaLerpTime > lerpTime)
                {
                    deltaLerpTime = lerpTime;
                }
            }
            perc = deltaLerpTime / lerpTime;
            currentRotation = (angle * perc) + startRotation;
            transform.eulerAngles = new Vector3(0, 0, currentRotation);
        }
        callback();
        yield return null;
    }


    public virtual IEnumerator Lerp(Vector3 startPosition, Vector3 endPosition, float lerpTime, float singleWait = 0.005f)
    {
        float deltaLerpTime = 0f;
        float perc;

        while (deltaLerpTime < lerpTime)
        {
            if (ConditionActionsScript.StopAnimation)
                yield break;

            yield return new WaitForSeconds(singleWait);

            if (ConditionActionsScript.GameplayEnabled)
            {
                deltaLerpTime += Time.fixedDeltaTime;
                if (deltaLerpTime > lerpTime)
                {
                    deltaLerpTime = lerpTime;
                }
            }
            perc = deltaLerpTime / lerpTime;
            transform.position = Vector3.Lerp(startPosition, endPosition, perc);
        }
        yield return null;
    }

    public virtual IEnumerator Lerp(GameObject obj, Vector3 startPosition, Vector3 endPosition, float lerpTime, float singleWait = 0.005f)
    {
        float deltaLerpTime = 0f;
        float perc;

        while (deltaLerpTime < lerpTime)
        {
            if (ConditionActionsScript.StopAnimation)
                yield break;

            yield return new WaitForSeconds(singleWait);

            if (ConditionActionsScript.GameplayEnabled)
            {
                deltaLerpTime += Time.fixedDeltaTime;
                if (deltaLerpTime > lerpTime)
                {
                    deltaLerpTime = lerpTime;
                }
            }
            perc = deltaLerpTime / lerpTime;


            obj.transform.position = Vector3.Lerp(startPosition, endPosition, perc);
        }
        yield return null;
    }

    public virtual IEnumerator Lerp(Vector3 startPosition, Vector3 endPosition, float startScale, float endScale, float lerpTime, float singleWait = 0.005f)
    {
        float deltaLerpTime = 0f;
        float perc;
        Vector3 vStart = new Vector3(startScale, startScale, startScale);
        Vector3 vEnd = new Vector3(endScale, endScale, endScale);

        while (deltaLerpTime < lerpTime)
        {
            if (ConditionActionsScript.StopAnimation)
                yield break;

            yield return new WaitForSeconds(singleWait);

            if (ConditionActionsScript.GameplayEnabled)
            {
                deltaLerpTime += Time.fixedDeltaTime;
                if (deltaLerpTime > lerpTime)
                {
                    deltaLerpTime = lerpTime;
                }
            }
            perc = deltaLerpTime / lerpTime;

            yield return null;

            transform.position = Vector3.Lerp(startPosition, endPosition, perc);
            transform.localScale = Vector3.Lerp(vStart, vEnd, perc);
        }
        yield return null;
    }

    public virtual IEnumerator Lerp(Vector3 startPosition, Vector3 endPosition, float startScale, float endScale, Vector3 rotate, float rotateSpeed, float lerpTime, float singleWait = 0.005f)
    {
        float deltaLerpTime = 0f;
        float perc;
        Vector3 vStart = new Vector3(startScale, startScale, startScale);
        Vector3 vEnd = new Vector3(endScale, endScale, endScale);

        while (deltaLerpTime < lerpTime)
        {
            if (ConditionActionsScript.StopAnimation)
                yield break;


            yield return null;
            if (ConditionActionsScript.GameplayEnabled)
            {
                deltaLerpTime += Time.fixedDeltaTime;
                if (deltaLerpTime > lerpTime)
                {
                    deltaLerpTime = lerpTime;
                }
            }
            perc = deltaLerpTime / lerpTime;
            transform.Rotate(rotate * rotateSpeed * Time.fixedDeltaTime);

            transform.position = Vector3.Lerp(startPosition, endPosition, perc);
            transform.localScale = Vector3.Lerp(vStart, vEnd, perc);
        }
        yield return null;
    }

    public virtual IEnumerator Lerp(Vector3 startPosition, Vector3 endPosition, Vector3 startScale, Vector3 endScale, Vector3 rotate, float rotateSpeed, float lerpTime, float singleWait = 0.005f)
    {
        float deltaLerpTime = 0f;
        float perc;
        Vector3 vStart = startScale;
        Vector3 vEnd = endScale;

        while (deltaLerpTime < lerpTime)
        {
            if (ConditionActionsScript.StopAnimation)
                yield break;


            yield return null;
            if (ConditionActionsScript.GameplayEnabled)
            {
                deltaLerpTime += Time.fixedDeltaTime;
                if (deltaLerpTime > lerpTime)
                {
                    deltaLerpTime = lerpTime;
                }
            }
            perc = deltaLerpTime / lerpTime;
            transform.Rotate(rotate * rotateSpeed * Time.fixedDeltaTime);

            transform.position = Vector3.Lerp(startPosition, endPosition, perc);
            transform.localScale = Vector3.Lerp(vStart, vEnd, perc);
        }
        yield return null;
    }

    public virtual IEnumerator Lerp(System.Action<bool> callback, Vector3 startPosition, Vector3 endPosition, float lerpTime, float singleWait = 0.005f)
    {
        float deltaLerpTime = 0f;
        float perc;

        while (deltaLerpTime < lerpTime)
        {
            if (ConditionActionsScript.StopAnimation)
                yield break;


            yield return null;
            if (ConditionActionsScript.GameplayEnabled)
            {
                deltaLerpTime += Time.fixedDeltaTime;
                if (deltaLerpTime > lerpTime)
                {
                    deltaLerpTime = lerpTime;
                }
            }
            perc = deltaLerpTime / lerpTime;
            transform.position = Vector3.Lerp(startPosition, endPosition, perc);
        }
        callback(true);

        yield return null;
    }

    public virtual IEnumerator LerpWithCallback(System.Action callback, Vector3 startPosition, Vector3 endPosition, float lerpTime, float singleWait = 0.005f)
    {
        float deltaLerpTime = 0f;
        float perc;

        while (deltaLerpTime < lerpTime)
        {


            if (ConditionActionsScript.StopAnimation)
                yield break;

            if (ConditionActionsScript.GameplayEnabled)
            {
                deltaLerpTime += Time.fixedDeltaTime;
                if (deltaLerpTime > lerpTime)
                {
                    deltaLerpTime = lerpTime;
                }
                perc = deltaLerpTime / lerpTime;
                transform.position = Vector3.Lerp(startPosition, endPosition, perc);
                yield return null;
            }

            yield return null;
        }
        callback();

        yield return null;
    }

    public virtual IEnumerator LerpWithCallback(System.Action<bool> callback, GameObject obj, Vector3 startPosition, Vector3 endPosition, float lerpTime, float singleWait = 0.005f)
    {
        float deltaLerpTime = 0f;
        float perc;

        while (deltaLerpTime < lerpTime)
        {
            if (ConditionActionsScript.StopAnimation)
                yield break;

            yield return null;
            if (ConditionActionsScript.GameplayEnabled)
            {
                deltaLerpTime += Time.fixedDeltaTime;
                if (deltaLerpTime > lerpTime)
                {
                    deltaLerpTime = lerpTime;
                }
            }
            perc = deltaLerpTime / lerpTime;
            obj.transform.position = Vector3.Lerp(startPosition, endPosition, perc);
        }
        callback(true);

        yield return null;
    }

    public virtual IEnumerator LerpWithCallback(System.Action callback, GameObject obj, Vector3 startPosition, Vector3 endPosition, float lerpTime, float singleWait = 0.005f)
    {
        float deltaLerpTime = 0f;
        float perc;

        while (deltaLerpTime < lerpTime)
        {
            if (ConditionActionsScript.StopAnimation)
                yield break;


            yield return null;
            if (ConditionActionsScript.GameplayEnabled)
            {
                deltaLerpTime += Time.fixedDeltaTime;
                if (deltaLerpTime > lerpTime)
                {
                    deltaLerpTime = lerpTime;
                }
            }
            perc = deltaLerpTime / lerpTime;



            obj.transform.position = Vector3.Lerp(startPosition, endPosition, perc);
        }
        callback();
        yield return null;
    }

    public virtual IEnumerator LerpWithCallback(System.Action<bool> callback, Vector3 startPosition, Vector3 endPosition, float startScale, float endScale, float lerpTime, float singleWait = 0.005f)
    {
        float deltaLerpTime = 0f;
        float perc;
        Vector3 vStart = new Vector3(startScale, startScale, startScale);
        Vector3 vEnd = new Vector3(endScale, endScale, endScale);

        while (deltaLerpTime < lerpTime)
        {
            if (ConditionActionsScript.StopAnimation)
                yield break;

            yield return null;
            if (ConditionActionsScript.GameplayEnabled)
            {
                deltaLerpTime += Time.fixedDeltaTime;
                if (deltaLerpTime > lerpTime)
                {
                    deltaLerpTime = lerpTime;
                }
            }
            perc = deltaLerpTime / lerpTime;



            transform.position = Vector3.Lerp(startPosition, endPosition, perc);
            transform.localScale = Vector3.Lerp(vStart, vEnd, perc);
        }
        callback(true);

        yield return null;
    }

    public virtual IEnumerator LerpWithCallback(System.Action callback, Vector3 startPosition, Vector3 endPosition, float startScale, float endScale, float lerpTime, float singleWait = 0.005f)
    {
        float deltaLerpTime = 0f;
        float perc;
        Vector3 vStart = new Vector3(startScale, startScale, startScale);
        Vector3 vEnd = new Vector3(endScale, endScale, endScale);

        while (deltaLerpTime < lerpTime)
        {
            if (ConditionActionsScript.StopAnimation)
                yield break;


            yield return null;
            if (ConditionActionsScript.GameplayEnabled)
            {
                deltaLerpTime += Time.fixedDeltaTime;
                if (deltaLerpTime > lerpTime)
                {
                    deltaLerpTime = lerpTime;
                }
            }
            perc = deltaLerpTime / lerpTime;



            transform.position = Vector3.Lerp(startPosition, endPosition, perc);
            transform.localScale = Vector3.Lerp(vStart, vEnd, perc);
        }
        callback();

        yield return null;
    }



    public virtual IEnumerator LerpWithCallback(System.Action<bool> callback, Vector3 startPosition, Vector3 endPosition, Vector3 startScale, Vector3 endScale, Vector3 rotate, float rotateSpeed, float lerpTime, float singleWait = 0.005f)
    {
        float deltaLerpTime = 0f;
        float perc;
        Vector3 vStart = startScale;
        Vector3 vEnd = endScale;

        while (deltaLerpTime < lerpTime)
        {
            if (ConditionActionsScript.StopAnimation)
                yield break;


            yield return null;
            if (ConditionActionsScript.GameplayEnabled)
            {
                deltaLerpTime += Time.fixedDeltaTime;
                if (deltaLerpTime > lerpTime)
                {
                    deltaLerpTime = lerpTime;
                }
            }
            perc = deltaLerpTime / lerpTime;
            transform.Rotate(rotate * rotateSpeed * Time.fixedDeltaTime);




            transform.position = Vector3.Lerp(startPosition, endPosition, perc);
            transform.localScale = Vector3.Lerp(vStart, vEnd, perc);
        }
        callback(true);
        yield return null;
    }

    public virtual IEnumerator LerpWithCallback(System.Action<bool> callback, LerpAnimationPackage x)
    {
        if (x.obj != null)
        {
            float deltaLerpTime = 0f;
            float perc;
            Vector3 vStart = new Vector3(x.startScale, x.startScale, x.startScale);
            Vector3 vEnd = new Vector3(x.endScale, x.endScale, x.endScale);

            while (deltaLerpTime < x.lerpTime)
            {
                if (ConditionActionsScript.StopAnimation)
                    yield break;


                yield return new WaitForSeconds(x.singleWait);
                if (x.obj != null)
                {
                    if (ConditionActionsScript.GameplayEnabled)
                    {
                        deltaLerpTime += Time.fixedDeltaTime;
                        if (deltaLerpTime > x.lerpTime)
                        {
                            deltaLerpTime = x.lerpTime;
                        }
                    }
                    perc = deltaLerpTime / x.lerpTime;
                    x.obj.transform.Rotate(x.rotate * x.rotateSpeed * Time.fixedDeltaTime);
                    x.obj.transform.position = Vector3.Lerp(x.startPosition, x.endPosition, perc);
                    x.obj.transform.localScale = Vector3.Lerp(vStart, vEnd, perc);
                }
            }
            if (x.action != null)
                x.action();
        }
        callback(true);
        yield return null;
    }

    public virtual bool AnimateObject(List<LerpAnimationPackage> singleMove, int i = 0)
    {
        bool w = false;

        Func<bool> temp = () =>
        {
            return AnimateObject(singleMove, i);
        };

        StartCoroutine(
            LerpWithCallback((myReturnValue) =>
            {
                if (myReturnValue)
                {
                    i++;
                    if (i < singleMove.Count)
                    {
                        w = temp();
                    }

                }
            }, singleMove[i])
        );
        return true;
    }

    public virtual bool AnimateObject(List<LerpAnimationPackage> singleMove, System.Action act, int i = 0)
    {
        bool w = false;

        Func<bool> temp = () =>
        {
            return AnimateObject(singleMove, act, i);
        };

        StartCoroutine(
            LerpWithCallback((myReturnValue) =>
            {
                if (myReturnValue)
                {
                    i++;
                    if (i < singleMove.Count)
                    {
                        w = temp();
                        //this.gameObject.SetActive(true);
                    }
                    else
                    {
                        act();
                        //this.gameObject.SetActive(false);
                    }
                }

            }, singleMove[i])
        );

        return true;
    }
}