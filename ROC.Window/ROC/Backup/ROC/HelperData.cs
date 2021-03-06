using System;
using System.Data;
using System.Collections.Generic;

using RDSEx;
using CSVEx;
using MarketDataEx;
using DictionaryEx;
using SerializationEx;
using System.Diagnostics;

namespace ROC
{
	// Main Orders Collection
	public class HelperOrdersData : HelperDataBase
	{
		private DataTable _optionTypes;
		public DataTable OptionTypes
		{
			get
			{
				if (_optionTypes == null)
				{
					_optionTypes = new DataTable();

					_optionTypes.Columns.Add(new DataColumn("Type", Type.GetType("System.String")));

					List<DataColumn> keyColumns = new List<DataColumn>();
					keyColumns.Add(_optionTypes.Columns["Type"]);
					_optionTypes.PrimaryKey = keyColumns.ToArray();

					_optionTypes.Rows.Add(_optionTypes.NewRow()["Type"] = "Call");
					_optionTypes.Rows.Add(_optionTypes.NewRow()["Type"] = "Put");

					_optionTypes.DefaultView.Sort = "Type";
				}
				return _optionTypes;
			}
			set
			{
				_optionTypes = value;
			}
		}

		private DataTable _baseOrderTypes;
		public DataTable BaseOrderTypes
		{
			get
			{
				if (_baseOrderTypes == null)
				{
					_baseOrderTypes = new DataTable();

					_baseOrderTypes.Columns.Add(new DataColumn("Type", Type.GetType("System.String")));

					List<DataColumn> keyColumns = new List<DataColumn>();
					keyColumns.Add(_baseOrderTypes.Columns["Type"]);
					_baseOrderTypes.PrimaryKey = keyColumns.ToArray();

					_baseOrderTypes.Rows.Add(_baseOrderTypes.NewRow()["Type"] = "MARKET");
					_baseOrderTypes.Rows.Add(_baseOrderTypes.NewRow()["Type"] = "LIMIT");
					_baseOrderTypes.Rows.Add(_baseOrderTypes.NewRow()["Type"] = "MOC");
					_baseOrderTypes.Rows.Add(_baseOrderTypes.NewRow()["Type"] = "MOO");
					_baseOrderTypes.Rows.Add(_baseOrderTypes.NewRow()["Type"] = "LOC");
					_baseOrderTypes.Rows.Add(_baseOrderTypes.NewRow()["Type"] = "STOP");
					_baseOrderTypes.Rows.Add(_baseOrderTypes.NewRow()["Type"] = "STOPLIMIT");

					_baseOrderTypes.DefaultView.Sort = "Type";
				}
				return _baseOrderTypes;
			}
		}

		private DataTable _stockOrderTypes;
		public DataTable StockOrderTypes
		{
			get
			{
				if (_stockOrderTypes == null)
				{
					_stockOrderTypes = BaseOrderTypes.Copy();
					_stockOrderTypes.Rows.Add(_stockOrderTypes.NewRow()["Type"] = "OCO");
					_stockOrderTypes.Rows.Add(_stockOrderTypes.NewRow()["Type"] = "PEG MKT");
					_stockOrderTypes.Rows.Add(_stockOrderTypes.NewRow()["Type"] = "PEG PRI");
					_stockOrderTypes.Rows.Add(_stockOrderTypes.NewRow()["Type"] = "PEG MID");
					_stockOrderTypes.Rows.Add(_stockOrderTypes.NewRow()["Type"] = "IMBOO");
					_stockOrderTypes.Rows.Add(_stockOrderTypes.NewRow()["Type"] = "IMBOC");
					_stockOrderTypes.Rows.Add(_stockOrderTypes.NewRow()["Type"] = "IMBOI");
					_stockOrderTypes.Rows.Add(_stockOrderTypes.NewRow()["Type"] = "VWAP MKT");
					_stockOrderTypes.Rows.Add(_stockOrderTypes.NewRow()["Type"] = "VWAP LIM");
					_stockOrderTypes.Rows.Add(_stockOrderTypes.NewRow()["Type"] = "GVWAP");
					_stockOrderTypes.TableName = "STK";
				}
				return _stockOrderTypes;
			}
			set
			{
				_stockOrderTypes = value;
			}
		}

		private DataTable _futureOrderTypes;
		public DataTable FutureOrderTypes
		{
			get
			{
				if (_futureOrderTypes == null)
				{
					_futureOrderTypes = BaseOrderTypes.Copy();
					_futureOrderTypes.Rows.Add(_futureOrderTypes.NewRow()["Type"] = "OCO");
					_futureOrderTypes.TableName = "FUT";
				}
				return _futureOrderTypes;
			}
			set
			{
				_futureOrderTypes = value;
			}
		}

