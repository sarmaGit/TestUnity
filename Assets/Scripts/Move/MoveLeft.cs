using UnityEngine;

namespace Move
{
    public class MoveLeft : AbstractMove
    {
        public Transform playerTransform;

        private Vector3 direction = Vector3.left;

        public override void Move()
        {
            Debug.Log(playerTransform.position);
            playerTransform.position += direction;
            Debug.Log(playerTransform.position);
        }

        private void Update()
        {
            button.interactable = CheckCollision(playerTransform.position, direction);
        }
    }
}