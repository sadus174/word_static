using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace word_static
{
    public partial class Form1 : Form
    {
        //Объявляем коллекции экземпляров классов
        List<Students> stud_list;
        //Счётчик количества экземпляров класса
        int i = 0;

        class Students
        {
            //Статическое поле Максимального возраста
            private static int max_age = 0;
            public string fio;
            private int age;
            //Свойство для поле возраста
            public int Age
            {
                set
                {
                    if (value < 18)
                    {
                        MessageBox.Show("Возраст студента не удовлетворяет требуемому условию.");
                    }
                    else
                    {
                        age = value;
                        if (value > max_age)
                        {
                            max_age = value;
                        }
                    }
                }
                get { return age; }
            }
            //Конструктор
            public Students(string fn, int a) { fio = fn; Age = a; }

            //Метод класса для вывода информации в listbox
            public void GetInfo(ListBox listbox1)
            {
                listbox1.Items.Add($"ФИО: {fio} Возраст {age}");
            }

            //Метод возврата максималььного возраста
            public static void GetMaxAge (Label label1)
            {
                label1.Text = max_age.ToString();
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            //Students st1 = new Students(textBox1.Text, Convert.ToInt32(textBox2.Text));
            //st1.GetInfo(listBox1);
            //Используя конструктор, вводим данные из textbox в поля экземплярра класса         
            stud_list.Add(new Students(textBox1.Text, Convert.ToInt32(textBox2.Text)));          
            //Метод вывода добавленного экземпляра класса в ListBox
            stud_list[i].GetInfo(listBox1);
            //Увеличиваем счётчик на единицу, что бы использовать данную переменную как индекс массива экземпляра классов.
            i++;
        }

        //Обычный метод вывода всех экземпляров класса
        public void GetAllList(ListBox listBox1)
        {
            listBox1.Items.Clear();

            for (int p = 0; p < stud_list.Count; p++)
            {
                stud_list[p].GetInfo(listBox1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetAllList(listBox1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Инициализируем коллекцию экземпляров класса
            stud_list = new List<Students>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Students.GetMaxAge(label1);
        }
    }
}
