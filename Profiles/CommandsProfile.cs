using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoolApi.DTOs;
using CoolApi.Models;

namespace CoolApi.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // Source -> Target
            CreateMap<Command, CommandReadDTO>();
            CreateMap<CommandCreateDTO, Command>();
            CreateMap<CommandUpdateDTO, Command>();
            CreateMap<Command, CommandUpdateDTO>();
        }
    }
}