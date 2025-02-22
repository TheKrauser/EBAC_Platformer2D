using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOPlayerStats : ScriptableObject
{
    public float speed;
    public float speedRun;
    public float jumpForce;

    public ParticleSystem jumpParticle;

    public Vector2 friction;
}
