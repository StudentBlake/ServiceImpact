using ServiceImpact.Properties;
using System;
using System.ServiceProcess;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

public class TrayLogic : ApplicationContext
{
    private static NotifyIcon trayIcon;

    public TrayLogic()
    {
        string appTitle = "Service Impact v" + Application.ProductVersion;

        // Initialize tray icon
        trayIcon = new NotifyIcon()
        {
            Icon = Resources.ServiceImpactIcon,
            Text = appTitle,
            ContextMenu = new ContextMenu(new MenuItem[]
                {
                new MenuItem
                {
                    Text = appTitle,
                    Enabled = false
                },
                new MenuItem("-"),
                new MenuItem{
                    Text = "Service Name: " + Settings.Default.ServiceName,
                    Enabled = false
                },
                new MenuItem{
                    Text = "Service Status: ???",
                    Enabled = false
                },
                new MenuItem("-"),
                new MenuItem("E&xit", OnExit)
                }),
            Visible = true
        };

        // Start async method to watch and stop service
        Task.Run(WatchService);
    }

    // Utils
    private static void WatchService()
    {
        while (true)
        {
            ServiceController service = new ServiceController(Settings.Default.ServiceName);

            Debug.WriteLine(Settings.Default.ServiceName + " state: " + service.Status);

            if (service.Status.Equals(ServiceControllerStatus.Running))
                service.Stop();

            trayIcon.ContextMenu.MenuItems[3].Text = "Service Status: " + service.Status;

            Thread.Sleep(Settings.Default.PollingTime);
        }
    }

    // Event handlers
    private void OnExit(object sender, EventArgs e)
    {
        trayIcon.Visible = false;

        Application.Exit();
    }
}