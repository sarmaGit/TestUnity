using Entity.Encounter;
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

            if (!hit.collider.gameObject.GetComponent<AbstractEncounter>())
            {
                return false;
            }

            return true;
        }
    }
}