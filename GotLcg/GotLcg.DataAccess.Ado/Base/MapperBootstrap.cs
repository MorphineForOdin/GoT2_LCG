using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using GotLcg.DataAccess.Ado.Interfaces;

namespace GotLcg.DataAccess.Ado.Base
{
    public class MapperBootstrap : IMapperBootstrap
    {
        private IEnumerable<ITableMapper> _tableMappers;

        public MapperBootstrap()
        {
            Init();
        }

        public void Init()
        {
            var mapperType = typeof (ITableMapper);

            // ReSharper disable once SuspiciousTypeConversion.Global
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(t => t.IsClass && !t.IsAbstract && mapperType.IsAssignableFrom(t));

            _tableMappers = types.Select(t => Activator.CreateInstance(t) as ITableMapper).ToArray();

            foreach (ITableMapper tableMapper in _tableMappers)
            {
                tableMapper.Init();

                SqlMapper.SetTypeMap(tableMapper.EntityType,
                    new CustomPropertyTypeMap(tableMapper.EntityType,
                        (type, columnName) => type.GetProperty(tableMapper.GetColumnMap(columnName))));
            }
        }

        public TMapper Get<TMapper>() where TMapper : ITableMapper
        {
            return _tableMappers.OfType<TMapper>().SingleOrDefault();
        }
    }
}