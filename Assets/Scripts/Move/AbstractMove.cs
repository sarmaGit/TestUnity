using System;
using Entity;
using UnityEngine;
using UnityEngine.UI;

namespace Move
{
    public abstract class AbstractMove : MonoBehaviour
    {
        public abstract void Move();

        protected Button button;

        private void Start()
        {
            button = gameObject.GetComponentInParent<Button>();
        }

        protected bool CheckCollision(Vector3 playerPosition, Vector3 direction)
        {
            RaycastHit hit;
            Physics.Raycast(playerPosition, direction, out hit, 1);
            Debug.DrawRay(playerPosition, direction,Color.magenta);

            if (hit.collider == null)
            {
                return false;
            }

            if (!hit.collider.gameObject.GetComponent<Encounter>())
            {
                Debug.Log("HIT WRONG - {0}", hit.collider.gameObject);
                return false;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log(hit.point);
                Destroy(hit.collider.gameObject);
            }

            return true;
        }
    }
}