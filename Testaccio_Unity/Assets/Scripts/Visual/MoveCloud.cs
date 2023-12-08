using System;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

namespace Visual
{
    public class MoveCloud : MonoBehaviour
    {
        private float moveSpeed;
        private List<Transform> childSpheres = new List<Transform>();

        public void SetMoveSpeed(float speed)
        {
            moveSpeed = speed;
            
            
            // Clear list to avoid duplicates
            childSpheres.Clear();

            // Get all child Spheres of the cloud
            foreach (Transform child in transform)
            {
                if (child == null) return;
                childSpheres.Add(child);
            }

            MoveSpheres();
        }

        private void MoveSpheres()
        {
            foreach (var sphere in childSpheres)
            {
                if (sphere.gameObject == null || sphere == null) return;
                sphere.DOShakePosition(25, 0.5f, 0, 80, false, true, ShakeRandomnessMode.Harmonic)
                    .SetLoops(-1, LoopType.Yoyo);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.gameObject == null) return;
            // Move the cloud in the negative X direction
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

       
    }
}
