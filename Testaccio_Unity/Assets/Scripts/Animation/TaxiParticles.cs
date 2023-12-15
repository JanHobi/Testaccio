using System;
using UnityEngine;

namespace Animation
{
    public class TaxiParticles : MonoBehaviour
    {
        [SerializeField] private ParticleSystem smokeSystem;
        [SerializeField] private ParticleSystem bloodSystem;
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            var forceOverLifetimeModule = smokeSystem.forceOverLifetime;
            forceOverLifetimeModule.y = _animator.speed * 2f;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Fisher") || other.CompareTag("Passenger"))
            {
                Debug.Log("Collision");
                bloodSystem.Play();
            }
        }
    }
}
