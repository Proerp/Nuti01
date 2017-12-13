﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq.Expressions;

using TotalBase.Enums;
using TotalModel.Models;

namespace TotalCore.Repositories
{
    public interface IBaseRepository
    {
        TotalSmartCodingEntities TotalSmartCodingEntities { get; }

        bool IsDirty();
        bool AutoUpdates(bool restoreProcedures);

        int? GetStoredID(int configID);
        int? GetVersionID(int configID);        
        bool VersionValidate(int configID, int configVersionID);        

        int GetModuleID(GlobalEnums.NmvnTaskID nmvnTaskID);

        ICollection<TElement> ExecuteFunction<TElement>(string functionName, params ObjectParameter[] parameters);
        int ExecuteFunction(string functionName, params ObjectParameter[] parameters);
        int ExecuteStoreCommand(string commandText, params Object[] parameters);


        T GetEntity<T>(params Expression<Func<T, object>>[] includes) where T : class;
        T GetEntity<T>(bool proxyCreationEnabled, params Expression<Func<T, object>>[] includes) where T : class;
        T GetEntity<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class;
        T GetEntity<T>(bool proxyCreationEnabled, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class;


        ICollection<T> GetEntities<T>(params Expression<Func<T, object>>[] includes) where T : class;
        ICollection<T> GetEntities<T>(bool proxyCreationEnabled, params Expression<Func<T, object>>[] includes) where T : class;
        ICollection<T> GetEntities<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class;
        ICollection<T> GetEntities<T>(bool proxyCreationEnabled, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class;


        string RepositoryTag { get; set; }
        Dictionary<string, object> RepositoryBag { get; set; }
    }
}