		private DataTable _autoSpreadOrderTypes;
		public DataTable AutoSpreadOrderTypes
		{
			get
			{
				if (_autoSpreadOrderTypes == null)
				{
					_autoSpreadOrderTypes = BaseOrderTypes.Clone();
					_autoSpreadOrderTypes.Rows.Add(_autoSpreadOrderTypes.NewRow()["Type"] = "LIMIT");
				}
				return _autoSpreadOrderTypes;
			}
			set
			{
				_autoSpreadOrderTypes = value;
			}
		}

		private DataTable _optionOrderTypes;
		public DataTable OptionOrderTypes
		{
			get
			{
				if (_optionOrderTypes == null)
				{
					_optionOrderTypes = BaseOrderTypes.Copy();
				}
				return _optionOrderTypes;
			}
			set
			{
				_optionOrderTypes = value;
			}
		}

		private DataTable _durations;
		public DataTable Durations
		{
			get
			{
				if (_durations == null)
				{
					_durations = new DataTable();

					_durations.Columns.Add(new DataColumn("Duration", Type.GetType("System.String")));

					List<DataColumn> keyColumns = new List<DataColumn>();
					keyColumns.Add(_durations.Columns["Duration"]);
					_durations.PrimaryKey = keyColumns.ToArray();

					_durations.Rows.Add(_durations.NewRow()["Duration"] = "DAY");
					_durations.Rows.Add(_durations.NewRow()["Duration"] = "GTC");
					_durations.Rows.Add(_durations.NewRow()["Duration"] = "IOC");
					_durations.Rows.Add(_durations.NewRow()["Duration"] = "FOK");
					_durations.Rows.Add(_durations.NewRow()["Duration"] = "OPG");

					_durations.DefaultView.Sort = "Duration";
				}
				return _durations;
			}
			set
			{
				_durations = value;
			}
		}

		private DataTable _stockDurations;
		public DataTable StockDurations
		{
			get
			{
				if (_stockDurations == null)
				{
					_stockDurations = Durations.Copy();
				}
				return _stockDurations;
			}
			set
			{
				_stockDurations = value;
			}
		}

		private DataTable _autoSpreadDurations;
		public DataTable AutoSpreadDurations
		{
			get
			{
				if (_autoSpreadDurations == null)
				{
					_autoSpreadDurations = Durations.Clone();
					_autoSpreadDurations.Rows.Add(_durations.NewRow()["Duration"] = "DAY");
				}
				return _autoSpreadDurations;
			}
			set
			{
				_autoSpreadDurations = value;
			}
		}

		private DataTable _stokAlgoTypes;
		public DataTable StokAlgoTypes
		{
			get
			{
				if (_stokAlgoTypes == null)
				{
					_stokAlgoTypes = new DataTable();

					_stokAlgoTypes.Columns.Add(new DataColumn("AlgoType", Type.GetType("System.String")));

					List<DataColumn> keyColumns = new List<DataColumn>();
					keyColumns.Add(_durations.Columns["AlgoType"]);
					_stokAlgoTypes.PrimaryKey = keyColumns.ToArray();

					_stokAlgoTypes.Rows.Add(_stokAlgoTypes.NewRow()["AlgoType"] = "");
					_stokAlgoTypes.Rows.Add(_stokAlgoTypes.NewRow()["AlgoType"] = "TWAP");
					_stokAlgoTypes.Rows.Add(_stokAlgoTypes.NewRow()["AlgoType"] = "VWAP");
					_stokAlgoTypes.Rows.Add(_stokAlgoTypes.NewRow()["AlgoType"] = "GVWAP");

					_stokAlgoTypes.DefaultView.Sort = "AlgoType";
				}
				return _stokAlgoTypes;
			}
			set
			{
				_stokAlgoTypes = value;
			}
		}

		private Dictionary<string, ROCOrder> _rocItems;
		public Dictionary<string, ROCOrder> RocItems
		{
			get
			{
				if (_rocItems == null)
				{
					_rocItems = new Dictionary<string, ROCOrder>();
				}
				return _rocItems;
			}
			set
			{
				_rocItems = value;
			}
		}

