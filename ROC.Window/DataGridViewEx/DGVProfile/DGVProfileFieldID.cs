using System;
using System.Collections.Generic;
using System.Text;

namespace DataGridViewEx
{
	public sealed class DGVColumnProfileFieldID
	{
		public sealed class Column
		{
			public const int IsFraction = 101;
			public const int IsNotified = 102;

			public const int ForeColor = 103;
			public const int BackColor = 104;
			public const int Font = 105;

			public const int HeaderForeColor = 106;
			public const int HeaderBackColor = 107;
			public const int HeaderFont = 108;

			public const int DisplayIndex = 109;
			public const int Name = 110;
			public const int Visiable = 111;
			public const int Width = 112;

			public const int SelectedBackColor = 113;
			public const int IsPercent = 114;
		}

		public sealed class Notify
		{
			public const int NotifyType = 201;
			public const int NotifyPositiveColor = 202;
			public const int NotifyPositiveBorderWidth = 103;
			public const int NotifyNegativeColor = 104;
			public const int NotifyNegativeBorderWidth = 105;
		}

		public sealed class OrderStatus
		{
			public const int ParitalFilledColor = 301;
			public const int FilledColor = 302;
			public const int DoneForDayColor = 303;
			public const int CancelledColor = 304;
			public const int ReplacedColor = 305;
			public const int PendingCancelColor = 306;
			public const int StoppedColor = 307;
			public const int RejectedColor = 308;
			public const int CalculatedColor = 309;
			public const int ExpiredColor = 310;
			public const int OpenColor = 311;
			public const int CancelRejectedColor = 312;
			public const int CorrectedColor = 313;
			public const int BustedColor = 314;
			public const int ReplaceRejectedColor = 315;
			public const int ReplacePendingColor = 316;
			public const int OtherColor = 317;
		}

		public sealed class OrderSide
		{
			public const int SellColor = 401;
			public const int BuyColor = 402;
			public const int SellShortColor = 403;
			public const int SSEColor = 404;
		}
	}

	public sealed class DGVProfileFieldID
	{
		public sealed class Grid
		{
			public const int ForeColor = 101;
			public const int SelectedBackColor = 102;
			public const int BackColor = 103;
			public const int LineColor = 104;
			public const int Font = 105;
		}

		public sealed class Order
		{
			public const int RowColorType = 201;

			public const int FilterOutStock = 202;
			public const int FilterOutFuture = 203;
			public const int FilterOutOption = 204;

			public const int FilterOutFilled = 205;
			public const int FilterOutPartialFilled = 206;
			public const int FilterOutReplaced = 207;
			public const int FilterOutOpen = 208;
			public const int FilterOutCancelled = 209;
			public const int FilterOutRejected = 210;
		}
	}
}
