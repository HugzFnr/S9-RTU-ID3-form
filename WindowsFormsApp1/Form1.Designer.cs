namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.stepButton = new System.Windows.Forms.Button();
            this.cbAnswers = new System.Windows.Forms.ComboBox();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.lblNumberTitle = new System.Windows.Forms.Label();
            this.lblNumberCount = new System.Windows.Forms.Label();
            this.dataviewAnswers = new System.Windows.Forms.DataGridView();
            this.lblGrid = new System.Windows.Forms.Label();
            this.btnCheat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataviewAnswers)).BeginInit();
            this.SuspendLayout();
            // 
            // stepButton
            // 
            this.stepButton.Enabled = false;
            this.stepButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stepButton.Location = new System.Drawing.Point(337, 228);
            this.stepButton.Name = "stepButton";
            this.stepButton.Size = new System.Drawing.Size(135, 34);
            this.stepButton.TabIndex = 0;
            this.stepButton.Text = "Next step";
            this.stepButton.UseVisualStyleBackColor = true;
            this.stepButton.Click += new System.EventHandler(this.stepButton_Click);
            // 
            // cbAnswers
            // 
            this.cbAnswers.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAnswers.FormattingEnabled = true;
            this.cbAnswers.Location = new System.Drawing.Point(573, 80);
            this.cbAnswers.Name = "cbAnswers";
            this.cbAnswers.Size = new System.Drawing.Size(172, 37);
            this.cbAnswers.TabIndex = 1;
            this.cbAnswers.SelectedIndexChanged += new System.EventHandler(this.cbAnswers_SelectedIndexChanged);
            this.cbAnswers.TextChanged += new System.EventHandler(this.cbAnswers_TextChanged);
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.Location = new System.Drawing.Point(83, 83);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(276, 29);
            this.lblQuestion.TabIndex = 2;
            this.lblQuestion.Text = "How is today\'s weather ?";
            // 
            // lblNumberTitle
            // 
            this.lblNumberTitle.AutoSize = true;
            this.lblNumberTitle.Location = new System.Drawing.Point(13, 13);
            this.lblNumberTitle.Name = "lblNumberTitle";
            this.lblNumberTitle.Size = new System.Drawing.Size(244, 17);
            this.lblNumberTitle.TabIndex = 3;
            this.lblNumberTitle.Text = "Number of answers in the database : ";
            // 
            // lblNumberCount
            // 
            this.lblNumberCount.AutoSize = true;
            this.lblNumberCount.Location = new System.Drawing.Point(263, 13);
            this.lblNumberCount.Name = "lblNumberCount";
            this.lblNumberCount.Size = new System.Drawing.Size(16, 17);
            this.lblNumberCount.TabIndex = 4;
            this.lblNumberCount.Text = "0";
            // 
            // dataviewAnswers
            // 
            this.dataviewAnswers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataviewAnswers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataviewAnswers.Location = new System.Drawing.Point(769, 47);
            this.dataviewAnswers.Name = "dataviewAnswers";
            this.dataviewAnswers.RowHeadersWidth = 51;
            this.dataviewAnswers.RowTemplate.Height = 24;
            this.dataviewAnswers.Size = new System.Drawing.Size(611, 315);
            this.dataviewAnswers.TabIndex = 5;
            // 
            // lblGrid
            // 
            this.lblGrid.AutoSize = true;
            this.lblGrid.Location = new System.Drawing.Point(984, 13);
            this.lblGrid.Name = "lblGrid";
            this.lblGrid.Size = new System.Drawing.Size(216, 17);
            this.lblGrid.TabIndex = 6;
            this.lblGrid.Text = "Knowledge data base of answers";
            // 
            // btnCheat
            // 
            this.btnCheat.Location = new System.Drawing.Point(88, 250);
            this.btnCheat.Name = "btnCheat";
            this.btnCheat.Size = new System.Drawing.Size(113, 23);
            this.btnCheat.TabIndex = 7;
            this.btnCheat.Text = "15 answers";
            this.btnCheat.UseVisualStyleBackColor = true;
            this.btnCheat.Click += new System.EventHandler(this.btnCheat_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.stepButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1392, 374);
            this.Controls.Add(this.btnCheat);
            this.Controls.Add(this.lblGrid);
            this.Controls.Add(this.dataviewAnswers);
            this.Controls.Add(this.lblNumberCount);
            this.Controls.Add(this.lblNumberTitle);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.cbAnswers);
            this.Controls.Add(this.stepButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataviewAnswers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button stepButton;
        private System.Windows.Forms.ComboBox cbAnswers;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Label lblNumberTitle;
        private System.Windows.Forms.Label lblNumberCount;
        private System.Windows.Forms.DataGridView dataviewAnswers;
        private System.Windows.Forms.Label lblGrid;
        private System.Windows.Forms.Button btnCheat;
    }
}

