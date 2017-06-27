namespace UberFrba.Abm_Automovil
{
    partial class ListadoAutomovilesForm
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
            this.filtrosGroupBox = new System.Windows.Forms.GroupBox();
            this.modeloComboBox = new System.Windows.Forms.ComboBox();
            this.choferTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.patenteTextBox = new System.Windows.Forms.TextBox();
            this.marcaComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.autosDataGridView = new System.Windows.Forms.DataGridView();
            this.buscarButton = new System.Windows.Forms.Button();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.autoSelectedPanelBtns = new System.Windows.Forms.Panel();
            this.eliminarButton = new System.Windows.Forms.Button();
            this.modificarButton = new System.Windows.Forms.Button();
            this.verButton = new System.Windows.Forms.Button();
            this.volverButton = new System.Windows.Forms.Button();
            this.filtrosGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autosDataGridView)).BeginInit();
            this.autoSelectedPanelBtns.SuspendLayout();
            this.SuspendLayout();
            // 
            // filtrosGroupBox
            // 
            this.filtrosGroupBox.Controls.Add(this.modeloComboBox);
            this.filtrosGroupBox.Controls.Add(this.choferTextBox);
            this.filtrosGroupBox.Controls.Add(this.label3);
            this.filtrosGroupBox.Controls.Add(this.patenteTextBox);
            this.filtrosGroupBox.Controls.Add(this.marcaComboBox);
            this.filtrosGroupBox.Controls.Add(this.label4);
            this.filtrosGroupBox.Controls.Add(this.label2);
            this.filtrosGroupBox.Controls.Add(this.label1);
            this.filtrosGroupBox.Location = new System.Drawing.Point(13, 13);
            this.filtrosGroupBox.Name = "filtrosGroupBox";
            this.filtrosGroupBox.Size = new System.Drawing.Size(441, 100);
            this.filtrosGroupBox.TabIndex = 0;
            this.filtrosGroupBox.TabStop = false;
            this.filtrosGroupBox.Text = "Filtros de busqueda";
            // 
            // modeloComboBox
            // 
            this.modeloComboBox.FormattingEnabled = true;
            this.modeloComboBox.Location = new System.Drawing.Point(228, 25);
            this.modeloComboBox.Name = "modeloComboBox";
            this.modeloComboBox.Size = new System.Drawing.Size(207, 21);
            this.modeloComboBox.TabIndex = 8;
            // 
            // choferTextBox
            // 
            this.choferTextBox.Location = new System.Drawing.Point(246, 62);
            this.choferTextBox.Name = "choferTextBox";
            this.choferTextBox.Size = new System.Drawing.Size(189, 20);
            this.choferTextBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Patente:";
            // 
            // patenteTextBox
            // 
            this.patenteTextBox.Location = new System.Drawing.Point(56, 62);
            this.patenteTextBox.Name = "patenteTextBox";
            this.patenteTextBox.Size = new System.Drawing.Size(110, 20);
            this.patenteTextBox.TabIndex = 5;
            // 
            // marcaComboBox
            // 
            this.marcaComboBox.FormattingEnabled = true;
            this.marcaComboBox.Location = new System.Drawing.Point(56, 25);
            this.marcaComboBox.Name = "marcaComboBox";
            this.marcaComboBox.Size = new System.Drawing.Size(110, 21);
            this.marcaComboBox.TabIndex = 4;
            this.marcaComboBox.SelectedIndexChanged += new System.EventHandler(this.marcaComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(177, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "DNI Chofer:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Modelo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Marca:";
            // 
            // autosDataGridView
            // 
            this.autosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.autosDataGridView.Location = new System.Drawing.Point(13, 165);
            this.autosDataGridView.MultiSelect = false;
            this.autosDataGridView.Name = "autosDataGridView";
            this.autosDataGridView.ReadOnly = true;
            this.autosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.autosDataGridView.Size = new System.Drawing.Size(441, 167);
            this.autosDataGridView.TabIndex = 1;
            this.autosDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.autosDataGridView_CellContentClick);
            // 
            // buscarButton
            // 
            this.buscarButton.Location = new System.Drawing.Point(378, 127);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(75, 23);
            this.buscarButton.TabIndex = 2;
            this.buscarButton.Text = "Buscar";
            this.buscarButton.UseVisualStyleBackColor = true;
            this.buscarButton.Click += new System.EventHandler(this.buscarButton_Click);
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(287, 127);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(75, 23);
            this.limpiarButton.TabIndex = 3;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Resultados de busqueda:";
            // 
            // autoSelectedPanelBtns
            // 
            this.autoSelectedPanelBtns.Controls.Add(this.eliminarButton);
            this.autoSelectedPanelBtns.Controls.Add(this.modificarButton);
            this.autoSelectedPanelBtns.Controls.Add(this.verButton);
            this.autoSelectedPanelBtns.Location = new System.Drawing.Point(193, 347);
            this.autoSelectedPanelBtns.Name = "autoSelectedPanelBtns";
            this.autoSelectedPanelBtns.Size = new System.Drawing.Size(261, 35);
            this.autoSelectedPanelBtns.TabIndex = 5;
            // 
            // eliminarButton
            // 
            this.eliminarButton.Location = new System.Drawing.Point(176, 6);
            this.eliminarButton.Name = "eliminarButton";
            this.eliminarButton.Size = new System.Drawing.Size(75, 23);
            this.eliminarButton.TabIndex = 2;
            this.eliminarButton.Text = "Eliminar";
            this.eliminarButton.UseVisualStyleBackColor = true;
            this.eliminarButton.Click += new System.EventHandler(this.eliminarButton_Click);
            // 
            // modificarButton
            // 
            this.modificarButton.Location = new System.Drawing.Point(92, 6);
            this.modificarButton.Name = "modificarButton";
            this.modificarButton.Size = new System.Drawing.Size(75, 23);
            this.modificarButton.TabIndex = 1;
            this.modificarButton.Text = "Modificar";
            this.modificarButton.UseVisualStyleBackColor = true;
            this.modificarButton.Click += new System.EventHandler(this.modificarButton_Click);
            // 
            // verButton
            // 
            this.verButton.Location = new System.Drawing.Point(8, 6);
            this.verButton.Name = "verButton";
            this.verButton.Size = new System.Drawing.Size(75, 23);
            this.verButton.TabIndex = 0;
            this.verButton.Text = "Ver";
            this.verButton.UseVisualStyleBackColor = true;
            this.verButton.Click += new System.EventHandler(this.verButton_Click);
            // 
            // volverButton
            // 
            this.volverButton.Location = new System.Drawing.Point(13, 352);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(75, 23);
            this.volverButton.TabIndex = 6;
            this.volverButton.Text = "<< Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // ListadoAutomovilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 395);
            this.Controls.Add(this.volverButton);
            this.Controls.Add(this.autoSelectedPanelBtns);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.buscarButton);
            this.Controls.Add(this.autosDataGridView);
            this.Controls.Add(this.filtrosGroupBox);
            this.Name = "ListadoAutomovilesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Automoviles";
            this.filtrosGroupBox.ResumeLayout(false);
            this.filtrosGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autosDataGridView)).EndInit();
            this.autoSelectedPanelBtns.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox filtrosGroupBox;
        private System.Windows.Forms.TextBox choferTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox patenteTextBox;
        private System.Windows.Forms.ComboBox marcaComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView autosDataGridView;
        private System.Windows.Forms.Button buscarButton;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel autoSelectedPanelBtns;
        private System.Windows.Forms.Button eliminarButton;
        private System.Windows.Forms.Button modificarButton;
        private System.Windows.Forms.Button verButton;
        private System.Windows.Forms.Button volverButton;
        private System.Windows.Forms.ComboBox modeloComboBox;
    }
}