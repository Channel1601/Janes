using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Cooldown
{
    [SerializeField] private float cooldownTime;
    private float _nextSwitchTime;

    public bool IsCoolingDown => Time.time < _nextSwitchTime;
    public void StartCooldown() => _nextSwitchTime = Time.time + cooldownTime;
}
