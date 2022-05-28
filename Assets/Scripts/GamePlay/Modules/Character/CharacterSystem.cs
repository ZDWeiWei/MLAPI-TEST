using System.Collections;
using System.Collections.Generic;
using SoFunny.Asset;
using SoFunny.UIGameProto;
using UnityEngine;

namespace SoFunny.GamePlay {
    public partial class CharacterSystem : SystemBase {
        public ChatacterData Data;
        public CharacterEntity Entity;

        protected override void OnInit() {
            base.OnInit();
            Data = new ChatacterData();
            Entity = AddEntity<CharacterEntity>();
        }

        protected override void OnClear() {
            base.OnClear();
            Data = null;
            Entity = null;
        }

        public void SetIsLocalRole(bool isLocalRole) {
            Data.IsLocalRole = isLocalRole;
            if (isLocalRole) {
                AddComponent<CharacterLocalInput>();
                AddComponent<CharacterControllerMove>();
                AddComponent<CharacterCamera>();
                AddComponent<CharacterWeapon>();
            }
        }
    }
}