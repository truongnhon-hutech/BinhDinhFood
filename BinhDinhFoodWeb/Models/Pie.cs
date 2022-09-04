using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BinhDinhFoodWeb.Models
{
    public class Pie
    {
        public string type = "pie";
        
        public Data data ;
        public Options options = new Options();


        public class Options
        {
            public Plugins plugins = new Plugins();
            public class Plugins
            {
                public Title title = new Title();
                public class Title
                {
                    public bool display = true;
                    public string text = "hi";
                }
            }
        }
        public class Data
        {
            public string[] labels ;
            public Dataset[] datasets = new Dataset[1];
            public class Dataset
            {
                public string[] backgroundColor;// = new string[2]
                public float[] data;
                public Dataset(int sogoi)
                {
                    this.backgroundColor = new string[sogoi];
                    this.data = new float[sogoi];
                }
            }
            public Data(int sogoi)
            {
                this.labels = new string[sogoi];
                this.datasets = new Dataset[1];
                this.datasets[0] = new Dataset(sogoi);
            }
        }
        public Pie(int sogoi)
        {
            this.data = new Data(sogoi);
        }
    }
}