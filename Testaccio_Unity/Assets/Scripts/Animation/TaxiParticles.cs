using UnityEngine;

namespace Animation
{
    public class TaxiParticles : MonoBehaviour
    {
        private ParticleSystem shipSmokeSystem;
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
    }
}
