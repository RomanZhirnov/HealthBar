using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class ShowHealth : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Health _health;

    private void Start()
    {
        _healthSlider.maxValue = _health.MaxHealth;
        _healthSlider.minValue = _health.MinHealth;
        StartCoroutine(MoveHealth());
    }

    private void ChangeText(float health)
    {
        int IntHealth = (int)health;
        _text.text = IntHealth.ToString();
    }

    private IEnumerator MoveHealth()
    {
        while (true)
        {
            _healthSlider.value = _health.CurrentHealth;
            _fill.color = _gradient.Evaluate(_healthSlider.normalizedValue);
            ChangeText(_health.CurrentHealth);
            yield return null;
        }
    }
}
