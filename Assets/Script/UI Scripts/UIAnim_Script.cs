using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Anim_Manager : MonoBehaviour
    {
        public GameObject popUp;
        private Animator animator1;
        //animator1> popup;

        private void Start()
        {
            animator1 = popUp.GetComponent<Animator>();
        }

        public void ShowPopup()
        {
            animator1.Play("PCB_IN");
        }

        public void HidePopup()
        {
            animator1.Play("PCB_OUT");
        }
    }
