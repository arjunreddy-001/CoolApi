using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoolApi.Models;

namespace CoolApi.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommandContext _ctx;

        public SqlCommanderRepo(CommandContext ctx)
        {
            _ctx = ctx;
        }

        public void CreateCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _ctx.Commands.Add(cmd);            
        }

        public void DeleteCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _ctx.Commands.Remove(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _ctx.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _ctx.Commands.FirstOrDefault(p => p.CommandId == id);
        }

        public bool SaveChanges()
        {
            return (_ctx.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command cmd)
        {
            // Nothing
        }
    }
}