 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ULProtoype
{
    public class KeyBoardInput : MonoBehaviour
    {
        private bool isGrounded;
        public Transform feetPos;
        public float checkRadius;

        void Update()
        {
            if (Input.GetKey(KeyCode.D))
            {
                VirtualInputManager.Instance.MoveRight = true;
            }
            else
            {
                VirtualInputManager.Instance.MoveRight = false;
            }
            if (Input.GetKey(KeyCode.A))
            {
                VirtualInputManager.Instance.MoveLeft = true;
            }
            else
            {
                VirtualInputManager.Instance.MoveLeft = false;
            }
        }
    }

}