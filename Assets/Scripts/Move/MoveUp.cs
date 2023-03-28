using System;
using UnityEngine;

namespace Move
{
    public class MoveUp : AbstractMove
    {
        private Transform _playerTransform;

        private Vector3 direction = Vector3.up;

        public override void Move()
        {
            _playerTransform.position += direction;
        }

        public override void SetPlayerTransform(Transform transform)
        {
            _playerTransform = transform;
        }

        private void Update()
        {
            button.interactable = CheckCollision(_playerTransform.position, direction);
        }
    }
}