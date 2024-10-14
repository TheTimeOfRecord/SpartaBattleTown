using System;
using UnityEngine;

public class TopDownAimRotaion : MonoBehaviour
{
    [SerializeField] private SpriteRenderer armRenderer;
    [SerializeField] private Transform armPivot;
    [SerializeField] private SpriteRenderer characterRenderer;
    [SerializeField] private RectTransform characterPivot;

    private TopDownController controller;

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
    }
    private void Start()
    {
        controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 direction)
    {
        RotateArm(direction);
    }

    private void RotateArm(Vector2 direction)
    {
        float rotArmZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool flip = Mathf.Abs(rotArmZ) > 90f;
        
        Vector3 scale = characterPivot.localScale;
        scale.x = flip ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
        characterPivot.localScale = scale;

        armPivot.rotation = Quaternion.Euler(0, 0, rotArmZ);
    }
}