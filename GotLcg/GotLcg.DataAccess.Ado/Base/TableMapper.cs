using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using GotLcg.Common.Extensions;
using GotLcg.DataAccess.Ado.Interfaces;
using GotLcg.Domain.Base;

namespace GotLcg.DataAccess.Ado.Base
{
    #region Mapper for IEntity

    public abstract class TableMapper<TEntity> : ITableMapper<TEntity>
        where TEntity : IEntity
    {
        #region Member Fields

        protected readonly IDictionary<string, Delegate[]> CommandMappings;

        private readonly Dictionary<string, string> _forward = new Dictionary<string, string>();

        private readonly Dictionary<string, string> _reverse = new Dictionary<string, string>();

        #endregion

        #region Properties

        public Type EntityType => typeof(TEntity);

        public virtual string ProcInsert => GetProcName("Insert");

        public virtual string ProcUpdate => GetProcName("Update");

        public virtual string ProcDelete => GetProcName("Delete");

        public virtual string ProcGetAll => GetProcName("GetAll");

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TableMapper{TEntity}"/> class.
        /// </summary>
        protected TableMapper()
        {
            CommandMappings = new Dictionary<string, Delegate[]>();
        }

        #endregion

        #region Implementation of ITableMapper

        public virtual void Init()
        {
            MapColumn(e => e.CreatedDate, "CreatedDate");
            MapColumn(e => e.ModifiedDate, "ModifiedDate");
        }

        public string GetColumnMap(string index)
        {
            string name;

            // Check for a custom column map.
            if (!_forward.TryGetValue(index, out name)
                && !_reverse.TryGetValue(index, out name))
            {
                // If no custom mapping exists, return the value passed in.
                name = index;
            }

            return name;
        }

        #endregion

        #region Implementation of TableMapper{TEntity}

        public CommandMap GetCommandMap(string commandName, TEntity entity)
        {
            return GetCommandMap<TEntity>(commandName, entity);
        }

        public CommandMap GetCommandMap<TParam>(string commandName, TParam parameter)
        {
            return new CommandMap
            {
                Name = commandName,
                CommandParams = CommandMappings[commandName]
                   .Cast<Func<TParam, CommandParam>>()
                   .Select(m => m(parameter))
                   .ToArray()
            };
        }

        #endregion

        #region Member Methods

        protected void MapColumn<TProp>(Expression<Func<TEntity, TProp>> propExpression, string columnName)
        {
            MemberExpression member = propExpression.Body as MemberExpression;

            if (member == null)
            {
                throw new ArgumentException(
                    $"Expression '{propExpression}' refers to a method, not a property.");
            }

            PropertyInfo propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
            {
                throw new ArgumentException(
                    $"Expression '{propExpression}' refers to a field, not a property.");
            }

            string propName = propInfo.Name;

            _forward.Add(propName, columnName);
            _reverse.Add(columnName, propName);
        }

        protected void MapCommand(string commandName,
            params Expression<Func<TEntity, CommandParam>>[] paramExpressions)
        {
            MapCommand<TEntity>(commandName, paramExpressions);
        }

        protected void MapCommand<TParam>(string commandName,
           params Expression<Func<TParam, CommandParam>>[] paramExpressions)
        {
            Delegate[] commandMapping = paramExpressions
                .Select(ex => ex.Compile())
                .ToArray<Delegate>();

            CommandMappings.Add(commandName, commandMapping);
        }

        protected string GetProcName(string command) => $"SP_{typeof(TEntity).Name}_{command}";

        #endregion
    }

    #endregion

    #region Mapper for IEntityWithKey

    public abstract class TableMapper<TEntity, TKey> : TableMapper<TEntity>, ITableMapper<TEntity, TKey>
        where TEntity : IEntityWithKey<TKey>
    {
        private const string CommandSuffix = "_WithKey";

        public string ProcGet => GetProcName("Get");

        protected void MapCommand(string commandName, Expression<Func<TKey, CommandParam>> paramExpression)
        {
            MapCommand<TKey>($"{commandName}{CommandSuffix}", paramExpression);
        }

        public override void Init()
        {
            base.Init();
            MapColumn(e => e.Id, "Id");
        }

        public CommandMap GetCommandMap(string commandName, TKey key)
        {
            var command = GetCommandMap<TKey>($"{commandName}{CommandSuffix}", key);

            command.Name = command.Name.RemoveSuffix(CommandSuffix);

            return command;
        }
    }

    #endregion
}