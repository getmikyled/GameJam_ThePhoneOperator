using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CableJack : InteractableObject
{
    public Camera mainCamera;
    Vector3 worldPosition;

    bool isMoving = false;

    ///-///////////////////////////////////////////////////
    ///
    private void Start()
    {
        mainCamera = Camera.main;
    }

    ///-///////////////////////////////////////////////////
    ///
    private void Update()
    {
        UpdatePosition();
    }

    ///-///////////////////////////////////////////////////
    ///
    public override void OnPointerClick(PointerEventData eventData)
    {
        isMoving = !isMoving;
    }

    ///-///////////////////////////////////////////////////
    ///
    private void UpdatePosition()
    {
        if (isMoving)
        {
            worldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10));

            transform.position = worldPosition;
        }
    }
}
