using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VelibGraphicClient
{
    public partial class Form1 : Form
    {
        private VelibService.Service1Client client;
        public Form1()
        {
            InitializeComponent();
            client = new VelibService.Service1Client();
        }



        private async void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] cities = await client.GetAllCityAsync(); 
            for (int i = 0; i < cities.Length; i++)
            {
                listBox1.Items.Add(cities[i]);
            }
            
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string[] stations = await client.GetAllStationsAsync(listBox1.Text);
            for (int i = 0; i < stations.Length; i++)
            {
                listBox2.Items.Add(stations[i]);
            }
            //listBox2.Items.Add(listBox1.Text);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            int s = await client.GetAvailableBikeAsync(listBox1.Text, listBox2.Text);
            label1.Text = s.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
