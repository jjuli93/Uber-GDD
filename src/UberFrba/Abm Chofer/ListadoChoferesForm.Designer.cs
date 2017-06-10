namespace UberFrba.Abm_Chofer
{
    partial class ListadoChoferesForm
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
            this.itemSelectedPanel = new System.Windows.Forms.Panel();
            this.eliminarButton = new System.Windows.Forms.Button();
            this.modificarButton = new System.Windows.Forms.Button();
            this.verButton = new System.Windows.Forms.Button();
            this.volverButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.choferesDataGridView = new System.Windows.Forms.DataGridView();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.buscarButton = new System.Windows.Forms.Button();
            this.dniTextBox = new System.Windows.Forms.TextBox();
            this.apellidoTextBox = new System.Windows.Forms.TextBox();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.choferSelectedPanel = new System.Windows.Forms.Panel();
            this.seleccionarButton = new System.Windows.Forms.Button();
            this.verButtonSelected = new System.Windows.Forms.Button();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.itemSelectedPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.choferesDataGridView)).BeginInit();
            this.choferSelectedPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemSelectedPanel
            // 
            this.itemSelectedPanel.Controls.Add(this.eliminarButton);
            this.itemSelectedPanel.Controls.Add(this.modificarButton);
            this.itemSelectedPanel.Controls.Add(this.verButton);
            this.itemSelectedPanel.Location = new System.Drawing.Point(160, 334);
            this.itemSelectedPanel.Name = "itemSelectedPanel";
            this.itemSelectedPanel.Size = new System.Drawing.Size(243, 29);
            this.itemSelectedPanel.TabIndex = 0;
            // 
            // eliminarButton
            // 
            this.eliminarButton.Enabled = false;
            this.eliminarButton.Location = new System.Drawing.Point(165, 3);
            this.eliminarButton.Name = "eliminarButton";
            this.eliminarButton.Size = new System.Drawing.Size(75, 23);
            this.eliminarButton.TabIndex = 2;
            this.eliminarButton.Text = "Eliminar";
            this.eliminarButton.UseVisualStyleBackColor = true;
            this.eliminarButton.Click += new System.EventHandler(this.eliminarButton_Click);
            // 
            // modificarButton
            // 
            this.modificarButton.Enabled = false;
            this.modificarButton.Location = new System.Drawing.Point(84, 3);
            this.modificarButton.Name = "modificarButton";
            this.modificarButton.Size = new System.Drawing.Size(75, 23);
            this.modificarButton.TabIndex = 1;
            this.modificarButton.Text = "Modificar";
            this.modificarButton.UseVisualStyleBackColor = true;
            this.modificarButton.Click += new System.EventHandler(this.modificarButton_Click);
            // 
            // verButton
            // 
            this.verButton.Enabled = false;
            this.verButton.Location = new System.Drawing.Point(3, 3);
            this.verButton.Name = "verButton";
            this.verButton.Size = new System.Drawing.Size(75, 23);
            this.verButton.TabIndex = 0;
            this.verButton.Text = "Ver";
            this.verButton.UseVisualStyleBackColor = true;
            this.verButton.Click += new System.EventHandler(this.verButton_Click);
            // 
            // volverButton
            // 
            this.volverButton.Location = new System.Drawing.Point(25, 337);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(75, 23);
            this.volverButton.TabIndex = 1;
            this.volverButton.Text = "<< Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.choferesDataGridView);
            this.groupBox1.Controls.Add(this.limpiarButton);
            this.groupBox1.Controls.Add(this.buscarButton);
            this.groupBox1.Controls.Add(this.dniTextBox);
            this.groupBox1.Controls.Add(this.apellidoTextBox);
            this.groupBox1.Controls.Add(this.nombreTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 306);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscador de choferes";
            // 
            // choferesDataGridView
            // 
            this.choferesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.choferesDataGridView.Location = new System.Drawing.Point(12, 121);
            this.choferesDataGridView.MultiSelect = false;
            this.choferesDataGridView.Name = "choferesDataGridView";
            this.choferesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.choferesDataGridView.Size = new System.Drawing.Size(362, 172);
            this.choferesDataGridView.TabIndex = 8;
            this.choferesDataGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.choferesDataGridView_MouseClick);
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(299, 68);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(75, 23);
            this.limpiarButton.TabIndex = 7;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // buscarButton
            // 
            this.buscarButton.Location = new System.Drawing.Point(299, 38);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(75, 23);
            this.buscarButton.TabIndex = 6;
            this.buscarButton.Text = "Buscar";
            this.buscarButton.UseVisualStyleBackColor = true;
            this.buscarButton.Click += new System.EventHandler(this.buscarButton_Click);
            // 
            // dniTextBox
            // 
            this.dniTextBox.Location = new System.Drawing.Point(91, 83);
            this.dniTextBox.Name = "dniTextBox";
            this.dniTextBox.Size = new System.Drawing.Size(190, 20);
            this.dniTextBox.TabIndex = 5;
            // 
            // apellidoTextBox
            // 
            this.apellidoTextBox.Location = new System.Drawing.Point(91, 55);
            this.apellidoTextBox.Name = "apellidoTextBox";
            this.apellidoTextBox.Size = new System.Drawing.Size(190, 20);
            this.apellidoTextBox.TabIndex = 4;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.Location = new System.Drawing.Point(91, 27);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(190, 20);
            this.nombreTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "DNI:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // choferSelectedPanel
            // 
            this.choferSelectedPanel.Controls.Add(this.seleccionarButton);
            this.choferSelectedPanel.Controls.Add(this.verButtonSelected);
            this.choferSelectedPanel.Controls.Add(this.cancelarButton);
            this.choferSelectedPanel.Enabled = false;
            this.choferSelectedPanel.Location = new System.Drawing.Point(160, 334);
            this.choferSelectedPanel.Name = "choferSelectedPanel";
            this.choferSelectedPanel.Size = new System.Drawing.Size(243, 29);
            this.choferSelectedPanel.TabIndex = 3;
            this.choferSelectedPanel.Visible = false;
            // 
            // seleccionarButton
            // 
            this.seleccionarButton.Enabled = false;
            this.seleccionarButton.Location = new System.Drawing.Point(3, 3);
            this.seleccionarButton.Name = "seleccionarButton";
            this.seleccionarButton.Size = new System.Drawing.Size(75, 23);
            this.seleccionarButton.TabIndex = 3;
            this.seleccionarButton.Text = "Seleccionar";
            this.seleccionarButton.UseVisualStyleBackColor = true;
            this.seleccionarButton.Click += new System.EventHandler(this.seleccionarButton_Click);
            // 
            // verButtonSelected
            // 
            this.verButtonSelected.Enabled = false;
            this.verButtonSelected.Location = new System.Drawing.Point(84, 3);
            this.verButtonSelected.Name = "verButtonSelected";
            this.verButtonSelected.Size = new System.Drawing.Size(75, 23);
            this.verButtonSelected.TabIndex = 4;
            this.verButtonSelected.Text = "Ver";
            this.verButtonSelected.UseVisualStyleBackColor = true;
            this.verButtonSelected.Click += new System.EventHandler(this.verButtonSelected_Click);
            // 
            // cancelarButton
            // 
            this.cancelarButton.Location = new System.Drawing.Point(165, 3);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(75, 23);
            this.cancelarButton.TabIndex = 5;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // ListadoChoferesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 375);
            this.Controls.Add(this.choferSelectedPanel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.volverButton);
            this.Controls.Add(this.itemSelectedPanel);
            this.Name = "ListadoChoferesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Choferes";
            this.itemSelectedPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.choferesDataGridView)).EndInit();
            this.choferSelectedPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel itemSelectedPanel;
        private System.Windows.Forms.Button eliminarButton;
        private System.Windows.Forms.Button modificarButton;
        private System.Windows.Forms.Button verButton;
        private System.Windows.Forms.Button volverButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buscarButton;
        private System.Windows.Forms.TextBox dniTextBox;
        private System.Windows.Forms.TextBox apellidoTextBox;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.DataGridView choferesDataGridView;
        private System.Windows.Forms.Panel choferSelectedPanel;
        private System.Windows.Forms.Button seleccionarButton;
        private System.Windows.Forms.Button verButtonSelected;
        private System.Windows.Forms.Button cancelarButton;
    }
}