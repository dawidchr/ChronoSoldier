using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{

    GraphicRaycaster raycaster;
    List<RaycastResult> results;
    PointerEventData ped;

    protected Action OnActionArea;

    void Update()
    {
        TouchConditionsAndActions();
    }

    public void TouchedInActionArea()
    {
        ThrowGraphicRay();

        if (!CheckIfTouchOnAnyButton())
            TouchOnActionArea();
    }

    private void TouchOnActionArea()
    {
        OnActionArea();
    }


    private void TouchConditionsAndActions()
    {
        if (TouchConditions.CheckIfDown())
        {
            TouchedInActionArea();
        }
    }

    void ThrowGraphicRay()
    {
        ped.position = Input.mousePosition;
        raycaster.Raycast(ped, results);
    }

    bool CheckIfTouchOnAnyButton()
    {
        if (results.Count > 0)
            return false;
        else
            return true;
    }
}
