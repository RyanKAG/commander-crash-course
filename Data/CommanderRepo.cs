using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Data;
using Commander.Models;

namespace Data
{
    public class CommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        public CommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public void createCommand(Command command)
        {
            if(command == null){
                throw new ArgumentNullException(nameof(command));
            }

            _context.Commands.Add(command);
        }

        public IEnumerable<Command> getAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command getCommandById(int id)
        {
            return _context.Commands.FirstOrDefault( p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void updateCommand( Command command){
            //noop
        }

        public void deleteCommand(Command command){
            if(command == null)
                throw new ArgumentNullException(nameof(command));
            
            _context.Commands.Remove(command);
        }
    }
}