using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> getAllCommands();
        Command getCommandById(int id);
        void createCommand(Command command);
        
        void updateCommand( Command command);
        void deleteCommand(Command command);
        bool SaveChanges();
    }
}