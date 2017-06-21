namespace UberFrba.Abm_Rol
{
    partial class ListadoRolesForm
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
            this.rolSeleccionadoPanel = new System.Windows.Forms.Panel();
            this.eliminarButton = new System.Windows.Forms.Button();
            this.modificarButton = new System.Windows.Forms.Button();
            this.verButton = new System.Windows.Forms.Button();
            this.atrasButton = new System.Windows.Forms.Button();
            this.rolesDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.rolSeleccionadoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rolesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rolSeleccionadoPanel);
            this.groupBox1.Controls.Add(this.atrasButton);
            this.groupBox1.Controls.Add(this.rolesDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 236);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Roles del sistema:";
            // 
            // rolSeleccionadoPanel
            // 
            this.rolSeleccionadoPanel.Controls.Add(this.eliminarButton);
            this.rolSeleccionadoPanel.Controls.Add(this.modificarButton);
            this.rolSeleccionadoPanel.Controls.Add(this.verButton);
            this.rolSeleccionadoPanel.Location = new System.Drawing.Point(109, 191);
            this.rolSeleccionadoPanel.Name = "rolSeleccionadoPanel";
            this.rolSeleccionadoPanel.Size = new System.Drawing.Size(258, 32);
            this.rolSeleccionadoPanel.TabIndex = 5;
            // 
            // eliminarButton
            // 
            this.eliminarButton.Enabled = false;
            this.eliminarButton.Location = new System.Drawing.Point(172, 5);
            this.eliminarButton.Name = "eliminarButton";
            this.eliminarButton.Size = new System.Drawing.Size(75, 23);
            this.eliminarButton.TabIndex = 3;
            this.eliminarButton.Text = "Eliminar";
            this.eliminarButton.UseVisualStyleBackColor = true;
            this.eliminarButton.Click += new System.EventHandler(this.eliminarButton_Click);
            // 
            // modificarButton
            // 
            this.modificarButton.Enabled = false;
            this.modificarButton.Location = new System.Drawing.Point(91, 5);
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
            this.verButton.Location = new System.Drawing.Point(10, 5);
            this.verButton.Name = "verButton";
            this.verButton.Size = new System.Drawing.Size(75, 23);
            this.verButton.TabIndex = 4;
            this.verButton.Text = "Ver";
            this.verButton.UseVisualStyleBackColor = true;
            this.verButton.Click += new System.EventHandler(this.verButton_Click);
            // 
            // atrasButton
            // 
            this.atrasButton.Location = new System.Drawing.Point(16, 196);
            this.atrasButton.Name = "atrasButton";
            this.atrasButton.Size = new System.Drawing.Size(75, 23);
            this.atrasButton.TabIndex = 2;
            this.atrasButton.Text = "<< Volver";
            this.atrasButton.UseVisualStyleBackColor = true;
            this.atrasButton.Click += new System.EventHandler(this.atrasButton_Click);
            // 
            // rolesDataGridView
            // 
            this.rolesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rolesDataGridView.Location = new System.Drawing.Point(16, 29);
            this.rolesDataGridView.MultiSelect = false;
            this.rolesDataGridView.Name = "rolesDataGridView";
            this.rolesDataGridView.ReadOnly = true;
            this.rolesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.rolesDataGridView.Size = new System.Drawing.Size(351, 150);
            this.rolesDataGridView.TabIndex = 0;
            this.rolesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ListadoRolesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 259);
            this.Controls.Add(this.groupBox1);
            this.Name = "ListadoRolesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Roles";
            this.Click += new System.EventHandler(this.ListadoRolesForm_Click);
            this.groupBox1.ResumeLayout(false);
            this.rolSeleccionadoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rolesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button atrasButton;
        private System.Windows.Forms.Button modificarButton;
        private System.Windows.Forms.DataGridView rolesDataGridView;
        private System.Windows.Forms.Button verButton;
        private System.Windows.Forms.Button eliminarButton;
        private System.Windows.Forms.Panel rolSeleccionadoPanel;
    }
}