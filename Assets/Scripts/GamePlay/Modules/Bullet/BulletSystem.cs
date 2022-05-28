using System.Collections;
using System.Collections.Generic;
using SoFunny.UIGameProto;
using UnityEngine;

namespace SoFunny.GamePlay {
    public partial class BulletSystem : SystemBase {
        public BulletData Data;
        public BulletEntity Entity;
        public enum BulletType {
            Base,
        }

        protected override void OnInit() {
            base.OnInit();
            Data = new BulletData();
            Entity = AddEntity<BulletEntity>();
        }

        protected override void OnClear() {
            base.OnClear();
        }

        public void SetData(int bulletId, GameProtoDoc_Bullet.CreateBullet data) {
            Data.BulletId = bulletId;
            AddComponent<BulletMove>();
            Dispatcher(Event_CreateBullet, data);
        }
    }
}