
namespace SistemaHotel.Reservas
{
    partial class FrmConsultarReserva
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
            this.grid = new System.Windows.Forms.DataGridView();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.txtBuscarNome = new System.Windows.Forms.TextBox();
            this.dtBuscarInicioReserva = new System.Windows.Forms.DateTimePicker();
            this.dtBuscarReserva = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnPago = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(71, 99);
            this.grid.Name = "grid";
            this.grid.RowTemplate.Height = 25;
            this.grid.Size = new System.Drawing.Size(690, 311);
            this.grid.TabIndex = 0;
            this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellClick);
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "Confirmado",
            "Cancelada"});
            this.cbStatus.Location = new System.Drawing.Point(116, 13);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(121, 23);
            this.cbStatus.TabIndex = 2;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // txtBuscarNome
            // 
            this.txtBuscarNome.Location = new System.Drawing.Point(116, 53);
            this.txtBuscarNome.Name = "txtBuscarNome";
            this.txtBuscarNome.Size = new System.Drawing.Size(100, 23);
            this.txtBuscarNome.TabIndex = 3;
            this.txtBuscarNome.TextChanged += new System.EventHandler(this.txtBuscarNome_TextChanged);
            // 
            // dtBuscarInicioReserva
            // 
            this.dtBuscarInicioReserva.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBuscarInicioReserva.Location = new System.Drawing.Point(425, 18);
            this.dtBuscarInicioReserva.Name = "dtBuscarInicioReserva";
            this.dtBuscarInicioReserva.Size = new System.Drawing.Size(122, 23);
            this.dtBuscarInicioReserva.TabIndex = 4;
            this.dtBuscarInicioReserva.ValueChanged += new System.EventHandler(this.dtBuscarInicioReserva_ValueChanged);
            // 
            // dtBuscarReserva
            // 
            this.dtBuscarReserva.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBuscarReserva.Location = new System.Drawing.Point(636, 15);
            this.dtBuscarReserva.Name = "dtBuscarReserva";
            this.dtBuscarReserva.Size = new System.Drawing.Size(125, 23);
            this.dtBuscarReserva.TabIndex = 5;
            this.dtBuscarReserva.ValueChanged += new System.EventHandler(this.dtBuscarReserva_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nome";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(556, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Data Reserva";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(311, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Data Inicio/Reserva";
            // 
            // btnPago
            // 
            this.btnPago.Location = new System.Drawing.Point(544, 58);
            this.btnPago.Name = "btnPago";
            this.btnPago.Size = new System.Drawing.Size(75, 23);
            this.btnPago.TabIndex = 10;
            this.btnPago.Text = "pago";
            this.btnPago.UseVisualStyleBackColor = true;
            this.btnPago.Click += new System.EventHandler(this.btnPago_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(636, 56);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 25);
            this.btnRemove.TabIndex = 11;
            this.btnRemove.Text = "remover";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(329, 57);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker1.TabIndex = 12;
            this.dateTimePicker1.Visible = false;
            // 
            // FrmConsultarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnPago);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtBuscarReserva);
            this.Controls.Add(this.dtBuscarInicioReserva);
            this.Controls.Add(this.txtBuscarNome);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.grid);
            this.Name = "FrmConsultarReserva";
            this.Text = "FrmConsultarReserva";
            this.Load += new System.EventHandler(this.FrmConsultarReserva_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.TextBox txtBuscarNome;
        private System.Windows.Forms.DateTimePicker dtBuscarInicioReserva;
        private System.Windows.Forms.DateTimePicker dtBuscarReserva;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnPago;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}