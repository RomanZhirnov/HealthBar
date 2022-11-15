using UnityEngine;
using System;
using System.Collections;


public class Health : MonoBehaviour
{
    [SerializeField] private float _minHealth = 0f;
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _currentHealth = 50f;

    public event Action OnHealthChange;
    public float MaxHealth => _maxHealth;
    public float MinHealth => _minHealth;
    public float CurrentHealth => _currentHealth;

    private void OnValidate()
    {
        if (_minHealth >= _maxHealth)
        {
            _minHealth = _maxHealth - 1;
        }

        _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);
    }
    public void Heal(float heal)
    {
        _currentHealth += heal;
        _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);
        OnHealthChange?.Invoke();
    }

    public void Damage(float damage)
    {
        _currentHealth -= damage;
        _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);
        OnHealthChange?.Invoke();
    }


}
