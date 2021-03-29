using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project_Main
{
    public partial class Form1 : Form
    {
        SerialPort sPort;
        
        //초기 통신 및 실행
        public Form1()
        {
            InitializeComponent();
            foreach (var port in SerialPort.GetPortNames()) //내가 사용할 수 있는 모든 port를 열어준다.
            {
                comPort.Items.Add(port);
            }
            comPort.Text = "Select Port";
            
            comBoudrate.Text = "Select Port";
            comBoudrate.Items.Add("9600");
            comBoudrate.Items.Add("115200");

            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;

        }
        private void comPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox pt = sender as ComboBox;
            sPort = new SerialPort(pt.SelectedItem.ToString());
        }
        private void comBoudrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox br = sender as ComboBox;
            sPort.BaudRate = Convert.ToInt32(br.SelectedItem);
        }
        
        private void btnConnect_Click(object sender, EventArgs e)
        {
            sPort.Open();
            textBox1.Text = "Connection Time : " + DateTime.Now.ToString();
            sPort.DataReceived += SPort_DataReceived;
            textBox1.Text = "연결이 성공적으로 되었습니다♡";

            btnConnect.Enabled = false;
            btnDisconnect.Enabled = true;
        } 
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            sPort.Close();
            btnConnect.Enabled = true;
            textBox1.Text = "수고하셨습니다♡";
        }
       
        //데이터 수신
        private void SPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            
        }




        // File처리


        // File처리


        //RC Throttle Data 및 실제 모터 회전속도, 보드와의 통신
        //LIstView


        //ListView


        //Graph

        //Graph

        //기체에 대한 오류와 상태 정보
        //TextBox

        //TextBox

        //데이터 종류 선택
        //CheckBox

        //CheckBox


    }
}
