using UnityEngine;
using UnityEngine.UI;

public class CharacterHealthBar : MonoBehaviour
{
    [SerializeField] private Image _HealthChanger;

    private Character _character;

    private float _timeEnemyHealthBarChange = 4f;

    private void Awake()
    {
        _character = GetComponentInChildren<Character>();
        _character.HealthChanged += OnHealthChanged;
    }

    private void OnDestroy()
    {
        _character.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float percent, int currentHealth, int maxHealth)
    {
        if (_HealthChanger.fillAmount != percent)
        {
            _HealthChanger.fillAmount = Mathf.Lerp(_HealthChanger.fillAmount, percent, _timeEnemyHealthBarChange * Time.deltaTime);
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
