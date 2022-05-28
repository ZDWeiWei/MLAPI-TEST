﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using SoFunny.Asset;
using SoFunny.UIGameProto;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace SoFunny.GamePlay {
    public class GameWorldLayerManager : IGameWorld {
        private GameWorldLayerEntity entity;

        public enum Layer : byte {
            Base = 0,
            Character = 1,
            Map = 2,
        }

        public void Init() {
            GameProtoManager.AddListener(GameProtoDoc_GameWorlLayer.SetLayer.ID, OnSetLayerCallBack);
            CreateEntity();
        }

        public void Clear() {
            GameProtoManager.RemoveListener(GameProtoDoc_GameWorlLayer.SetLayer.ID, OnSetLayerCallBack);
        }

        private void OnSetLayerCallBack(IGameProtoDoc message) {
            var data = (GameProtoDoc_GameWorlLayer.SetLayer) message;
            var layer = GetLayer((Layer) data.layer);
            data.child.SetParent(layer);
        }

        public void CreateEntity() {
            var prefab = AssetManager.LoadGameWorldLayer();
            if (prefab != null) {
                var roleGameObj = GameObject.Instantiate(prefab);
                entity = roleGameObj.GetComponent<GameWorldLayerEntity>();
            } else {
                Debug.LogError("GamePlayRole 加载失败:");
            }
        }

        private Transform GetLayer(Layer layerState) {
            Transform layer = null;
            switch (layerState) {
                case Layer.Base:
                    layer = entity.BaseLayer;
                    break;
                case Layer.Character:
                    layer = entity.CharacterLayer;
                    break;
                case Layer.Map:
                    layer = entity.MapLayer;
                    break;
                default:
                    Debug.LogError("层级设置错误:" + layerState);
                    break;
            }
            return layer;
        }
    }
}