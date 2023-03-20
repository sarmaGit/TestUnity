using System;
using UnityEngine;

namespace Move
{
    public class MoveDown : AbstractMove
    {
        public Transform playerTransform;

        private Vector3 direction = Vector3.down;

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