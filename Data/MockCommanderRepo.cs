using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> getAppCommands()
        {
        }

        public Command getCommandById(int id)
        {
        }
    }
}