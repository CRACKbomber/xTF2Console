using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Test.Xbox.XDRPC;
using XDevkit;
using XRPCLib;

namespace xTF2Console
{
	internal class RemoteConsole
	{
		private XRPC xrpc;
		internal RemoteConsole()
		{
			xrpc = new XRPC();
			xrpc.Connect();

			xrpc.Notify(XRPC.XNotiyLogo.UPDATING, "xTF2Console Connected");
		}

		internal void SendCommand(string command)
		{
			// tob

			// cbuff_addtext
			xrpc.Call(0x8609A848, new object[] { command });
			// cbuff_execute
			xrpc.Call(0x8609CE90, new object[] { null });
		}

		internal uint GetTitleID()
		{
			return xrpc.SystemCall(new object[] { xrpc.ResolveFunction("xam.xex", 463) });
		}
	}
}
