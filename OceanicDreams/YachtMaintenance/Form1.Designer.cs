
namespace YachtMaintenance
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvKoltsegek = new System.Windows.Forms.DataGridView();
            this.txtYachtName = new System.Windows.Forms.TextBox();
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.cmbKategoria = new System.Windows.Forms.ComboBox();
            this.txtOsszeg = new System.Windows.Forms.TextBox();
            this.txtMegjegyzes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnHozzaadas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKoltsegek)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKoltsegek
            // 
            this.dgvKoltsegek.AllowUserToAddRows = false;
            this.dgvKoltsegek.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKoltsegek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKoltsegek.Location = new System.Drawing.Point(47, 54);
            this.dgvKoltsegek.Name = "dgvKoltsegek";
            this.dgvKoltsegek.ReadOnly = true;
            this.dgvKoltsegek.RowHeadersWidth = 51;
            this.dgvKoltsegek.RowTemplate.Height = 24;
            this.dgvKoltsegek.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKoltsegek.Size = new System.Drawing.Size(769, 150);
            this.dgvKoltsegek.TabIndex = 0;
            // 
            // txtYachtName
            // 
            this.txtYachtName.Location = new System.Drawing.Point(192, 233);
            this.txtYachtName.Name = "txtYachtName";
            this.txtYachtName.Size = new System.Drawing.Size(215, 22);
            this.txtYachtName.TabIndex = 1;
            // 
            // dtpDatum
            // 
            this.dtpDatum.Location = new System.Drawing.Point(192, 271);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(215, 22);
            this.dtpDatum.TabIndex = 2;
            // 
            // cmbKategoria
            // 
            this.cmbKategoria.FormattingEnabled = true;
            this.cmbKategoria.Location = new System.Drawing.Point(192, 312);
            this.cmbKategoria.Name = "cmbKategoria";
            this.cmbKategoria.Size = new System.Drawing.Size(215, 24);
            this.cmbKategoria.TabIndex = 3;
            // 
            // txtOsszeg
            // 
            this.txtOsszeg.Location = new System.Drawing.Point(602, 233);
            this.txtOsszeg.Name = "txtOsszeg";
            this.txtOsszeg.Size = new System.Drawing.Size(194, 22);
            this.txtOsszeg.TabIndex = 4;
            // 
            // txtMegjegyzes
            // 
            this.txtMegjegyzes.Location = new System.Drawing.Point(602, 271);
            this.txtMegjegyzes.Name = "txtMegjegyzes";
            this.txtMegjegyzes.Size = new System.Drawing.Size(194, 22);
            this.txtMegjegyzes.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Yacht neve:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Dátum:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 315);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Kategória";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(500, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Összeg (EUR):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(503, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Megjegyzés:";
            // 
            // btnHozzaadas
            // 
            this.btnHozzaadas.Location = new System.Drawing.Point(506, 357);
            this.btnHozzaadas.Name = "btnHozzaadas";
            this.btnHozzaadas.Size = new System.Drawing.Size(169, 23);
            this.btnHozzaadas.TabIndex = 11;
            this.btnHozzaadas.Text = "Hozzáadás";
            this.btnHozzaadas.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(882, 453);
            this.Controls.Add(this.btnHozzaadas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMegjegyzes);
            this.Controls.Add(this.txtOsszeg);
            this.Controls.Add(this.cmbKategoria);
            this.Controls.Add(this.dtpDatum);
            this.Controls.Add(this.txtYachtName);
            this.Controls.Add(this.dgvKoltsegek);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yacht karbantartási költségnyilvántartás";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKoltsegek)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private System.Windows.Forms.DataGridView dgvKoltsegek;
        private System.Windows.Forms.TextBox txtYachtName;
        private System.Windows.Forms.DateTimePicker dtpDatum;
        private System.Windows.Forms.ComboBox cmbKategoria;
        private System.Windows.Forms.TextBox txtOsszeg;
        private System.Windows.Forms.TextBox txtMegjegyzes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnHozzaadas;
    }
}
