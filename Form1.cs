using System.Diagnostics;
using System.Reflection;
using System.Xml.Serialization;

namespace test_softhouse
{
    public partial class Form1 : Form
    {
        List<Person> persons = new List<Person>();
        public Form1()
        {
            InitializeComponent();
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            persons.Clear();
            List<string> oldDataLines = oldData.Text.Split("\r\n").ToList();
            List<int> allPersonIndexes = Enumerable.Range(0, oldDataLines.Count).Where(i => oldDataLines[i].ToLower().StartsWith("p")).ToList();
            // iterate over each index where a "P" line exists
            foreach (var (item, index) in allPersonIndexes.WithIndex())
            {
                int maxIndex;
                if (index == allPersonIndexes.Count - 1)
                {
                    maxIndex = oldDataLines.Count - 1;
                }
                else
                {
                    maxIndex = allPersonIndexes[index + 1] - 1;
                }
                Person p = new Person();
                List<Family> familyMembers = new List<Family>();

                // iterate over each line from the "P" row to the last line before the next "P" row
                for (int i = item; i <= maxIndex; i++)
                {
                    string[] currentLine = oldDataLines[i].Split("|");
                    switch (oldDataLines[i].First().ToString().ToLower())
                    {
                        case "p":
                            p.Firstname = currentLine[1];
                            p.Lastname = currentLine[2];
                            // iterate over each line, adding phone and address info after the "P" line until an "F" line is found or until it reaches the next "P" line
                            for (int j = i + 1; j <= maxIndex; j++)
                            {
                                if (oldDataLines[j].ToLower().StartsWith("f"))
                                {
                                    break;
                                }
                                string[] lineContent = oldDataLines[j].Split("|");

                                if (oldDataLines[j].ToLower().StartsWith("t"))
                                {
                                    Phone phone = new Phone();
                                    phone.Mobile = lineContent[1];
                                    phone.FixedLine = lineContent[2];
                                    p.Phone = phone;
                                }
                                else if (oldDataLines[j].ToLower().StartsWith("a"))
                                {
                                    Address a = new Address();
                                    a.Street = lineContent[1];
                                    a.City = lineContent[2];
                                    // Handle postal number being optional
                                    if (lineContent.Length > 3)
                                    {
                                        a.Postalnumber = lineContent[3];
                                    }
                                    p.Address = a;
                                }
                            }
                            break;
                        case "f":
                            Family fm = new Family();
                            fm.Name = currentLine[1];
                            fm.Born = currentLine[2];
                            // iterate over each line, adding phone and address info after the "P" line until an "F" line is found or until it reaches the next "P" line
                            for (int j = i + 1; j <= maxIndex; j++)
                            {
                                if (oldDataLines[j].ToLower().StartsWith("f"))
                                {
                                    break;
                                }
                                string[] lineContent = oldDataLines[j].Split("|");

                                if (oldDataLines[j].ToLower().StartsWith("t"))
                                {
                                    Phone phone = new Phone();
                                    phone.Mobile = lineContent[1];
                                    phone.FixedLine = lineContent[2];
                                    fm.Phone = phone;
                                }
                                else if (oldDataLines[j].ToLower().StartsWith("a"))
                                {
                                    Address a = new Address();
                                    a.Street = lineContent[1];
                                    a.City = lineContent[2];
                                    // Handle postal number being optional
                                    if (lineContent.Length > 3)
                                    {
                                        a.Postalnumber = lineContent[3];
                                    }
                                    fm.Address = a;
                                }
                            }
                            familyMembers.Add(fm);
                            break;
                    }
                }
                p.Family = familyMembers;
                persons.Add(p);
            }

            Debug.WriteLine(persons.Count); // TODO remove
            createXml();
        }

        private void createXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>), new XmlRootAttribute("people"));
            TextWriter writer = new StringWriter();
            serializer.Serialize(writer, persons);
            newData.Text = writer.ToString();
            writer.Close();
        }
    }

    [XmlType(TypeName = "person")]
    public class Person
    {
        [XmlElement("firstname", IsNullable = true)]
        public string? Firstname { get; set; }
        
        [XmlElement("lastname", IsNullable = true)]
        public string? Lastname { get; set; }

        [XmlElement("address", IsNullable = true)]
        public Address? Address { get; set; }
        
        [XmlElement("phone", IsNullable = true)]
        public Phone? Phone { get; set; }

        [XmlElement("family")]
        public List<Family>? Family { get; set; }
    }

    [XmlType(TypeName = "address")]
    public class Address
    {
        [XmlElement("street", IsNullable = true)]
        public string? Street { get; set; }

        [XmlElement("city", IsNullable = true)]
        public string? City { get; set; }
        
        [XmlElement("postalnumber", IsNullable = true)]
        public string? Postalnumber { get; set; }
    }

    [XmlType(TypeName = "family")]
    public class Family
    {
        
        [XmlElement("name", IsNullable = true)]
        public string? Name { get; set; }
        
        [XmlElement("born", IsNullable = true)]
        public string? Born { get; set; }
        
        [XmlElement("phone", IsNullable = true)]
        public Phone? Phone { get; set; }

        [XmlElement("address", IsNullable = true)]
        public Address? Address { get; set; }
    }

    [XmlType(TypeName = "phone")]
    public class Phone
    {
        [XmlElement("mobile", IsNullable = true)]
        public string? Mobile { get; set; }
        
        [XmlElement("fixedline", IsNullable = true)]
        public string? FixedLine { get; set; }
    }

    public static class EnumExtension
    {
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self) => self.Select((item, index) => (item, index));
    }
}