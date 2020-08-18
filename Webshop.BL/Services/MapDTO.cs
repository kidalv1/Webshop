using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop.BL
{ 
    internal static class MapDTO
    {
        internal static T1 Map<T1, T2>(T2 e)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<T2, T1>());
            var mapper = config.CreateMapper();
            mapper = new Mapper(config);
            T1 dto = mapper.Map<T1>(e);
            return dto;
        }

        internal static List<T1> MapList<T1, T2>(List<T2> list)
        {
            List<T1> items = new List<T1>();
            foreach (T2 item in list)
            {
                items.Add(Map<T1, T2>(item));
            }
            return items;
        }
    }
}