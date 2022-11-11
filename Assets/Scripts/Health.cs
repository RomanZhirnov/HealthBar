using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Health : MonoBehaviour
{
    private float _currentHealth;
    private float _maxHealth;
    private float _minHealth;
    private float _damage;
    private float _treat;
    private Coroutine _moveHealth;

    [SerializeField] private Slider _healthSlider;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;
    [SerializeField] private float _changingSpeed = 0.1f;

    private void Start()
    {
        _currentHealth = 50f;
        _maxHealth = 100f;
        _minHealth = 0f;
        _damage = 10f;
        _treat = 10f;

        _healthSlider.maxValue = _maxHealth;
        _healthSlider.minValue = _minHealth;
        _healthSlider.value = _currentHealth;

        _moveHealth = StartCoroutine(MoveBar(_maxHealth));
    }

    public void IncreaseHealth()
    {
        float targetHealt = _currentHealth + _treat;

        if (targetHealt > _maxHealth)
        {
            targetHealt = _maxHealth;
        }

        if (_moveHealth != null)
        {
             StopCoroutine(_moveHealth);
        }

        _moveHealth = StartCoroutine(MoveBar(targetHealt));
    }

    public void ReduceHealth()
    {
        float targetHealt = _currentHealth - _damage;

        if (targetHealt < _minHealth)
        {
            targetHealt = _minHealth;
        }

        if (_moveHealth != null && targetHealt != _currentHealth)
        {
            StopCoroutine(_moveHealth);
        }

        _moveHealth = StartCoroutine(MoveBar(targetHealt));
    }

    private void ChangeText(float health)
    {
        int IntHealth = (int)health;
        _text.text = IntHealth.ToString();
    }

    private IEnumerator MoveBar(float targetHealth)
    {
        while (_currentHealth != targetHealth)
        {
            _currentHealth = Mathf.MoveTowards(_currentHealth, targetHealth, _changingSpeed);
            _healthSlider.value = _currentHealth;
            _fill.color = _gradient.Evaluate(_healthSlider.normalizedValue);
            ChangeText(_currentHealth);
            yield return null;
        }
    }
}
