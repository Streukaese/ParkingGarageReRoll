namespace ParkingGarageReRoll
{
    partial class Parkhouse
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelSearchResult = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.labelSearch = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.labelSlotFloorBike = new System.Windows.Forms.Label();
            this.labelSlotFloorCar = new System.Windows.Forms.Label();
            this.numericUpDownFloorBike = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownFloorCar = new System.Windows.Forms.NumericUpDown();
            this.comboBoxVehicleType = new System.Windows.Forms.ComboBox();
            this.textBoxVehicleLicensePlate = new System.Windows.Forms.TextBox();
            this.labelVehicleType = new System.Windows.Forms.Label();
            this.labelVehicleLicensePlate = new System.Windows.Forms.Label();
            this.labelParkingVehicle = new System.Windows.Forms.Label();
            this.labelParkingFloor = new System.Windows.Forms.Label();
            this.labelFreeParkSlot = new System.Windows.Forms.Label();
            this.buttonVehicleUpdate = new System.Windows.Forms.Button();
            this.buttonVehicleRemove = new System.Windows.Forms.Button();
            this.buttonVehicleAdd = new System.Windows.Forms.Button();
            this.buttonFloorUpdate = new System.Windows.Forms.Button();
            this.buttonFloorRemove = new System.Windows.Forms.Button();
            this.buttonFloorAdd = new System.Windows.Forms.Button();
            this.dataGridViewVehicle = new System.Windows.Forms.DataGridView();
            this.ColumnVehicleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnVehicleType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnVehicleParkingPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnVehicleLicensePlate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewParkingFloor = new System.Windows.Forms.DataGridView();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFloorname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCarSlotCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBikeSlotCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFloorBike)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFloorCar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVehicle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParkingFloor)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSearchResult
            // 
            this.labelSearchResult.AutoSize = true;
            this.labelSearchResult.Location = new System.Drawing.Point(879, 391);
            this.labelSearchResult.Name = "labelSearchResult";
            this.labelSearchResult.Size = new System.Drawing.Size(162, 16);
            this.labelSearchResult.TabIndex = 49;
            this.labelSearchResult.Text = "<<Result of your Search>>";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(922, 494);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(221, 35);
            this.buttonSearch.TabIndex = 48;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(879, 469);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(101, 16);
            this.labelSearch.TabIndex = 47;
            this.labelSearch.Text = "Search Vehicle:";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(1011, 466);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(132, 22);
            this.textBoxSearch.TabIndex = 46;
            this.textBoxSearch.Text = "<<License Plate>>";
            this.textBoxSearch.Click += new System.EventHandler(this.textBoxSearch_Click);
            this.textBoxSearch.Enter += new System.EventHandler(this.textBoxSearch_Click);
            // 
            // labelSlotFloorBike
            // 
            this.labelSlotFloorBike.AutoSize = true;
            this.labelSlotFloorBike.Location = new System.Drawing.Point(7, 66);
            this.labelSlotFloorBike.Name = "labelSlotFloorBike";
            this.labelSlotFloorBike.Size = new System.Drawing.Size(119, 16);
            this.labelSlotFloorBike.TabIndex = 45;
            this.labelSlotFloorBike.Text = "Bike Parking Slots:";
            // 
            // labelSlotFloorCar
            // 
            this.labelSlotFloorCar.AutoSize = true;
            this.labelSlotFloorCar.Location = new System.Drawing.Point(13, 38);
            this.labelSlotFloorCar.Name = "labelSlotFloorCar";
            this.labelSlotFloorCar.Size = new System.Drawing.Size(113, 16);
            this.labelSlotFloorCar.TabIndex = 44;
            this.labelSlotFloorCar.Text = "Car Parking Slots:";
            // 
            // numericUpDownFloorBike
            // 
            this.numericUpDownFloorBike.Location = new System.Drawing.Point(132, 64);
            this.numericUpDownFloorBike.Name = "numericUpDownFloorBike";
            this.numericUpDownFloorBike.Size = new System.Drawing.Size(183, 22);
            this.numericUpDownFloorBike.TabIndex = 43;
            // 
            // numericUpDownFloorCar
            // 
            this.numericUpDownFloorCar.Location = new System.Drawing.Point(132, 36);
            this.numericUpDownFloorCar.Name = "numericUpDownFloorCar";
            this.numericUpDownFloorCar.Size = new System.Drawing.Size(183, 22);
            this.numericUpDownFloorCar.TabIndex = 42;
            // 
            // comboBoxVehicleType
            // 
            this.comboBoxVehicleType.FormattingEnabled = true;
            this.comboBoxVehicleType.Items.AddRange(new object[] {
            "Car",
            "Motorcycle"});
            this.comboBoxVehicleType.Location = new System.Drawing.Point(132, 342);
            this.comboBoxVehicleType.Name = "comboBoxVehicleType";
            this.comboBoxVehicleType.Size = new System.Drawing.Size(183, 24);
            this.comboBoxVehicleType.TabIndex = 41;
            // 
            // textBoxVehicleLicensePlate
            // 
            this.textBoxVehicleLicensePlate.Location = new System.Drawing.Point(132, 314);
            this.textBoxVehicleLicensePlate.Name = "textBoxVehicleLicensePlate";
            this.textBoxVehicleLicensePlate.Size = new System.Drawing.Size(183, 22);
            this.textBoxVehicleLicensePlate.TabIndex = 40;
            // 
            // labelVehicleType
            // 
            this.labelVehicleType.AutoSize = true;
            this.labelVehicleType.Location = new System.Drawing.Point(36, 345);
            this.labelVehicleType.Name = "labelVehicleType";
            this.labelVehicleType.Size = new System.Drawing.Size(90, 16);
            this.labelVehicleType.TabIndex = 39;
            this.labelVehicleType.Text = "Vehicle Type:";
            // 
            // labelVehicleLicensePlate
            // 
            this.labelVehicleLicensePlate.AutoSize = true;
            this.labelVehicleLicensePlate.Location = new System.Drawing.Point(35, 317);
            this.labelVehicleLicensePlate.Name = "labelVehicleLicensePlate";
            this.labelVehicleLicensePlate.Size = new System.Drawing.Size(91, 16);
            this.labelVehicleLicensePlate.TabIndex = 38;
            this.labelVehicleLicensePlate.Text = "License Plate:";
            // 
            // labelParkingVehicle
            // 
            this.labelParkingVehicle.AutoSize = true;
            this.labelParkingVehicle.Location = new System.Drawing.Point(318, 282);
            this.labelParkingVehicle.Name = "labelParkingVehicle";
            this.labelParkingVehicle.Size = new System.Drawing.Size(329, 16);
            this.labelParkingVehicle.TabIndex = 35;
            this.labelParkingVehicle.Text = "\"Parkende Fahrzeuge der markierten Etage anzeigen\"";
            // 
            // labelParkingFloor
            // 
            this.labelParkingFloor.AutoSize = true;
            this.labelParkingFloor.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.labelParkingFloor.Location = new System.Drawing.Point(318, 12);
            this.labelParkingFloor.Name = "labelParkingFloor";
            this.labelParkingFloor.Size = new System.Drawing.Size(137, 16);
            this.labelParkingFloor.TabIndex = 34;
            this.labelParkingFloor.Text = "Parking Floors Below:";
            // 
            // labelFreeParkSlot
            // 
            this.labelFreeParkSlot.AutoSize = true;
            this.labelFreeParkSlot.Location = new System.Drawing.Point(879, 84);
            this.labelFreeParkSlot.Name = "labelFreeParkSlot";
            this.labelFreeParkSlot.Size = new System.Drawing.Size(195, 16);
            this.labelFreeParkSlot.TabIndex = 33;
            this.labelFreeParkSlot.Text = "\"Aviable parking space of floor\"";
            // 
            // buttonVehicleUpdate
            // 
            this.buttonVehicleUpdate.Location = new System.Drawing.Point(94, 429);
            this.buttonVehicleUpdate.Name = "buttonVehicleUpdate";
            this.buttonVehicleUpdate.Size = new System.Drawing.Size(221, 35);
            this.buttonVehicleUpdate.TabIndex = 32;
            this.buttonVehicleUpdate.Text = "Update Vehicle";
            this.buttonVehicleUpdate.UseVisualStyleBackColor = true;
            this.buttonVehicleUpdate.Click += new System.EventHandler(this.buttonVehicleUpdate_Click);
            // 
            // buttonVehicleRemove
            // 
            this.buttonVehicleRemove.Location = new System.Drawing.Point(959, 301);
            this.buttonVehicleRemove.Name = "buttonVehicleRemove";
            this.buttonVehicleRemove.Size = new System.Drawing.Size(221, 35);
            this.buttonVehicleRemove.TabIndex = 31;
            this.buttonVehicleRemove.Text = "Remove Vehicle";
            this.buttonVehicleRemove.UseVisualStyleBackColor = true;
            this.buttonVehicleRemove.Click += new System.EventHandler(this.buttonVehicleRemove_Click);
            // 
            // buttonVehicleAdd
            // 
            this.buttonVehicleAdd.Location = new System.Drawing.Point(94, 372);
            this.buttonVehicleAdd.Name = "buttonVehicleAdd";
            this.buttonVehicleAdd.Size = new System.Drawing.Size(221, 35);
            this.buttonVehicleAdd.TabIndex = 30;
            this.buttonVehicleAdd.Text = "Add Vehicle";
            this.buttonVehicleAdd.UseVisualStyleBackColor = true;
            this.buttonVehicleAdd.Click += new System.EventHandler(this.buttonVehicleAdd_Click);
            // 
            // buttonFloorUpdate
            // 
            this.buttonFloorUpdate.Location = new System.Drawing.Point(94, 150);
            this.buttonFloorUpdate.Name = "buttonFloorUpdate";
            this.buttonFloorUpdate.Size = new System.Drawing.Size(221, 35);
            this.buttonFloorUpdate.TabIndex = 29;
            this.buttonFloorUpdate.Text = "Update Parking Floor";
            this.buttonFloorUpdate.UseVisualStyleBackColor = true;
            this.buttonFloorUpdate.Click += new System.EventHandler(this.buttonFloorUpdate_Click);
            // 
            // buttonFloorRemove
            // 
            this.buttonFloorRemove.Location = new System.Drawing.Point(959, 29);
            this.buttonFloorRemove.Name = "buttonFloorRemove";
            this.buttonFloorRemove.Size = new System.Drawing.Size(221, 35);
            this.buttonFloorRemove.TabIndex = 28;
            this.buttonFloorRemove.Text = "Remove Parking Floor";
            this.buttonFloorRemove.UseVisualStyleBackColor = true;
            this.buttonFloorRemove.Click += new System.EventHandler(this.buttonFloorRemove_Click);
            // 
            // buttonFloorAdd
            // 
            this.buttonFloorAdd.Location = new System.Drawing.Point(94, 92);
            this.buttonFloorAdd.Name = "buttonFloorAdd";
            this.buttonFloorAdd.Size = new System.Drawing.Size(221, 35);
            this.buttonFloorAdd.TabIndex = 27;
            this.buttonFloorAdd.Text = "Add Parking Floor";
            this.buttonFloorAdd.UseVisualStyleBackColor = true;
            this.buttonFloorAdd.Click += new System.EventHandler(this.buttonFloorAdd_Click);
            // 
            // dataGridViewVehicle
            // 
            this.dataGridViewVehicle.AllowUserToAddRows = false;
            this.dataGridViewVehicle.AllowUserToDeleteRows = false;
            this.dataGridViewVehicle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVehicle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnVehicleId,
            this.ColumnVehicleType,
            this.ColumnVehicleParkingPosition,
            this.ColumnVehicleLicensePlate});
            this.dataGridViewVehicle.Location = new System.Drawing.Point(321, 301);
            this.dataGridViewVehicle.MultiSelect = false;
            this.dataGridViewVehicle.Name = "dataGridViewVehicle";
            this.dataGridViewVehicle.ReadOnly = true;
            this.dataGridViewVehicle.RowHeadersWidth = 51;
            this.dataGridViewVehicle.RowTemplate.Height = 24;
            this.dataGridViewVehicle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewVehicle.Size = new System.Drawing.Size(552, 231);
            this.dataGridViewVehicle.TabIndex = 26;
            // 
            // ColumnVehicleId
            // 
            this.ColumnVehicleId.HeaderText = "ID";
            this.ColumnVehicleId.MinimumWidth = 6;
            this.ColumnVehicleId.Name = "ColumnVehicleId";
            this.ColumnVehicleId.ReadOnly = true;
            this.ColumnVehicleId.Visible = false;
            this.ColumnVehicleId.Width = 125;
            // 
            // ColumnVehicleType
            // 
            this.ColumnVehicleType.HeaderText = "Vehicle Type";
            this.ColumnVehicleType.MinimumWidth = 6;
            this.ColumnVehicleType.Name = "ColumnVehicleType";
            this.ColumnVehicleType.ReadOnly = true;
            this.ColumnVehicleType.Width = 125;
            // 
            // ColumnVehicleParkingPosition
            // 
            this.ColumnVehicleParkingPosition.HeaderText = "Parking Position";
            this.ColumnVehicleParkingPosition.MinimumWidth = 6;
            this.ColumnVehicleParkingPosition.Name = "ColumnVehicleParkingPosition";
            this.ColumnVehicleParkingPosition.ReadOnly = true;
            this.ColumnVehicleParkingPosition.Visible = false;
            this.ColumnVehicleParkingPosition.Width = 125;
            // 
            // ColumnVehicleLicensePlate
            // 
            this.ColumnVehicleLicensePlate.HeaderText = "License Plate";
            this.ColumnVehicleLicensePlate.MinimumWidth = 6;
            this.ColumnVehicleLicensePlate.Name = "ColumnVehicleLicensePlate";
            this.ColumnVehicleLicensePlate.ReadOnly = true;
            this.ColumnVehicleLicensePlate.Width = 125;
            // 
            // dataGridViewParkingFloor
            // 
            this.dataGridViewParkingFloor.AllowUserToAddRows = false;
            this.dataGridViewParkingFloor.AllowUserToDeleteRows = false;
            this.dataGridViewParkingFloor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewParkingFloor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ColumnFloorname,
            this.ColumnCarSlotCount,
            this.ColumnBikeSlotCount});
            this.dataGridViewParkingFloor.Location = new System.Drawing.Point(321, 29);
            this.dataGridViewParkingFloor.MultiSelect = false;
            this.dataGridViewParkingFloor.Name = "dataGridViewParkingFloor";
            this.dataGridViewParkingFloor.ReadOnly = true;
            this.dataGridViewParkingFloor.RowHeadersWidth = 51;
            this.dataGridViewParkingFloor.RowTemplate.Height = 24;
            this.dataGridViewParkingFloor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewParkingFloor.Size = new System.Drawing.Size(552, 224);
            this.dataGridViewParkingFloor.TabIndex = 25;
            this.dataGridViewParkingFloor.SelectionChanged += new System.EventHandler(this.dataGridViewParkingFloor_SelectionChanged);
            // 
            // ColumnID
            // 
            this.ColumnID.HeaderText = "ID";
            this.ColumnID.MinimumWidth = 6;
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            this.ColumnID.Visible = false;
            this.ColumnID.Width = 125;
            // 
            // ColumnFloorname
            // 
            this.ColumnFloorname.HeaderText = "Floorname";
            this.ColumnFloorname.MinimumWidth = 6;
            this.ColumnFloorname.Name = "ColumnFloorname";
            this.ColumnFloorname.ReadOnly = true;
            this.ColumnFloorname.Width = 125;
            // 
            // ColumnCarSlotCount
            // 
            this.ColumnCarSlotCount.HeaderText = "Car Slot Count";
            this.ColumnCarSlotCount.MinimumWidth = 6;
            this.ColumnCarSlotCount.Name = "ColumnCarSlotCount";
            this.ColumnCarSlotCount.ReadOnly = true;
            this.ColumnCarSlotCount.Width = 125;
            // 
            // ColumnBikeSlotCount
            // 
            this.ColumnBikeSlotCount.HeaderText = "Bike Slot Count";
            this.ColumnBikeSlotCount.MinimumWidth = 6;
            this.ColumnBikeSlotCount.Name = "ColumnBikeSlotCount";
            this.ColumnBikeSlotCount.ReadOnly = true;
            this.ColumnBikeSlotCount.Width = 125;
            // 
            // Parkhouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 556);
            this.Controls.Add(this.labelSearchResult);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.labelSlotFloorBike);
            this.Controls.Add(this.labelSlotFloorCar);
            this.Controls.Add(this.numericUpDownFloorBike);
            this.Controls.Add(this.numericUpDownFloorCar);
            this.Controls.Add(this.comboBoxVehicleType);
            this.Controls.Add(this.textBoxVehicleLicensePlate);
            this.Controls.Add(this.labelVehicleType);
            this.Controls.Add(this.labelVehicleLicensePlate);
            this.Controls.Add(this.labelParkingVehicle);
            this.Controls.Add(this.labelParkingFloor);
            this.Controls.Add(this.labelFreeParkSlot);
            this.Controls.Add(this.buttonVehicleUpdate);
            this.Controls.Add(this.buttonVehicleRemove);
            this.Controls.Add(this.buttonVehicleAdd);
            this.Controls.Add(this.buttonFloorUpdate);
            this.Controls.Add(this.buttonFloorRemove);
            this.Controls.Add(this.buttonFloorAdd);
            this.Controls.Add(this.dataGridViewVehicle);
            this.Controls.Add(this.dataGridViewParkingFloor);
            this.Name = "Parkhouse";
            this.Text = "Parkhouse";
            this.Load += new System.EventHandler(this.Parkhouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFloorBike)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFloorCar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVehicle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParkingFloor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSearchResult;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label labelSlotFloorBike;
        private System.Windows.Forms.Label labelSlotFloorCar;
        private System.Windows.Forms.NumericUpDown numericUpDownFloorBike;
        private System.Windows.Forms.NumericUpDown numericUpDownFloorCar;
        private System.Windows.Forms.ComboBox comboBoxVehicleType;
        private System.Windows.Forms.TextBox textBoxVehicleLicensePlate;
        private System.Windows.Forms.Label labelVehicleType;
        private System.Windows.Forms.Label labelVehicleLicensePlate;
        private System.Windows.Forms.Label labelParkingVehicle;
        private System.Windows.Forms.Label labelParkingFloor;
        private System.Windows.Forms.Label labelFreeParkSlot;
        private System.Windows.Forms.Button buttonVehicleUpdate;
        private System.Windows.Forms.Button buttonVehicleRemove;
        private System.Windows.Forms.Button buttonVehicleAdd;
        private System.Windows.Forms.Button buttonFloorUpdate;
        private System.Windows.Forms.Button buttonFloorRemove;
        private System.Windows.Forms.Button buttonFloorAdd;
        internal System.Windows.Forms.DataGridView dataGridViewVehicle;
        internal System.Windows.Forms.DataGridView dataGridViewParkingFloor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFloorname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCarSlotCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBikeSlotCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnVehicleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnVehicleType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnVehicleParkingPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnVehicleLicensePlate;
    }
}

