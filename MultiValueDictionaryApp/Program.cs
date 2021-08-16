using System;
using System.Collections.Generic;

namespace MultiValueDictionaryApp
{
    class Program
    {

        static void Main(string[] args)
        {
            String command = "";

            Display.DisplayText("Enter stop to quit program");

            while (command.ToLower() != "stop")
            {
                command = Console.ReadLine();

                String[] commandElements = command.Split(" ");

                if(commandElements.Length > 3)
                {
                    Display.DisplayText("Please check documentation for command list!"); 
                }

                if(commandElements.Length == 1)
                {
                    switch (commandElements[0].ToLower())
                    {
                        case "items":
                            Display.DisplayList(Storage.Items());
                            break;
                        case "allmembers":
                            Display.DisplayList(Storage.AllMembers());
                            break;
                        case "clear":
                            Storage.Clear();
                            Display.DisplayText("Cleared");
                            break;
                        case "keys":
                            Display.DisplayList(Storage.Keys());
                            break;
                        case "stop":
                            Display.DisplayText("Goodbye!");
                            break;
                        default:
                            Display.DisplayText("Invalid Input!");
                            break;
                    }
                }


                if(commandElements.Length == 2)
                {
                    string parameter = commandElements[1];
                    switch (commandElements[0].ToLower())
                    {
                        case "members":
                            try
                            {
                                Display.DisplayList(Storage.Members(parameter));
                            }
                            catch(KeyNotFoundException k)
                            {
                                Display.DisplayText(k.Message);
                            }
                            break;
                        case "removeall":
                            try
                            {
                                Storage.RemoveAll(parameter);
                                Display.DisplayText("Removed");
                            }
                            catch (KeyNotFoundException k)
                            {
                                Display.DisplayText(k.Message);
                            }
                            break;
                        case "keyexists":
                            Display.DisplayText(Storage.KeyExists(parameter).ToString().ToLower());
                            break;
                        default:
                            Display.DisplayText("Invalid Input!");
                            break;

                    }
                }

                if(commandElements.Length == 3)
                {
                    string parameter = commandElements[1];
                    string parameter2 = commandElements[2];
                    switch (commandElements[0].ToLower())
                    {
                        case "add":
                            try
                            {
                                Storage.Add(parameter, parameter2);
                                Display.DisplayText("Added");
                            }
                            catch (CustomException c)
                            {
                                Display.DisplayText(c.Message);
                            }
                            break;
                        case "remove":
                            try
                            {
                                Storage.Remove(parameter, parameter2);
                                Display.DisplayText("Removed");
                            }
                            catch (KeyNotFoundException k)
                            {
                                Display.DisplayText(k.Message);
                            }catch (CustomException c)
                            {
                                Display.DisplayText(c.Message);
                            }
                            break;
                        case "memberexists":
                            Display.DisplayText(Storage.MemberExists(parameter, parameter2).ToString().ToLower());
                            break;
                        default:
                            Display.DisplayText("Invalid Input!");
                            break;

                    }
                }

            }
        }
    }
}
