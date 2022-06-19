namespace DumbnotesCli
{
    public class ScriptSelector
    {
        private List<Script> scripts;

        public ScriptSelector(List<Script> scripts)
        {
            this.scripts = scripts;
        }

        public Script LoopList()
        {
            int selectedI = 0;

            Console.WriteLine("Select script to run");
            ShowList(selectedI);

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            while (keyInfo.Key != ConsoleKey.Enter)
            {
                if (keyInfo.Key == ConsoleKey.DownArrow || keyInfo.Key == ConsoleKey.UpArrow)
                {
                    ResetConsoleCursor();
                    selectedI = DefineNextSelectedI(selectedI, keyInfo.Key);
                    ShowList(selectedI);
                }
                keyInfo = Console.ReadKey();
            }

            return scripts[selectedI];
        }

        private void ShowList(int hoverI)
        {
            for (int i = 0; i < scripts.Count; i++)
            {
                Script script = scripts[i];
                Console.ForegroundColor = i == hoverI ? ConsoleColor.Green : ConsoleColor.White;
                Console.WriteLine($"{i + 1}: {script.Name.PadRight(26)} - ${script.Description}", ConsoleColor.Green);
            }
        }

        private void ResetConsoleCursor()
        {
            Console.SetCursorPosition(0, Console.CursorTop - scripts.Count);
        }

        private int DefineNextSelectedI(int curSelectedI, ConsoleKey key)
        {
            if (key == ConsoleKey.DownArrow && scripts.Count - 1 == curSelectedI)
                return 0;

            else if (key == ConsoleKey.DownArrow && scripts.Count - 1 != curSelectedI)
                return curSelectedI + 1;

            else if (key == ConsoleKey.UpArrow && curSelectedI == 0)
                return scripts.Count - 1;

            else if (key == ConsoleKey.UpArrow && curSelectedI != 0)
                return curSelectedI - 1;

            return 0;
        }
    }
}