		public override void SetTable()
		{
			Table = new DataTable("Orders");

			Table.Columns.Add(new DataColumn("Tag", Type.GetType("System.String")));
			List<DataColumn> keyColumns = new List<DataColumn>();
			keyColumns.Add(Table.Columns["Tag"]);
			Table.Columns.Add(new DataColumn("Symbol", Type.GetType("System.String")));
			Table.Columns.Add(new DataColumn("SymbolDetail", Type.GetType("System.String")));
			Table.Columns.Add(new DataColumn("SymbolDisplay", Type.GetType("System.String")));
			Table.Columns.Add(new DataColumn("Status", Type.GetType("System.Int64")));
			Table.Columns.Add(new DataColumn("Side", Type.GetType("System.Int64")));
			Table.Columns.Add(new DataColumn("Qty", Type.GetType("System.Int64")));
			Table.Columns.Add(new DataColumn("Price", Type.GetType("System.Double")));
			Table.Columns.Add(new DataColumn("StopPrice", Type.GetType("System.Double")));
			Table.Columns.Add(new DataColumn("PegPrice", Type.GetType("System.Double")));
			Table.Columns.Add(new DataColumn("LeaveQty", Type.GetType("System.Int64")));
			Table.Columns.Add(new DataColumn("CumQty", Type.GetType("System.Int64")));
			Table.Columns.Add(new DataColumn("AvgPrice", Type.GetType("System.Double")));
			Table.Columns.Add(new DataColumn("OrderType", Type.GetType("System.Int64")));
			Table.Columns.Add(new DataColumn("TIF", Type.GetType("System.Int64")));
			Table.Columns.Add(new DataColumn("AlgoType", Type.GetType("System.Int64")));
			Table.Columns.Add(new DataColumn("AlgoEndTime", Type.GetType("System.String")));
			Table.Columns.Add(new DataColumn("DestID", Type.GetType("System.Int64")));
			Table.Columns.Add(new DataColumn("OmTime", Type.GetType("System.DateTime")));
			Table.Columns.Add(new DataColumn("ClearingAcct", Type.GetType("System.String")));
			Table.Columns.Add(new DataColumn("ContractSize", Type.GetType("System.Double")));
			Table.Columns.Add(new DataColumn("TickSize", Type.GetType("System.Double")));
			Table.Columns.Add(new DataColumn("DisplayFactor", Type.GetType("System.Double")));

			Table.Columns.Add(new DataColumn("OMTag", Type.GetType("System.String")));
			Table.Columns.Add(new DataColumn("SecType", Type.GetType("System.String")));
			Table.Columns.Add(new DataColumn("Text", Type.GetType("System.String")));

			Table.Columns.Add(new DataColumn("ParentTag", Type.GetType("System.String")));
			Table.Columns.Add(new DataColumn("Echo", Type.GetType("System.String")));
			Table.Columns.Add(new DataColumn("CplxOrderType", Type.GetType("System.Int64")));

			Table.PrimaryKey = keyColumns.ToArray();
			Table.CaseSensitive = true;

			SearchView = new DataView(Table);
			SearchView.Sort = "Tag";
		}

		// Used by RDS When it first got all the orders from DB
		public void Update(Dictionary<string, ROCOrder> orders)
		{
			if (GLOBAL.HRDS.GotRocOrders)
			{
				lock (Table)
				{
					string[] keys = new string[orders.Count];
					orders.Keys.CopyTo(keys, 0);
					foreach (string key in keys)
					{
						orders[key] = Update(orders[key]);
					}
				}
			}
		}

