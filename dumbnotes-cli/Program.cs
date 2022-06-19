using DumbnotesCli;
using System;

namespace DumbnotesCli;

internal class Program
{
	static async Task Main(string[] args)
	{
		CommandService commandService = new CommandService();
		Config config = await Config.ReadConfig();

		if (args.Length == 0)
        {
			ScriptSelector scriptSelector = new ScriptSelector(config.Scripts);
			Script selectedScript = scriptSelector.LoopList();
			commandService.RunCommand(selectedScript.Command);
		}
		else if (args[0] == "run" && args[1] == "default")
        {
			commandService.RunCommand(config.Scripts[0].Command);
		}
	}
} 