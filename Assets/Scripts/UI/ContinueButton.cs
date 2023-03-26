using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ContinueButton : MonoBehaviour
    {
        private Button _button;

        public void Start()
        {
            _button = gameObject.GetComponent<Button>();
            _button.interactable = false;
        }

        public void SetInteractable()
        {
            _button.interactable = true;
        }
    }
}