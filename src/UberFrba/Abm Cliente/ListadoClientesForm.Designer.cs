namespace UberFrba.Abm_Cliente
{
    partial class ListadoClientesForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cleanParamsButton = new System.Windows.Forms.Button();
            this.dniFilterTB = new System.Windows.Forms.TextBox();
            this.buscarButton = new System.Windows.Forms.Button();
            this.lnameFilterTB = new System.Windows.Forms.TextBox();
            this.nameFilterTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clientesDataGridView = new System.Windows.Forms.DataGridView();
            this.volverButton = new System.Windows.Forms.Button();
            this.cleanTableButton = new System.Windows.Forms.Button();
            this.modificarButton = new System.Windows.Forms.Button();
            this.eliminarButton = new System.Windows.Forms.Button();
            this.verButton = new System.Windows.Forms.Button();
            this.clienteSeleccionadoPanel = new System.Windows.Forms.Panel();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.seleccionarButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientesDataGridView)).BeginInit();
            this.clienteSeleccionadoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cleanParamsButton);
            this.groupBox1.Controls.Add(this.dniFilterTB);
            this.groupBox1.Controls.Add(this.buscarButton);
            this.groupBox1.Controls.Add(this.lnameFilterTB);
            this.groupBox1.Controls.Add(this.nameFilterTB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(507, 118);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda de clientes";
            // 
            // cleanParamsButton
            // 
            this.cleanParamsButton.Location = new System.Drawing.Point(388, 66);
            this.cleanParamsButton.Name = "cleanParamsButton";
            this.cleanParamsButton.Size = new System.Drawing.Size(75, 34);
            this.cleanParamsButton.TabIndex = 6;
            this.cleanParamsButton.Text = "Limpiar parámetros";
            this.cleanParamsButton.UseVisualStyleBackColor = true;
            this.cleanParamsButton.Click += new System.EventHandler(this.cleanParamsButton_Click);
            // 
            // dniFilterTB
            // 
            this.dniFilterTB.Location = new System.Drawing.Point(107, 87);
            this.dniFilterTB.MaxLength = 10;
            this.dniFilterTB.Name = "dniFilterTB";
            this.dniFilterTB.Size = new System.Drawing.Size(224, 20);
            this.dniFilterTB.TabIndex = 5;
            this.dniFilterTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dniFilterTB_KeyPress);
            // 
            // buscarButton
            // 
            this.buscarButton.Location = new System.Drawing.Point(388, 26);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(75, 23);
            this.buscarButton.TabIndex = 1;
            this.buscarButton.Text = "Buscar";
            this.buscarButton.UseVisualStyleBackColor = true;
            this.buscarButton.Click += new System.EventHandler(this.buscarButton_Click);
            // 
            // lnameFilterTB
            // 
            this.lnameFilterTB.Location = new System.Drawing.Point(107, 57);
            this.lnameFilterTB.Name = "lnameFilterTB";
            this.lnameFilterTB.Size = new System.Drawing.Size(224, 20);
            this.lnameFilterTB.TabIndex = 4;
            // 
            // nameFilterTB
            // 
            this.nameFilterTB.Location = new System.Drawing.Point(107, 28);
            this.nameFilterTB.Name = "nameFilterTB";
            this.nameFilterTB.Size = new System.Drawing.Size(224, 20);
            this.nameFilterTB.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "DNI:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre: ";
            // 
            // clientesDataGridView
            // 
            this.clientesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientesDataGridView.Location = new System.Drawing.Point(12, 145);
            this.clientesDataGridView.Name = "clientesDataGridView";
            this.clientesDataGridView.ReadOnly = true;
            this.clientesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.clientesDataGridView.Size = new System.Drawing.Size(507, 150);
            this.clientesDataGridView.TabIndex = 2;
            this.clientesDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clientesDataGridView_CellClick);
            // 
            // volverButton
            // 
            this.volverButton.Location = new System.Drawing.Point(28, 317);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(75, 23);
            this.volverButton.TabIndex = 3;
            this.volverButton.Text = "<< Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // cleanTableButton
            // 
            this.cleanTableButton.Location = new System.Drawing.Point(119, 317);
            this.cleanTableButton.Name = "cleanTableButton";
            this.cleanTableButton.Size = new System.Drawing.Size(75, 23);
            this.cleanTableButton.TabIndex = 4;
            this.cleanTableButton.Text = "Limpiar tabla";
            this.cleanTableButton.UseVisualStyleBackColor = true;
            this.cleanTableButton.Click += new System.EventHandler(this.cleanTableButton_Click);
            // 
            // modificarButton
            // 
            this.modificarButton.Location = new System.Drawing.Point(95, 13);
            this.modificarButton.Name = "modificarButton";
            this.modificarButton.Size = new System.Drawing.Size(75, 23);
            this.modificarButton.TabIndex = 5;
            this.modificarButton.Text = "Modificar";
            this.modificarButton.UseVisualStyleBackColor = true;
            this.modificarButton.Click += new System.EventHandler(this.modificarButton_Click);
            // 
            // eliminarButton
            // 
            this.eliminarButton.Location = new System.Drawing.Point(180, 13);
            this.eliminarButton.Name = "eliminarButton";
            this.eliminarButton.Size = new System.Drawing.Size(75, 23);
            this.eliminarButton.TabIndex = 6;
            this.eliminarButton.Text = "Eliminar";
            this.eliminarButton.UseVisualStyleBackColor = true;
            this.eliminarButton.Click += new System.EventHandler(this.eliminarButton_Click);
            // 
            // verButton
            // 
            this.verButton.Location = new System.Drawing.Point(11, 13);
            this.verButton.Name = "verButton";
            this.verButton.Size = new System.Drawing.Size(75, 23);
            this.verButton.TabIndex = 7;
            this.verButton.Text = "Ver";
            this.verButton.UseVisualStyleBackColor = true;
            this.verButton.Click += new System.EventHandler(this.verButton_Click);
            // 
            // clienteSeleccionadoPanel
            // 
            this.clienteSeleccionadoPanel.Controls.Add(this.verButton);
            this.clienteSeleccionadoPanel.Controls.Add(this.cancelarButton);
            this.clienteSeleccionadoPanel.Controls.Add(this.seleccionarButton);
            this.clienteSeleccionadoPanel.Controls.Add(this.modificarButton);
            this.clienteSeleccionadoPanel.Controls.Add(this.eliminarButton);
            this.clienteSeleccionadoPanel.Location = new System.Drawing.Point(252, 304);
            this.clienteSeleccionadoPanel.Name = "clienteSeleccionadoPanel";
            this.clienteSeleccionadoPanel.Size = new System.Drawing.Size(267, 49);
            this.clienteSeleccionadoPanel.TabIndex = 8;
            // 
            // cancelarButton
            // 
            this.cancelarButton.Enabled = false;
            this.cancelarButton.Location = new System.Drawing.Point(180, 13);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(75, 23);
            this.cancelarButton.TabIndex = 8;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
            this.cancelarButton.Visible = false;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // seleccionarButton
            // 
            this.seleccionarButton.Enabled = false;
            this.seleccionarButton.Location = new System.Drawing.Point(95, 13);
            this.seleccionarButton.Name = "seleccionarButton";
            this.seleccionarButton.Size = new System.Drawing.Size(75, 23);
            this.seleccionarButton.TabIndex = 7;
            this.seleccionarButton.Text = "Seleccionar";
            this.seleccionarButton.UseVisualStyleBackColor = true;
            this.seleccionarButton.Visible = false;
            this.seleccionarButton.Click += new System.EventHandler(this.seleccionarButton_Click);
            // 
            // ListadoClientesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 361);
            this.Controls.Add(this.cleanTableButton);
            this.Controls.Add(this.volverButton);
            this.Controls.Add(this.clientesDataGridView);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.clienteSeleccionadoPanel);
            this.Name = "ListadoClientesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Clientes";
            this.Click += new System.EventHandler(this.ListadoClientesForm_Click);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientesDataGridView)).EndInit();
            this.clienteSeleccionadoPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox dniFilterTB;
        private System.Windows.Forms.TextBox lnameFilterTB;
        private System.Windows.Forms.TextBox nameFilterTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buscarButton;
        private System.Windows.Forms.DataGridView clientesDataGridView;
        private System.Windows.Forms.Button cleanParamsButton;
        private System.Windows.Forms.Button volverButton;
        private System.Windows.Forms.Button cleanTableButton;
        private System.Windows.Forms.Button modificarButton;
        private System.Windows.Forms.Button eliminarButton;
        private System.Windows.Forms.Button verButton;
        private System.Windows.Forms.Panel clienteSeleccionadoPanel;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.Button seleccionarButton;
    }
}