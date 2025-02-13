using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CommandSystem
{
    public class CommandInvoker
    {
        private readonly List<ICommand> commands;
        private readonly List<ICommand> scheduledCommands;
        private const int CommandCount = 10;

        public CommandInvoker()
        {
            commands = new();
            scheduledCommands = new();
        }

        public void AddCommand(ICommand command)
        {
            scheduledCommands.Add(command);
        }

        public void InvokeCommand(ICommand command)
        {
            command.Invoke(command.Position);
            commands.Add(command);
            if (commands.Count > CommandCount)
            {
                commands.RemoveAt(0);
            }
        }

        public void InvokeScheduledCommands()
        {
            foreach (ICommand command in scheduledCommands)
            {
                InvokeCommand(command);
            }
        }

        public void UndoCommand()
        {
            if(commands.Count > 0)
            {
                commands.ElementAt(commands.Count - 1).Undo();
                commands.RemoveAt(commands.Count - 1);
            }
        }
    }
    
}
