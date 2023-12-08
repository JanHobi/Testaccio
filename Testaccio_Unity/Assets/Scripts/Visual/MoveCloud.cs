using UnityEngine;

namespace Visual
{
    public class MoveCloud : MonoBehaviour
    {
        private float moveSpeed;

        public void SetMoveSpeed(float speed)
        {
            moveSpeed = speed;
        }

        // Update is called once per frame
        void Update()
        {
            // Move the cloud in the negative X direction
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

       
    }
}
