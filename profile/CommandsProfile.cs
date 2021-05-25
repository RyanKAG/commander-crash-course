using AutoMapper;
using Commander.Models;
using DTO;

namespace profile
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //map the source to the target
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
        }
    }
}