using AutoMapper;
using Domain.Entities;
using API.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<string, string>().ConvertUsing(s => s == null ? null : s.Trim());
        CreateMap<LoginDTo, DocGia>();
        CreateMap<DocGia, RegisterDTO>()
            .ForMember(dest => dest.Email, opt => opt.Ignore()).ReverseMap();   
    }
}