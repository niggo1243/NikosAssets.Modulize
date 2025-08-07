using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using NikosAssets.Helpers;
using UnityEngine;

namespace NikosAssets.Modulize
{
    /// <summary>
    /// Stores the specified module type in lists, preparing for execution
    /// </summary>
    /// <typeparam name="TBaseModule"></typeparam>
    public abstract class BaseCompositeModule<TBaseModule> : BaseModule where TBaseModule : BaseModule
    {
        [SerializeField]
        [BoxGroup(HelperConstants.ATTRIBUTE_FIELD_BOXGROUP_SETTINGS)]
        protected List<TBaseModule> _modulesToUpdate = new List<TBaseModule>();
        
        [SerializeField]
        [BoxGroup(HelperConstants.ATTRIBUTE_FIELD_BOXGROUP_SETTINGS)]
        protected List<TBaseModule> _modulesToFixedUpdate = new List<TBaseModule>();
        
        [SerializeField]
        [BoxGroup(HelperConstants.ATTRIBUTE_FIELD_BOXGROUP_SETTINGS)]
        protected List<TBaseModule> _modulesToLateUpdate = new List<TBaseModule>();

        public override void AwakeInit()
        {
            foreach (TBaseModule module in _modulesToUpdate)
                module.AwakeInit();
            foreach (TBaseModule module in _modulesToFixedUpdate)
                module.AwakeInit();
            foreach (TBaseModule module in _modulesToLateUpdate)
                module.AwakeInit();
        }
        
        public override void StartInit()
        {
            foreach (TBaseModule module in _modulesToUpdate)
                module.StartInit();
            foreach (TBaseModule module in _modulesToFixedUpdate)
                module.StartInit();
            foreach (TBaseModule module in _modulesToLateUpdate)
                module.StartInit();
        }
        
        public override void Destroy()
        {
            foreach (TBaseModule module in _modulesToUpdate)
                module.Destroy();
            foreach (TBaseModule module in _modulesToFixedUpdate)
                module.Destroy();
            foreach (TBaseModule module in _modulesToLateUpdate)
                module.Destroy();
        }
        
        public override void Enable()
        {
            foreach (TBaseModule module in _modulesToUpdate)
                module.Enable();
            foreach (TBaseModule module in _modulesToFixedUpdate)
                module.Enable();
            foreach (TBaseModule module in _modulesToLateUpdate)
                module.Enable();
        }
        
        public override void Disable()
        {
            foreach (TBaseModule module in _modulesToUpdate)
                module.Disable();
            foreach (TBaseModule module in _modulesToFixedUpdate)
                module.Disable();
            foreach (TBaseModule module in _modulesToLateUpdate)
                module.Disable();
        }

        public override void UpdateTick(float deltaTime)
        {
            foreach (TBaseModule module in _modulesToUpdate)
                module.UpdateTick(deltaTime);
        }

        public override void FixedTick(float deltaTime)
        {
            foreach (TBaseModule module in _modulesToFixedUpdate)
                module.FixedTick(deltaTime);
        }
        
        public override void LateTick(float deltaTime)
        {
            foreach (TBaseModule module in _modulesToLateUpdate)
                module.LateTick(deltaTime);
        }

        public void AddModuleToUpdate(TBaseModule moduleToUpdate)
        {
            if (_modulesToUpdate.Contains(moduleToUpdate))
                return;
            
            _modulesToUpdate.Add(moduleToUpdate);
        }
        
        public void AddModuleToFixedUpdate(TBaseModule moduleToFixedUpdate)
        {
            if (_modulesToFixedUpdate.Contains(moduleToFixedUpdate))
                return;
            
            _modulesToFixedUpdate.Add(moduleToFixedUpdate);
        }
        
        public void AddModuleToLateUpdate(TBaseModule moduleToLateUpdate)
        {
            if (_modulesToLateUpdate.Contains(moduleToLateUpdate))
                return;
            
            _modulesToLateUpdate.Add(moduleToLateUpdate);
        }
        
        public void RemoveModuleFromUpdate(TBaseModule moduleToUpdate)
        {
            _modulesToUpdate.Remove(moduleToUpdate);
        }
        
        public void RemoveModuleFromFixedUpdate(TBaseModule moduleToFixedUpdate)
        {
            _modulesToFixedUpdate.Remove(moduleToFixedUpdate);
        }
        
        public void RemoveModule(TBaseModule module, UpdateType updateType)
        {
            if (updateType.HasFlag(UpdateType.Update)) RemoveModuleFromUpdate(module);
            if (updateType.HasFlag(UpdateType.FixedUpdate)) RemoveModuleFromFixedUpdate(module);
            if (updateType.HasFlag(UpdateType.LateUpdate)) RemoveModuleFromLateUpdate(module);
        }
        
        public void InsertModuleToLateUpdate(TBaseModule moduleToLateUpdate, int index)
        {
            _modulesToLateUpdate[index] = moduleToLateUpdate;
        }

        public void InsertModuleToUpdate(TBaseModule moduleToUpdate, int index)
        {
            _modulesToUpdate[index] = moduleToUpdate;
        }
        
        public void InsertModuleToFixedUpdate(TBaseModule moduleToFixedUpdate, int index)
        {
            _modulesToFixedUpdate[index] = moduleToFixedUpdate;
        }
        
        public void RemoveModuleFromLateUpdate(TBaseModule moduleToLateUpdate)
        {
            _modulesToLateUpdate.Remove(moduleToLateUpdate);
        }
        
        public List<TBaseModuleToUpdate> GetModulesByModuleType<TBaseModuleToUpdate>() where TBaseModuleToUpdate : TBaseModule
        {
            List<TBaseModule> allModules = new List<TBaseModule>(_modulesToUpdate);
            allModules.AddRange(_modulesToFixedUpdate);
            allModules.AddRange(_modulesToLateUpdate);
            return allModules.FindAll(order => order is TBaseModuleToUpdate).Select(order => order as TBaseModuleToUpdate).ToList();
        }
        
        public List<TBaseModuleToUpdate> GetModulesToUpdateByModuleType<TBaseModuleToUpdate>() where TBaseModuleToUpdate : TBaseModule
        {
            return _modulesToUpdate.FindAll(order => order is TBaseModuleToUpdate).Select(order => order as TBaseModuleToUpdate).ToList();
        }
        
        public List<TBaseModuleToFixedUpdate> GetModulesToFixedUpdateByModuleType<TBaseModuleToFixedUpdate>() where TBaseModuleToFixedUpdate : TBaseModule
        {
            return _modulesToFixedUpdate.FindAll(order => order is TBaseModuleToFixedUpdate).Select(order => order as TBaseModuleToFixedUpdate).ToList();
        }
        
        public List<TBaseModuleToLateUpdate> GetModulesToLateUpdateByModuleType<TBaseModuleToLateUpdate>() where TBaseModuleToLateUpdate : TBaseModule
        {
            return _modulesToLateUpdate.FindAll(order => order is TBaseModuleToLateUpdate).Select(order => order as TBaseModuleToLateUpdate).ToList();
        }
    }
}
