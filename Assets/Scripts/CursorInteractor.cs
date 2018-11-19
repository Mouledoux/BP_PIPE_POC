using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CursorInteraction
{
    public enum eInteractionType
    {
        DEFAULT,
        INSPECT,
        PICKUP,
        HOLD,
        DISABLED,
        OTHER,
        ERR,
    }

    [RequireComponent(typeof(Camera))]
    public class CursorInteractor : MonoBehaviour
    {
        private Camera thisCamera;

        [SerializeField]
        private UnityEngine.UI.Image playerRetical;
        

        [SerializeField]
        private Sprite
            cursorDefault,
            cursorInteract,
            cursorInspect,
            cursorPickUp,
            cursorHold,
            cursorDisabled,
            cursorOther;
    


        private void Start()
        {
            thisCamera = GetComponent<Camera>();
        }

        private void Update()
        {

        }

        private void FixedUpdate()
        {
            RaycastHit rayHit;

            if (Physics.Raycast(transform.position, transform.forward, out rayHit))
            {
                InteractableObject io = rayHit.transform.GetComponent<InteractableObject>();

                if (io != null)
                {
                    return;
                }
            }
            
        }


        //private void SetCursorTo(eInteractionType intType)
        //{

        //    SetCursorAlpha(1f);

        //    switch(intType)
        //    {
        //        case eInteractionType.DEFAULT:
        //            playerRetical.sprite = cursorDefault;
        //            break;

        //        case eInteractionType.INSPECT:
        //            playerRetical.sprite = cursorInspect;
        //            break;

        //        case eInteractionType.PICKUP:
        //            playerRetical.sprite = cursorPickUp;
        //            break;

        //        case eInteractionType.HOLD:
        //            playerRetical.sprite = cursorHold;
        //            break;

        //        case eInteractionType.DISABLED:
        //            playerRetical.sprite = cursorDisabled;
        //            break;

        //        case eInteractionType.OTHER:
        //            playerRetical.sprite = cursorOther;
        //            break;

        //        default:
        //            SetCursorAlpha(0f);
        //            playerRetical.sprite = null;
        //            break;
        //    }
        //}

        private void SetCursorAlpha(float alpha)
        {
            Color tcolor = playerRetical.color;
            tcolor.a = alpha;
            playerRetical.color = tcolor;
        }


        public static Texture2D textureFromSprite(Sprite sprite)
        {
            if (sprite.rect.width != sprite.texture.width)
            {
                Texture2D newText = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
                Color[] newColors = sprite.texture.GetPixels((int)sprite.textureRect.x,
                                                             (int)sprite.textureRect.y,
                                                             (int)sprite.textureRect.width,
                                                             (int)sprite.textureRect.height);
                newText.SetPixels(newColors);
                newText.Apply();
                return newText;
            }
            else
                return sprite.texture;
        }
    }
}