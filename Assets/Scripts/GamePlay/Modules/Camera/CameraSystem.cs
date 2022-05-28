using System.Collections;
using System.Collections.Generic;
using SoFunny.Asset;
using SoFunny.UIGameProto;
using UnityEngine;

namespace SoFunny.GamePlay {
    public partial class CameraSystem : SystemBase {
        public CameraData Data;
        public CameraEntity Entity;

        protected override void OnInit() {
            base.OnInit();
            Data = new CameraData();
            Entity = AddEntity<CameraEntity>();
            InitComponent();
        }

        private void InitComponent() {
            AddComponent<CameraMove>();
            AddComponent<CameraRota>();
        }

        protected override void OnClear() {
            base.OnClear();
            Data = null;
        }
    }
}