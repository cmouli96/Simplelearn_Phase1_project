using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Assignments
{
    class TeacherBO
    {
        public List<TeacherModel> teachers { get; set; }

        public TeacherBO()
        {
            teachers = new List<TeacherModel>();
        }

        public List<TeacherModel> GetAllTeachers()
        {
            string fpath = @"e:\Phase1_Project.txt";
            List<TeacherModel> teachers=new List<TeacherModel>();
            foreach(string line in File.ReadLines(fpath))
            {
                TeacherModel t = CreateModel(line);
                teachers.Add(t);
            }
            return teachers;
        }


        public TeacherModel CreateModel(string str)
        {


            string[] st = str.Split(" ");

            int id = Convert.ToInt32(st[0]);
            string Name = st[1];
            string Class = st[2];
            string Section = st[3];

            return new TeacherModel { id = id, Name = Name, Class = Class,Section=Section };
        }

        public void DisplayAllData()
        {
            teachers = GetAllTeachers();
            foreach (TeacherModel t in teachers)
            {
                Console.WriteLine($"{t.id} {t.Name} {t.Class} {t.Section}");
            }
        }

       
        public void Update(TeacherModel t,int update_id)
        {
           

            teachers = GetAllTeachers();
            int index = teachers.FindIndex(x => x.id == update_id);

            teachers[index] = t;

            WriteToFile(teachers);
        }

        public void Delete(int id)
        {
            teachers = GetAllTeachers();
            int index = teachers.FindIndex(x => x.id == id);

            teachers.RemoveAt(index);

            WriteToFile(teachers);
        }

       public void Append(TeacherModel t)
        {
            string fpath = @"e:\Phase1_Project.txt";
            StreamWriter fname = File.AppendText(fpath);

            fname.WriteLine($"{t.id} {t.Name} {t.Class} {t.Section}");
            fname.Close();
        }

        public void Add(TeacherModel t)
        {
            string fpath = @"e:\Phase1_Project.txt";
            StreamWriter fname = new StreamWriter(fpath,false);

            fname.WriteLine($"{t.id} {t.Name} {t.Class} {t.Section}");
            fname.Close();
        }

        public bool CheckId(int id)
        {
            teachers=GetAllTeachers();
            int index = teachers.FindIndex(x => x.id == id);

            if (index == -1)
                return false;
            return true; 
        }

        public void WriteToFile(List<TeacherModel> teachers)
        {

            int i = 0;
            foreach (TeacherModel t in teachers)
            {
                if (i == 0)
                    Add(t);
                else
                    Append(t);
                i++;
             }

        }
       
    }
}
