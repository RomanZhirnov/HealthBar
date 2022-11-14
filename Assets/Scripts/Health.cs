using UnityEngine;
using System;
using System.Collections;


public class Health : MonoBehaviour
{
    [SerializeField] private float _minHealth = 0f;
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _currentHealth = 50f;
    [SerializeField] private float _rateOfChange = 0.01f;

    private float _targetHealth;

    public float MaxHealth => _maxHealth;
    public float MinHealth => _minHealth;
    public float CurrentHealth => _currentHealth;

    private void Start()
    {
        _targetHealth = _currentHealth;
        StartCoroutine(SmoothÑhange());
    }

    private void OnValidate()
    {
        if (_minHealth >= _maxHealth)
        {
            _minHealth = _maxHealth - 1;
        }

        if (_currentHealth < _minHealth || _currentHealth > _maxHealth)
        {
            _currentHealth = (_maxHealth - _minHealth) / 2;
        }
    }
    public void Heal(float heal)
    {
        _targetHealth += heal;

        if (_targetHealth > _maxHealth)
        {
            _targetHealth = _maxHealth;
        }
    }

    public void Damage(float damage)
    {
        _targetHealth -= damage;

        if (_targetHealth < _minHealth)
        {
            _targetHealth = _minHealth;
        }
    }

    private IEnumerator SmoothÑhange()
    {
        while (true)
        {
            _currentHealth = Mathf.MoveTowards(_currentHealth, _targetHealth, _rateOfChange);
            yield return null;
        }
    }
}
