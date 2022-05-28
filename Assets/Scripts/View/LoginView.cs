using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoFunny.UI;
using SoFunny.UIGameProto;

namespace SoFunny.View {
    public class LoginView : ViewBase {
        protected override void RegisterUIEvent(UI.UIBase ui) {
            ui.Register(UILogin.Event_OnClose, OnCloseCallBack);
            ui.Register<bool>(UILogin.Event_OnPlay, OnPlayCallBack);
        }

        private void OnCloseCallBack() {
            Close();
        }

        private void OnPlayCallBack(bool isDown) {
            GameProtoManager.Send(new GameProtoDoc_StartGame.EnterGame {});
            Close();
        }
    }
}
