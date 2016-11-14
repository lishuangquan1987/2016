using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using NHibernate.Cfg;
using NHibernate;

namespace Nhibernate_数据库中插入图片
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Person p = new Person();
            p.Name = "li2";
            p.Age = 15;
            Image img = Image.FromFile(@"C:\Users\Administrator\Desktop\图片\33333.jpg");
            p.Image = ImageConvertToBytes(img);

            Configuration config = new Configuration().Configure();
            ISessionFactory factory = config.BuildSessionFactory();
            ISession session = factory.OpenSession();
            ITransaction tran = session.BeginTransaction();
            session.Save(p);
            tran.Commit();
            session.Close();
            factory.Close();
        }
        /// <summary>
        /// 将byte[]转为图片
        /// </summary>
        /// <param name="imgData"></param>
        /// <returns></returns>
        public  Image BytesConvertToImage(byte[] imgData)
        {
            if (imgData == null)
                return null;
            MemoryStream ms = new MemoryStream(imgData, 0, imgData.Length);
            BinaryFormatter bf = new BinaryFormatter();
            object obj = bf.Deserialize(ms);
            ms.Close();
            return (Image)obj;
        }

        /// <summary>
        /// 将图片转换为byte[]数组
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public byte[] ImageConvertToBytes(Image img)
        {
            if (img == null)
                return null;
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, (object)img);
            ms.Close();
            return ms.ToArray();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Configuration config = new Configuration().Configure();
            ISessionFactory factory = config.BuildSessionFactory();
            ISession session = factory.OpenSession();
            IList<Person> lstPerson = session.CreateCriteria<Person>().List<Person>();
            session.Close();
            factory.Close();
            this.pictureBox1.Image = BytesConvertToImage(lstPerson[2].Image);
        }
    }
}
