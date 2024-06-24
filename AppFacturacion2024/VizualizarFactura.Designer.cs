namespace AppFacturacion2024
{
    partial class VizualizarFactura
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cmb_Cod_Factura = new System.Windows.Forms.ComboBox();
            this.lblCod_Fac = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // cmb_Cod_Factura
            // 
            this.cmb_Cod_Factura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_Cod_Factura.Enabled = false;
            this.cmb_Cod_Factura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Cod_Factura.FormattingEnabled = true;
            this.cmb_Cod_Factura.Location = new System.Drawing.Point(713, 0);
            this.cmb_Cod_Factura.Name = "cmb_Cod_Factura";
            this.cmb_Cod_Factura.Size = new System.Drawing.Size(87, 28);
            this.cmb_Cod_Factura.TabIndex = 1;
            this.cmb_Cod_Factura.Visible = false;
            this.cmb_Cod_Factura.SelectedIndexChanged += new System.EventHandler(this.cmb_Cod_Factura_SelectedIndexChanged);
            // 
            // lblCod_Fac
            // 
            this.lblCod_Fac.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCod_Fac.AutoSize = true;
            this.lblCod_Fac.Enabled = false;
            this.lblCod_Fac.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCod_Fac.Location = new System.Drawing.Point(635, 6);
            this.lblCod_Fac.Name = "lblCod_Fac";
            this.lblCod_Fac.Size = new System.Drawing.Size(76, 16);
            this.lblCod_Fac.TabIndex = 2;
            this.lblCod_Fac.Text = "COD_FAC";
            this.lblCod_Fac.Visible = false;
            // 
            // VizualizarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCod_Fac);
            this.Controls.Add(this.cmb_Cod_Factura);
            this.Controls.Add(this.reportViewer1);
            this.Name = "VizualizarFactura";
            this.Text = "VizualizarFactura";
            this.Load += new System.EventHandler(this.VizualizarFactura_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ComboBox cmb_Cod_Factura;
        private System.Windows.Forms.Label lblCod_Fac;
    }
}