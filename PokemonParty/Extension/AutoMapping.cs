using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonParty.Extension {
    public class AutoMapping<TSource, TDestination> : Profile {
        public AutoMapping() {
            CreateMap<TSource, TDestination>().ReverseMap();
        }
        public static MapperConfiguration GetMapperConfiguration() {
            return new MapperConfiguration(c => c.AddProfile(new AutoMapping<TSource, TDestination>()));
        }
        public TDestination GetMappingResult(TSource myDTO) {
            //
            var conf = GetMapperConfiguration();
            var mapper = conf.CreateMapper();
            return mapper.Map<TSource, TDestination>(myDTO);
        }
    }
    public class AutoMappingList<TSource, TDestination> {
        public List<TDestination> GetMappingResultList(ICollection<TSource> source) {
            //
            List<TDestination> resultList = new List<TDestination>();
            foreach (var item in source) {
                var itemToMapp = new AutoMapping<TSource, TDestination>().GetMappingResult(item);
                resultList.Add(itemToMapp);
            }
            return resultList;
        }
        public List<TDestination> GetMappingResultList(IEnumerable<TSource> source) {
            //
            List<TDestination> resultList = new List<TDestination>();
            foreach (var item in source) {
                var itemToMapp = new AutoMapping<TSource, TDestination>().GetMappingResult(item);
                resultList.Add(itemToMapp);
            }
            return resultList;
        }
        public List<TDestination> GetMappingResultList(List<TSource> source) {
            //
            List<TDestination> resultList = new List<TDestination>();
            foreach (var item in source) {
                var itemToMapp = new AutoMapping<TSource, TDestination>().GetMappingResult(item);
                resultList.Add(itemToMapp);
            }
            return resultList;
        }
    }

}
