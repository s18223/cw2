using System;
using System.Collections.Generic;
using System.IO;

namespace cw2
{
    class Program
    {
        private static string defaultSourcePath = "data.csv";
        private static string defaultDestinationPath = "result.xml";
        private static string defaultFormat = "xml";

        static void Main(string[] args)
        {
            var sourcePath = getParam(args, 0, defaultSourcePath);
            var destinationPath = getParam(args, 1, defaultDestinationPath);
            var format = getParam(args, 2, defaultFormat);
            var students = new List<Student>();

            //todo jakub: strategy pattern for different formats, one below - csv
            using (var reader = new StreamReader(sourcePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(",");

                    if (values.Length == 9)
                    {
                        //todo jakub: check emptiness of the values, otherwise log into the file
                        students.Add(new Student(
                            values[0],
                            values[1],
                            getDateTime(values[2]),
                            values[3],
                            values[4],
                            values[5],
                            values[6],
                            values[7],
                            getStudies(values[8])
                            ));
                    } else
                    {
                        //todo jakub: log into the file
                    }
                }

                //todo jakub: filter out students and log duplicates into the file
            }
        }

        private static List<Study> getStudies(string value)
        {
            throw new NotImplementedException();
        }

        private static DateTime getDateTime(string value)
        {
            throw new NotImplementedException();
        }

        private static string getParam(string[] args, int index, string defaultValue)
        {
            if (args.Length < index + 1)
            {
                return defaultValue;
            }
            else
            {
                return args[index];
            }
        }
    }

    struct Student
    {

        public Student(
            string fname,
            string lname,
            DateTime birthdate,
            string email,
            string mothersName,
            string fathersName,
            List<Study> studies
            )
        {
            this.fname = fname;
            this.lname = lname;
            this.birthdate = birthdate;
            this.email = email;
            this.mothersName = mothersName;
            this.fathersName = fathersName;
            this.studies = studies;
        }

        public string fname { get; }
        public string lname { get; }
        public DateTime birthdate { get; }
        public string email { get; }
        public string mothersName { get; }
        public string fathersName { get; }
        public List<Study> studies { get; }
    }

    struct Study
    {
        public Study(string name, int numberOfStudents)
        {
            this.name = name;
            this.numberOfStudents = numberOfStudents;
        }

        public string name { get; }
        public int numberOfStudents { get; }
    }
}
