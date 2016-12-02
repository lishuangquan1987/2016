using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WPF.Model;
using System.Collections.ObjectModel;
using System.Threading;

namespace Test20161202
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        private ObservableCollection<TestItem> lstTestItem = new ObservableCollection<TestItem>()
        {
            new TestItem(){ItemName="111",Upper="1111",Lower="111",Value="111",TestStatus= EnumTestStatus.Normal},
            new TestItem(){ItemName="111",Upper="1111",Lower="111",Value="111",TestStatus= EnumTestStatus.Normal},
            new TestItem(){ItemName="111",Upper="1111",Lower="111",Value="111",TestStatus= EnumTestStatus.Normal},
            new TestItem(){ItemName="111",Upper="1111",Lower="111",Value="111",TestStatus= EnumTestStatus.Normal},
            new TestItem(){ItemName="111",Upper="1111",Lower="111",Value="111",TestStatus= EnumTestStatus.Normal},
            new TestItem(){ItemName="111",Upper="1111",Lower="111",Value="111",TestStatus= EnumTestStatus.Normal},
            new TestItem(){ItemName="111",Upper="1111",Lower="111",Value="111",TestStatus= EnumTestStatus.Normal},
        };
        public ObservableCollection<TestItem> LstTestItem
        {
            get { return lstTestItem; }
            set { this.lstTestItem = value; }
        }
        private ObservableCollection<Student> lstStudent = new ObservableCollection<Student>()
        {
            new Student(){Name="li",Pass=false,Uri=new Uri("http://294388344@qq.com"),Gender= Gender.Male},
            new Student(){Name="li",Pass=false,Uri=new Uri("http://294388344@qq.com"),Gender= Gender.Male},
            new Student(){Name="li",Pass=false,Uri=new Uri("http://294388344@qq.com"),Gender= Gender.Male},
            new Student(){Name="li",Pass=false,Uri=new Uri("http://294388344@qq.com"),Gender= Gender.Male}
        };
        public ObservableCollection<Student> LstStudent
        {
            get { return lstStudent; }
            set { this.lstStudent = value; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //LstTestItem.Add(new TestItem() { ItemName = "222", Upper = "222", Lower = "22", Value = "22", TestStatus = EnumTestStatus.Fail });
            //System.Threading.Thread thread = new System.Threading.Thread(() => 
            //    {
            //        for (int i = 0; i <= 100; i++)
            //        {
            //            LstTestItem[0].Value = i.ToString();
            //            System.Threading.Thread.Sleep(500);
            //        }
            //    });
            //thread.Start();
            //Thread t = new Thread(() => LstTestItem.Add(new TestItem() { ItemName = "222", Upper = "222", Lower = "22", Value = "22", TestStatus = EnumTestStatus.Normal }));
            //t.Start();
            //new Thread(StartTest).Start();
            MessageBox.Show(LstTestItem[0].TestStatus.ToString());
        }
        void StartTest()
        {
            for (int i = 0; i < LstTestItem.Count; i++)
            {
                LstTestItem[i].TestStatus = EnumTestStatus.Normal;
                LstTestItem[i].Value = "Testing...";
                System.Threading.Thread.Sleep(500);
                LstTestItem[i].Value = i.ToString();
                if (i % 2 == 1)
                    LstTestItem[i].TestStatus = EnumTestStatus.Fail;
                else
                    LstTestItem[i].TestStatus = EnumTestStatus.Pass;

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.ucListView1.DataContext = this;
            this.ucDataGrid1.DataContext = this;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Thread(StartTest1).Start();
        }
        private void StartTest1()
        {
            for (int i = 0; i < LstStudent.Count; i++)
            {
                LstStudent[i].Name = "...";
                Thread.Sleep(1000);
                LstStudent[i].Name = "Done";
                Thread.Sleep(1000);
                LstStudent[i].Name = i.ToString();
            }
        }
    }
}
