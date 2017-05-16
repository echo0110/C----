using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Net.Sockets;
//private Socket rsock=null;
//private Thread  th2;


namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Add("D");
           
        }
        private void Form1_Load(object sender,EventArgs e)
          {

              listBox1.Items.Clear();
              listBox1.Items.Add("A1");
    
          }

        private void button1_Click(object sender, EventArgs e)
        {
          //  this.textBox1.AppendText("S");
            this.textBox1.AppendText("安徽建筑大学");
            

          
                byte[] result = new byte[1024];
                //设定服务器IP地址
                IPAddress ip = IPAddress.Parse("192.168.1.1");

                Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    clientSocket.Connect(new IPEndPoint(ip, 8080)); //配置服务器IP与端口
                    MessageBox.Show("连接服务器成功");
                }
                catch
                {
                    MessageBox.Show("连接服务器失败，请按回车键退出！");
                    return;
                }
                //通过clientSocket接收数据


                // this textBox2.AppendText("服务器电压："+this textBox1.Text+"IP");
                int receiveLength = clientSocket.Receive(result);
                MessageBox.Show("接收服务器消息：{0}", Encoding.ASCII.GetString(result, 0, receiveLength));

                while (true)
                {
                    this.textBox1.AppendText("当前时间：" + DateTime.Now);
                    this.textBox2.AppendText("电压：" + Encoding.ASCII.GetString(result, 0, receiveLength)+"mv");
                    this.textBox3.AppendText("当前电流：" + Encoding.ASCII.GetString(result, 0, receiveLength) + "mA");
                 //   this.textBox5.AppendText("当前电压："+Encoding.ASCII .(result,0,receiveLength));

                }
                //通过 clientSocket 发送数据
                for (int i = 0; i < 1; i++)
                {
                    try
                    {
                        Thread.Sleep(1000);    //等待1秒钟
                        string sendMessage = "client send Message Hellp" + DateTime.Now;
                        clientSocket.Send(Encoding.ASCII.GetBytes(sendMessage));
                        MessageBox.Show("向服务器发送消息：{0}" + sendMessage);
                    }
                    catch
                    {
                        clientSocket.Shutdown(SocketShutdown.Both);
                        clientSocket.Close();
                        break;
                    }
                }
                MessageBox.Show("发送完毕，按回车键退出");
                //Console.ReadLine(); 

              

           
          
          

         }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           // try {

              //  int receiveLength = clientSocket.Receive(result)(this textBox1 .Text);
            
           // }
           
   
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            this.textBox1.AppendText(" 单片机无线数据采集");
        }

        private void 安徽建筑大学ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        }
    }