		public ROCOrder Update(ROCOrder order)
		{
			if (!RocItems.ContainsKey(order.Tag))
			{
				RocItems.Add(order.Tag, order);
			}
			else
			{
				// Update Only Active Orders
				if (RocItems[order.Tag].IsActive)
				{
					RocItems[order.Tag].Status = order.Status;
					RocItems[order.Tag].LeaveQty = order.LeaveQty;
					RocItems[order.Tag].CumQty = order.CumQty;

					if (order.UpdateOrder)
					{
						RocItems[order.Tag].Qty = order.Qty;
						RocItems[order.Tag].Price = order.Price;
						RocItems[order.Tag].StopPrice = order.StopPrice;
						RocItems[order.Tag].PegPrice = order.PegPrice;
						RocItems[order.Tag].AvgPrice = order.AvgPrice;
					}
					else
					{
						// Container back fill
						order.Symbol = RocItems[order.Tag].Symbol;
						if (RocItems[order.Tag].Price != 0)
						{
							order.Price = RocItems[order.Tag].Price;
						}
						if (RocItems[order.Tag].StopPrice != 0)
						{
							order.StopPrice = RocItems[order.Tag].StopPrice;
						}
						if (RocItems[order.Tag].PegPrice != 0)
						{
							order.PegPrice = RocItems[order.Tag].PegPrice;
						}
						if (RocItems[order.Tag].AvgPrice != 0)
						{
							order.AvgPrice = RocItems[order.Tag].AvgPrice;
						}
					}

					RocItems[order.Tag].OrderType = order.OrderType;
					RocItems[order.Tag].TIF = order.TIF;
					RocItems[order.Tag].OmTime = order.OmTime;
					RocItems[order.Tag].Text = order.Text;
				}
			}

			if (!Keys.Contains(order.Tag))
			{
				Keys.Add(order.Tag);

				Table.Rows.Add(new object[] {
					order.Tag,
					order.Symbol,
					order.SymbolDetail,
					order.SymbolDisplay,
					order.Status,
					order.Side,
					order.Qty,
					order.Price,
					order.StopPrice,
					order.PegPrice,
					order.LeaveQty,
					order.CumQty,
					order.AvgPrice,
					order.OrderType,
					order.TIF,
					order.AlgoType,
					order.EndTime,
					order.DestID,
					order.OmTime,
					order.ClearingAcct,
					order.ContractSize,
					order.TickSize,
					order.DisplayFactor,
					order.OmTag,
					order.SecType,
					order.Text,
					order.ParentTag,
					order.ClientEcho,
					order.CplxOrderType });
			}
			else
			{
				DataRowView[] rows = SearchView.FindRows(order.Tag);
				foreach (DataRowView row in rows)
				{
					row["Status"] = order.Status;
					row["LeaveQty"] = order.LeaveQty;
					row["CumQty"] = order.CumQty;

					if (RocItems[order.Tag].UpdateOrder)
					{
						row["Qty"] = order.Qty;
						row["Price"] = order.Price;
						row["StopPrice"] = order.StopPrice;
						row["PegPrice"] = order.PegPrice;
						row["AvgPrice"] = order.AvgPrice;
					}

					row["OrderType"] = order.OrderType;
					row["TIF"] = order.TIF;
					row["AlgoType"] = order.AlgoType;
					row["OmTime"] = order.OmTime;
					row["Text"] = order.Text;
				}
			}

			return order;
		}

		public ROCOrder GetOrderByOrderID(string orderID)
		{
			if (GLOBAL.HOrders.RocItems.ContainsKey(orderID))
			{
				return GLOBAL.HOrders.RocItems[orderID];
			}

			return null;
		}

		#region - Export & Import -

		public void Import(string username)
		{
			try
			{
				if (GLOBAL.HROM.Status == HelperROM.StatusTypes.Started)
				{
					string data = HelperFile.Load(Configuration.Path.Default.OrderPath, String.Format(@"{0}_{1:G}{2:G3}.orders", username, DateTime.Today.Year, DateTime.Today.DayOfYear));

					if (data != "")
					{
						byte[] bytes = System.Convert.FromBase64String(data);
						Dictionary<string, ROCOrder> orders = (Dictionary<string, ROCOrder>)new ToBinary().Deserialize(bytes, SerializationTypes.Normal);

						Keys.Clear();
						RocItems.Clear();
						Table.Clear();

						Update(orders);
					}
				}
			}
			catch (Exception ex)
			{
				GLOBAL.HROC.AddToException(ex);
			}
		}

		public void Export()
		{
			if (GLOBAL.HROM.UserName != "")
			{
				if (RocItems != null && RocItems.Count > 0)
				{
					byte[] bytes = new ToBinary().Serialize(RocItems, SerializationTypes.Normal);
					string data = System.Convert.ToBase64String(bytes);

					HelperFile.Save(data, Configuration.Path.Default.OrderPath, String.Format(@"{0}_{1:G}{2:G3}.orders", GLOBAL.HROM.UserName, DateTime.Today.Year, DateTime.Today.DayOfYear));
				}
			}
		}

		#endregion
	}

	// Main Executions Collection
	public class HelperExecutionsData : HelperDataBase
	{
		private Dictionary<string, ROCExecution> _rocItems;
		public Dictionary<string, ROCExecution> RocItems
		{
			get
			{
				if (_rocItems == null)
				{
					_rocItems = new Dictionary<string, ROCExecution>();
				}
				return _rocItems;
			}
			set
			{
				_rocItems = value;
			}
		}

		private Dictionary<string, TPOSExecution> _tposItems;
		public Dictionary<string, TPOSExecution> TposItems
		{
			get
			{
				if (_tposItems == null)
				{
					_tposItems = new Dictionary<string, TPOSExecution>();
				}
				return _tposItems;
			}
			set
			{
				_tposItems = value;
			}
		}

