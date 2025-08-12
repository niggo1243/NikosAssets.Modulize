using System;
using NikosAssets.Helpers;

namespace NikosAssets.Modulize
{
    /// <summary>
    /// The base template to inherit from
    /// </summary>
    public abstract class BaseModule : BaseNotesMono
    {
        [Flags]
        public enum UpdateType
        {
            Update = 1,
            FixedUpdate = 2,
            LateUpdate = 4,
        }
        
        /// <summary>
        /// Your (optional) Awake logic 
        /// </summary>
        public abstract void AwakeInit();
        
        /// <summary>
        /// Your (optional) Start logic
        /// </summary>
        public abstract void StartInit();
        
        /// <summary>
        /// Your (optional) OnDestroy logic
        /// </summary>
        public abstract void Destroy();
        
        /// <summary>
        /// Your (optional) OnEnable logic
        /// </summary>
        public abstract void Enable();
        
        /// <summary>
        /// Your (optional) OnDisable logic
        /// </summary>
        public abstract void Disable();

        
        /// <summary>
        /// Your (optional) Update logic
        /// </summary>
        /// <param name="deltaTime"></param>
        public abstract void UpdateTick(float deltaTime);
        
        /// <summary>
        /// Your (optional) FixedUpdate logic
        /// </summary>
        /// <param name="deltaTime"></param>
        public abstract void FixedTick(float deltaTime);
        
        /// <summary>
        /// Your (optional) LateUpdate logic
        /// </summary>
        /// <param name="deltaTime"></param>
        public abstract void LateTick(float deltaTime);
    }
}
