using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

namespace SRLabMDS
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			if (args.Length > 0)
			{
				foreach (string arg in args)
				{
					switch (arg.ToUpper())
					{
						case "-HIDE":
							GLOBAL.AutoHide = true;
							break;
						case "-LBM":
							GLOBAL.AutoStartLBM = true;
							break;
						case "-LOAD":
							GLOBAL.AutoLoad = true;
							break;
						case "-MDS":
							GLOBAL.AutoStartMDS = true;
							break;
						case "-REALTIME":
							Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;
							break;
					}
				}
			}

			if (Process.GetCurrentProcess().PriorityClass != ProcessPriorityClass.RealTime)
			{
				Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
			}

			if (Configuration.User.Default.UseLogRetensionLimit)
			{
				GLOBAL.LOG.Log = new LoggerEx.Logger(Configuration.Path.Default.LogPath, LoggerEx.LogTypes.Log, Configuration.User.Default.LogRetensionDays, Configuration.User.Default.LogFileSizeLimit);
				GLOBAL.LOG.TCP = new LoggerEx.Logger(Configuration.Path.Default.LogPath, LoggerEx.LogTypes.TCP, Configuration.User.Default.LogRetensionDays, Configuration.User.Default.LogFileSizeLimit);
				GLOBAL.LOG.MDS = new LoggerEx.Logger(Configuration.Path.Default.LogPath, LoggerEx.LogTypes.MDS, Configuration.User.Default.LogRetensionDays, Configuration.User.Default.LogFileSizeLimit);
				GLOBAL.LOG.SRLab = new LoggerEx.Logger(Configuration.Path.Default.LogPath, LoggerEx.LogTypes.SRLab, Configuration.User.Default.LogRetensionDays, Configuration.User.Default.LogFileSizeLimit);
				GLOBAL.LOG.BMK = new LoggerEx.Logger(Configuration.Path.Default.LogPath, LoggerEx.LogTypes.Benchmark, Configuration.User.Default.LogRetensionDays, Configuration.User.Default.LogFileSizeLimit);
			}
			else
			{
				GLOBAL.LOG.Log = new LoggerEx.Logger(Configuration.Path.Default.LogPath, LoggerEx.LogTypes.Log, Configuration.User.Default.LogFileSizeLimit);
				GLOBAL.LOG.TCP = new LoggerEx.Logger(Configuration.Path.Default.LogPath, LoggerEx.LogTypes.TCP, Configuration.User.Default.LogFileSizeLimit);
				GLOBAL.LOG.MDS = new LoggerEx.Logger(Configuration.Path.Default.LogPath, LoggerEx.LogTypes.MDS, Configuration.User.Default.LogFileSizeLimit);
				GLOBAL.LOG.SRLab = new LoggerEx.Logger(Configuration.Path.Default.LogPath, LoggerEx.LogTypes.SRLab, Configuration.User.Default.LogFileSizeLimit);
				GLOBAL.LOG.BMK = new LoggerEx.Logger(Configuration.Path.Default.LogPath, LoggerEx.LogTypes.Benchmark, Configuration.User.Default.LogFileSizeLimit);
			}

			try
			{
				Application.Run(new frmMain());
			}
			catch (Exception ex)
			{
				GLOBAL.AddToExecption(ex);
			}
		}
	}
}