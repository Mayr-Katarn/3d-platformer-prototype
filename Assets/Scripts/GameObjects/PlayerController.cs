using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private GameObject _model;
    private Rigidbody _body;
    private Animator _animator;

    void Start()
    {
        //_body = _model.GetComponent<Rigidbody>();
        _animator = _model.GetComponent<Animator>();
    }

    void Update()
    {
        InputCatcher();
    }

    private void InputCatcher()
    {
        float moveDirection = Input.GetAxis("Horizontal");
        float aimHeight = Input.GetAxis("Vertical");
        float atack = Input.GetAxis("Fire1");
        Vector3 translation = moveDirection > 0 ? Vector3.right : Vector3.left;
        transform.Translate(_moveSpeed * moveDirection * Time.deltaTime * translation);

        //Debug.Log(aimHeight);
        UpdateMovementAnimation(moveDirection);
        //UpdateAimAnimation(aimHeight);
        Fire(atack);

        SetBodyOrientation(moveDirection);
    }

    private void SetBodyOrientation(float direction)
    {
        float x = transform.localEulerAngles.x;
        float y = transform.localEulerAngles.y;
        float z = transform.localEulerAngles.z;

        if (direction > 0 && y > 0)
        {
            transform.localEulerAngles = new Vector3(x, 0, z);
        }
        else if (direction < 0 && y < 180)
        {
            transform.localEulerAngles = new Vector3(x, 180, z);
        }
    }


    private void UpdateMovementAnimation(float moveDirection)
    {
        _animator.SetFloat("moveSpeed", Mathf.Abs(moveDirection));
    }

    private void UpdateAimAnimation(float aimHeight)
    {
        _animator.SetFloat("aimHeight", 1 + aimHeight);
    }

    private void Fire(float atack)
    {
        bool isAtacking = atack == 1;
        _animator.SetBool("isAtacking", isAtacking);
        //_animator.SetLayerWeight(_animator.GetLayerIndex("Aiming"), atack);
    }
}
