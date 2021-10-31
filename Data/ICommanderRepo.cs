using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoolApi.Models;

namespace CoolApi.Data
{
    public interface ICommanderRepo
    {
        bool SaveChanges();
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);
        void DeleteCommand(Command cmd);
    }
}