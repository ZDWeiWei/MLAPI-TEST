using System.Collections;
using System.Collections.Generic;
using SoFunny.UIGameProto;
using UnityEngine;

namespace SoFunny.View {
    public class PlayerOperrateViewFeature : IFeature {
        public void Init() {
            GameProtoManager.AddListener(GameProtoDoc_Character.OpenCharacterUI.ID, OnOpenCharacterUICallBack);
        }
        public void Clear() {
            GameProtoManager.RemoveListener(GameProtoDoc_Character.OpenCharacterUI.ID, OnOpenCharacterUICallBack);
        }

        private void OnOpenCharacterUICallBack(IGameProtoDoc message) {
            ViewManager.Instance.Open<PlayerOperateView>(null);
        }
    }
}
