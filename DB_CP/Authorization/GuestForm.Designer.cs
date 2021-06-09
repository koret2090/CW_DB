
namespace Authorization
{
    partial class GuestForm
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
            this.viewTable = new System.Windows.Forms.DataGridView();
            this.showFilmsBtn = new System.Windows.Forms.Button();
            this.showActorsBtn = new System.Windows.Forms.Button();
            this.showGenresBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.viewTable)).BeginInit();
            this.SuspendLayout();
            // 
            // viewTable
            // 
            this.viewTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewTable.Location = new System.Drawing.Point(12, 12);
            this.viewTable.Name = "viewTable";
            this.viewTable.RowHeadersWidth = 51;
            this.viewTable.RowTemplate.Height = 29;
            this.viewTable.Size = new System.Drawing.Size(728, 726);
            this.viewTable.TabIndex = 0;
            // 
            // showFilmsBtn
            // 
            this.showFilmsBtn.Location = new System.Drawing.Point(772, 579);
            this.showFilmsBtn.Name = "showFilmsBtn";
            this.showFilmsBtn.Size = new System.Drawing.Size(154, 49);
            this.showFilmsBtn.TabIndex = 1;
            this.showFilmsBtn.Text = "Вывести фильмы";
            this.showFilmsBtn.UseVisualStyleBackColor = true;
            this.showFilmsBtn.Click += new System.EventHandler(this.showFilmsBtn_Click);
            // 
            // showActorsBtn
            // 
            this.showActorsBtn.Location = new System.Drawing.Point(772, 634);
            this.showActorsBtn.Name = "showActorsBtn";
            this.showActorsBtn.Size = new System.Drawing.Size(154, 49);
            this.showActorsBtn.TabIndex = 2;
            this.showActorsBtn.Text = "Вывести актеров";
            this.showActorsBtn.UseVisualStyleBackColor = true;
            this.showActorsBtn.Click += new System.EventHandler(this.showActorsBtn_Click);
            // 
            // showGenresBtn
            // 
            this.showGenresBtn.Location = new System.Drawing.Point(772, 689);
            this.showGenresBtn.Name = "showGenresBtn";
            this.showGenresBtn.Size = new System.Drawing.Size(154, 49);
            this.showGenresBtn.TabIndex = 3;
            this.showGenresBtn.Text = "Вывести жанры";
            this.showGenresBtn.UseVisualStyleBackColor = true;
            this.showGenresBtn.Click += new System.EventHandler(this.showGenresBtn_Click);
            // 
            // GuestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 753);
            this.Controls.Add(this.showGenresBtn);
            this.Controls.Add(this.showActorsBtn);
            this.Controls.Add(this.showFilmsBtn);
            this.Controls.Add(this.viewTable);
            this.Name = "GuestForm";
            this.Text = "Гость";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GuestForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.viewTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView viewTable;
        private System.Windows.Forms.Button showFilmsBtn;
        private System.Windows.Forms.Button showActorsBtn;
        private System.Windows.Forms.Button showGenresBtn;
    }
}