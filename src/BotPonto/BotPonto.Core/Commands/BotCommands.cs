using System;
using System.Collections.Generic;
using System.Linq;
using BotPonto.Core.Interface;
using BotPonto.CrossCuting.Exceptions;

namespace BotPonto.Core.Commands
{
    public class BotCommands : IBotCommands
    {
        private readonly IEnumerable<IBotCommand> commands;

        public BotCommands(IEnumerable<IBotCommand> commands)
        {
            this.commands = commands;
        }

        public IBotCommand this[string command]
        {
            get
            {
                var commandService = commands.FirstOrDefault(cmd => cmd.Command.Equals(command, StringComparison.CurrentCultureIgnoreCase));
                if (commandService == null)
                    throw new ComandoInexistenteException($"O comando {command} não existe, sinto muito X(, informe um comando válido.");
                return commandService;
            }
        }
    }
}
