
namespace Authorization
{
    partial class UserForm
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
            this.genresListBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addGenreBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.actorNameTxtBox = new System.Windows.Forms.TextBox();
            this.showGenresBtn = new System.Windows.Forms.Button();
            this.showActorsBtn = new System.Windows.Forms.Button();
            this.showFilmsBtn = new System.Windows.Forms.Button();
            this.recommendBtn = new System.Windows.Forms.Button();
            this.deleteGenreBtn = new System.Windows.Forms.Button();
            this.showFavouriteGenreBtn = new System.Windows.Forms.Button();
            this.showFavouriteActorBtn = new System.Windows.Forms.Button();
            this.deleteActorBtn = new System.Windows.Forms.Button();
            this.addActorBtn = new System.Windows.Forms.Button();
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
            this.viewTable.TabIndex = 1;
            // 
            // genresListBox
            // 
            this.genresListBox.FormattingEnabled = true;
            this.genresListBox.Location = new System.Drawing.Point(755, 46);
            this.genresListBox.Name = "genresListBox";
            this.genresListBox.Size = new System.Drawing.Size(188, 114);
            this.genresListBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(755, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Выбор любимых жанров";
            // 
            // addGenreBtn
            // 
            this.addGenreBtn.Location = new System.Drawing.Point(755, 166);
            this.addGenreBtn.Name = "addGenreBtn";
            this.addGenreBtn.Size = new System.Drawing.Size(87, 48);
            this.addGenreBtn.TabIndex = 4;
            this.addGenreBtn.Text = "Добавить";
            this.addGenreBtn.UseVisualStyleBackColor = true;
            this.addGenreBtn.Click += new System.EventHandler(this.addGenreBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(755, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Выбор любимого актера";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(755, 315);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Введите имя и фамилию";
            // 
            // actorNameTxtBox
            // 
            this.actorNameTxtBox.Location = new System.Drawing.Point(755, 338);
            this.actorNameTxtBox.Multiline = true;
            this.actorNameTxtBox.Name = "actorNameTxtBox";
            this.actorNameTxtBox.Size = new System.Drawing.Size(188, 60);
            this.actorNameTxtBox.TabIndex = 7;
            // 
            // showGenresBtn
            // 
            this.showGenresBtn.Location = new System.Drawing.Point(773, 634);
            this.showGenresBtn.Name = "showGenresBtn";
            this.showGenresBtn.Size = new System.Drawing.Size(154, 49);
            this.showGenresBtn.TabIndex = 11;
            this.showGenresBtn.Text = "Вывести жанры";
            this.showGenresBtn.UseVisualStyleBackColor = true;
            this.showGenresBtn.Click += new System.EventHandler(this.showGenresBtn_Click);
            // 
            // showActorsBtn
            // 
            this.showActorsBtn.Location = new System.Drawing.Point(773, 579);
            this.showActorsBtn.Name = "showActorsBtn";
            this.showActorsBtn.Size = new System.Drawing.Size(154, 49);
            this.showActorsBtn.TabIndex = 10;
            this.showActorsBtn.Text = "Вывести актеров";
            this.showActorsBtn.UseVisualStyleBackColor = true;
            this.showActorsBtn.Click += new System.EventHandler(this.showActorsBtn_Click);
            // 
            // showFilmsBtn
            // 
            this.showFilmsBtn.Location = new System.Drawing.Point(773, 524);
            this.showFilmsBtn.Name = "showFilmsBtn";
            this.showFilmsBtn.Size = new System.Drawing.Size(154, 49);
            this.showFilmsBtn.TabIndex = 9;
            this.showFilmsBtn.Text = "Вывести фильмы";
            this.showFilmsBtn.UseVisualStyleBackColor = true;
            this.showFilmsBtn.Click += new System.EventHandler(this.showFilmsBtn_Click);
            // 
            // recommendBtn
            // 
            this.recommendBtn.Location = new System.Drawing.Point(773, 689);
            this.recommendBtn.Name = "recommendBtn";
            this.recommendBtn.Size = new System.Drawing.Size(154, 49);
            this.recommendBtn.TabIndex = 12;
            this.recommendBtn.Text = "Получить рекомендацию";
            this.recommendBtn.UseVisualStyleBackColor = true;
            this.recommendBtn.Click += new System.EventHandler(this.recommendBtn_Click);
            // 
            // deleteGenreBtn
            // 
            this.deleteGenreBtn.Location = new System.Drawing.Point(856, 166);
            this.deleteGenreBtn.Name = "deleteGenreBtn";
            this.deleteGenreBtn.Size = new System.Drawing.Size(87, 48);
            this.deleteGenreBtn.TabIndex = 13;
            this.deleteGenreBtn.Text = "Удалить";
            this.deleteGenreBtn.UseVisualStyleBackColor = true;
            this.deleteGenreBtn.Click += new System.EventHandler(this.deleteGenreBtn_Click);
            // 
            // showFavouriteGenreBtn
            // 
            this.showFavouriteGenreBtn.Location = new System.Drawing.Point(755, 220);
            this.showFavouriteGenreBtn.Name = "showFavouriteGenreBtn";
            this.showFavouriteGenreBtn.Size = new System.Drawing.Size(188, 48);
            this.showFavouriteGenreBtn.TabIndex = 14;
            this.showFavouriteGenreBtn.Text = "Вывести добавленные";
            this.showFavouriteGenreBtn.UseVisualStyleBackColor = true;
            this.showFavouriteGenreBtn.Click += new System.EventHandler(this.showFavouriteGenreBtn_Click);
            // 
            // showFavouriteActorBtn
            // 
            this.showFavouriteActorBtn.Location = new System.Drawing.Point(755, 458);
            this.showFavouriteActorBtn.Name = "showFavouriteActorBtn";
            this.showFavouriteActorBtn.Size = new System.Drawing.Size(188, 48);
            this.showFavouriteActorBtn.TabIndex = 17;
            this.showFavouriteActorBtn.Text = "Вывести добавленные";
            this.showFavouriteActorBtn.UseVisualStyleBackColor = true;
            this.showFavouriteActorBtn.Click += new System.EventHandler(this.showFavouriteActorBtn_Click);
            // 
            // deleteActorBtn
            // 
            this.deleteActorBtn.Location = new System.Drawing.Point(856, 404);
            this.deleteActorBtn.Name = "deleteActorBtn";
            this.deleteActorBtn.Size = new System.Drawing.Size(87, 48);
            this.deleteActorBtn.TabIndex = 16;
            this.deleteActorBtn.Text = "Удалить";
            this.deleteActorBtn.UseVisualStyleBackColor = true;
            this.deleteActorBtn.Click += new System.EventHandler(this.deleteActorBtn_Click);
            // 
            // addActorBtn
            // 
            this.addActorBtn.Location = new System.Drawing.Point(755, 404);
            this.addActorBtn.Name = "addActorBtn";
            this.addActorBtn.Size = new System.Drawing.Size(87, 48);
            this.addActorBtn.TabIndex = 15;
            this.addActorBtn.Text = "Добавить";
            this.addActorBtn.UseVisualStyleBackColor = true;
            this.addActorBtn.Click += new System.EventHandler(this.addActorBtn_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 753);
            this.Controls.Add(this.showFavouriteActorBtn);
            this.Controls.Add(this.deleteActorBtn);
            this.Controls.Add(this.addActorBtn);
            this.Controls.Add(this.showFavouriteGenreBtn);
            this.Controls.Add(this.deleteGenreBtn);
            this.Controls.Add(this.recommendBtn);
            this.Controls.Add(this.showGenresBtn);
            this.Controls.Add(this.showActorsBtn);
            this.Controls.Add(this.showFilmsBtn);
            this.Controls.Add(this.actorNameTxtBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addGenreBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.genresListBox);
            this.Controls.Add(this.viewTable);
            this.Name = "UserForm";
            this.Text = "Пользователь";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.viewTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView viewTable;
        private System.Windows.Forms.CheckedListBox genresListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addGenreBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox actorNameTxtBox;
        private System.Windows.Forms.Button showGenresBtn;
        private System.Windows.Forms.Button showActorsBtn;
        private System.Windows.Forms.Button showFilmsBtn;
        private System.Windows.Forms.Button recommendBtn;
        private System.Windows.Forms.Button deleteGenreBtn;
        private System.Windows.Forms.Button showFavouriteGenreBtn;
        private System.Windows.Forms.Button showFavouriteActorBtn;
        private System.Windows.Forms.Button deleteActorBtn;
        private System.Windows.Forms.Button addActorBtn;
    }
}