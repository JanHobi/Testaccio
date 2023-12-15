using System;
using UnityEngine;

namespace Animation
{
    public class ShipParticles : MonoBehaviour
    {
        [SerializeField] private ParticleSystem shipSmokeSystem;
       [SerializeField] private ParticleSystem bloodSystem;
        private Animator _animator;
        private bool isMoving = false;


        private void Start()
        {
            shipSmokeSystem = GetComponentInChildren<ParticleSystem>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            var forceOverLifetimeModule = shipSmokeSystem.forceOverLifetime;
            forceOverLifetimeModule.y = _animator.speed * 2f;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Shark"))
            {
                bloodSystem.Play();
            }
        }
    }
}
