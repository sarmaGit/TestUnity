using System;
using UnityEngine;

namespace Move
{
    public class MoveRight : AbstractMove
    {
        public Transform playerTransform;

        private Vector3 direction = Vector3.right;

        public override void Move()
        {
            playerTransform.position += Vector3.right;
        }

        private void Update()
        {
            button.interactable = CheckCollision(playerTransform.position, direction);
        }
    }
}