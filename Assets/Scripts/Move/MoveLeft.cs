using UnityEngine;

namespace Move
{
    public class MoveLeft : AbstractMove
    {
        public Transform playerTransform;

        private Vector3 direction = Vector3.left;

        public override void Move()
        {
            playerTransform.position += direction;
        }

        private void Update()
        {
            button.interactable = CheckCollision(playerTransform.position, direction);
        }
    }
}