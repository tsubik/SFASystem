using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;


public partial class Administration_Controls_Charts_BestProductsChart : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Populate series data
        double[] yValues = { 65.62, 75.54, 60.45, 34.73, 85.42 };
        string[] xValues = { "France", "Canada", "Germany", "USA", "Italy" };
        chartBestProducts.Titles.Add("Najlepiej sprzedające się produkty");
        chartBestProducts.Series["Default"].Points.DataBindXY(xValues, yValues);
 
        // Set Doughnut chart type
        chartBestProducts.Series["Default"].ChartType = SeriesChartType.Pie;

        // Set labels style
        chartBestProducts.Series["Default"]["PieLabelStyle"] = "Inside";

        // Set Doughnut radius percentage
        chartBestProducts.Series["Default"]["DoughnutRadius"] = "30";

        // Explode data point with label "Italy"
        //chartBestProducts.Series["Default"].Points[4]["Exploded"] = "true";

        // Enable 3D
        chartBestProducts.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
        
        // Disable the Legend
        //chartBestProducts.Legends[0].Enabled = false;

    }
}
