﻿using System.Collections;
using System.Collections.Generic;
using SoFunny.UIGameProto;
using SoFunny.Util;
using UnityEngine;

namespace SoFunny.GamePlay {
    public class CharacterCamera : SystemBase.IComponent {
        private CharacterSystem system;
        private Vector3 scale;
        
        public void Init(SystemBase systemBase) {
            system = (CharacterSystem)systemBase;
            ATUpdateRegister.AddUpdate(OnUpdate);
        }
        
        public void Clear() {
            ATUpdateRegister.RemoveUpdate(OnUpdate);
        }

        public void OnUpdate(float delta) {
            if (system.Data.IsLocalRole == false || system.Entity.IsLoadEntityObj == false) {
                return;
            }
            var rootPoint = system.Entity.GetPoint(CharacterEntity.Root);
            GameProtoManager.Send(new GameProtoDoc_Camera.SetPoint {
                point = rootPoint
            });
            var rootRota = system.Entity.GetRota(CharacterEntity.Root);
            GameProtoManager.Send(new GameProtoDoc_Camera.SetRotation {
                rota = rootRota
            });
        }
    }
}
