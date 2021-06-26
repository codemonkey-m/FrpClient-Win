using System;
using System.Management.Automation;

namespace FrpClient_Win
{
    public class RdpHelper
    {
        public static string GetRdpPort()
        {
            PowerShell ps = PowerShell.Create().AddCommand("Get-ItemProperty")
                .AddParameter("Path", @"HKLM:\SYSTEM\CurrentControlSet\Control\Terminal Server\WinStations\RDP-Tcp");
            IAsyncResult asyncpl = ps.BeginInvoke();
            PSObject result = ps.EndInvoke(asyncpl)[0];

            //foreach (PSObject result in ps.EndInvoke(asyncpl))
            //{
            //    Console.WriteLine("{0}",
            //            result.Members["PortNumber"].Value);
            //}

            return result.Members["PortNumber"].Value.ToString();
        }

        public static bool SetRdpPort(int port)
        {
            PowerShell ps = PowerShell.Create().AddCommand("Set-ItemProperty")
                .AddParameter("Path", @"HKLM:\SYSTEM\CurrentControlSet\Control\Terminal Server\WinStations\RDP-Tcp")
                .AddParameter("name", "PortNumber")
                .AddParameter("Value", port);
            IAsyncResult asyncpl = ps.BeginInvoke();

            PowerShell ps2 = PowerShell.Create().AddCommand("New-NetFirewallRule")
                .AddParameter("DisplayName", @"RDPPORTLatest")
                .AddParameter("Profile", @"Public")
                .AddParameter("Direction", "Inbound")
                .AddParameter("Action", "Allow")
                .AddParameter("Protocol", "TCP")
                .AddParameter("LocalPort", port);
            IAsyncResult asyncpl2 = ps2.BeginInvoke();
            PSObject result = ps2.EndInvoke(asyncpl2)[0];

            if (result.Members["PrimaryStatus"].Value.ToString().Trim() == "1")
            {
                return true;
            }
            return false;
        }

        public static bool GetRdpStatus()
        {
            PowerShell ps = PowerShell.Create().AddCommand("Get-ItemProperty")
                .AddParameter("Path", @"HKLM:\SYSTEM\CurrentControlSet\Control\Terminal Server\")
                .AddParameter("Name", "fDenyTSConnections");
            IAsyncResult asyncpl = ps.BeginInvoke();
            PSObject result = ps.EndInvoke(asyncpl)[0];
            if (Convert.ToInt32(result.Members["fDenyTSConnections"].Value) == 0)
            {
                return true;
            }
            return false;
        }

        public static void SetRdpStatus(bool swicth)
        {
            string cm1 = $"(gwmi -class win32_terminalservicesetting -namespace \"root\\cimv2\\terminalservices\").setallowtsconnections({Convert.ToInt32(swicth)})";
            string cm2 = $"Get-NetFirewallRule -Name RemoteDesktop* | Set-NetFirewallRule -Enabled {swicth}";
            PowerShell ps = PowerShell.Create().AddScript(cm1);
            PowerShell ps2 = PowerShell.Create().AddScript(cm2);
            IAsyncResult asyncpl = ps.BeginInvoke();
            IAsyncResult asyncpl2 = ps2.BeginInvoke();
            ps.EndInvoke(asyncpl);
            ps2.EndInvoke(asyncpl2);
        }
    }
}