		public override void SetTable()
		{
			Table = new DataTable("Trades");

			Table.Columns.Add(new DataColumn("ExecID", Type.GetType("System.String")));
			List<DataColumn> keyColumns = new List<DataColumn>();
			keyColumns.Add(Table.Columns["ExecID"]);
			Table.Columns.Add(new DataColumn("Symbol", Type.GetType("System.String")));
			Table.Columns.Add(new DataColumn("SymbolDetail", Type.GetType("System.String")));
			Table.Columns.Add(new DataColumn("SymbolDisplay", Type.GetType("System.String")));
			Table.Columns.Add(new DataColumn("Side", Type.GetType("System.Int64")));
			Table.Columns.Add(new DataColumn("Qty", Type.GetType("System.Int64")));
			Table.Columns.Add(new DataColumn("Price", Type.GetType("System.Double")));
			Table.Columns.Add(new DataColumn("TradeValue", Type.GetType("System.Double")));
			Table.Columns.Add(new DataColumn("DestID", Type.GetType("System.Int64")));
			Table.Columns.Add(new DataColumn("OmTime", Type.GetType("System.DateTime")));
			Table.Columns.Add(new DataColumn("ClearingAcct", Type.GetType("System.String")));
			Table.Columns.Add(new DataColumn("ContractSize", Type.GetType("System.Double")));
			Table.Columns.Add(new DataColumn("TickSize", Type.GetType("System.Double")));
			Table.Columns.Add(new DataColumn("DisplayFactor", Type.GetType("System.Double")));

			Table.Columns.Add(new DataColumn("OMTag", Type.GetType("System.String")));
			Table.Columns.Add(new DataColumn("SecType", Type.GetType("System.String")));
			Table.Columns.Add(new DataColumn("TPOS", Type.GetType("System.Int64")));

			Table.Columns.Add(new DataColumn("CplxOrderType", Type.GetType("System.Int64")));

			Table.PrimaryKey = keyColumns.ToArray();

			SearchView = new DataView(Table);
			SearchView.Sort = "ExecID";
		}

		// Used by RDS When it first got all the roc executions from DB
		public void Update(Dictionary<string, ROCExecution> trades)
		{
			if (GLOBAL.HRDS.GotRocExecutions)
			{
				lock (Table)
				{
					foreach (ROCExecution trade in trades.Values)
					{
						Update(trade);
					}
				}
			}
		}
		
		public void Update(ROCExecution trade)
		{
			if (trade.UpdateTrade)
			{
				if (RocItems.ContainsKey(trade.OmExecTag))
				{
					RocItems[trade.OmExecTag] = trade;
				}
				else
				{
					RocItems.Add(trade.OmExecTag, trade);
				}

				if (!Keys.Contains(trade.OmExecTag))
				{
					Keys.Add(trade.OmExecTag);

					Table.Rows.Add(new object[] {
		            trade.OmExecTag,
		            trade.Symbol,
		            trade.SymbolDetail,
					trade.SymbolDisplay,
		            trade.Side,
		            trade.Qty,
		            trade.Price,
		            trade.TradeValue,
		            trade.DestID,
		            trade.TradeTime,
		            trade.ClearingAcct,
		            trade.ContractSize,
		            trade.TickSize,
		            trade.DisplayFactor,
		            trade.OmTag,
		            trade.SecType,
		            0,
					trade.CplxOrderType });
				}
				else
				{
					DataRowView[] rows = SearchView.FindRows(trade.OmExecTag);
					foreach (DataRowView row in rows)
					{
						row["Qty"] = trade.Qty;
						row["Price"] = trade.Price;
						row["TradeValue"] = trade.TradeValue;
						if (trade.TradeTime != null)
						{
							row["OmTime"] = trade.TradeTime;
						}
					}
				}
			}
		}

		// Used by RDS When it first got all the executions tpos
		public void Update(Dictionary<string, TPOSExecution> trades)
		{
			if (GLOBAL.HRDS.GotTposExecutions)
			{
				lock (Table)
				{
					foreach (TPOSExecution trade in trades.Values)
					{
						Update(trade);
					}
				}
			}
		}

