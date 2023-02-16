using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Step_Particles : MonoBehaviour
{
    [SerializeField] private ParticleSystem _stepParticle;

    public void PlayerStepParticles()
    {
        _stepParticle.Play();
    }
}
