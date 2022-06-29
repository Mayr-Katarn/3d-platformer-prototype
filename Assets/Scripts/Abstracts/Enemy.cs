using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _maxMoveSpeed;
    [SerializeField] private float _xpCost;

    private float _health;
    private float _moveSpeed;
    private string _lookSide;

}
