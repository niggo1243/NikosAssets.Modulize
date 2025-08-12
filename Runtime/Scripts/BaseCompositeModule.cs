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

        /// <summary>
        /// Calls AwakeInit() for every assigned module
        /// </summary>
        public override void AwakeInit()
        {
            foreach (TBaseModule module in _modulesToUpdate)
                module.AwakeInit();
            foreach (TBaseModule module in _modulesToFixedUpdate)
                module.AwakeInit();
            foreach (TBaseModule module in _modulesToLateUpdate)
                module.AwakeInit();
        }
        
        /// <summary>
        /// Calls StartInit() for every assigned module
        /// </summary>
        public override void StartInit()
        {
            foreach (TBaseModule module in _modulesToUpdate)
                module.StartInit();
            foreach (TBaseModule module in _modulesToFixedUpdate)
                module.StartInit();
            foreach (TBaseModule module in _modulesToLateUpdate)
                module.StartInit();
        }
        
        /// <summary>
        /// Calls Destroy() for every assigned module
        /// </summary>
        public override void Destroy()
        {
            foreach (TBaseModule module in _modulesToUpdate)
                module.Destroy();
            foreach (TBaseModule module in _modulesToFixedUpdate)
                module.Destroy();
            foreach (TBaseModule module in _modulesToLateUpdate)
                module.Destroy();
        }
        
        /// <summary>
        /// Calls Enable() for every assigned module
        /// </summary>
        public override void Enable()
        {
            foreach (TBaseModule module in _modulesToUpdate)
                module.Enable();
            foreach (TBaseModule module in _modulesToFixedUpdate)
                module.Enable();
            foreach (TBaseModule module in _modulesToLateUpdate)
                module.Enable();
        }
        
        /// <summary>
        /// Calls Disable() for every assigned module
        /// </summary>
        public override void Disable()
        {
            foreach (TBaseModule module in _modulesToUpdate)
                module.Disable();
            foreach (TBaseModule module in _modulesToFixedUpdate)
                module.Disable();
            foreach (TBaseModule module in _modulesToLateUpdate)
                module.Disable();
        }

        /// <summary>
        /// Calls UpdateTick() for every assigned module in _modulesToUpdate
        /// </summary>
        public override void UpdateTick(float deltaTime)
        {
            foreach (TBaseModule module in _modulesToUpdate)
                module.UpdateTick(deltaTime);
        }

        /// <summary>
        /// Calls FixedTick() for every assigned module in _modulesToFixedUpdate
        /// </summary>
        public override void FixedTick(float deltaTime)
        {
            foreach (TBaseModule module in _modulesToFixedUpdate)
                module.FixedTick(deltaTime);
        }
        
        /// <summary>
        /// Calls LateTick() for every assigned module in _modulesToLateUpdate
        /// </summary>
        public override void LateTick(float deltaTime)
        {
            foreach (TBaseModule module in _modulesToLateUpdate)
                module.LateTick(deltaTime);
        }

        /// <summary>
        /// Add the module to _modulesToUpdate
        /// </summary>
        /// <param name="moduleToUpdate"></param>
        public void AddModuleToUpdate(TBaseModule moduleToUpdate)
        {
            if (_modulesToUpdate.Contains(moduleToUpdate))
                return;
            
            _modulesToUpdate.Add(moduleToUpdate);
        }
        
        /// <summary>
        /// Add the module to _modulesToFixedUpdate
        /// </summary>
        /// <param name="moduleToFixedUpdate"></param>
        public void AddModuleToFixedUpdate(TBaseModule moduleToFixedUpdate)
        {
            if (_modulesToFixedUpdate.Contains(moduleToFixedUpdate))
                return;
            
            _modulesToFixedUpdate.Add(moduleToFixedUpdate);
        }
        
        /// <summary>
        /// Add the module to _modulesToLateUpdate
        /// </summary>
        /// <param name="moduleToLateUpdate"></param>
        public void AddModuleToLateUpdate(TBaseModule moduleToLateUpdate)
        {
            if (_modulesToLateUpdate.Contains(moduleToLateUpdate))
                return;
            
            _modulesToLateUpdate.Add(moduleToLateUpdate);
        }
        
        /// <summary>
        /// Remove the module from _modulesToUpdate
        /// </summary>
        /// <param name="moduleToUpdate"></param>
        public void RemoveModuleFromUpdate(TBaseModule moduleToUpdate)
        {
            _modulesToUpdate.Remove(moduleToUpdate);
        }
        
        /// <summary>
        /// Remove the module from _modulesToFixedUpdate
        /// </summary>
        /// <param name="moduleToFixedUpdate"></param>
        public void RemoveModuleFromFixedUpdate(TBaseModule moduleToFixedUpdate)
        {
            _modulesToFixedUpdate.Remove(moduleToFixedUpdate);
        }
        
        /// <summary>
        /// Remove the module from _modulesToLateUpdate
        /// </summary>
        /// <param name="moduleToLateUpdate"></param>
        public void RemoveModuleFromLateUpdate(TBaseModule moduleToLateUpdate)
        {
            _modulesToLateUpdate.Remove(moduleToLateUpdate);
        }
        
        /// <summary>
        /// Remove the module from at least one of the lists (multiple possible set it up this way) 
        /// </summary>
        /// <param name="module"></param>
        /// <param name="updateType"></param>
        public void RemoveModule(TBaseModule module, UpdateType updateType)
        {
            if (updateType.HasFlag(UpdateType.Update)) RemoveModuleFromUpdate(module);
            if (updateType.HasFlag(UpdateType.FixedUpdate)) RemoveModuleFromFixedUpdate(module);
            if (updateType.HasFlag(UpdateType.LateUpdate)) RemoveModuleFromLateUpdate(module);
        }

        /// <summary>
        /// Inserts and replaced the module at the given index of the _modulesToUpdate list 
        /// </summary>
        /// <param name="moduleToUpdate"></param>
        /// <param name="index"></param>
        public void InsertModuleToUpdate(TBaseModule moduleToUpdate, int index)
        {
            _modulesToUpdate[index] = moduleToUpdate;
        }
        
        /// <summary>
        /// Inserts and replaced the module at the given index of the _modulesToFixedUpdate list 
        /// </summary>
        /// <param name="moduleToFixedUpdate"></param>
        /// <param name="index"></param>
        public void InsertModuleToFixedUpdate(TBaseModule moduleToFixedUpdate, int index)
        {
            _modulesToFixedUpdate[index] = moduleToFixedUpdate;
        }
        
        /// <summary>
        /// Inserts and replaced the module at the given index of the _modulesToLateUpdate list 
        /// </summary>
        /// <param name="moduleToLateUpdate"></param>
        /// <param name="index"></param>
        public void InsertModuleToLateUpdate(TBaseModule moduleToLateUpdate, int index)
        {
            _modulesToLateUpdate[index] = moduleToLateUpdate;
        }

        /// <summary>
        /// Get the module matching the type from any list
        /// </summary>
        /// <typeparam name="TBaseModuleToUpdate"></typeparam>
        /// <returns></returns>
        public List<TBaseModuleToUpdate> GetModulesByModuleType<TBaseModuleToUpdate>() where TBaseModuleToUpdate : TBaseModule
        {
            List<TBaseModule> allModules = new List<TBaseModule>(_modulesToUpdate);
            allModules.AddRange(_modulesToFixedUpdate);
            allModules.AddRange(_modulesToLateUpdate);
            return allModules.FindAll(order => order is TBaseModuleToUpdate).Select(order => order as TBaseModuleToUpdate).ToList();
        }
        
        /// <summary>
        /// Get the module matching the type from the _modulesToUpdate list
        /// </summary>
        /// <typeparam name="TBaseModuleToUpdate"></typeparam>
        /// <returns></returns>
        public List<TBaseModuleToUpdate> GetModulesToUpdateByModuleType<TBaseModuleToUpdate>() where TBaseModuleToUpdate : TBaseModule
        {
            return _modulesToUpdate.FindAll(order => order is TBaseModuleToUpdate).Select(order => order as TBaseModuleToUpdate).ToList();
        }
        
        /// <summary>
        /// Get the module matching the type from the _modulesToFixedUpdate list
        /// </summary>
        /// <typeparam name="TBaseModuleToFixedUpdate"></typeparam>
        /// <returns></returns>
        public List<TBaseModuleToFixedUpdate> GetModulesToFixedUpdateByModuleType<TBaseModuleToFixedUpdate>() where TBaseModuleToFixedUpdate : TBaseModule
        {
            return _modulesToFixedUpdate.FindAll(order => order is TBaseModuleToFixedUpdate).Select(order => order as TBaseModuleToFixedUpdate).ToList();
        }
        
        /// <summary>
        /// Get the module matching the type from the _modulesToLateUpdate list
        /// </summary>
        /// <typeparam name="TBaseModuleToLateUpdate"></typeparam>
        /// <returns></returns>
        public List<TBaseModuleToLateUpdate> GetModulesToLateUpdateByModuleType<TBaseModuleToLateUpdate>() where TBaseModuleToLateUpdate : TBaseModule
        {
            return _modulesToLateUpdate.FindAll(order => order is TBaseModuleToLateUpdate).Select(order => order as TBaseModuleToLateUpdate).ToList();
        }
    }
}
