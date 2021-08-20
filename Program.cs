using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Assignments
{
    
    class Program
    {
        static void Main(string[] args)
        {
            TeacherBO context = new TeacherBO();

            TeacherModel teacher;


           while(true)
            {
                Console.Write("options for the user \n 1. Display Elements \n 2. Add Elements \n 3. Update data \n 4. Delete record \n 5. Exit \n");
                Console.Write("Enter your input : ");
               

                try
                {
                   int  input_from_user = Convert.ToInt32(Console.ReadLine());



                    if (input_from_user == 5)
                    {
                        Console.WriteLine($"User given input is {input_from_user} , exited from the application");
                        break;
                    }
                    switch (input_from_user)
                    {


                        case 1:

                            context.DisplayAllData();
                            Console.WriteLine("\n");
                            break;

                        case 2:

                            Console.WriteLine("Existing Data : ");
                            context.DisplayAllData();
                            Console.WriteLine("\n");
                            Console.WriteLine("Adding to the existing Data ");
                            Console.Write("Enter id number : ");
                            try
                            {
                                int id = Convert.ToInt32(Console.ReadLine());
                                if (context.CheckId(id))
                                {
                                    Console.WriteLine($"this id :{id} already exists in the database");
                                }
                                else
                                {
                                    Console.Write("Enter Teacher name : ");
                                    string Name = Console.ReadLine();
                                    Console.Write("Enter Class the teacher teaches : ");
                                    string Class = Console.ReadLine();
                                    Console.Write("Enter Section the teacher takes : ");
                                    string Section = Console.ReadLine();

                                    teacher = new TeacherModel { id = id, Name = Name, Class = Class, Section = Section };
                                    context.Append(teacher);

                                    Console.WriteLine(" data is added to the DataBase");
                                }

                                Console.WriteLine("\n");
                               
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine($"Error :"+ex.Message);
                            }
                            break;
                           
    
                        case 3:

                            Console.WriteLine("Existing Data : ");
                            context.DisplayAllData();
                            Console.WriteLine("\n");
                            Console.Write("Enter id number to be updated : ");

                            try
                            {
                                int update_id = Convert.ToInt32(Console.ReadLine());

                                if (context.CheckId(update_id))
                                {
                                    Console.Write("Enter Teacher name : ");
                                    string Name = Console.ReadLine();
                                    Console.Write("Enter Class the teacher teaches : ");
                                    string Class = Console.ReadLine();
                                    Console.Write("Enter Section the teacher takes : ");
                                    string Section = Console.ReadLine();

                                    teacher = new TeacherModel { id = update_id, Name = Name, Class = Class, Section = Section };
                                    context.Update(teacher, update_id);

                                    Console.WriteLine($"Database is updated successfully");
                                    Console.WriteLine("\n Updated Database is : \n");
                                    context.DisplayAllData();

                                }
                                else
                                {
                                    Console.WriteLine($"There is no entry avaialable with the given id :{update_id}");
                                }
                                Console.WriteLine("\n");
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine($"Error : " + ex.Message);
                            }

                            break;
                           

                        case 4:

                            Console.WriteLine("Existing Data ");
                            context.DisplayAllData();
                            Console.WriteLine("\n");
                            Console.Write("Enter id number to be deleted : ");

                            try
                            {
                                int delete_id = Convert.ToInt32(Console.ReadLine());

                                if (context.CheckId(delete_id))
                                {
                                    context.Delete(delete_id);
                                    Console.WriteLine($"Database with the id : {delete_id} is successfully deleted");
                                }
                                else
                                {
                                    Console.WriteLine($"There is no record preseent with the id as {delete_id}");
                                }


                                Console.WriteLine("\n");
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine($"Error is : " + ex.Message) ;
                            }
                            
                            break;


                        default:
                            Console.WriteLine($"{input_from_user} is invalid input from the user");
                            Console.WriteLine("\n");
                            break;
                    }
                }

                catch(FormatException)
                {
                    Console.WriteLine("Incorrect input , please enter input in a range 1-5");
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error : "+ex.Message);
                }

                
            }
            

           
        }
    }
}
