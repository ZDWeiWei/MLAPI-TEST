﻿using System;
using System.Collections;
using System.Collections.Generic;
using SoFunny.GamePlay;
using SoFunny.Stage;
using SoFunny.Util;
using SoFunny.View;
using UnityEngine;

namespace SoFunny.Main {
    public sealed class ATMain : MonoBehaviour {
        private readonly Queue<Task> tasks = new Queue<Task>();
        private ATUpdateRegister updateRegister;

        void Awake() {
            DontDestroyOnLoad(this);
        }

        void Start() {
            tasks.Enqueue(new Task("初始化 UpdateRegister", InitUpdateRegister));
            tasks.Enqueue(new Task("初始化 TouchSystem", InitTouchSystem));
            tasks.Enqueue(new Task("初始化 ViewManager", InitView));
            tasks.Enqueue(new Task("初始化 GamePlayManager", InitGamePlay));
            tasks.Enqueue(new Task("初始化 StageManager", InitStage));
        }

        void Update() {
            if (updateRegister != null) {
                updateRegister.OnUpdate(Time.deltaTime);
            }
            if (tasks.Count > 0) {
                var task = tasks.Dequeue();
                task.OnStart();
            }
        }

        void FixedUpdate() {
            if (updateRegister != null) {
                updateRegister.OnFixUpdate(Time.fixedDeltaTime);
            }
        }

        void LateUpdate() {
            if (updateRegister != null) {
                updateRegister.OnLateUpdate(Time.deltaTime);
            }
        }

        void InitUpdateRegister() {
            updateRegister = new ATUpdateRegister();
            updateRegister.Init();
        }

        void InitTouchSystem() {
            var touchSystem = new TouchSystem();
            touchSystem.Init();
        }

        void InitView() {
            var manager = new ViewManager();
            manager.Init();
        }

        void InitGamePlay() {
            var manager = new GamePlayManager();
            manager.Init();
        }
        
        void InitStage() {
            var manager = new StageManager();
            manager.Init();
        }

        /// <summary>
        /// 创建启动任务
        /// </summary>
        private class Task {
            protected readonly string taskName;
            protected readonly Action action;

            public Task(string taskName, Action action) {
                this.taskName = taskName;
                this.action = action;
            }

            public virtual void OnStart() {
                Debug.Log(taskName);
                try {
                    action?.Invoke();
                } catch (Exception ex) {
                    Debug.LogErrorFormat("启动任务异常:{0} ,exception:{1}", taskName, ex);
                }
            }
        }
    }
}