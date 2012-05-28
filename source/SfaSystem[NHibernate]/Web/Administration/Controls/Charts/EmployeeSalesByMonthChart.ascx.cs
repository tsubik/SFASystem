using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;

public partial class Administration_Controls_Charts_EmployeeSalesByMonthChart : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        double[] yValues = { 65.62, 75.54, 60.45, 34.73, 85.42, 22,33,12,45,32,35,56 };
        string[] xValues = { "sty", "lut", "mar", "kwi", "maj", "cze", "lip", "sie", "wrz", "paź", "lis", "gru" };

        chartEmployeeByMonth.Series["Default"].Points.DataBindXY(xValues, yValues);
        chartEmployeeByMonth.BackColor = ColorTranslator.FromHtml("#e7efef");
        //chartEmployeeByMonth.BackGradientStyle = GradientStyle.DiagonalRight;
        // Set series chart type
        chartEmployeeByMonth.Series["Default"].ChartType = SeriesChartType.Column;
        chartEmployeeByMonth.ChartAreas["ChartArea1"].AxisX.Interval = 1;
        // Set series point width
        chartEmployeeByMonth.Series["Default"]["PointWidth"] = "0.6";

        // Show data points labels
        chartEmployeeByMonth.Series["Default"].IsValueShownAsLabel = false;

        // Set data points label style
        chartEmployeeByMonth.Series["Default"]["BarLabelStyle"] = "Center";

        // Show as 3D
        chartEmployeeByMonth.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;

        // Draw as 3D Cylinder
        chartEmployeeByMonth.Series["Default"]["DrawingStyle"] = "Default";

    }



    private string GetMonthName(int month)
    {
        switch (month)
        {
            case 1:
                return "sty";
            case 2:
                return "lut";
            case 3:
                return "mar";
            case 4:
                return "kwi";
            case 5:
                return "maj";
            case 6:
                return "cze";
            case 7:
                return "lip";
            case 8:
                return "sie";
            case 9:
                return "wrz";
            case 10:
                return "paź";
            case 11:
                return "lis";
            case 12:
                return "gru";
            default:
                return "";
        }
    }
}
