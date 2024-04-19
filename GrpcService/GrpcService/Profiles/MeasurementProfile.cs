using AutoMapper;
using Google.Protobuf.WellKnownTypes;

namespace GrpcService.Profiles
{
    public class MeasurementProfile:Profile
    {
        public MeasurementProfile()
        {
            CreateMap<Models.Measurement, CRUDService.Measurement>()
            .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => Timestamp.FromDateTime(src.Timestamp)));

            CreateMap<DateTime, Timestamp>().ConvertUsing(dateTime => Timestamp.FromDateTime(dateTime));

            CreateMap<CRUDService.Measurement, Models.Measurement>()
            .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => src.Timestamp.ToDateTime()));

            CreateMap<Timestamp, DateTime>().ConvertUsing(timestamp => timestamp.ToDateTime());
        }
    }
}
