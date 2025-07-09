using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LifeController : MonoBehaviour
{
    [SerializeField] private Image _healthBarSprite;
    [SerializeField] private Gradient _gradient;

    public void UpdateHealthBar(int hp, int maxHp)
    {
        _healthBarSprite.fillAmount = (float) hp / maxHp;
        _healthBarSprite.color = _gradient.Evaluate(_healthBarSprite.fillAmount);
    }
}
