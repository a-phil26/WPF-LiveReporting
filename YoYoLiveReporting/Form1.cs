//File:         Form1.cs
//Project:      BI-A02
//Programmer:   Addison Phillips
//Initial Date: January 25, 2024
//Description:  This is the main form control. It deals with setting up all UI charts and handling all events. 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Timers;

namespace YoYoLiveReporting
{
    public partial class LiveReporting : Form
    {
        //list of products to go into a drop down menu, and add all to it. 
        DataReader DataReader = null;
        bool intialized = false; // used to make sure the program doesnt update before it is initialized.
        private  System.Timers.Timer timer;
        public LiveReporting()
        {
            InitializeComponent();
            DataReader = new DataReader();
            IntializeReport();
            intialized = true;
            SetTimer();
        }


        //Function:     SetTimer
        //Description:  Sets up the timer
        private void SetTimer()
        {
            // Create a timer with a two second interval.
            timer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        //Function:     OnTimedEvent
        //Description:  Call back function to execute the update every 2 seconds
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                UpdateAll();
            });
        }

        //Function:     UpdateAll
        //Description:  This function updates all the charts and their data sources
        private void UpdateAll()
        {
           
                if (intialized)
                {
                    DataReader.DefectTable.Clear();
                    DataReader.ReadDefectTable(productsComboBox.SelectedItem.ToString()); //cross threading
                    PopulateChart(DataReader.DefectTable);
                    UpdateChart(rejectionChart, "Defects", "Pareto Line");
                    DataReader.ReadLineData(productsComboBox.SelectedItem.ToString()); //cross threading
                    PopulateYieldChart();
                    PopulateTotalsChart();
                    PopulateSuccessChart();
                }
           
        }

        //Function:     IntializeReport
        //Description:  Thsi function intializes all the data and charts for the first time
        void IntializeReport()
        {
            //Control Initialization
            productsComboBox.DataSource = DataReader.ProductNames;
            productsComboBox.SelectedIndex = 0;

            //Data Intialization
            DataReader.ReadDefectTable(productsComboBox.SelectedItem.ToString());
            PopulateChart(DataReader.DefectTable);
            MakeParetoChart(rejectionChart, "Defects", "Pareto Line");
            DataReader.ReadLineData(productsComboBox.SelectedItem.ToString());
            PopulateYieldChart();
            PopulateTotalsChart();
            PopulateSuccessChart();

            //Set up titles
            yieldChart.Titles.Add("Yield Amounts at Stages of Production");
            yieldChart.ChartAreas[0].AxisX.Title = "Stage of Production";
            yieldChart.ChartAreas[0].AxisY.Title = "Yield Percentage %";

            totalAmountChart.Titles.Add("Number of YoYo's per Stage");
            totalAmountChart.ChartAreas[0].AxisX.Title = "Stage of Production";
            totalAmountChart.ChartAreas[0].AxisY.Title = "# of YoYo's";

            successChart.Titles.Add("YoYo's Success per Stage");
            successChart.ChartAreas[0].AxisX.Title = "Stage of Production";
            successChart.ChartAreas[0].AxisY.Title = "# Of YoYo's";

        }


        //Function:     PopulateSuccessChart
        //Description:  Populates the success chart indicating how many yoyo succesfully made it past each production part. 
        void PopulateSuccessChart()
        {
            if (DataReader.LineData.Rows.Count > 0)
            {
                successChart.Series["Success per Stage"].Points.Clear();
                successChart.Series["Success per Stage"].IsValueShownAsLabel = true;


                DataRow row = DataReader.LineData.Rows[0];

                double success_mold = Convert.ToDouble(row["success_mold"]);
                double success_paint = Convert.ToDouble(row["success_paint"]);
                double success_assembled = Convert.ToDouble(row["success_assembled"]);

                successChart.Series["Success per Stage"].Points.AddXY("Success at Mold", success_mold);
                successChart.Series["Success per Stage"].Points.AddXY("Success at Paint", success_paint);
                successChart.Series["Success per Stage"].Points.AddXY("Success at Assembly", success_assembled);
                //successChart.Update();

            }
            else
            {
                successChart.Series["Success per Stage"].Points.Clear();
            }

        }

        //Function:     PopulateTotalsChart
        //Description:  Populates the totals chart.
        void PopulateTotalsChart()
        {

            if (DataReader.LineData.Rows.Count > 0)
            {
                totalAmountChart.Series["YoYo's per Stage"].Points.Clear();
                totalAmountChart.Series["YoYo's per Stage"].IsValueShownAsLabel = true;

                DataRow row = DataReader.LineData.Rows[0];

                double total_mold = Convert.ToDouble(row["total_mold"]);
                double total_packaged = Convert.ToDouble(row["total_package"]);

                //add to chart
                totalAmountChart.Series["YoYo's per Stage"].Points.AddXY("Total Molded", total_mold);
                totalAmountChart.Series["YoYo's per Stage"].Points.AddXY("Total Packaged", total_packaged);

            }
            else
            {
                totalAmountChart.Series["YoYo's per Stage"].Points.Clear();
            }
                
        }
        //Function:     PopulateYieldChart
        //Description:  Populates the yield chart with the data from its data table
        void PopulateYieldChart()
        {
            if(DataReader.LineData.Rows.Count > 0) 
            {
                yieldChart.Series["YieldData"].Points.Clear();
                yieldChart.Series["YieldData"].IsValueShownAsLabel = true;

                DataRow row = DataReader.LineData.Rows[0];

                double mold_yield = Convert.ToDouble(row["yeild_mold"]) * 100;
                double paint_yield = Convert.ToDouble(row["yeild_paint"]) * 100;
                double assembly_yield = Convert.ToDouble(row["yeild_assembly"]) * 100;
                double total_yield = Convert.ToDouble(row["yeild_total"]) * 100;

                //add to chart
                yieldChart.Series["YieldData"].Points.AddXY("Yield at Mold", mold_yield);
                yieldChart.Series["YieldData"].Points.AddXY("Yield at Paint", paint_yield);
                yieldChart.Series["YieldData"].Points.AddXY("Yield at Assembly", assembly_yield);
                yieldChart.Series["YieldData"].Points.AddXY("Total Yield", total_yield);

                yieldChart.ChartAreas[0].AxisY.LabelStyle.Format = "{0}%";
                yieldChart.ChartAreas[0].AxisY.Maximum = 100;
                //yieldChart.Update();
            }
            else
            {
                yieldChart.Series["YieldData"].Points.Clear();
            }


        }

        //Function:     PopulateChart
        //Description:  This function Populates the column chart with the data passed to it in a data table
        void PopulateChart(DataTable paretoData)
        {
            rejectionChart.Series["Defects"].Points.Clear();
            rejectionChart.Series["Defects"].IsValueShownAsLabel = true;

            foreach (DataRow row in paretoData.Rows)
            {
                string points = row["REASON"].ToString();
                int amount = Convert.ToInt32(row["Count"]);

                 rejectionChart.Series["Defects"].Points.AddXY(points, amount);
               
            }
        }


        //Function:    MakeParetoChart 
        //Description: This function creates the pareto chart for the first time.
        void MakeParetoChart(Chart chart, string srcSeriesName, string destSeriesName)
        {

            chart.Titles.Add("Reasons For Rejection");
            chart.ChartAreas[0].AxisX.Title = "Defect Reason";
            chart.ChartAreas[0].AxisY.Title = "Defect Frequency";
            chart.ChartAreas[0].AxisY2.Title = "Cumulative %";// Get the name of the ChartArea of the source series
            string strChartArea = chart.Series[srcSeriesName].ChartArea;
         
            chart.Series[srcSeriesName].ChartType = SeriesChartType.Column;            
            chart.DataManipulator.Sort(PointSortOrder.Descending, srcSeriesName);

            double total = 0.0;
            foreach (DataPoint pt in chart.Series[srcSeriesName].Points) total += pt.YValues[0];
 
            chart.ChartAreas[strChartArea].AxisY.Maximum = total;
            Series destSeries = new Series(destSeriesName);
            chart.Series.Add(destSeries);

            destSeries.ChartType = SeriesChartType.Line;
            destSeries.BorderWidth = 3;
            destSeries.ChartArea = chart.Series[srcSeriesName].ChartArea;
            destSeries.YAxisType = AxisType.Secondary;

            chart.ChartAreas[strChartArea].AxisY2.Maximum = 1;            
            chart.ChartAreas[strChartArea].AxisY2.LabelStyle.Format = "P0";            
            chart.ChartAreas[strChartArea].AxisX.LabelStyle.IsEndLabelVisible = false;
            
            double percentage = 0.0;
            foreach (DataPoint pt in chart.Series[srcSeriesName].Points)
            {
                percentage += (pt.YValues[0] / total);
                destSeries.Points.AddXY(pt.XValue, percentage);
            }
        }


        //Function:     UpdateChart   
        //Description:  This function updates the pareto chart. Main difference is that it is clearing the line part of the chart to ensure the right data points are inside it. 
        public void UpdateChart(Chart chart, string srcSeriesName, string destSeriesName)
        {
            string strChartArea = chart.Series[srcSeriesName].ChartArea;       
            rejectionChart.Series[destSeriesName].Points.Clear();           
            chart.Series[srcSeriesName].ChartType = SeriesChartType.Column;           
            chart.DataManipulator.Sort(PointSortOrder.Descending, srcSeriesName);

            double total = 0.0;
            foreach (DataPoint pt in chart.Series[srcSeriesName].Points) total += pt.YValues[0];

            chart.ChartAreas[strChartArea].AxisY.Maximum = total;
            Series destSeries = chart.Series[destSeriesName];

            destSeries.ChartType = SeriesChartType.Line;
            destSeries.BorderWidth = 3;
            destSeries.ChartArea = chart.Series[srcSeriesName].ChartArea;
            destSeries.YAxisType = AxisType.Secondary;

            chart.ChartAreas[strChartArea].AxisY2.Maximum = 1;
            chart.ChartAreas[strChartArea].AxisY2.LabelStyle.Format = "P0";
            chart.ChartAreas[strChartArea].AxisX.LabelStyle.IsEndLabelVisible = false;

            double percentage = 0.0;
            foreach (DataPoint pt in chart.Series[srcSeriesName].Points)
            {
                percentage += (pt.YValues[0] / total);
                destSeries.Points.AddXY(pt.XValue, percentage);
            }
        }


        //Function:     productsComboBox_SelectedIndexChanged
        //Description:  Invokes the updateAll to change which product data the charts display
        private void productsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        { 
            if(intialized)
            {
                UpdateAll();
            }
        }


    }
}


//e. The data should be updated automatically using a timer or manually using a button on the report.

