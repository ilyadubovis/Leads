using AutoMapper;
using Leads.Server.Models;

namespace Leads.Server.Services;

public class LeadAutoMapperProfile : Profile
{
    public LeadAutoMapperProfile()
    {
        CreateMap<LeadInputViewModel, Lead>();

        CreateMap<Lead, LeadDetailsViewModel>();

        CreateMap<Lead, LeadViewModel>();
    }
}

public static class AutoMapperStartupExtensions
{
    public static void AddAutoMapper<T>(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(T).Assembly);
    }
}
