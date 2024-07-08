using Aura.LonelySatan.Cards;
using Aura.LonelySatan.Cards.Dto;
using Mapster;

namespace Aura.LonelySatan.Commons
{
    public static class MappingConfig
    {
        public static void ConfigureMappings()
        {
            TypeAdapterConfig<Card, CardDetailsDto>.NewConfig()
                .Map(dest => dest.Cvv, src => src.Cvv.Value);

            // Add more mappings as needed
        }
    }
}
