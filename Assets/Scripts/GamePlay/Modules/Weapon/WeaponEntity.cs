using System;
using System.Collections;
using System.Collections.Generic;
using SoFunny.Asset;
using SoFunny.UIGameProto;
using SoFunny.Util;
using UnityEngine;

namespace SoFunny.GamePlay {
    public class WeaponEntity : EntityBase {
        public const string Root = "Root";
        private ProtoCallBack createCallBack;
        private WeaponSystem weaponSystem;

        public override void OnInit() {
            this.weaponSystem = (WeaponSystem) system;
        }

        public override void OnClear() {
            this.weaponSystem = null;
        }

        public void SetWeaponData(GameProtoDoc_Weapon.CreateWeapon message) {
            createCallBack = message.CallBack;
            CreateEntityObj(StringUtil.Concat(URI.Weapon, message.Sign));
        }

        protected override void OnCreateEntityComponent() {
            base.OnCreateEntityComponent();
            createCallBack(new GameProtoDoc_Weapon.CreateWeaponCallBackData {
                WeaponId = this.weaponSystem.Data.WeaponID, 
                WeaponTran = entityTran
            });
            this.SetLocalPoint(Root, Vector3.zero);
            this.SetLocalRota(Root, Quaternion.identity);
            this.SetLocalScale(Root, Vector3.one);
        }
    }
}