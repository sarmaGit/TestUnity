using System;
using UnityEngine;

namespace Move
{
    public class MoveUp : AbstractMove
    {
        public Transform playerTransform;

        private Vector3 direction = Vector3.up;

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