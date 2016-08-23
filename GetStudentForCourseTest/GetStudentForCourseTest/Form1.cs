using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetStudentForCourseTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var studentTableAdapter = new Learning_databasesDataSetTableAdapters.StudentsTableAdapter();
            var studentsTable = studentTableAdapter.GetDataByCourseId(2);

            StringBuilder allNames = new StringBuilder();

            // Loop through each returned student row and add name/second name to string
            foreach(var studentRow in studentsTable.Rows.Cast<Learning_databasesDataSet.StudentsRow>())
            {
                allNames.AppendLine(studentRow.Name + " " + studentRow.SecondName);
            }

            MessageBox.Show(allNames.ToString());
        }
        private void btnCourses_Click(object sender, EventArgs e)
        {
            var courseAdapter = new Learning_databasesDataSetTableAdapters.CoursesTableAdapter();
            var courseTable = courseAdapter.GetData();

            StringBuilder allClasses = new StringBuilder();

            // Loop through each returned student row and add name/second name to string
            foreach (var coursesRow in courseTable.Rows.Cast<Learning_databasesDataSet.CoursesRow>())
            {
                allClasses.AppendLine(coursesRow.Description );
            }

            MessageBox.Show(allClasses.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var studentTableAdapter = new Learning_databasesDataSetTableAdapters.StudentsTableAdapter();
            var studentsTable = studentTableAdapter.GetDataByStudentSecondName(textBox1.Text);
            StringBuilder allNames = new StringBuilder();

            // Loop through each returned student row and add name/second name to string
            foreach (var studentRow in studentsTable.Rows.Cast<Learning_databasesDataSet.StudentsRow>())
            {
                allNames.AppendLine(studentRow.Name + " " + studentRow.SecondName);
            }

            MessageBox.Show(allNames.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var studentTableAdapter = new Learning_databasesDataSetTableAdapters.StudentsTableAdapter();
            var studentsTable = studentTableAdapter.InsertStudent(FirstName.Text, SecondName.Text, int.Parse(Age.Text), Gender.Text, int.Parse(CourseId.Text));
            
        }

        private void learningdatabasesDataSetBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
