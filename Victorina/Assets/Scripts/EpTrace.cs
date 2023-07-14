using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class EpTrace : MonoBehaviour
    {
        [Header("Set in dinamically")]
        private Image image;

        private void OnEnable()
        {
            PlayerEventManager.OnUpdatePoints += ExpBarUpdate;
        }


        // Use this for initialization
        void Start()
        {
            image = GetComponent<Image>();
        }

        void ExpBarUpdate(float totalPoints)
        {
            image.fillAmount = totalPoints / 100;
        }

    }
}