using System;
using NikosAssets.Helpers;

namespace NikosAssets.Modulize
{
    public abstract class BaseModule : BaseNotesMono
    {
        [Flags]
        public enum UpdateType
        {
            Update = 1,
            FixedUpdate = 2,
            LateUpdate = 4,
        }
        
        public abstract void AwakeInit();
        public abstract void StartInit();
        public abstract void Destroy();
        public abstract void Enable();
        public abstract void Disable();

        public void RemoveFromCompositeModule <TCompositeModule, TModule>(TCompositeModule compositeModule, UpdateType updateType)
            where TModule : BaseModule
            where TCompositeModule : BaseCompositeModule<TModule>
        {
            compositeModule.RemoveModule((TModule) this, updateType);
        }
        
        public abstract void UpdateTick(float deltaTime);
        
        public abstract void FixedTick(float deltaTime);
        
        public abstract void LateTick(float deltaTime);
    }
}
