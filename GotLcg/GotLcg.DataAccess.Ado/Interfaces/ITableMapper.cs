using System;
using GotLcg.DataAccess.Ado.Base;
using GotLcg.Domain.Base;

namespace GotLcg.DataAccess.Ado.Interfaces
{
    public interface ITableMapper
    {
        Type EntityType { get; }

        string GetColumnMap(string index);

        void Init();
    }

    public interface ITableMapper<in TEntity> : ITableMapper
        where TEntity : IEntity
    {
        string ProcInsert { get; }

        string ProcUpdate { get; }

        string ProcDelete { get; }

        string ProcGetAll { get; }

        CommandMap GetCommandMap(string commandName, TEntity entity);

        CommandMap GetCommandMap<TParam>(string commandName, TParam parameter);
    }

    public interface ITableMapper<in TEntity, in TKey> : ITableMapper<TEntity>
        where TEntity : IEntity
    {
        string ProcGet { get; }

        CommandMap GetCommandMap(string commandName, TKey key);
    }
}