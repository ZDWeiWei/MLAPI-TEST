using System;
using System.Collections;
using System.Collections.Generic;
using SoFunny.Util;
using UnityEngine;

namespace SoFunny.UI {
    public class UILogin : UIBase {
        public const int Event_OnClose = 1;
        public const int Event_OnPlay = 2;
        
        [SerializeField]
        private BtnComponent BtnPlay;

        override protected void OnInit() {
            BtnPlay.AddOnClick(OnBtnPlayClickCallBack);
        }

        override protected void OnClear() {
            BtnPlay.Clear();
        }

        public void OnBtnPlayClickCallBack(bool isDown) {
            Dispatcher(Event_OnPlay, isDown);
        }
    }
}