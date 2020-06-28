using UnityEngine;
using Kandooz.Burger;


namespace Kandooz.KVR
{
    public class WrinkleMapper : MonoBehaviour
    {

        public SkinnedMeshRenderer hand;
        Material handMaterial;
        HandAnimationController handAnimationContorller;
        void Start()
        {
            handMaterial = hand.material;
            handAnimationContorller = this.GetComponent<HandAnimationController>();
        }

        void Update()
        {
            handMaterial.SetFloat("_FingerThree", handAnimationContorller[FingerName.Middle]);

            handMaterial.SetFloat("_FingerIndex", handAnimationContorller[FingerName.Index]);
            handMaterial.SetFloat("_FingerThumb", handAnimationContorller[FingerName.Thumb]);

        }
    }
}