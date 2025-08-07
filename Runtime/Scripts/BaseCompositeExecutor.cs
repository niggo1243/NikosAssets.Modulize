using UnityEngine;

namespace NikosAssets.Modulize
{
    /// <summary>
    /// Executes the stored specified module types
    /// </summary>
    /// <typeparam name="TBaseModule"></typeparam>
    public abstract class BaseCompositeExecutor<TBaseModule> : BaseCompositeModule<TBaseModule> where TBaseModule : BaseModule
    {
        private void Awake() => AwakeInit();
        private void Start() => StartInit();
        private void OnDestroy() => Destroy();
        private void OnEnable() => Enable();
        private void OnDisable() => Disable();

        private void Update() => UpdateTick(Time.deltaTime);
        private void FixedUpdate() => FixedTick(Time.fixedDeltaTime);
        private void LateUpdate() => LateTick(Time.deltaTime);
    }
}
