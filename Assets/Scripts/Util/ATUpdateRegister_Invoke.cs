using System.Collections;
using System.Collections.Generic;
using SoFunny.Util;
using UnityEngine;

namespace SoFunny.Util {
    public delegate void InvokeDelegate();

    public partial class ATUpdateRegister {
        private List<WrapperInvoke> m_Invokes = new List<WrapperInvoke>(64);

        public void RegisterInvoke(InvokeDelegate handler, float invokeTime) {
            m_Invokes.Add(new WrapperInvoke(handler, invokeTime));
        }
        
        private void TickInvokeUpdates(float delta) {
            var length = m_Invokes.Count;
            for (var i = 0; i < length; ++i) {
                var handler = m_Invokes[i];
                handler.OnUpdate(delta);
            }
        }
        
        private struct WrapperInvoke {
            public InvokeDelegate Handler;
            public float invokeTime;

            public WrapperInvoke(InvokeDelegate handler, float invokeTime) {
                this.Handler = handler;
                this.invokeTime = invokeTime;
            }

            public void Clear() {
                Handler = null;
            }

            public void OnUpdate(float delta) {
                invokeTime -= delta;
                if (invokeTime <= 0) {
                    Handler.Invoke();
                }
            }
        }
    }
}