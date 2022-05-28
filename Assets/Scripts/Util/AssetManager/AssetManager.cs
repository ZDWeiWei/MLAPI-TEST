﻿using System;
using System.Collections;
using System.Collections.Generic;
using SoFunny.Util;
using UnityEngine;

namespace SoFunny.Asset {
    public class AssetManager {
        public static ResourceRequest LoadUI(string functionSign) {
            var url = StringUtil.Concat(URI.UI, "/UI", functionSign);
            Debug.Log("LoadUI:" + url);
            return LoadAssetAsync<GameObject>(url);
        }

        public static GameObject LoadUIRoot() {
            return LoadAsset<GameObject>(URI.Root);
        }

        public static ResourceRequest LoadGamePlayObjAsync(string url) {
            return LoadAssetAsync<GameObject>(url);
        }

        public static GameObject LoadGameWorldLayer() {
            return LoadAsset<GameObject>(URI.GameWorldLayer);
        }

        public static T LoadAsset<T>(string url) where T : UnityEngine.Object {
            return Resources.Load<T>(url);
        }

        public static ResourceRequest LoadAssetAsync<T>(string url) where T : UnityEngine.Object {
            return Resources.LoadAsync<T>(url);
        }
    }
}