using System;
using System.Collections;
using UnityEngine;
namespace Kandooz.Burger
{
    public class Watch : MonoBehaviour
    {
        public RectTransform secondHand;
        public RectTransform minutesHand;
        public RectTransform hourHand;

        private void Start()
        {
            StartCoroutine(UpdateTime());
        }

        private void UpdateCurrentTime()
        {
            DateTime currentTime = DateTime.Now;

            float seconds = (currentTime.Second / 60f) * 360f;
            float minutes = (currentTime.Minute / 60f) * 360f;
            float hours = (currentTime.Hour / 12f) * 360f;
            secondHand.localRotation = Quaternion.Euler(new Vector3(0, 0, seconds));
            minutesHand.localRotation = Quaternion.Euler(new Vector3(0, 0, minutes));
            hourHand.localRotation = Quaternion.Euler(new Vector3(0, 0, hours));
        }

        IEnumerator UpdateTime()
        {
            yield return new WaitForSeconds(1);
            UpdateCurrentTime();
            StartCoroutine(UpdateTime());
        }
    }
}