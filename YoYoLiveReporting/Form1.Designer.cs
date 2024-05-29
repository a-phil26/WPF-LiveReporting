namespace YoYoLiveReporting
{
    partial class LiveReporting
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.rejectionChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.productsComboBox = new System.Windows.Forms.ComboBox();
            this.yieldChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.totalAmountChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.successChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rejectionChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yieldChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalAmountChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.successChart)).BeginInit();
            this.SuspendLayout();
            // 
            // rejectionChart
            // 
            chartArea5.Name = "ChartArea1";
            this.rejectionChart.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.rejectionChart.Legends.Add(legend5);
            this.rejectionChart.Location = new System.Drawing.Point(12, 12);
            this.rejectionChart.Name = "rejectionChart";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Defects";
            this.rejectionChart.Series.Add(series5);
            this.rejectionChart.Size = new System.Drawing.Size(633, 383);
            this.rejectionChart.TabIndex = 0;
            this.rejectionChart.Text = "Rejection Chart";
            // 
            // productsComboBox
            // 
            this.productsComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productsComboBox.FormattingEnabled = true;
            this.productsComboBox.Location = new System.Drawing.Point(865, 178);
            this.productsComboBox.Name = "productsComboBox";
            this.productsComboBox.Size = new System.Drawing.Size(218, 33);
            this.productsComboBox.TabIndex = 1;
            this.productsComboBox.SelectedIndexChanged += new System.EventHandler(this.productsComboBox_SelectedIndexChanged);
            // 
            // yieldChart
            // 
            chartArea6.Name = "ChartArea1";
            this.yieldChart.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.yieldChart.Legends.Add(legend6);
            this.yieldChart.Location = new System.Drawing.Point(12, 401);
            this.yieldChart.Name = "yieldChart";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "YieldData";
            this.yieldChart.Series.Add(series6);
            this.yieldChart.Size = new System.Drawing.Size(458, 316);
            this.yieldChart.TabIndex = 2;
            this.yieldChart.Text = "chart1";
            // 
            // totalAmountChart
            // 
            chartArea7.Name = "ChartArea1";
            this.totalAmountChart.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.totalAmountChart.Legends.Add(legend7);
            this.totalAmountChart.Location = new System.Drawing.Point(476, 401);
            this.totalAmountChart.Name = "totalAmountChart";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "YoYo\'s per Stage";
            this.totalAmountChart.Series.Add(series7);
            this.totalAmountChart.Size = new System.Drawing.Size(464, 316);
            this.totalAmountChart.TabIndex = 3;
            this.totalAmountChart.Text = "chart1";
            // 
            // successChart
            // 
            chartArea8.Name = "ChartArea1";
            this.successChart.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.successChart.Legends.Add(legend8);
            this.successChart.Location = new System.Drawing.Point(946, 401);
            this.successChart.Name = "successChart";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Success per Stage";
            this.successChart.Series.Add(series8);
            this.successChart.Size = new System.Drawing.Size(392, 316);
            this.successChart.TabIndex = 4;
            this.successChart.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(730, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(508, 46);
            this.label1.TabIndex = 5;
            this.label1.Text = "YoYO Production Live Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(893, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select Product";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.successChart);
            this.Controls.Add(this.totalAmountChart);
            this.Controls.Add(this.yieldChart);
            this.Controls.Add(this.productsComboBox);
            this.Controls.Add(this.rejectionChart);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "YoYo Live Data";
            ((System.ComponentModel.ISupportInitialize)(this.rejectionChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yieldChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalAmountChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.successChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart rejectionChart;
        private System.Windows.Forms.ComboBox productsComboBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart yieldChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart totalAmountChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart successChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

