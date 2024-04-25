using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace WPFStackedArea100Chart
{
    public class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Model> collection;
        public ObservableCollection<Model> Collection
        {
            get { return collection; }
            set
            {
                collection = value;
                NotifyPropertyChanged();
            }
        }


        public ViewModel()
        {
            Collection = new ObservableCollection<Model>(ReadCSV("WPFStackedArea100Chart.productionbycountry.csv"));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public IEnumerable<Model> ReadCSV(string fileName)
        {
            Assembly executingAssembly = typeof(App).GetTypeInfo().Assembly;
            Stream inputStream = executingAssembly.GetManifestResourceStream(fileName);
            List<string> lines = new List<string>();
            List<Model> collection = new List<Model>();
            if (inputStream != null)
            {
                string line;
                StreamReader reader = new StreamReader(inputStream);
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
                string[] headers = lines[0].Split(',');
                lines.RemoveAt(0);
                
                for (int i = 1; i < headers.Length; i++)
                {
                    double[] doubles = new double[lines.Count];
                    for (int j = 0; j < lines.Count; j++)
                    {
                        string[] data = lines[j].Split(',');
                        if (data[i] == string.Empty)
                        {
                            continue;
                        }

                        doubles[j] = Convert.ToDouble(data[i]);
                        
                    }

                    collection.Add(new Model(headers[i], doubles[0], doubles[1], doubles[2], doubles[3], doubles[4], doubles[5], doubles[6]));

                }

            }

            return collection;
        }
    }
}