		public void Update(TPOSExecution trade)
		{
			if (TposItems.ContainsKey(trade.TradeID))
			{
				TposItems[trade.TradeID] = trade;
			}
			else
			{
				TposItems.Add(trade.TradeID, trade);
			}

			if (!Keys.Contains(trade.TradeID))
			{
				Keys.Add(trade.TradeID);

				Table.Rows.Add(new object[] {
		            trade.TradeID,
		            trade.Symbol,
		            trade.SymbolDetail,
					trade.SymbolDisplay,
		            trade.Side,
		            trade.Qty,
		            trade.Price,
		            trade.TradeValue,
		            trade.DestID,
		            trade.TradeTime,
		            trade.ClearingAcct,
		            trade.ContractSize,
		            trade.TickSize,
		            trade.DisplayFactor,
		            trade.OmTag,
		            trade.SecType,
		            1});
			}
			else
			{
				DataRowView[] rows = SearchView.FindRows(trade.TradeID);
				foreach (DataRowView row in rows)
				{
					row["Qty"] = trade.Qty;
					row["Price"] = trade.Price;
					row["TradeValue"] = trade.TradeValue;
					row["OmTime"] = trade.TradeTime;
				}
			}
		}

		#region - Export & Import -

		public void Import(string username)
		{
			try
			{
				if (GLOBAL.HROM.Status == HelperROM.StatusTypes.Started)
				{
					string data = HelperFile.Load(Configuration.Path.Default.TradePath, String.Format(@"{0}_{1:G}{2:G3}.trades", username, DateTime.Today.Year, DateTime.Today.DayOfYear));

					if (data != "")
					{
						byte[] bytes = System.Convert.FromBase64String(data);
						Dictionary<string, ROCExecution> trades = (Dictionary<string, ROCExecution>)new ToBinary().Deserialize(bytes, SerializationTypes.Normal);

						// Don't clear the Trade Table, because trades are duplicated.
						//Keys.Clear();
						RocItems.Clear();
						//Table.Clear();

						Update(trades);

						// Update ROC Trades when loading from local file
						GLOBAL.HPositions.Update(trades);
					}
				}
			}
			catch (Exception ex)
			{
				GLOBAL.HROC.AddToException(ex);
			}
		}

		public void Export()
		{
			if (GLOBAL.HROM.UserName != "")
			{
				if (RocItems != null && RocItems.Count > 0)
				{
					byte[] bytes = new ToBinary().Serialize(RocItems, SerializationTypes.Normal);
					string data = System.Convert.ToBase64String(bytes);

					HelperFile.Save(data, Configuration.Path.Default.TradePath, String.Format(@"{0}_{1:G}{2:G3}.trades", GLOBAL.HROM.UserName, DateTime.Today.Year, DateTime.Today.DayOfYear));
				}
			}
		}

		#endregion
	}

	// Main Positions Collection
	public class HelperPositionsData : HelperDataBase
	{
		private Dictionary<string, TPOSPosition> _rocItems;
		public Dictionary<string, TPOSPosition> RocItems
		{
			get
			{
				if (_rocItems == null)
				{
					_rocItems = new Dictionary<string, TPOSPosition>();
				}
				return _rocItems;
			}
			set
			{
				_rocItems = value;
			}
		}

		private Dictionary<string, TPOSPosition> _tposItems;
		public Dictionary<string, TPOSPosition> TposItems
		{
			get
			{
				if (_tposItems == null)
				{
					_tposItems = new Dictionary<string, TPOSPosition>();
				}
				return _tposItems;
			}
			set
			{
				_tposItems = value;
			}
		}

