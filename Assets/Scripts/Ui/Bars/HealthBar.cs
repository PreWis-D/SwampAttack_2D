﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : Bar
{
    private Player _player;

    private void OnEnable()
    {
        _player.HealthChanged += OnValueChanged;
        Slider.value = 1;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChanged;
    }

    public void Init(Player player)
    {
        _player = player;
        
    }
}