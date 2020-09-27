# Service Impact
 A tiny program to stop a Windows Service.
 
 ![](https://i.imgur.com/vkg5fGi.png)

### Prerequisites
 - [.NET Framework 4.8 Runtime](https://dotnet.microsoft.com/download/dotnet-framework/thank-you/net48-offline-installer)
 - Administrator privileges 

### Configuration
The program can be configured in the **ServiceImpact.exe.config** file using the following properties:
 - `ServiceName` *[string]* - The name of the Windows Service to stop 
 - `PollingTime` *[int]* - How often to check the Windows Service status (in ms)

### How to use
 1. Configure the **ServiceImpact.exe.config** file (by default, set to Genshin Impact anti-cheat with 1 second polling).
 2. Run the **ServiceImpact.exe** file.
 3. (optional) Create a shortcut and place it in the Startup folder to start the program on boot.

### Why?
 Specifically, Genshin Impact currently has its anti-cheat service always running in the background if the game has been run at least once. This program will prevent that from happening when it's not necessary.

### Alternative
 This can be done with a bat file as seen [here](https://www.reddit.com/r/Genshin_Impact/comments/j06zs0/how_to_fix_the_kernel_anticheat_from_running_in/).