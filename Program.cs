using xTF2Console;

var exitSignal = ".exit";

var rcon = new RemoteConsole();
var titleID = rcon.GetTitleID();

Console.WriteLine("Waiting for The Orange Box to start");
while (titleID != 0x4541080f)
{
	Thread.Sleep(5000);
	titleID = rcon.GetTitleID();
}

Console.WriteLine($"The Orange Box Detected. Begin sending commands once the game is fully loaded (background map is playing.)");
Console.WriteLine($"Type {exitSignal} to exit");

string? cmd = Console.ReadLine();

while (cmd != exitSignal) 
{
	if (cmd == null) break;
	rcon.SendCommand(cmd);
	cmd = Console.ReadLine();
}