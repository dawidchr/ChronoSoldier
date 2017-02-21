using UnityEngine;
using System.Collections;

public class TouchConditions : MonoBehaviour
{
    public static Vector3 OnScreenPosition()
    {
#if !UNITY_EDITOR
        if (Input.touchCount > 0)
        {
            return Input.GetTouch(0).position;
        }
        else
            return new Vector3();
#else
        return Input.mousePosition;
#endif
    }

    public static Vector3 MousePosition()
    {
        return Camera.main.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
    }

    public static bool CheckIfInput()
    {
        DeviceType deviceType = SystemInfo.deviceType;
        if (deviceType == DeviceType.Handheld)
        {
            if (Input.touchCount > 0) return true;
            else return false;
        }
        else
        {
            if (Input.anyKey) return true;
            return false;
        }
    }

    public static bool CheckIfDown()
    {
        DeviceType deviceType = SystemInfo.deviceType;
        if (deviceType == DeviceType.Handheld)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began) return true;
            else return false;
        }
        else
        {
            if (Input.GetMouseButtonDown(0)) return true;
            return false;
        }
    }

    public static bool CheckIfMove()
    {
        DeviceType deviceType = SystemInfo.deviceType;
        if (deviceType == DeviceType.Handheld)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved) return true;
            else return false;
        }
        else
        {
            if (Input.GetMouseButton(0)) return true;
            return false;
        }
    }

    public static bool CheckIfUp()
    {
        DeviceType deviceType = SystemInfo.deviceType;
        if (deviceType == DeviceType.Handheld)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended) return true;
            else return false;
        }
        else
        {
            if (Input.GetMouseButtonUp(0)) return true;
            else return false;
        }
    }

    public static bool IsMoreThanOneFinger()
    {
        if (Input.touchCount > 1) return true;
        else return false;
    }
}
