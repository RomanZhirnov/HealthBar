using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Health _health;
    [SerializeField] private float _rateOfChange = 0.2f;

    private Coroutine _coroutine;
    private float _displedHealth;
    private float _targetHealth;



    private void OnEnable()
    {
        _health.OnHealthChange += ShowHealth;
    }

    private void OnDisable()
    {
        _health.OnHealthChange -= ShowHealth;
    }

    private void Start()
    {
        _displedHealth = _health.CurrentHealth;
        _healthSlider.minValue = _health.MinHealth;
        _healthSlider.maxValue = _health.MaxHealth;
        _healthSlider.value = _displedHealth;
    }

    private void ShowHealth()
    {
        _targetHealth = _health.CurrentHealth;

        if (_coroutine != null)
        {
            StopCoroutine(Smooth—hange());
        }

        _coroutine = StartCoroutine(Smooth—hange());
    }

    private void ChangeText(float health)
    {
        int IntHealth = (int)health;
        _text.text = IntHealth.ToString();
    }

    private IEnumerator Smooth—hange()
    {
        while (_displedHealth != _targetHealth)
        {
            _displedHealth = Mathf.MoveTowards(_displedHealth, _targetHealth, _rateOfChange);
            _healthSlider.value = _displedHealth;
            _fill.color = _gradient.Evaluate(_healthSlider.normalizedValue);
            ChangeText(_displedHealth);
            yield return null;
        }
    }
}
