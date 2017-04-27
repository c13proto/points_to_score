namespace points_to_score
{
    partial class Main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_data1 = new System.Windows.Forms.Button();
            this.button_data2 = new System.Windows.Forms.Button();
            this.textBox_data1 = new System.Windows.Forms.TextBox();
            this.textBox_data2 = new System.Windows.Forms.TextBox();
            this.button_採点開始 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // button_data1
            // 
            this.button_data1.Location = new System.Drawing.Point(12, 12);
            this.button_data1.Name = "button_data1";
            this.button_data1.Size = new System.Drawing.Size(75, 23);
            this.button_data1.TabIndex = 0;
            this.button_data1.Text = "data1";
            this.button_data1.UseVisualStyleBackColor = true;
            this.button_data1.Click += new System.EventHandler(this.Click_data1);
            // 
            // button_data2
            // 
            this.button_data2.Location = new System.Drawing.Point(487, 12);
            this.button_data2.Name = "button_data2";
            this.button_data2.Size = new System.Drawing.Size(75, 23);
            this.button_data2.TabIndex = 1;
            this.button_data2.Text = "data2";
            this.button_data2.UseVisualStyleBackColor = true;
            this.button_data2.Click += new System.EventHandler(this.Click_data2);
            // 
            // textBox_data1
            // 
            this.textBox_data1.Location = new System.Drawing.Point(12, 41);
            this.textBox_data1.Multiline = true;
            this.textBox_data1.Name = "textBox_data1";
            this.textBox_data1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_data1.Size = new System.Drawing.Size(469, 254);
            this.textBox_data1.TabIndex = 2;
            // 
            // textBox_data2
            // 
            this.textBox_data2.Location = new System.Drawing.Point(487, 41);
            this.textBox_data2.Multiline = true;
            this.textBox_data2.Name = "textBox_data2";
            this.textBox_data2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_data2.Size = new System.Drawing.Size(469, 254);
            this.textBox_data2.TabIndex = 3;
            // 
            // button_採点開始
            // 
            this.button_採点開始.Location = new System.Drawing.Point(12, 302);
            this.button_採点開始.Name = "button_採点開始";
            this.button_採点開始.Size = new System.Drawing.Size(75, 23);
            this.button_採点開始.TabIndex = 4;
            this.button_採点開始.Text = "採点開始";
            this.button_採点開始.UseVisualStyleBackColor = true;
            this.button_採点開始.Click += new System.EventHandler(this.Click_採点開始);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(94, 301);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(853, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 520);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button_採点開始);
            this.Controls.Add(this.textBox_data2);
            this.Controls.Add(this.textBox_data1);
            this.Controls.Add(this.button_data2);
            this.Controls.Add(this.button_data1);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_data1;
        private System.Windows.Forms.Button button_data2;
        private System.Windows.Forms.TextBox textBox_data1;
        private System.Windows.Forms.TextBox textBox_data2;
        private System.Windows.Forms.Button button_採点開始;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

