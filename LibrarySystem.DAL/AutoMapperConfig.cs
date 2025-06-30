using AutoMapper;
using LibrarySystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
namespace LibrarySystem.DAL
{

    public static class AutoMapperConfig
    {
        private static IMapper _mapper;

        public static IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    Initialize();
                }
                return _mapper;
            }
        }

        public static void Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                // DataRow to Entity Mapping
                cfg.CreateMap<DataRow, AuthorEntity>()
                   .ConvertUsing<DataRowConverter<DataRow, AuthorEntity>>();

                cfg.CreateMap<DataRow, BarrowEntity>()
                   .ConvertUsing<DataRowConverter<DataRow, BarrowEntity>>();

                cfg.CreateMap<DataRow, BookEntity>()
                   .ConvertUsing<DataRowConverter<DataRow, BookEntity>>();

                cfg.CreateMap<DataRow, CategoryEntity>()
                   .ConvertUsing<DataRowConverter<DataRow, CategoryEntity>>();

                cfg.CreateMap<DataRow, LanguageEntity>()
                   .ConvertUsing<DataRowConverter<DataRow, LanguageEntity>>();

                cfg.CreateMap<DataRow, ReserveEntity>()
                   .ConvertUsing<DataRowConverter<DataRow, ReserveEntity>>();

                cfg.CreateMap<DataRow, UserEntity>()
                   .ConvertUsing<DataRowConverter<DataRow, UserEntity>>();

                // datatable to Entity list Mapping
                cfg.CreateMap<DataTable, List<AuthorEntity>>()
                   .ConvertUsing<DataTableConverter<AuthorEntity>>();

                cfg.CreateMap<DataTable, List<BarrowEntity>>()
                    .ConvertUsing<DataTableConverter<BarrowEntity>>();

                cfg.CreateMap<DataTable, List<BookEntity>>()
                    .ConvertUsing<DataTableConverter<BookEntity>>();

                cfg.CreateMap<DataTable, List<CategoryEntity>>()
                    .ConvertUsing<DataTableConverter<CategoryEntity>>();

                cfg.CreateMap<DataTable, List<LanguageEntity>>()
                    .ConvertUsing<DataTableConverter<LanguageEntity>>();

                cfg.CreateMap<DataTable, List<ReserveEntity>>()
                    .ConvertUsing<DataTableConverter<ReserveEntity>>();

                cfg.CreateMap<DataTable, List<UserEntity>>()
                    .ConvertUsing<DataTableConverter<UserEntity>>();
            });
            //config.AssertConfigurationIsValid();
            _mapper = config.CreateMapper();
        }
    }
    public class DataRowConverter<TSource, TDestination> : ITypeConverter<DataRow, TDestination>
    where TDestination : new()
    {
        public TDestination Convert(DataRow source, TDestination destination, ResolutionContext context)
        {
            var entity = new TDestination();
            var properties = typeof(TDestination).GetProperties();

            foreach (var property in properties)
            {
                if (source.Table.Columns.Contains(property.Name))
                {
                    var value = source[property.Name];
                    if (value != DBNull.Value)
                    {
                        property.SetValue(entity, value);
                    }
                }
            }

            return entity;
        }
    }
    public class DataTableConverter<T> : ITypeConverter<DataTable, List<T>>
    {
        public List<T> Convert(DataTable source, List<T> destination, ResolutionContext context)
        {
            destination = new List<T>();
            foreach (DataRow row in source.Rows)
            {
                destination.Add(context.Mapper.Map<T>(row));
            }
            return destination;
        }
    }
}
