namespace MapLayout
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.progressBestPlacement = new System.Windows.Forms.ProgressBar();
            this.panelPlayer = new System.Windows.Forms.Panel();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.btnSlowDown = new System.Windows.Forms.Button();
            this.btnSpeedUp = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnHeatMap = new System.Windows.Forms.Button();
            this.mapPictureBox = new System.Windows.Forms.PictureBox();
            this.panelMapBuilder = new System.Windows.Forms.Panel();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.AmTicks = new System.Windows.Forms.TextBox();
            this.btnGetBestPlacement = new System.Windows.Forms.Button();
            this.gbDijkstraTool = new System.Windows.Forms.GroupBox();
            this.DrawAllClosests = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tbDrawShop = new System.Windows.Forms.TextBox();
            this.btnDrawWarehouseRoute = new System.Windows.Forms.Button();
            this.tbDrawWarehouse = new System.Windows.Forms.TextBox();
            this.btnAnalyzeMap = new System.Windows.Forms.Button();
            this.tbDrawRouteTo = new System.Windows.Forms.TextBox();
            this.tbDrawRouteFrom = new System.Windows.Forms.TextBox();
            this.btnDrawDijkstra = new System.Windows.Forms.Button();
            this.tbDrawDijkstraFrom = new System.Windows.Forms.TextBox();
            this.btnDrawRoute = new System.Windows.Forms.Button();
            this.gbImportExport = new System.Windows.Forms.GroupBox();
            this.loadMapBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.gbMapEditor = new System.Windows.Forms.GroupBox();
            this.tbMapEditor = new System.Windows.Forms.TextBox();
            this.btnRandomMap = new System.Windows.Forms.Button();
            this.btnRandomHeatMap = new System.Windows.Forms.Button();
            this.btnShop = new System.Windows.Forms.Button();
            this.lblMapEditor = new System.Windows.Forms.Label();
            this.btnCursor = new System.Windows.Forms.Button();
            this.btnRoadMode = new System.Windows.Forms.Button();
            this.btnWarehouse = new System.Windows.Forms.Button();
            this.btnLocationMode = new System.Windows.Forms.Button();
            this.lbLocationLog = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).BeginInit();
            this.panelMapBuilder.SuspendLayout();
            this.gbDijkstraTool.SuspendLayout();
            this.gbImportExport.SuspendLayout();
            this.gbMapEditor.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Panel1.Controls.Add(this.mapPictureBox);
            this.splitContainer1.Panel1.Controls.Add(this.progressBestPlacement);
            this.splitContainer1.Panel1.Controls.Add(this.panelPlayer);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.splitContainer1.Panel2.Controls.Add(this.panelMapBuilder);
            this.splitContainer1.Panel2.Controls.Add(this.lbLocationLog);
            this.splitContainer1.Size = new System.Drawing.Size(1152, 742);
            this.splitContainer1.SplitterDistance = 822;
            this.splitContainer1.TabIndex = 0;
            // 
            // progressBestPlacement
            // 
            this.progressBestPlacement.Location = new System.Drawing.Point(4, 629);
            this.progressBestPlacement.Margin = new System.Windows.Forms.Padding(4);
            this.progressBestPlacement.Name = "progressBestPlacement";
            this.progressBestPlacement.Size = new System.Drawing.Size(803, 36);
            this.progressBestPlacement.TabIndex = 3;
            this.progressBestPlacement.Visible = false;
            // 
            // panelPlayer
            // 
            this.panelPlayer.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelPlayer.Controls.Add(this.btnStatistics);
            this.panelPlayer.Controls.Add(this.lblSpeed);
            this.panelPlayer.Controls.Add(this.btnSlowDown);
            this.panelPlayer.Controls.Add(this.btnSpeedUp);
            this.panelPlayer.Controls.Add(this.btnReset);
            this.panelPlayer.Controls.Add(this.btnPlay);
            this.panelPlayer.Controls.Add(this.btnHeatMap);
            this.panelPlayer.Location = new System.Drawing.Point(4, 672);
            this.panelPlayer.Margin = new System.Windows.Forms.Padding(4);
            this.panelPlayer.Name = "panelPlayer";
            this.panelPlayer.Size = new System.Drawing.Size(803, 66);
            this.panelPlayer.TabIndex = 2;
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(455, 26);
            this.lblSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(71, 17);
            this.lblSpeed.TabIndex = 23;
            this.lblSpeed.Text = "Speed: 1x";
            // 
            // btnSlowDown
            // 
            this.btnSlowDown.Location = new System.Drawing.Point(552, 33);
            this.btnSlowDown.Margin = new System.Windows.Forms.Padding(4);
            this.btnSlowDown.Name = "btnSlowDown";
            this.btnSlowDown.Size = new System.Drawing.Size(97, 30);
            this.btnSlowDown.TabIndex = 22;
            this.btnSlowDown.Text = "Slow Down";
            this.btnSlowDown.UseVisualStyleBackColor = true;
            this.btnSlowDown.Click += new System.EventHandler(this.btnSlowDown_Click);
            // 
            // btnSpeedUp
            // 
            this.btnSpeedUp.Location = new System.Drawing.Point(552, 4);
            this.btnSpeedUp.Margin = new System.Windows.Forms.Padding(4);
            this.btnSpeedUp.Name = "btnSpeedUp";
            this.btnSpeedUp.Size = new System.Drawing.Size(97, 30);
            this.btnSpeedUp.TabIndex = 21;
            this.btnSpeedUp.Text = "Speed Up";
            this.btnSpeedUp.UseVisualStyleBackColor = true;
            this.btnSpeedUp.Click += new System.EventHandler(this.btnSpeedUp_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackgroundImage = global::MapLayout.Properties.Resources.Reset;
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReset.Location = new System.Drawing.Point(272, 4);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(79, 59);
            this.btnReset.TabIndex = 20;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.BackgroundImage = global::MapLayout.Properties.Resources.Play;
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPlay.Location = new System.Drawing.Point(165, 4);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(4);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(79, 59);
            this.btnPlay.TabIndex = 19;
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnHeatMap
            // 
            this.btnHeatMap.Location = new System.Drawing.Point(712, 4);
            this.btnHeatMap.Margin = new System.Windows.Forms.Padding(4);
            this.btnHeatMap.Name = "btnHeatMap";
            this.btnHeatMap.Size = new System.Drawing.Size(87, 59);
            this.btnHeatMap.TabIndex = 18;
            this.btnHeatMap.Text = "Display HeatMap";
            this.btnHeatMap.UseVisualStyleBackColor = true;
            this.btnHeatMap.Click += new System.EventHandler(this.btnHeatMap_Click);
            // 
            // mapPictureBox
            // 
            this.mapPictureBox.Location = new System.Drawing.Point(4, 4);
            this.mapPictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mapPictureBox.Name = "mapPictureBox";
            this.mapPictureBox.Size = new System.Drawing.Size(803, 662);
            this.mapPictureBox.TabIndex = 1;
            this.mapPictureBox.TabStop = false;
            this.mapPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint_1);
            this.mapPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mapPictureBox_MouseClick);
            this.mapPictureBox.MouseEnter += new System.EventHandler(this.mapPictureBox_MouseEnter);
            // 
            // panelMapBuilder
            // 
            this.panelMapBuilder.Controls.Add(this.AmTicks);
            this.panelMapBuilder.Controls.Add(this.btnGetBestPlacement);
            this.panelMapBuilder.Controls.Add(this.gbDijkstraTool);
            this.panelMapBuilder.Controls.Add(this.gbImportExport);
            this.panelMapBuilder.Controls.Add(this.gbMapEditor);
            this.panelMapBuilder.Location = new System.Drawing.Point(4, 4);
            this.panelMapBuilder.Margin = new System.Windows.Forms.Padding(4);
            this.panelMapBuilder.Name = "panelMapBuilder";
            this.panelMapBuilder.Size = new System.Drawing.Size(317, 734);
            this.panelMapBuilder.TabIndex = 23;
            // 
            // btnStatistics
            // 
            this.btnStatistics.Location = new System.Drawing.Point(8, 4);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(124, 54);
            this.btnStatistics.TabIndex = 29;
            this.btnStatistics.Text = "Statistics";
            this.btnStatistics.UseVisualStyleBackColor = true;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // AmTicks
            // 
            this.AmTicks.Location = new System.Drawing.Point(152, 663);
            this.AmTicks.Margin = new System.Windows.Forms.Padding(4);
            this.AmTicks.Name = "AmTicks";
            this.AmTicks.Size = new System.Drawing.Size(132, 22);
            this.AmTicks.TabIndex = 28;
            this.AmTicks.Text = "50";
            // 
            // btnGetBestPlacement
            // 
            this.btnGetBestPlacement.Location = new System.Drawing.Point(9, 660);
            this.btnGetBestPlacement.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetBestPlacement.Name = "btnGetBestPlacement";
            this.btnGetBestPlacement.Size = new System.Drawing.Size(125, 28);
            this.btnGetBestPlacement.TabIndex = 27;
            this.btnGetBestPlacement.Text = "Best Placement";
            this.btnGetBestPlacement.UseVisualStyleBackColor = true;
            this.btnGetBestPlacement.Click += new System.EventHandler(this.btnGetBestPlacement_Click);
            // 
            // gbDijkstraTool
            // 
            this.gbDijkstraTool.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.gbDijkstraTool.Controls.Add(this.DrawAllClosests);
            this.gbDijkstraTool.Controls.Add(this.button1);
            this.gbDijkstraTool.Controls.Add(this.tbDrawShop);
            this.gbDijkstraTool.Controls.Add(this.btnDrawWarehouseRoute);
            this.gbDijkstraTool.Controls.Add(this.tbDrawWarehouse);
            this.gbDijkstraTool.Controls.Add(this.btnAnalyzeMap);
            this.gbDijkstraTool.Controls.Add(this.tbDrawRouteTo);
            this.gbDijkstraTool.Controls.Add(this.tbDrawRouteFrom);
            this.gbDijkstraTool.Controls.Add(this.btnDrawDijkstra);
            this.gbDijkstraTool.Controls.Add(this.tbDrawDijkstraFrom);
            this.gbDijkstraTool.Controls.Add(this.btnDrawRoute);
            this.gbDijkstraTool.Location = new System.Drawing.Point(1, 388);
            this.gbDijkstraTool.Margin = new System.Windows.Forms.Padding(4);
            this.gbDijkstraTool.Name = "gbDijkstraTool";
            this.gbDijkstraTool.Padding = new System.Windows.Forms.Padding(4);
            this.gbDijkstraTool.Size = new System.Drawing.Size(311, 234);
            this.gbDijkstraTool.TabIndex = 26;
            this.gbDijkstraTool.TabStop = false;
            this.gbDijkstraTool.Text = "Dijkstra Tool";
            // 
            // DrawAllClosests
            // 
            this.DrawAllClosests.Location = new System.Drawing.Point(8, 165);
            this.DrawAllClosests.Margin = new System.Windows.Forms.Padding(4);
            this.DrawAllClosests.Name = "DrawAllClosests";
            this.DrawAllClosests.Size = new System.Drawing.Size(295, 28);
            this.DrawAllClosests.TabIndex = 22;
            this.DrawAllClosests.Text = "Draw Closest Warehouse-Shop";
            this.DrawAllClosests.UseVisualStyleBackColor = true;
            this.DrawAllClosests.Click += new System.EventHandler(this.DrawAllClosests_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 130);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 28);
            this.button1.TabIndex = 21;
            this.button1.Text = "Draw Closest Shop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbDrawShop
            // 
            this.tbDrawShop.Location = new System.Drawing.Point(199, 133);
            this.tbDrawShop.Margin = new System.Windows.Forms.Padding(4);
            this.tbDrawShop.Name = "tbDrawShop";
            this.tbDrawShop.Size = new System.Drawing.Size(85, 22);
            this.tbDrawShop.TabIndex = 20;
            this.tbDrawShop.Text = "0";
            // 
            // btnDrawWarehouseRoute
            // 
            this.btnDrawWarehouseRoute.Location = new System.Drawing.Point(9, 95);
            this.btnDrawWarehouseRoute.Margin = new System.Windows.Forms.Padding(4);
            this.btnDrawWarehouseRoute.Name = "btnDrawWarehouseRoute";
            this.btnDrawWarehouseRoute.Size = new System.Drawing.Size(180, 28);
            this.btnDrawWarehouseRoute.TabIndex = 19;
            this.btnDrawWarehouseRoute.Text = "Draw Closest Warehouse";
            this.btnDrawWarehouseRoute.UseVisualStyleBackColor = true;
            this.btnDrawWarehouseRoute.Click += new System.EventHandler(this.btnDrawWarehouseRoute_Click);
            // 
            // tbDrawWarehouse
            // 
            this.tbDrawWarehouse.Location = new System.Drawing.Point(199, 97);
            this.tbDrawWarehouse.Margin = new System.Windows.Forms.Padding(4);
            this.tbDrawWarehouse.Name = "tbDrawWarehouse";
            this.tbDrawWarehouse.Size = new System.Drawing.Size(85, 22);
            this.tbDrawWarehouse.TabIndex = 18;
            this.tbDrawWarehouse.Text = "0";
            // 
            // btnAnalyzeMap
            // 
            this.btnAnalyzeMap.Location = new System.Drawing.Point(8, 201);
            this.btnAnalyzeMap.Margin = new System.Windows.Forms.Padding(4);
            this.btnAnalyzeMap.Name = "btnAnalyzeMap";
            this.btnAnalyzeMap.Size = new System.Drawing.Size(295, 28);
            this.btnAnalyzeMap.TabIndex = 17;
            this.btnAnalyzeMap.Text = "(Re)Analyze Map";
            this.btnAnalyzeMap.UseVisualStyleBackColor = true;
            this.btnAnalyzeMap.Click += new System.EventHandler(this.btnAnalyzeMap_Click);
            // 
            // tbDrawRouteTo
            // 
            this.tbDrawRouteTo.Location = new System.Drawing.Point(247, 58);
            this.tbDrawRouteTo.Margin = new System.Windows.Forms.Padding(4);
            this.tbDrawRouteTo.Name = "tbDrawRouteTo";
            this.tbDrawRouteTo.Size = new System.Drawing.Size(36, 22);
            this.tbDrawRouteTo.TabIndex = 16;
            this.tbDrawRouteTo.Text = "0";
            // 
            // tbDrawRouteFrom
            // 
            this.tbDrawRouteFrom.Location = new System.Drawing.Point(197, 58);
            this.tbDrawRouteFrom.Margin = new System.Windows.Forms.Padding(4);
            this.tbDrawRouteFrom.Name = "tbDrawRouteFrom";
            this.tbDrawRouteFrom.Size = new System.Drawing.Size(36, 22);
            this.tbDrawRouteFrom.TabIndex = 15;
            this.tbDrawRouteFrom.Text = "0";
            // 
            // btnDrawDijkstra
            // 
            this.btnDrawDijkstra.Location = new System.Drawing.Point(8, 23);
            this.btnDrawDijkstra.Margin = new System.Windows.Forms.Padding(4);
            this.btnDrawDijkstra.Name = "btnDrawDijkstra";
            this.btnDrawDijkstra.Size = new System.Drawing.Size(181, 28);
            this.btnDrawDijkstra.TabIndex = 14;
            this.btnDrawDijkstra.Text = "Draw Dijkstra Creation";
            this.btnDrawDijkstra.UseVisualStyleBackColor = true;
            this.btnDrawDijkstra.Click += new System.EventHandler(this.btnDrawDijkstra_Click);
            // 
            // tbDrawDijkstraFrom
            // 
            this.tbDrawDijkstraFrom.Location = new System.Drawing.Point(197, 26);
            this.tbDrawDijkstraFrom.Margin = new System.Windows.Forms.Padding(4);
            this.tbDrawDijkstraFrom.Name = "tbDrawDijkstraFrom";
            this.tbDrawDijkstraFrom.Size = new System.Drawing.Size(85, 22);
            this.tbDrawDijkstraFrom.TabIndex = 10;
            this.tbDrawDijkstraFrom.Text = "0";
            // 
            // btnDrawRoute
            // 
            this.btnDrawRoute.Location = new System.Drawing.Point(9, 59);
            this.btnDrawRoute.Margin = new System.Windows.Forms.Padding(4);
            this.btnDrawRoute.Name = "btnDrawRoute";
            this.btnDrawRoute.Size = new System.Drawing.Size(180, 28);
            this.btnDrawRoute.TabIndex = 11;
            this.btnDrawRoute.Text = "Draw Shortest Route";
            this.btnDrawRoute.UseVisualStyleBackColor = true;
            this.btnDrawRoute.Click += new System.EventHandler(this.btnDrawRoute_Click);
            // 
            // gbImportExport
            // 
            this.gbImportExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.gbImportExport.Controls.Add(this.loadMapBtn);
            this.gbImportExport.Controls.Add(this.saveBtn);
            this.gbImportExport.Location = new System.Drawing.Point(3, 290);
            this.gbImportExport.Margin = new System.Windows.Forms.Padding(4);
            this.gbImportExport.Name = "gbImportExport";
            this.gbImportExport.Padding = new System.Windows.Forms.Padding(4);
            this.gbImportExport.Size = new System.Drawing.Size(311, 90);
            this.gbImportExport.TabIndex = 25;
            this.gbImportExport.TabStop = false;
            this.gbImportExport.Text = "Import/Export ";
            // 
            // loadMapBtn
            // 
            this.loadMapBtn.Location = new System.Drawing.Point(8, 54);
            this.loadMapBtn.Margin = new System.Windows.Forms.Padding(4);
            this.loadMapBtn.Name = "loadMapBtn";
            this.loadMapBtn.Size = new System.Drawing.Size(295, 28);
            this.loadMapBtn.TabIndex = 16;
            this.loadMapBtn.Text = "Load Map Configuration";
            this.loadMapBtn.UseVisualStyleBackColor = true;
            this.loadMapBtn.Click += new System.EventHandler(this.loadMapBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(8, 23);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(4);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(295, 28);
            this.saveBtn.TabIndex = 15;
            this.saveBtn.Text = "Save Map Configuration";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // gbMapEditor
            // 
            this.gbMapEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.gbMapEditor.Controls.Add(this.tbMapEditor);
            this.gbMapEditor.Controls.Add(this.btnRandomMap);
            this.gbMapEditor.Controls.Add(this.btnRandomHeatMap);
            this.gbMapEditor.Controls.Add(this.btnShop);
            this.gbMapEditor.Controls.Add(this.lblMapEditor);
            this.gbMapEditor.Controls.Add(this.btnCursor);
            this.gbMapEditor.Controls.Add(this.btnRoadMode);
            this.gbMapEditor.Controls.Add(this.btnWarehouse);
            this.gbMapEditor.Controls.Add(this.btnLocationMode);
            this.gbMapEditor.Location = new System.Drawing.Point(3, 4);
            this.gbMapEditor.Margin = new System.Windows.Forms.Padding(4);
            this.gbMapEditor.Name = "gbMapEditor";
            this.gbMapEditor.Padding = new System.Windows.Forms.Padding(4);
            this.gbMapEditor.Size = new System.Drawing.Size(309, 279);
            this.gbMapEditor.TabIndex = 24;
            this.gbMapEditor.TabStop = false;
            this.gbMapEditor.Text = "Map Editor";
            // 
            // tbMapEditor
            // 
            this.tbMapEditor.Location = new System.Drawing.Point(153, 175);
            this.tbMapEditor.Margin = new System.Windows.Forms.Padding(4);
            this.tbMapEditor.Name = "tbMapEditor";
            this.tbMapEditor.Size = new System.Drawing.Size(132, 22);
            this.tbMapEditor.TabIndex = 26;
            this.tbMapEditor.Text = "0";
            // 
            // btnRandomMap
            // 
            this.btnRandomMap.Location = new System.Drawing.Point(8, 244);
            this.btnRandomMap.Margin = new System.Windows.Forms.Padding(4);
            this.btnRandomMap.Name = "btnRandomMap";
            this.btnRandomMap.Size = new System.Drawing.Size(295, 28);
            this.btnRandomMap.TabIndex = 25;
            this.btnRandomMap.Text = "Create Random Map";
            this.btnRandomMap.UseVisualStyleBackColor = true;
            this.btnRandomMap.Click += new System.EventHandler(this.btnRandomMap_Click);
            // 
            // btnRandomHeatMap
            // 
            this.btnRandomHeatMap.Location = new System.Drawing.Point(7, 208);
            this.btnRandomHeatMap.Margin = new System.Windows.Forms.Padding(4);
            this.btnRandomHeatMap.Name = "btnRandomHeatMap";
            this.btnRandomHeatMap.Size = new System.Drawing.Size(296, 28);
            this.btnRandomHeatMap.TabIndex = 24;
            this.btnRandomHeatMap.Text = "Create Random HeatMap";
            this.btnRandomHeatMap.UseVisualStyleBackColor = true;
            this.btnRandomHeatMap.Click += new System.EventHandler(this.btnRandomHeatMap_Click);
            // 
            // btnShop
            // 
            this.btnShop.BackgroundImage = global::MapLayout.Properties.Resources.shopIcon;
            this.btnShop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShop.Location = new System.Drawing.Point(7, 22);
            this.btnShop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShop.Name = "btnShop";
            this.btnShop.Size = new System.Drawing.Size(88, 71);
            this.btnShop.TabIndex = 1;
            this.btnShop.UseVisualStyleBackColor = true;
            this.btnShop.Click += new System.EventHandler(this.btnShop_Click);
            // 
            // lblMapEditor
            // 
            this.lblMapEditor.AutoSize = true;
            this.lblMapEditor.Location = new System.Drawing.Point(9, 178);
            this.lblMapEditor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMapEditor.Name = "lblMapEditor";
            this.lblMapEditor.Size = new System.Drawing.Size(135, 17);
            this.lblMapEditor.TabIndex = 23;
            this.lblMapEditor.Text = "Initial Cost For Road";
            // 
            // btnCursor
            // 
            this.btnCursor.BackgroundImage = global::MapLayout.Properties.Resources.cursorIcon;
            this.btnCursor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCursor.Location = new System.Drawing.Point(195, 23);
            this.btnCursor.Margin = new System.Windows.Forms.Padding(4);
            this.btnCursor.Name = "btnCursor";
            this.btnCursor.Size = new System.Drawing.Size(88, 70);
            this.btnCursor.TabIndex = 6;
            this.btnCursor.UseVisualStyleBackColor = true;
            this.btnCursor.Click += new System.EventHandler(this.btnCursor_Click);
            // 
            // btnRoadMode
            // 
            this.btnRoadMode.BackgroundImage = global::MapLayout.Properties.Resources.Road;
            this.btnRoadMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRoadMode.Location = new System.Drawing.Point(100, 100);
            this.btnRoadMode.Margin = new System.Windows.Forms.Padding(4);
            this.btnRoadMode.Name = "btnRoadMode";
            this.btnRoadMode.Size = new System.Drawing.Size(88, 70);
            this.btnRoadMode.TabIndex = 20;
            this.btnRoadMode.UseVisualStyleBackColor = true;
            this.btnRoadMode.Click += new System.EventHandler(this.btnRoadMode_Click);
            // 
            // btnWarehouse
            // 
            this.btnWarehouse.BackgroundImage = global::MapLayout.Properties.Resources.warehouseIcon;
            this.btnWarehouse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnWarehouse.Location = new System.Drawing.Point(100, 23);
            this.btnWarehouse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.Size = new System.Drawing.Size(88, 70);
            this.btnWarehouse.TabIndex = 2;
            this.btnWarehouse.UseVisualStyleBackColor = true;
            this.btnWarehouse.Click += new System.EventHandler(this.btnWarehouse_Click);
            // 
            // btnLocationMode
            // 
            this.btnLocationMode.BackgroundImage = global::MapLayout.Properties.Resources.Locations;
            this.btnLocationMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLocationMode.Location = new System.Drawing.Point(8, 100);
            this.btnLocationMode.Margin = new System.Windows.Forms.Padding(4);
            this.btnLocationMode.Name = "btnLocationMode";
            this.btnLocationMode.Size = new System.Drawing.Size(88, 70);
            this.btnLocationMode.TabIndex = 21;
            this.btnLocationMode.UseVisualStyleBackColor = true;
            this.btnLocationMode.Click += new System.EventHandler(this.btnLocationMode_Click);
            // 
            // lbLocationLog
            // 
            this.lbLocationLog.AutoSize = true;
            this.lbLocationLog.Location = new System.Drawing.Point(12, 779);
            this.lbLocationLog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLocationLog.Name = "lbLocationLog";
            this.lbLocationLog.Size = new System.Drawing.Size(0, 17);
            this.lbLocationLog.TabIndex = 7;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 742);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelPlayer.ResumeLayout(false);
            this.panelPlayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).EndInit();
            this.panelMapBuilder.ResumeLayout(false);
            this.panelMapBuilder.PerformLayout();
            this.gbDijkstraTool.ResumeLayout(false);
            this.gbDijkstraTool.PerformLayout();
            this.gbImportExport.ResumeLayout(false);
            this.gbMapEditor.ResumeLayout(false);
            this.gbMapEditor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnShop;
        private System.Windows.Forms.PictureBox mapPictureBox;
        private System.Windows.Forms.Button btnWarehouse;
        private System.Windows.Forms.Button btnCursor;
        private System.Windows.Forms.Label lbLocationLog;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnDrawRoute;
        private System.Windows.Forms.TextBox tbDrawDijkstraFrom;
        private System.Windows.Forms.Button btnDrawDijkstra;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnHeatMap;
        private System.Windows.Forms.Button btnRoadMode;
        private System.Windows.Forms.Button btnLocationMode;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button loadMapBtn;
        private System.Windows.Forms.Panel panelMapBuilder;
        private System.Windows.Forms.GroupBox gbImportExport;
        private System.Windows.Forms.GroupBox gbMapEditor;
        private System.Windows.Forms.Button btnRandomMap;
        private System.Windows.Forms.Button btnRandomHeatMap;
        private System.Windows.Forms.Label lblMapEditor;
        private System.Windows.Forms.GroupBox gbDijkstraTool;
        private System.Windows.Forms.TextBox tbDrawRouteFrom;
        private System.Windows.Forms.TextBox tbDrawRouteTo;
        private System.Windows.Forms.Panel panelPlayer;
        private System.Windows.Forms.Button btnAnalyzeMap;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Button btnSlowDown;
        private System.Windows.Forms.Button btnSpeedUp;
        private System.Windows.Forms.TextBox tbMapEditor;
        private System.Windows.Forms.Button btnDrawWarehouseRoute;
        private System.Windows.Forms.TextBox tbDrawWarehouse;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbDrawShop;
        private System.Windows.Forms.Button DrawAllClosests;
        private System.Windows.Forms.Button btnGetBestPlacement;
        private System.Windows.Forms.TextBox AmTicks;
        private System.Windows.Forms.ProgressBar progressBestPlacement;
        private System.Windows.Forms.Button btnStatistics;
    }
}

