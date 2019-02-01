using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    public class FlashLightUiScrollbar : MonoBehaviour
    {
        private Scrollbar _scrollbar;

        private void Start()
        {
            _scrollbar = GetComponent<Scrollbar>();
        }

        public float Scrollbar
        {
            set { _scrollbar.size = value; }
        }

        public void SetActive(bool value)
        {
            _scrollbar.gameObject.SetActive(value);
        }
    }
}