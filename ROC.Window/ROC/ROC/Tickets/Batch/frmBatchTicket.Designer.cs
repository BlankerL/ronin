namespace ROC
{
	partial class frmBatchTicket
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBatchTicket));
			DataGridViewEx.DGVBasePrinter dgvBasePrinter1 = new DataGridViewEx.DGVBasePrinter();
			System.Drawing.StringFormat stringFormat1 = new System.Drawing.StringFormat();
			System.Drawing.StringFormat stringFormat2 = new System.Drawing.StringFormat();
			System.Drawing.StringFormat stringFormat3 = new System.Drawing.StringFormat();
			System.Drawing.StringFormat stringFormat4 = new System.Drawing.StringFormat();
			this.CaptionBar = new FormEx.VistaWindowCaptionBar();
			this.panelBatchCommands = new PanelEx.VistaPanel();
			this.lblMultiple = new System.Windows.Forms.Label();
			this.chkAutoReset = new System.Windows.Forms.CheckBox();
			this.cmdLoadCSV = new ButtonEx.VistaButton();
			this.cmdToggleAutoReset = new ButtonEx.VistaButton();
			this.updMultiple = new System.Windows.Forms.NumericUpDown();
			this.cmdClear = new ButtonEx.VistaButton();
			this.cmdCopy = new ButtonEx.VistaButton();
			this.cmdPaste = new ButtonEx.VistaButton();
			this.panelStatus = new PanelEx.VistaPanel();
			this.lblTotalQty = new LabelEx.LabelVista();
			this.dspNetQty = new LabelEx.LabelVista();
			this.lblSellQty = new LabelEx.LabelVista();
			this.dspSellQty = new LabelEx.LabelVista();
			this.cmdExecuteAll = new LabelEx.LabelVista();
			this.cmdExecuteSelected = new LabelEx.LabelVista();
			this.lblShortQty = new LabelEx.LabelVista();
			this.dspShortQty = new LabelEx.LabelVista();
			this.lblBuyQty = new LabelEx.LabelVista();
			this.dspBuyQty = new LabelEx.LabelVista();
			this.lblOrdersQty = new LabelEx.LabelVista();
			this.dspOrdersQty = new LabelEx.LabelVista();
			this.rocBatch = new DataGridViewEx.ROCBatch();
			this.menuProcessing = new ROC.menuBaseProcessing();
			this.panelBatchCommands.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.updMultiple)).BeginInit();
			this.panelStatus.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.rocBatch)).BeginInit();
			this.SuspendLayout();
			// 
			// CaptionBar
			// 
			this.CaptionBar.BackColor = System.Drawing.Color.Transparent;
			this.CaptionBar.ConfirmBeforeClose = true;
			this.CaptionBar.Dock = System.Windows.Forms.DockStyle.Top;
			this.CaptionBar.Location = new System.Drawing.Point(0, 0);
			this.CaptionBar.Name = "CaptionBar";
			this.CaptionBar.ShowFit = true;
			this.CaptionBar.ShowShowAll = true;
			this.CaptionBar.Size = new System.Drawing.Size(642, 26);
			this.CaptionBar.TabIndex = 0;
			// 
			// panelBatchCommands
			// 
			this.panelBatchCommands.BackColor = System.Drawing.Color.Black;
			this.panelBatchCommands.Controls.Add(this.lblMultiple);
			this.panelBatchCommands.Controls.Add(this.chkAutoReset);
			this.panelBatchCommands.Controls.Add(this.cmdLoadCSV);
			this.panelBatchCommands.Controls.Add(this.cmdToggleAutoReset);
			this.panelBatchCommands.Controls.Add(this.updMultiple);
			this.panelBatchCommands.Controls.Add(this.cmdClear);
			this.panelBatchCommands.Controls.Add(this.cmdCopy);
			this.panelBatchCommands.Controls.Add(this.cmdPaste);
			this.panelBatchCommands.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelBatchCommands.Location = new System.Drawing.Point(0, 26);
			this.panelBatchCommands.Name = "panelBatchCommands";
			this.panelBatchCommands.Size = new System.Drawing.Size(642, 24);
			this.panelBatchCommands.TabIndex = 7;
			// 
			// lblMultiple
			// 
			this.lblMultiple.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lblMultiple.AutoSize = true;
			this.lblMultiple.Location = new System.Drawing.Point(470, 5);
			this.lblMultiple.Name = "lblMultiple";
			this.lblMultiple.Size = new System.Drawing.Size(120, 13);
			this.lblMultiple.TabIndex = 14;
			this.lblMultiple.Text = "No. Of Batches to Send";
			this.lblMultiple.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// chkAutoReset
			// 
			this.chkAutoReset.AutoSize = true;
			this.chkAutoReset.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkAutoReset.Dock = System.Windows.Forms.DockStyle.Left;
			this.chkAutoReset.Location = new System.Drawing.Point(229, 0);
			this.chkAutoReset.Name = "chkAutoReset";
			this.chkAutoReset.Size = new System.Drawing.Size(79, 24);
			this.chkAutoReset.TabIndex = 13;
			this.chkAutoReset.Text = "Auto Reset";
			this.chkAutoReset.UseVisualStyleBackColor = true;
			this.chkAutoReset.Visible = false;
			// 
			// cmdLoadCSV
			// 
			this.cmdLoadCSV.AutoSize = true;
			this.cmdLoadCSV.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cmdLoadCSV.BackColor = System.Drawing.Color.Navy;
			this.cmdLoadCSV.Dock = System.Windows.Forms.DockStyle.Left;
			this.cmdLoadCSV.Location = new System.Drawing.Point(188, 0);
			this.cmdLoadCSV.Name = "cmdLoadCSV";
			this.cmdLoadCSV.Size = new System.Drawing.Size(41, 24);
			this.cmdLoadCSV.TabIndex = 9;
			this.cmdLoadCSV.TabStop = false;
			this.cmdLoadCSV.Text = "Load";
			this.cmdLoadCSV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.cmdLoadCSV.UserSplitSize = 20;
			this.cmdLoadCSV.Click += new System.EventHandler(this.cmdLoadCSV_Click);
			// 
			// cmdToggleAutoReset
			// 
			this.cmdToggleAutoReset.AutoSize = true;
			this.cmdToggleAutoReset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cmdToggleAutoReset.BackColor = System.Drawing.Color.DarkRed;
			this.cmdToggleAutoReset.Dock = System.Windows.Forms.DockStyle.Left;
			this.cmdToggleAutoReset.Location = new System.Drawing.Point(126, 0);
			this.cmdToggleAutoReset.Name = "cmdToggleAutoReset";
			this.cmdToggleAutoReset.Size = new System.Drawing.Size(62, 24);
			this.cmdToggleAutoReset.TabIndex = 8;
			this.cmdToggleAutoReset.TabStop = false;
			this.cmdToggleAutoReset.Text = "No Reset";
			this.cmdToggleAutoReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.cmdToggleAutoReset.UserSplitSize = 20;
			this.cmdToggleAutoReset.Click += new System.EventHandler(this.cmdToggleAutoReset_Click);
			// 
			// updMultiple
			// 
			this.updMultiple.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.updMultiple.AutoSize = true;
			this.updMultiple.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.updMultiple.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.updMultiple.Location = new System.Drawing.Point(596, 1);
			this.updMultiple.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.updMultiple.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.updMultiple.Name = "updMultiple";
			this.updMultiple.Size = new System.Drawing.Size(45, 22);
			this.updMultiple.TabIndex = 6;
			this.updMultiple.TabStop = false;
			this.updMultiple.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.updMultiple.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.updMultiple.ValueChanged += new System.EventHandler(this.updMultiple_ValueChanged);
			// 
			// cmdClear
			// 
			this.cmdClear.AutoSize = true;
			this.cmdClear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cmdClear.BackColor = System.Drawing.Color.Black;
			this.cmdClear.Dock = System.Windows.Forms.DockStyle.Left;
			this.cmdClear.Location = new System.Drawing.Point(85, 0);
			this.cmdClear.Name = "cmdClear";
			this.cmdClear.Size = new System.Drawing.Size(41, 24);
			this.cmdClear.TabIndex = 1;
			this.cmdClear.TabStop = false;
			this.cmdClear.Text = "Clear";
			this.cmdClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.cmdClear.UserSplitSize = 20;
			this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
			// 
			// cmdCopy
			// 
			this.cmdCopy.AutoSize = true;
			this.cmdCopy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cmdCopy.BackColor = System.Drawing.Color.Black;
			this.cmdCopy.Dock = System.Windows.Forms.DockStyle.Left;
			this.cmdCopy.Location = new System.Drawing.Point(44, 0);
			this.cmdCopy.Name = "cmdCopy";
			this.cmdCopy.Size = new System.Drawing.Size(41, 24);
			this.cmdCopy.TabIndex = 2;
			this.cmdCopy.TabStop = false;
			this.cmdCopy.Text = "Copy";
			this.cmdCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.cmdCopy.UserSplitSize = 20;
			this.cmdCopy.Click += new System.EventHandler(this.cmdCopy_Click);
			// 
			// cmdPaste
			// 
			this.cmdPaste.AutoSize = true;
			this.cmdPaste.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cmdPaste.BackColor = System.Drawing.Color.Navy;
			this.cmdPaste.Dock = System.Windows.Forms.DockStyle.Left;
			this.cmdPaste.Location = new System.Drawing.Point(0, 0);
			this.cmdPaste.Name = "cmdPaste";
			this.cmdPaste.Size = new System.Drawing.Size(44, 24);
			this.cmdPaste.TabIndex = 3;
			this.cmdPaste.TabStop = false;
			this.cmdPaste.Text = "Paste";
			this.cmdPaste.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.cmdPaste.UserSplitSize = 20;
			this.cmdPaste.Click += new System.EventHandler(this.cmdPaste_Click);
			// 
			// panelStatus
			// 
			this.panelStatus.BackColor = System.Drawing.Color.Black;
			this.panelStatus.Controls.Add(this.lblTotalQty);
			this.panelStatus.Controls.Add(this.dspNetQty);
			this.panelStatus.Controls.Add(this.lblSellQty);
			this.panelStatus.Controls.Add(this.dspSellQty);
			this.panelStatus.Controls.Add(this.cmdExecuteAll);
			this.panelStatus.Controls.Add(this.cmdExecuteSelected);
			this.panelStatus.Controls.Add(this.lblShortQty);
			this.panelStatus.Controls.Add(this.dspShortQty);
			this.panelStatus.Controls.Add(this.lblBuyQty);
			this.panelStatus.Controls.Add(this.dspBuyQty);
			this.panelStatus.Controls.Add(this.lblOrdersQty);
			this.panelStatus.Controls.Add(this.dspOrdersQty);
			this.panelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelStatus.Location = new System.Drawing.Point(0, 218);
			this.panelStatus.Name = "panelStatus";
			this.panelStatus.Size = new System.Drawing.Size(642, 24);
			this.panelStatus.TabIndex = 10;
			// 
			// lblTotalQty
			// 
			this.lblTotalQty.AutoColor = false;
			this.lblTotalQty.AutoSize = true;
			this.lblTotalQty.DefaultColor = System.Drawing.Color.White;
			this.lblTotalQty.DefaultText = "0";
			this.lblTotalQty.DisplayFactor = 1;
			this.lblTotalQty.Dock = System.Windows.Forms.DockStyle.Left;
			this.lblTotalQty.DownColor = System.Drawing.Color.Red;
			this.lblTotalQty.Is64Th = false;
			this.lblTotalQty.IsCurrency = false;
			this.lblTotalQty.IsFraction = false;
			this.lblTotalQty.IsPercent = false;
			this.lblTotalQty.Location = new System.Drawing.Point(262, 0);
			this.lblTotalQty.MaxDecimal = 0;
			this.lblTotalQty.MinimumSize = new System.Drawing.Size(17, 24);
			this.lblTotalQty.Name = "lblTotalQty";
			this.lblTotalQty.Padding = new System.Windows.Forms.Padding(2);
			this.lblTotalQty.Size = new System.Drawing.Size(17, 24);
			this.lblTotalQty.TabIndex = 9;
			this.lblTotalQty.Text = "0";
			this.lblTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblTotalQty.TickSize = 0.01;
			this.lblTotalQty.UpColor = System.Drawing.Color.LimeGreen;
			this.lblTotalQty.Value = "";
			// 
			// dspNetQty
			// 
			this.dspNetQty.AutoColor = false;
			this.dspNetQty.AutoSize = true;
			this.dspNetQty.DefaultColor = System.Drawing.Color.White;
			this.dspNetQty.DefaultText = "NET";
			this.dspNetQty.DisplayFactor = 1;
			this.dspNetQty.Dock = System.Windows.Forms.DockStyle.Left;
			this.dspNetQty.DownColor = System.Drawing.Color.Red;
			this.dspNetQty.Is64Th = false;
			this.dspNetQty.IsCurrency = false;
			this.dspNetQty.IsFraction = false;
			this.dspNetQty.IsPercent = false;
			this.dspNetQty.Location = new System.Drawing.Point(229, 0);
			this.dspNetQty.MaxDecimal = 7;
			this.dspNetQty.MinimumSize = new System.Drawing.Size(24, 24);
			this.dspNetQty.Name = "dspNetQty";
			this.dspNetQty.Padding = new System.Windows.Forms.Padding(2);
			this.dspNetQty.Size = new System.Drawing.Size(33, 24);
			this.dspNetQty.TabIndex = 8;
			this.dspNetQty.Text = "NET";
			this.dspNetQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.dspNetQty.TickSize = 0.01;
			this.dspNetQty.UpColor = System.Drawing.Color.LimeGreen;
			this.dspNetQty.Value = "";
			// 
			// lblSellQty
			// 
			this.lblSellQty.AutoColor = false;
			this.lblSellQty.AutoSize = true;
			this.lblSellQty.DefaultColor = System.Drawing.Color.White;
			this.lblSellQty.DefaultText = "0";
			this.lblSellQty.DisplayFactor = 1;
			this.lblSellQty.Dock = System.Windows.Forms.DockStyle.Left;
			this.lblSellQty.DownColor = System.Drawing.Color.Red;
			this.lblSellQty.ForeColor = System.Drawing.Color.Red;
			this.lblSellQty.Is64Th = false;
			this.lblSellQty.IsCurrency = false;
			this.lblSellQty.IsFraction = false;
			this.lblSellQty.IsPercent = false;
			this.lblSellQty.Location = new System.Drawing.Point(212, 0);
			this.lblSellQty.MaxDecimal = 0;
			this.lblSellQty.MinimumSize = new System.Drawing.Size(17, 24);
			this.lblSellQty.Name = "lblSellQty";
			this.lblSellQty.Padding = new System.Windows.Forms.Padding(2);
			this.lblSellQty.Size = new System.Drawing.Size(17, 24);
			this.lblSellQty.TabIndex = 6;
			this.lblSellQty.Text = "0";
			this.lblSellQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblSellQty.TickSize = 0.01;
			this.lblSellQty.UpColor = System.Drawing.Color.LimeGreen;
			this.lblSellQty.Value = "";
			// 
			// dspSellQty
			// 
			this.dspSellQty.AutoColor = false;
			this.dspSellQty.AutoSize = true;
			this.dspSellQty.DefaultColor = System.Drawing.Color.White;
			this.dspSellQty.DefaultText = "SELL";
			this.dspSellQty.DisplayFactor = 1;
			this.dspSellQty.Dock = System.Windows.Forms.DockStyle.Left;
			this.dspSellQty.DownColor = System.Drawing.Color.Red;
			this.dspSellQty.ForeColor = System.Drawing.Color.Red;
			this.dspSellQty.Is64Th = false;
			this.dspSellQty.IsCurrency = false;
			this.dspSellQty.IsFraction = false;
			this.dspSellQty.IsPercent = false;
			this.dspSellQty.Location = new System.Drawing.Point(175, 0);
			this.dspSellQty.MaxDecimal = 7;
			this.dspSellQty.MinimumSize = new System.Drawing.Size(24, 24);
			this.dspSellQty.Name = "dspSellQty";
			this.dspSellQty.Padding = new System.Windows.Forms.Padding(2);
			this.dspSellQty.Size = new System.Drawing.Size(37, 24);
			this.dspSellQty.TabIndex = 5;
			this.dspSellQty.Text = "SELL";
			this.dspSellQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.dspSellQty.TickSize = 0.01;
			this.dspSellQty.UpColor = System.Drawing.Color.LimeGreen;
			this.dspSellQty.Value = "";
			// 
			// cmdExecuteAll
			// 
			this.cmdExecuteAll.Animate = true;
			this.cmdExecuteAll.ApplyShine = true;
			this.cmdExecuteAll.AutoColor = false;
			this.cmdExecuteAll.DefaultColor = System.Drawing.Color.White;
			this.cmdExecuteAll.DefaultText = "Total";
			this.cmdExecuteAll.DisplayFactor = 1;
			this.cmdExecuteAll.Dock = System.Windows.Forms.DockStyle.Right;
			this.cmdExecuteAll.DownColor = System.Drawing.Color.Red;
			this.cmdExecuteAll.ForeColor = System.Drawing.Color.Lime;
			this.cmdExecuteAll.Is64Th = false;
			this.cmdExecuteAll.IsCurrency = false;
			this.cmdExecuteAll.IsFraction = false;
			this.cmdExecuteAll.IsPercent = false;
			this.cmdExecuteAll.Location = new System.Drawing.Point(473, 0);
			this.cmdExecuteAll.MaxDecimal = 7;
			this.cmdExecuteAll.Name = "cmdExecuteAll";
			this.cmdExecuteAll.Padding = new System.Windows.Forms.Padding(5, 2, 2, 2);
			this.cmdExecuteAll.Shape = LabelEx.LabelVista.Shapes.LeftHalfPill;
			this.cmdExecuteAll.Size = new System.Drawing.Size(74, 24);
			this.cmdExecuteAll.TabIndex = 16;
			this.cmdExecuteAll.Text = "Execute All";
			this.cmdExecuteAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExecuteAll.TickSize = 0.01;
			this.cmdExecuteAll.UpColor = System.Drawing.Color.LimeGreen;
			this.cmdExecuteAll.Value = "";
			this.cmdExecuteAll.Click += new System.EventHandler(this.cmdExecuteAll_Click);
			// 
			// cmdExecuteSelected
			// 
			this.cmdExecuteSelected.Animate = true;
			this.cmdExecuteSelected.ApplyShine = true;
			this.cmdExecuteSelected.AutoColor = false;
			this.cmdExecuteSelected.DefaultColor = System.Drawing.Color.White;
			this.cmdExecuteSelected.DefaultText = "Total";
			this.cmdExecuteSelected.DisplayFactor = 1;
			this.cmdExecuteSelected.Dock = System.Windows.Forms.DockStyle.Right;
			this.cmdExecuteSelected.DownColor = System.Drawing.Color.Red;
			this.cmdExecuteSelected.ForeColor = System.Drawing.Color.Aqua;
			this.cmdExecuteSelected.Is64Th = false;
			this.cmdExecuteSelected.IsCurrency = false;
			this.cmdExecuteSelected.IsFraction = false;
			this.cmdExecuteSelected.IsPercent = false;
			this.cmdExecuteSelected.Location = new System.Drawing.Point(547, 0);
			this.cmdExecuteSelected.MaxDecimal = 7;
			this.cmdExecuteSelected.Name = "cmdExecuteSelected";
			this.cmdExecuteSelected.Padding = new System.Windows.Forms.Padding(2);
			this.cmdExecuteSelected.Size = new System.Drawing.Size(95, 24);
			this.cmdExecuteSelected.TabIndex = 15;
			this.cmdExecuteSelected.Text = "Execute Selected";
			this.cmdExecuteSelected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExecuteSelected.TickSize = 0.01;
			this.cmdExecuteSelected.UpColor = System.Drawing.Color.LimeGreen;
			this.cmdExecuteSelected.Value = "";
			this.cmdExecuteSelected.Click += new System.EventHandler(this.cmdExecuteSelected_Click);
			// 
			// lblShortQty
			// 
			this.lblShortQty.AutoColor = false;
			this.lblShortQty.AutoSize = true;
			this.lblShortQty.DefaultColor = System.Drawing.Color.White;
			this.lblShortQty.DefaultText = "0";
			this.lblShortQty.DisplayFactor = 1;
			this.lblShortQty.Dock = System.Windows.Forms.DockStyle.Left;
			this.lblShortQty.DownColor = System.Drawing.Color.Red;
			this.lblShortQty.ForeColor = System.Drawing.Color.Magenta;
			this.lblShortQty.Is64Th = false;
			this.lblShortQty.IsCurrency = false;
			this.lblShortQty.IsFraction = false;
			this.lblShortQty.IsPercent = false;
			this.lblShortQty.Location = new System.Drawing.Point(158, 0);
			this.lblShortQty.MaxDecimal = 0;
			this.lblShortQty.MinimumSize = new System.Drawing.Size(17, 24);
			this.lblShortQty.Name = "lblShortQty";
			this.lblShortQty.Padding = new System.Windows.Forms.Padding(2);
			this.lblShortQty.Size = new System.Drawing.Size(17, 24);
			this.lblShortQty.TabIndex = 11;
			this.lblShortQty.Text = "0";
			this.lblShortQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblShortQty.TickSize = 0.01;
			this.lblShortQty.UpColor = System.Drawing.Color.LimeGreen;
			this.lblShortQty.Value = "";
			// 
			// dspShortQty
			// 
			this.dspShortQty.AutoColor = false;
			this.dspShortQty.AutoSize = true;
			this.dspShortQty.DefaultColor = System.Drawing.Color.White;
			this.dspShortQty.DefaultText = "SHORT";
			this.dspShortQty.DisplayFactor = 1;
			this.dspShortQty.Dock = System.Windows.Forms.DockStyle.Left;
			this.dspShortQty.DownColor = System.Drawing.Color.Red;
			this.dspShortQty.ForeColor = System.Drawing.Color.Magenta;
			this.dspShortQty.Is64Th = false;
			this.dspShortQty.IsCurrency = false;
			this.dspShortQty.IsFraction = false;
			this.dspShortQty.IsPercent = false;
			this.dspShortQty.Location = new System.Drawing.Point(109, 0);
			this.dspShortQty.MaxDecimal = 7;
			this.dspShortQty.MinimumSize = new System.Drawing.Size(24, 24);
			this.dspShortQty.Name = "dspShortQty";
			this.dspShortQty.Padding = new System.Windows.Forms.Padding(2);
			this.dspShortQty.Size = new System.Drawing.Size(49, 24);
			this.dspShortQty.TabIndex = 10;
			this.dspShortQty.Text = "SHORT";
			this.dspShortQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.dspShortQty.TickSize = 0.01;
			this.dspShortQty.UpColor = System.Drawing.Color.LimeGreen;
			this.dspShortQty.Value = "";
			// 
			// lblBuyQty
			// 
			this.lblBuyQty.AutoColor = false;
			this.lblBuyQty.AutoSize = true;
			this.lblBuyQty.DefaultColor = System.Drawing.Color.White;
			this.lblBuyQty.DefaultText = "0";
			this.lblBuyQty.DisplayFactor = 1;
			this.lblBuyQty.Dock = System.Windows.Forms.DockStyle.Left;
			this.lblBuyQty.DownColor = System.Drawing.Color.Red;
			this.lblBuyQty.ForeColor = System.Drawing.Color.LimeGreen;
			this.lblBuyQty.Is64Th = false;
			this.lblBuyQty.IsCurrency = false;
			this.lblBuyQty.IsFraction = false;
			this.lblBuyQty.IsPercent = false;
			this.lblBuyQty.Location = new System.Drawing.Point(92, 0);
			this.lblBuyQty.MaxDecimal = 0;
			this.lblBuyQty.MinimumSize = new System.Drawing.Size(17, 24);
			this.lblBuyQty.Name = "lblBuyQty";
			this.lblBuyQty.Padding = new System.Windows.Forms.Padding(2);
			this.lblBuyQty.Size = new System.Drawing.Size(17, 24);
			this.lblBuyQty.TabIndex = 3;
			this.lblBuyQty.Text = "0";
			this.lblBuyQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblBuyQty.TickSize = 0.01;
			this.lblBuyQty.UpColor = System.Drawing.Color.LimeGreen;
			this.lblBuyQty.Value = "";
			// 
			// dspBuyQty
			// 
			this.dspBuyQty.AutoColor = false;
			this.dspBuyQty.AutoSize = true;
			this.dspBuyQty.DefaultColor = System.Drawing.Color.White;
			this.dspBuyQty.DefaultText = "BUY";
			this.dspBuyQty.DisplayFactor = 1;
			this.dspBuyQty.Dock = System.Windows.Forms.DockStyle.Left;
			this.dspBuyQty.DownColor = System.Drawing.Color.Red;
			this.dspBuyQty.ForeColor = System.Drawing.Color.LimeGreen;
			this.dspBuyQty.Is64Th = false;
			this.dspBuyQty.IsCurrency = false;
			this.dspBuyQty.IsFraction = false;
			this.dspBuyQty.IsPercent = false;
			this.dspBuyQty.Location = new System.Drawing.Point(59, 0);
			this.dspBuyQty.MaxDecimal = 7;
			this.dspBuyQty.MinimumSize = new System.Drawing.Size(24, 24);
			this.dspBuyQty.Name = "dspBuyQty";
			this.dspBuyQty.Padding = new System.Windows.Forms.Padding(2);
			this.dspBuyQty.Size = new System.Drawing.Size(33, 24);
			this.dspBuyQty.TabIndex = 2;
			this.dspBuyQty.Text = "BUY";
			this.dspBuyQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.dspBuyQty.TickSize = 0.01;
			this.dspBuyQty.UpColor = System.Drawing.Color.LimeGreen;
			this.dspBuyQty.Value = "";
			// 
			// lblOrdersQty
			// 
			this.lblOrdersQty.AutoColor = false;
			this.lblOrdersQty.AutoSize = true;
			this.lblOrdersQty.DefaultColor = System.Drawing.Color.White;
			this.lblOrdersQty.DefaultText = "0";
			this.lblOrdersQty.DisplayFactor = 1;
			this.lblOrdersQty.Dock = System.Windows.Forms.DockStyle.Left;
			this.lblOrdersQty.DownColor = System.Drawing.Color.Red;
			this.lblOrdersQty.Is64Th = false;
			this.lblOrdersQty.IsCurrency = false;
			this.lblOrdersQty.IsFraction = false;
			this.lblOrdersQty.IsPercent = false;
			this.lblOrdersQty.Location = new System.Drawing.Point(42, 0);
			this.lblOrdersQty.MaxDecimal = 0;
			this.lblOrdersQty.MinimumSize = new System.Drawing.Size(17, 24);
			this.lblOrdersQty.Name = "lblOrdersQty";
			this.lblOrdersQty.Padding = new System.Windows.Forms.Padding(2);
			this.lblOrdersQty.Size = new System.Drawing.Size(17, 24);
			this.lblOrdersQty.TabIndex = 1;
			this.lblOrdersQty.Text = "0";
			this.lblOrdersQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblOrdersQty.TickSize = 0.01;
			this.lblOrdersQty.UpColor = System.Drawing.Color.LimeGreen;
			this.lblOrdersQty.Value = "";
			// 
			// dspOrdersQty
			// 
			this.dspOrdersQty.ApplyShine = true;
			this.dspOrdersQty.AutoColor = false;
			this.dspOrdersQty.AutoSize = true;
			this.dspOrdersQty.DefaultColor = System.Drawing.Color.White;
			this.dspOrdersQty.DefaultText = "Orders";
			this.dspOrdersQty.DisplayFactor = 1;
			this.dspOrdersQty.Dock = System.Windows.Forms.DockStyle.Left;
			this.dspOrdersQty.DownColor = System.Drawing.Color.Red;
			this.dspOrdersQty.Is64Th = false;
			this.dspOrdersQty.IsCurrency = false;
			this.dspOrdersQty.IsFraction = false;
			this.dspOrdersQty.IsPercent = false;
			this.dspOrdersQty.Location = new System.Drawing.Point(0, 0);
			this.dspOrdersQty.MaxDecimal = 7;
			this.dspOrdersQty.MinimumSize = new System.Drawing.Size(24, 24);
			this.dspOrdersQty.Name = "dspOrdersQty";
			this.dspOrdersQty.Padding = new System.Windows.Forms.Padding(2);
			this.dspOrdersQty.Size = new System.Drawing.Size(42, 24);
			this.dspOrdersQty.TabIndex = 0;
			this.dspOrdersQty.Text = "Orders";
			this.dspOrdersQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.dspOrdersQty.TickSize = 0.01;
			this.dspOrdersQty.UpColor = System.Drawing.Color.LimeGreen;
			this.dspOrdersQty.Value = "";
			// 
			// rocBatch
			// 
			this.rocBatch.AlertMessage = "";
			this.rocBatch.BlueDefault = 228;
			this.rocBatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			new BindingListEx.ROCBindingList<string>().Add("");
			this.rocBatch.DisplayFactors = ((System.Collections.Generic.Dictionary<string, double>)(resources.GetObject("rocBatch.DisplayFactors")));
			this.rocBatch.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rocBatch.GreenDefault = 243;
			this.rocBatch.GridKeys = ((System.Collections.Generic.List<string>)(resources.GetObject("rocBatch.GridKeys")));
			this.rocBatch.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(243)))), ((int)(((byte)(228)))));
			this.rocBatch.Importing = false;
			this.rocBatch.LastFilter = "";
			this.rocBatch.LastSort = "";
			this.rocBatch.Location = new System.Drawing.Point(0, 50);
			this.rocBatch.Name = "rocBatch";
			dgvBasePrinter1.BlackWhite = true;
			dgvBasePrinter1.CellAlignment = System.Drawing.StringAlignment.Near;
			dgvBasePrinter1.CellFormatFlags = ((System.Drawing.StringFormatFlags)((System.Drawing.StringFormatFlags.LineLimit | System.Drawing.StringFormatFlags.NoClip)));
			dgvBasePrinter1.DocName = null;
			dgvBasePrinter1.Footer = null;
			dgvBasePrinter1.FooterAlignment = System.Drawing.StringAlignment.Center;
			dgvBasePrinter1.FooterColor = System.Drawing.Color.Black;
			dgvBasePrinter1.FooterFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
			stringFormat1.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat1.FormatFlags = ((System.Drawing.StringFormatFlags)(((System.Drawing.StringFormatFlags.NoWrap | System.Drawing.StringFormatFlags.LineLimit)
						| System.Drawing.StringFormatFlags.NoClip)));
			stringFormat1.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat1.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat1.Trimming = System.Drawing.StringTrimming.Word;
			dgvBasePrinter1.FooterFormat = stringFormat1;
			dgvBasePrinter1.FooterFormatFlags = ((System.Drawing.StringFormatFlags)(((System.Drawing.StringFormatFlags.NoWrap | System.Drawing.StringFormatFlags.LineLimit)
						| System.Drawing.StringFormatFlags.NoClip)));
			dgvBasePrinter1.FooterSpacing = 0F;
			dgvBasePrinter1.HeaderCellAlignment = System.Drawing.StringAlignment.Near;
			dgvBasePrinter1.HeaderCellFormatFlags = ((System.Drawing.StringFormatFlags)((System.Drawing.StringFormatFlags.LineLimit | System.Drawing.StringFormatFlags.NoClip)));
			dgvBasePrinter1.Owner = null;
			dgvBasePrinter1.PageNumberAlignment = System.Drawing.StringAlignment.Center;
			dgvBasePrinter1.PageNumberColor = System.Drawing.Color.Black;
			dgvBasePrinter1.PageNumberFont = new System.Drawing.Font("Tahoma", 8F);
			stringFormat2.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat2.FormatFlags = ((System.Drawing.StringFormatFlags)(((System.Drawing.StringFormatFlags.NoWrap | System.Drawing.StringFormatFlags.LineLimit)
						| System.Drawing.StringFormatFlags.NoClip)));
			stringFormat2.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat2.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat2.Trimming = System.Drawing.StringTrimming.Word;
			dgvBasePrinter1.PageNumberFormat = stringFormat2;
			dgvBasePrinter1.PageNumberFormatFlags = ((System.Drawing.StringFormatFlags)(((System.Drawing.StringFormatFlags.NoWrap | System.Drawing.StringFormatFlags.LineLimit)
						| System.Drawing.StringFormatFlags.NoClip)));
			dgvBasePrinter1.PageNumberInHeader = false;
			dgvBasePrinter1.PageNumberOnSeparateLine = true;
			dgvBasePrinter1.PageNumbers = true;
			dgvBasePrinter1.PageSeparator = " of ";
			dgvBasePrinter1.PageText = "Page ";
			dgvBasePrinter1.PartText = " - Part ";
			dgvBasePrinter1.PorportionalColumns = false;
			dgvBasePrinter1.PreviewDialogIcon = null;
			dgvBasePrinter1.PrinterName = null;
			dgvBasePrinter1.PrintMargins = new System.Drawing.Printing.Margins(60, 60, 40, 40);
			dgvBasePrinter1.PrintPreviewZoom = 1;
			dgvBasePrinter1.ShowTotalPageNumber = true;
			dgvBasePrinter1.SubTitle = null;
			dgvBasePrinter1.SubTitleAlignment = System.Drawing.StringAlignment.Center;
			dgvBasePrinter1.SubTitleColor = System.Drawing.Color.Black;
			dgvBasePrinter1.SubTitleFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
			stringFormat3.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat3.FormatFlags = ((System.Drawing.StringFormatFlags)(((System.Drawing.StringFormatFlags.NoWrap | System.Drawing.StringFormatFlags.LineLimit)
						| System.Drawing.StringFormatFlags.NoClip)));
			stringFormat3.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat3.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat3.Trimming = System.Drawing.StringTrimming.Word;
			dgvBasePrinter1.SubTitleFormat = stringFormat3;
			dgvBasePrinter1.SubTitleFormatFlags = ((System.Drawing.StringFormatFlags)(((System.Drawing.StringFormatFlags.NoWrap | System.Drawing.StringFormatFlags.LineLimit)
						| System.Drawing.StringFormatFlags.NoClip)));
			dgvBasePrinter1.TableAlignment = DataGridViewEx.DGVBasePrinter.Alignment.NotSet;
			dgvBasePrinter1.Title = null;
			dgvBasePrinter1.TitleAlignment = System.Drawing.StringAlignment.Center;
			dgvBasePrinter1.TitleColor = System.Drawing.Color.Black;
			dgvBasePrinter1.TitleFont = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
			stringFormat4.Alignment = System.Drawing.StringAlignment.Center;
			stringFormat4.FormatFlags = ((System.Drawing.StringFormatFlags)(((System.Drawing.StringFormatFlags.NoWrap | System.Drawing.StringFormatFlags.LineLimit)
						| System.Drawing.StringFormatFlags.NoClip)));
			stringFormat4.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			stringFormat4.LineAlignment = System.Drawing.StringAlignment.Center;
			stringFormat4.Trimming = System.Drawing.StringTrimming.Word;
			dgvBasePrinter1.TitleFormat = stringFormat4;
			dgvBasePrinter1.TitleFormatFlags = ((System.Drawing.StringFormatFlags)(((System.Drawing.StringFormatFlags.NoWrap | System.Drawing.StringFormatFlags.LineLimit)
						| System.Drawing.StringFormatFlags.NoClip)));
			this.rocBatch.Printer = dgvBasePrinter1;
			this.rocBatch.Processing = false;
			this.rocBatch.RedDefault = 233;
			this.rocBatch.RefreshAggragation = true;
			this.rocBatch.RefreshSharedRows = false;
			this.rocBatch.ShouldScrollToLastRow = false;
			this.rocBatch.ShowAccountMenu = false;
			this.rocBatch.ShowAlgoTypeMenu = false;
			this.rocBatch.ShowColumnMenu = false;
			this.rocBatch.ShowDurationMenu = false;
			this.rocBatch.ShowEndTimeMenu = false;
			this.rocBatch.ShowExchangeMenu = false;
			this.rocBatch.ShowMenu = false;
			this.rocBatch.ShowOrderTypeMenu = false;
			this.rocBatch.ShowShortLenderMenu = false;
			this.rocBatch.ShowSideMenu = false;
			this.rocBatch.ShowStartTimeMenu = false;
			this.rocBatch.ShowStatusMenu = false;
			this.rocBatch.ShowTraderMenu = false;
			this.rocBatch.Size = new System.Drawing.Size(642, 168);
			new BindingListEx.ROCBindingList<string>().Add("");
			this.rocBatch.TabIndex = 13;
			this.rocBatch.TickSizes = ((System.Collections.Generic.Dictionary<string, double>)(resources.GetObject("rocBatch.TickSizes")));
			// 
			// menuProcessing
			// 
			this.menuProcessing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.menuProcessing.BackColor = System.Drawing.Color.Transparent;
			this.menuProcessing.Caption = "000";
			this.menuProcessing.Location = new System.Drawing.Point(21, 158);
			this.menuProcessing.MaximumSize = new System.Drawing.Size(51, 51);
			this.menuProcessing.MinimumSize = new System.Drawing.Size(51, 51);
			this.menuProcessing.Name = "menuProcessing";
			this.menuProcessing.Size = new System.Drawing.Size(51, 51);
			this.menuProcessing.TabIndex = 12;
			this.menuProcessing.TabStop = false;
			this.menuProcessing.Visible = false;
			// 
			// frmBatchTicket
			// 
			this.Animate = false;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Caption = "Batch Ticket";
			this.ClientSize = new System.Drawing.Size(642, 242);
			this.Controls.Add(this.menuProcessing);
			this.Controls.Add(this.rocBatch);
			this.Controls.Add(this.panelBatchCommands);
			this.Controls.Add(this.CaptionBar);
			this.Controls.Add(this.panelStatus);
			this.MinimumSize = new System.Drawing.Size(500, 250);
			this.Name = "frmBatchTicket";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.panelBatchCommands.ResumeLayout(false);
			this.panelBatchCommands.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.updMultiple)).EndInit();
			this.panelStatus.ResumeLayout(false);
			this.panelStatus.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.rocBatch)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private FormEx.VistaWindowCaptionBar CaptionBar;
		private PanelEx.VistaPanel panelBatchCommands;
		private PanelEx.VistaPanel panelStatus;
		private LabelEx.LabelVista lblTotalQty;
		private LabelEx.LabelVista dspNetQty;
		private LabelEx.LabelVista lblShortQty;
		private LabelEx.LabelVista dspShortQty;
		private LabelEx.LabelVista lblSellQty;
		private LabelEx.LabelVista dspSellQty;
		private LabelEx.LabelVista lblBuyQty;
		private LabelEx.LabelVista dspBuyQty;
		private LabelEx.LabelVista lblOrdersQty;
		private LabelEx.LabelVista dspOrdersQty;
		private menuBaseProcessing menuProcessing;
		private ButtonEx.VistaButton cmdPaste;
		private ButtonEx.VistaButton cmdCopy;
		private ButtonEx.VistaButton cmdClear;
		private System.Windows.Forms.NumericUpDown updMultiple;
		private DataGridViewEx.ROCBatch rocBatch;
		private ButtonEx.VistaButton cmdToggleAutoReset;
		private ButtonEx.VistaButton cmdLoadCSV;
		private System.Windows.Forms.CheckBox chkAutoReset;
		private LabelEx.LabelVista cmdExecuteAll;
		private LabelEx.LabelVista cmdExecuteSelected;
		private System.Windows.Forms.Label lblMultiple;
	}
}