		public override void SetTable()
		{
			Table = new DataTable("Positions");

			Table.Columns.Add(new DataColumn("PositionKey", Type.GetType("System.String")));
			//List<DataColumn> keyColumns = new List<DataColumn>();
			//keyColumns.Add(Table.Columns["PositionKey"]);

			Table.Columns.Add(new DataColumn("Symbol", Type.GetType("System.String")));
			Table.Columns.Add(new DataColumn("SymbolDetail", Type.GetType("System.String")));
			Table.Columns.Add(new DataColumn("SymbolDisplay", Type.GetType("System.String")));
			Table.Columns.Add(new DataColumn("BidPrice", Type.GetType("System.Double")));
			Table.Columns.Add(new DataColumn("BidSize", Type.GetType("System.Int64")));
			Table.Columns.Add(new DataColumn("AskPrice", Type.GetType("System.Double")));
			Table.Columns.Add(new DataColumn("AskSize", Type.GetType("System.Int64")));
			Table.Columns.Add(new DataColumn("LastTraded", Type.GetType("System.Double")));
			Table.Columns.Add(new DataColumn("NetChange", Type.GetType("System.Double")));
			Table.Columns.Add(new DataColumn("PctChange", Type.GetType("System.Double")));
			Table.Columns.Add(new DataColumn("Volume", Type.GetType("System.Int64")));
			Table.Columns.Add(new DataColumn("ClearingAcct", Type.GetType("System.String")));
			Table.Columns.Add(new DataColumn("Trader", Type.GetType("System.String")));
			Table.Columns.Add(new DataColumn("OpenQty", Type.GetType("System.Int64")));
			Table.Columns.Add(new DataColumn("OpenAvg", Type.GetType("System.Double")));
			Table.Columns.Add(new DataColumn("BuyQty", Type.GetType("System.Int64")));
			Table.Columns.Add(new DataColumn("BuyAvg", Type.GetType("System.Double")));
			Table.Columns.Add(new DataColumn("SellQty", Type.GetType("System.Int64")));
			Table.Columns.Add(new DataColumn("SellAvg", Type.GetType("System.Double")));
			Table.Columns.Add(new DataColumn("CurrentQty", Type.GetType("System.Int64")));
			Table.Columns.Add(new DataColumn("ContractSize", Type.GetType("System.Double")));
			Table.Columns.Add(new DataColumn("TickSize", Type.GetType("System.Double")));
			Table.Columns.Add(new DataColumn("DisplayFactor", Type.GetType("System.Double")));

			Table.Columns.Add(new DataColumn("OpenPnL", Type.GetType("System.Double")));
			Table.Columns.Add(new DataColumn("DayPnL", Type.GetType("System.Double")));
			Table.Columns.Add(new DataColumn("DayRealizedPnL", Type.GetType("System.Double")));
			Table.Columns.Add(new DataColumn("TotalPnL", Type.GetType("System.Double")));
			Table.Columns.Add(new DataColumn("MarketValue", Type.GetType("System.Double")));

			Table.Columns.Add(new DataColumn("SecType", Type.GetType("System.String")));
			Table.Columns.Add(new DataColumn("SecurityStatus", Type.GetType("System.String")));
			Table.Columns.Add(new DataColumn("Underlying", Type.GetType("System.String")));
			Table.Columns.Add(new DataColumn("ExpDate", Type.GetType("System.String")));
			Table.Columns.Add(new DataColumn("StrikePrice", Type.GetType("System.String")));
			Table.Columns.Add(new DataColumn("CallPut", Type.GetType("System.String")));

			Table.Columns.Add(new DataColumn("TPOS", Type.GetType("System.String")));
			Table.Columns.Add(new DataColumn("SettlePrice", Type.GetType("System.Double")));

			//Table.PrimaryKey = keyColumns.ToArray();
		}

		#region - TPOS Position -

		// Used by RDS When it first got all positions from TPOS
		public void Update(Dictionary<string, TPOSPosition> positions)
		{
			if (GLOBAL.HRDS.GotTposPositions)
			{
				lock (Table)
				{
					foreach (TPOSPosition position in positions.Values)
					{
						Update(position);
					}
				}
			}
		}

		public void Update(TPOSPosition position)
		{
			string key = position.PositionKey;
			double cost = 0;

			lock (TposItems)
			{
				TPOSPosition currentPosition;
				if (TposItems.ContainsKey(key))
				{
					currentPosition = TposItems[key];

					if (position.OpenQty > 0)
					{
						currentPosition.OpenQty = position.OpenQty;
						currentPosition.OpenAvg = position.OpenAvg;
					}

					if (position.BuyQty > 0)
					{
						cost = (currentPosition.BuyQty * currentPosition.BuyAvg) + (position.BuyQty * position.BuyAvg);
						currentPosition.BuyQty = currentPosition.BuyQty + position.BuyQty;
						currentPosition.BuyAvg = cost / currentPosition.BuyQty;
					}

					if (position.SellQty > 0)
					{
						cost = (currentPosition.SellQty * currentPosition.SellAvg) + (position.SellQty * position.SellAvg);
						currentPosition.SellQty = currentPosition.SellQty + position.SellQty;
						currentPosition.SellAvg = cost / currentPosition.SellQty;
					}

					TposItems[key] = currentPosition;
				}
				else
				{
					currentPosition = position;
					TposItems.Add(key, currentPosition);
				}
			}
		}

		#endregion

		#region - ROC Trades -

		// Used by RDS When it first got all the roc executions from DB
		public void Update(Dictionary<string, ROCExecution> trades)
		{
			if (GLOBAL.HRDS.GotRocExecutions)
			{
				lock (Table)
				{
					foreach (ROCExecution trade in trades.Values)
					{
						Update(trade);
					}
				}
			}
		}

