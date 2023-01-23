
namespace TicTacToe
{
    partial class MainForm
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód automaticky vytvořený konstruktérem formulářů Windows

        /// <summary>
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.играToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.играСБотомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.играСЧеловекомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GamePanel = new System.Windows.Forms.Panel();
            this.историяИгрИХодовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.эксопртироватьВXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.экспортироватьВCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.играToolStripMenuItem,
            this.историяИгрИХодовToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(423, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // HraToolStripMenuItem
            // 
            this.играToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.играСБотомToolStripMenuItem,
            this.играСЧеловекомToolStripMenuItem});
            this.играToolStripMenuItem.Name = "hraToolStripMenuItem";
            this.играToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.играToolStripMenuItem.Text = "Hra";
            // 
            // HraSBotemToolStripMenuItem
            // 
            this.играСБотомToolStripMenuItem.Name = "hraSbotemToolStripMenuItem";
            this.играСБотомToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.играСБотомToolStripMenuItem.Text = "Hra s botem";
            this.играСБотомToolStripMenuItem.Click += new System.EventHandler(this.StartGamePvB);
            // 
            // hraSčlověkemToolStripMenuItem
            // 
            this.играСЧеловекомToolStripMenuItem.Name = "hraSclovekemToolStripMenuItem";
            this.играСЧеловекомToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.играСЧеловекомToolStripMenuItem.Text = "Hra s clovekem";
            this.играСЧеловекомToolStripMenuItem.Click += new System.EventHandler(this.StartGamePvP);
            // 
            // GamePanel
            // 
            this.GamePanel.BackColor = System.Drawing.Color.White;
            this.GamePanel.Location = new System.Drawing.Point(12, 27);
            this.GamePanel.Name = "GamePanel";
            this.GamePanel.Size = new System.Drawing.Size(400, 400);
            this.GamePanel.TabIndex = 1;
            // 
            // historietahuToolStripMenuItem
            // 
            this.историяИгрИХодовToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.эксопртироватьВXMLToolStripMenuItem,
            this.экспортироватьВCSVToolStripMenuItem});
            this.историяИгрИХодовToolStripMenuItem.Name = "historietahuToolStripMenuItem";
            this.историяИгрИХодовToolStripMenuItem.Size = new System.Drawing.Size(133, 20);
            this.историяИгрИХодовToolStripMenuItem.Text = "Historie tahu";
            // 
            // exportdoXMLToolStripMenuItem
            // 
            this.эксопртироватьВXMLToolStripMenuItem.Name = "exportdoXMLToolStripMenuItem";
            this.эксопртироватьВXMLToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.эксопртироватьВXMLToolStripMenuItem.Text = "Export do XML";
            this.эксопртироватьВXMLToolStripMenuItem.Click += new System.EventHandler(this.XmlExport);
            // 
            // exportdoCSVToolStripMenuItem
            // 
            this.экспортироватьВCSVToolStripMenuItem.Name = "exportdoCSVToolStripMenuItem";
            this.экспортироватьВCSVToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.экспортироватьВCSVToolStripMenuItem.Text = "Export do CSV";
            this.экспортироватьВCSVToolStripMenuItem.Click += new System.EventHandler(this.CsvExport);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(423, 434);
            this.Controls.Add(this.GamePanel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Krizek-krozek";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem играToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem играСБотомToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem играСЧеловекомToolStripMenuItem;
        private System.Windows.Forms.Panel GamePanel;
        private System.Windows.Forms.ToolStripMenuItem историяИгрИХодовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem эксопртироватьВXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem экспортироватьВCSVToolStripMenuItem;
    }
}

