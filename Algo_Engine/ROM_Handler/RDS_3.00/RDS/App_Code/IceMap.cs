using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Diagnostics;

/// <summary>
/// Summary description for IceMap
/// </summary>
public static class ICEMap
{
	private static DataTable _futureMap;
	public static DataTable FutureMap
	{
		get
		{
			try
			{
				if (_futureMap == null)
				{
					GetFutureMap(ref _futureMap, ConfigurationManager.AppSettings["ICEFuturesDef"]);
				}
			}
			catch (Exception ex)
			{
				Debug.Assert(RdsGlobal.InIDE, ex.Message, ex.StackTrace);
			}
			return _futureMap;
		}
	}
	private static void GetFutureMap(ref DataTable table, string path)
	{
		try
		{
			table = new DataTable("ICESecDef");
			table.Columns.Add("Symbol");
			table.Columns.Add("SecType");
			table.Columns.Add("TickSize");
			table.Columns.Add("ContractSize");
			table.Columns.Add("ExpDate");
			table.Columns.Add("DataSource");
			table.Columns.Add("MDSymbol");
			table.ReadXml(path);
		}
		catch (Exception ex)
		{
			Debug.Assert(RdsGlobal.InIDE, ex.Message, ex.StackTrace);
		}
	}
	public static string ReloadFutureMap()
	{
		_futureMap = null;

		return FutureMap.Rows.Count.ToString();
	}

	private static DataTable _spreadMap;
	public static DataTable SpreadMap
	{
		get
		{
			try
			{
				if (_spreadMap == null)
				{
					GetSpreadMap(ref _spreadMap, ConfigurationManager.AppSettings["ICESpreadsDef"]);
				}
			}
			catch (Exception ex)
			{
				Debug.Assert(RdsGlobal.InIDE, ex.Message, ex.StackTrace);
			}
			return _spreadMap;
		}
	}
	private static void GetSpreadMap(ref DataTable table, string path)
	{
		try
		{
			table = new DataTable("ICESecDef");
			table.Columns.Add("Symbol");
			table.Columns.Add("SecType");
			table.Columns.Add("TickSize");
			table.Columns.Add("ContractSize");
			table.Columns.Add("ExpDate");
			table.Columns.Add("DataSource");
			table.Columns.Add("MDSymbol");
			table.ReadXml(path);
		}
		catch (Exception ex)
		{
			Debug.Assert(RdsGlobal.InIDE, ex.Message, ex.StackTrace);
		}
	}
	public static string ReloadSpreadMap()
	{
		_spreadMap = null;

		return SpreadMap.Rows.Count.ToString();
	}
}
