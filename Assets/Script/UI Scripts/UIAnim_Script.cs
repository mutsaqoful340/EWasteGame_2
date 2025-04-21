using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Anim_Manager : MonoBehaviour
    {
        public GameObject popPCB, popMenuButtons;
        private Animator animator1, animator2;
        //animator1 > popup PCB
        //animator2 > popup MenuButtons

        private void Start()
        {
            animator1 = popPCB.GetComponent<Animator>();
            animator2 = popMenuButtons.GetComponent<Animator>();
        }

        public void ShowPopup()
        {
            animator1.Play("PCB_IN");
        animator2.Play("BTN_IN");
        }

        public void HidePopup()
        {
            animator1.Play("PCB_OUT");
        animator2.Play("BTN_OUT");
        }
    }
