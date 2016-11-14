using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;

namespace 天气预报_WebService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var s = new Service.WeatherService.WeatherWebServiceSoapClient("WeatherWebServiceSoap");
            MessageBox.Show(s.getSupportProvince()[2]);
        }
    }
}