		public void Update(ROCExecution trade)
		{
		    string key = trade.PositionKey;
			double cost = 0;
			TPOSPosition position;
			
		    lock (RocItems)
		    {
		        if (RocItems.ContainsKey(key))
		        {
		            position = RocItems[key];
		        }
		        else
		        {
		            position = new TPOSPosition();

					position.Symbol = trade.Symbol;
					//position.SymbolDetail,
					position.Underlying = trade.Underlying;
					position.ExpDate = trade.ExpDate;
					position.StrikePrice = trade.StrikePrice;
					position.CallPut = trade.CallPut;
					position.SecType = trade.SecType;
					//position.LastTraded,
					//position.NetChange,
					//position.PctChange,
					//position.TotalVolume,
					if (trade.ClearingAcct.Length > 5)
					{
						position.ClearingAcct = trade.ClearingAcct.Substring(0, 5);
					}
					else
					{
						position.ClearingAcct = trade.ClearingAcct;
					}
					position.Trader = trade.LocalAcct;
					//position.OpenQty,
					//position.OpenAvg,
					//position.CurrentQty,
					//position.ContractSize,
					//position.OpenPnL,
					//position.DayPnL,
					//position.DayRealizedPnL,
					//position.TotalPnL,

		            RocItems.Add(key, position);
		        }

				switch (trade.Side)
				{
					case CSVFieldIDs.SideCodes.Buy:
						cost = (position.BuyQty * position.BuyAvg) + (trade.Qty * trade.Price);
						position.BuyQty = position.BuyQty + trade.Qty;
						position.BuyAvg = cost / position.BuyQty;
						break;
					case CSVFieldIDs.SideCodes.Sell:
					case CSVFieldIDs.SideCodes.Short:
					default:
						cost = (position.SellQty * position.SellAvg) + (trade.Qty * trade.Price);
						position.SellQty = position.SellQty + trade.Qty;
						position.SellAvg = cost / position.SellQty;
						break;
				}

		        RocItems[key] = position;
		    }
		}

		#endregion

		#region - TPOS Trades -

		// Used by RDS When it first got all the executions from Tpos
		public void Update(Dictionary<string, TPOSExecution> trades)
		{
			if (GLOBAL.HRDS.GotTposExecutions)
			{
				lock (Table)
				{
					foreach (TPOSExecution trade in trades.Values)
					{
						Update(trade);
					}
				}
			}
		}

		public void Update(TPOSExecution trade)
		{
			// Filter out Auot Blance Trades from TPOS
			if (trade.Price > 0)
			{
				string key = trade.PositionKey;
				double cost = 0;
				TPOSPosition position;

				lock (TposItems)
				{
					if (TposItems.ContainsKey(key))
					{
						position = TposItems[key];
					}
					else
					{
						position = new TPOSPosition();

						position.Symbol = trade.Symbol;
						//position.SymbolDetail,
						position.Underlying = trade.Underlying;
						position.ExpDate = trade.ExpDate;
						position.StrikePrice = trade.StrikePrice;
						position.CallPut = trade.CallPut;
						position.SecType = trade.SecType;
						//position.LastTraded,
						//position.NetChange,
						//position.PctChange,
						//position.TotalVolume,
						if (trade.ClearingAcct.Length > 5)
						{
							position.ClearingAcct = trade.ClearingAcct.Substring(0, 5);
						}
						else
						{
							position.ClearingAcct = trade.ClearingAcct;
						}
						position.Trader = trade.Trader;
						//position.OpenQty,
						//position.OpenAvg,
						//position.CurrentQty,
						//position.ContractSize,
						//position.OpenPnL,
						//position.DayPnL,
						//position.DayRealizedPnL,
						//position.TotalPnL,

						TposItems.Add(key, position);
					}

					switch (trade.Side)
					{
						case CSVFieldIDs.SideCodes.Buy:
							cost = (position.BuyQty * position.BuyAvg) + (trade.Qty * trade.Price);
							position.BuyQty = position.BuyQty + trade.Qty;
							position.BuyAvg = cost / position.BuyQty;
							break;
						case CSVFieldIDs.SideCodes.Sell:
						case CSVFieldIDs.SideCodes.Short:
						default:
							cost = (position.SellQty * position.SellAvg) + (trade.Qty * trade.Price);
							position.SellQty = position.SellQty + trade.Qty;
							position.SellAvg = cost / position.SellQty;
							break;
					}

					TposItems[key] = position;
				}
			}
		}
		
		#endregion
	}

	#region - Main Market Data -

	// Main Market Data Collection
	public class HelperMarketData
	{
		private Dictionary<string, MDServerToClient> _current;
		public Dictionary<string, MDServerToClient> Current
		{
			get
			{
				if (_current == null)
				{
					_current = new Dictionary<string, MDServerToClient>();
				}
				return _current;
			}
		}
	}

	#endregion
}
