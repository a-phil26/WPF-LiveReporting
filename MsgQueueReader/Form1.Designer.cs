namespace MsgQueueReader
{
    partial class QueueReaderForm
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.chkCount = new System.Windows.Forms.CheckBox();
            this.btnPurgeQ = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQueueServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRemaining = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(50, 78);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start Read";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(50, 107);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop Read";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // chkCount
            // 
            this.chkCount.AutoSize = true;
            this.chkCount.Location = new System.Drawing.Point(597, 43);
            this.chkCount.Name = "chkCount";
            this.chkCount.Size = new System.Drawing.Size(54, 17);
            this.chkCount.TabIndex = 13;
            this.chkCount.Text = "Count";
            this.chkCount.UseVisualStyleBackColor = true;
            // 
            // btnPurgeQ
            // 
            this.btnPurgeQ.Location = new System.Drawing.Point(50, 136);
            this.btnPurgeQ.Name = "btnPurgeQ";
            this.btnPurgeQ.Size = new System.Drawing.Size(75, 23);
            this.btnPurgeQ.TabIndex = 14;
            this.btnPurgeQ.Text = "Purge Q";
            this.btnPurgeQ.UseVisualStyleBackColor = true;
            this.btnPurgeQ.Click += new System.EventHandler(this.btnPurgeQ_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Message Queue Server";
            // 
            // txtQueueServer
            // 
            this.txtQueueServer.Location = new System.Drawing.Point(195, 41);
            this.txtQueueServer.Name = "txtQueueServer";
            this.txtQueueServer.Size = new System.Drawing.Size(173, 20);
            this.txtQueueServer.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(402, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Remaining";
            // 
            // txtRemaining
            // 
            this.txtRemaining.Location = new System.Drawing.Point(465, 40);
            this.txtRemaining.Name = "txtRemaining";
            this.txtRemaining.Size = new System.Drawing.Size(100, 20);
            this.txtRemaining.TabIndex = 18;
            this.txtRemaining.Text = "0";
            this.txtRemaining.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // QueueReaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 239);
            this.Controls.Add(this.txtRemaining);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQueueServer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPurgeQ);
            this.Controls.Add(this.chkCount);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "QueueReaderForm";
            this.Text = "Message Queue Reader";
            this.Load += new System.EventHandler(this.QueueReaderForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.CheckBox chkCount;
        private System.Windows.Forms.Button btnPurgeQ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQueueServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRemaining;
    }
}

