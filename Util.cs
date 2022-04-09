using System;
using System.IO;
using System.Net;
using System.Drawing;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
    class Util
    {
        // Add list parameter to method
        public static void PrintEmployees(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                string template = "{0, -10}\t{1, -20}\t{2}";
                Console.WriteLine(String.Format(template, employees[i].GetID(), employees[i].GetName(), employees[i].GetPhotoURL()));
            }
        }
        public static void MakeCSV(List<Employee> employees)
        {
            if(!Directory.Exists("data"))
            {
                // It not, create the directory
                Directory.CreateDirectory("data");
            }
            using (StreamWriter file = new StreamWriter("data/empoyees.csv"))
            {
                // loop over each employee
                for (int i = 0; i < employees.Count; i++)
                {
                    // write each employee tot he file
                    string template = "{0}, {1}, {2}";
                    file.WriteLine(String.Format(template, employees[i].GetID(), employees[i].GetName(), employees[i].GetPhotoURL()));
                }
            }
        }
        public static void MakeBadges(List<Employee> employees) 
        {   
            // Layout variables
            int BADGE_WIDTH = 669;
            int BADGE_HEIGHT = 1044;
            int COMPANY_NAME_START_X = 0;
            int COMPANY_NAME_START_Y = 110;
            int COMPANY_NAME_WIDTH = 100;
            int PHOTO_START_X = 184;
            int PHOTO_START_Y = 215;
            int PHOTO_WIDTH = 302;
            int PHOTO_HEIGHT = 302;
            int EMPLOYEE_NAME_START_X = 0;
            int EMPLOYEE_NAME_START_Y = 560;
            int EMPLOYEE_NAME_WIDTH = BADGE_WIDTH;
            int EMPLOYEE_NAME_HEIGHT = 100;
            int EMPLOYEE_ID_START_X = 0;
            int EMPLOYEE_ID_START_Y = 690;
            int EMPLOYEE_ID_WIDTH = BADGE_WIDTH;
            int EMPLOYEE_ID_HEIGHT = 100;
            
            // Graphics objects
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            int FONT_SIZE = 32;
            Font font = new Font("Arial", FONT_SIZE);
            Font monoFont = new Font("Courier New", FONT_SIZE);
            SolidBrush brush = new SolidBrush(Color.Black);
            
            // create image
            using(WebClient client = new WebClient())
            {
                for (int i = 0; i < employees.Count; i++)
                {
                    Image photo = Image.FromStream(client.OpenRead(employees[i].GetPhotoURL()));
                    Image background = Image.FromFile("badge.png");
                    Image badge = new Bitmap(BADGE_WIDTH, BADGE_HEIGHT);
                    Graphics graphic = Graphics.FromImage(badge);
                    graphic.DrawImage(background, new Rectangle(0, 0, BADGE_WIDTH, BADGE_HEIGHT));
                    graphic.DrawImage(photo, new Rectangle(PHOTO_START_X, PHOTO_START_Y, PHOTO_WIDTH, PHOTO_HEIGHT));
                    badge.Save("data/employeeBadge.png");

                   
                }
            }
        }
    }
}