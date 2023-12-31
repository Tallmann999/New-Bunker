using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarChange : MonoBehaviour
{
    [SerializeField] private Slider _healthBarSlider;
    [SerializeField] private Player _player;

    private Coroutine _activeCoroutine = null;
    private float _stepSize = 0.5f;
    private float _maxHealhValue;

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChange;
    }

    private void Start()
    {
        _maxHealhValue = _player.CurrentHealth;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChange;
    }

    private void OnHealthChange(int health)
    {
        if (_activeCoroutine != null)
        {
            StopCoroutine(_activeCoroutine);
        }

        _activeCoroutine = StartCoroutine(ChangeValue(health));
    }

    private IEnumerator ChangeValue(float currentHealthValue)
    {
        float healthPercent = currentHealthValue / _maxHealhValue;

        while (_healthBarSlider.value != healthPercent)
        {
            _healthBarSlider.value = Mathf.MoveTowards
                (_healthBarSlider.value, healthPercent, _stepSize * Time.deltaTime);
            yield return null;
        }
    }
}
