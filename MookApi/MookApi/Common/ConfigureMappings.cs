using AutoMapper;

namespace MookApi.Common
{
    public static class ConfigureMappings<TEntity, TViewModel> where TEntity : class
                                          where TViewModel : class
    {
        public static IMapper ConfigureMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TEntity, TViewModel>();
                cfg.CreateMap<TViewModel, TEntity>();
            });

            return config.CreateMapper();
        }


        //beginning of the class
        //private IMapper mapper;

        //the method
        //public void create()
        //{

        //    mapper = ConfigureMappings<DataAccess.Models.Gift, CreateGiftViewModel>.ConfigureMapping();

        //    var gift = mapper.Map<CreateGiftViewModel, DataAccess.Models.Gift>(model);
        //}


    }

}
