using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DynamicJoystick : Joystick
{
    public float MoveThreshold { get { return moveThreshold; } set { moveThreshold = Mathf.Abs(value); } }

    [SerializeField] private float moveThreshold = 1;

    private Vector3 originPos;

    private Animator anim = null;

    private bool isTouch = false;

    protected override void Start()
    {
        MoveThreshold = moveThreshold;
        base.Start();

        anim = playerMove.GetComponent<Animator>();

        originPos = background.anchoredPosition;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);

        isTouch = true;
        playerMove.IsMove = isTouch;

        anim.SetBool("Walk", true);

        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        background.anchoredPosition = originPos;

        playerMove.MoveDir = Vector3.zero;
        dir = Vector3.zero;

        isTouch = false;
        playerMove.IsMove = isTouch;

        anim.SetBool("Walk", false);

        base.OnPointerUp(eventData);
    }

    protected override void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
    {
        base.HandleInput(magnitude, normalised, radius, cam);
    }
}