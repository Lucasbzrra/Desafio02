using AutoMapper;
using Desafio002.Data.Dtos;
using Desafio002.Models;
using System;

namespace Desafio002.Profiles;

public class UrlProfile: Profile
{
    public UrlProfile()
    {
        CreateMap<CreateUrlDto,Url>();
    }

}
