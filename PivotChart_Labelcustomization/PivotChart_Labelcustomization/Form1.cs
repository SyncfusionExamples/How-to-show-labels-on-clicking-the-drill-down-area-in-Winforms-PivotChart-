using Syncfusion.PivotAnalysis.Base;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Chart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PivotChart_Labelcustomization
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            InitializePivotChart();
            this.StartPosition = FormStartPosition.CenterScreen;     
        }

        private void InitializePivotChart()
        {
            // Adding ItemSource to the Control
            this.pivotChart1.ItemSource = ProductSalesData.GetSalesData();
            this.pivotChart1.AllowDrillDown = true;

            //Intialize the ChartRegionClick event
          this.pivotChart1.ChartControl.ChartRegionClick += ChartControl_ChartRegionClick;

            // Adding PivotAxis to the Control
            this.pivotChart1.PivotAxis.Add(new PivotItem { FieldMappingName = "Product", TotalHeader = "Total" });
            this.pivotChart1.PivotAxis.Add(new PivotItem { FieldMappingName = "Date", TotalHeader = "Total" });

            // Adding PivotLegend to the Control
            this.pivotChart1.PivotLegend.Add(new PivotItem { FieldMappingName = "Country", TotalHeader = "Total" });

            // Adding PivotCalculations to the Control
            this.pivotChart1.PivotCalculations.Add(new PivotComputationInfo { FieldName = "Quantity", Format = "#,##0" });
           
            this.pivotChart1.ShowLegend = true;

            for (int i = 0; i < this.pivotChart1.ChartControl.Series.Count; i++)
            {
                // Enabling DisplayText
                this.pivotChart1.ChartControl.Series[i].Style.DisplayText = true;

                // Sets the Offset of the text from the position of the chart point.
                this.pivotChart1.ChartControl.Series[i].Styles[0].TextOffset = 10.0F;

                // Align the text of the series within the data point region.
                this.pivotChart1.ChartControl.Series[i].Style.TextOrientation = ChartTextOrientation.Up;
            }
        }

        //Invoke ChartRegionClick method to display text on clicking + and - button
        private void ChartControl_ChartRegionClick(object sender, ChartRegionMouseEventArgs e)
        {
            if (e.Region != null && e.Region.Type == ChartRegionType.HorAxisLabel)
            {
                for (int i = 0; i < this.pivotChart1.ChartControl.Series.Count; i++)
                {
                    // Enabling DisplayText
                    this.pivotChart1.ChartControl.Series[i].Style.DisplayText = true;

                    // Sets the Offset of the text from the position of the chart point.
                    this.pivotChart1.ChartControl.Series[i].Styles[0].TextOffset = 10.0F;

                    // Align the text of the series within the data point region.
                    this.pivotChart1.ChartControl.Series[i].Style.TextOrientation = ChartTextOrientation.Up;
                }
            }
        }
    }
}
