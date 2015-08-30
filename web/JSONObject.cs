using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zhuhai.web
{
    /// <summary>
    /// 微小生物
    /// </summary>
    public class Microclimate
    {
        private string temperature;
        public string Temperature {
            get { return temperature; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    temperature = "温度：" + value + "℃";
            }
        }

        private string humidity;
        public string Humidity {
            get {return humidity;}
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    humidity = "湿度：" + value + "%RH";
            }
        }

        private string lux;
        public string Lux {
            get { return lux;}
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    lux = "照度：" + value + "lux";
            }
        }

        private string pm;
        public string Pm {
            get { return pm; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    pm = "PM2.5/PM10：" + value + "ug/m3";
            } 
        }

        private string pressure;
        public string Pressure {
            get { return pressure; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    pressure = "大气压：" + value + "kPa";
            } 
        }

        private string co;
        public string Co {
            get { return co; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    co = "一氧化碳：" + value + "ppm";
            }
        }

        private string co2;
        public string Co2 {
            get { return co2; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    co2 = "二氧化碳：" + value + "ppm";
            }

        }

        private string ms;
        public string Ms {
            get { return ms; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    ms = "风速：" + value + "m/s";
            } 
        }

        private string hcho;
        public string Hcho {
            get { return hcho; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    hcho = "甲醛：" + value + "ppm";
            } 
        }

        private string db;
        public string Db {
            get { return db; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    db = "噪声：" + value + "dB";
            }
        }

        public override string ToString()
        {
            return String.Format("temperature= {0}, humidity= {1}, lux= {2}, pm= {3}, pressure= {4},co= {5}, co2= {6}, ms= {7}, hcho= {8}, db= {9}", this.temperature, this.humidity,
                this.lux, this.pm,this.pressure, this.co,this.co2, this.ms,this.hcho, this.db);
        }
    }

    /// <summary>
    /// 化学毒剂
    /// </summary>
    public class ChemicalToxic
    {
        public string error { get; set; }
        public string reading { get; set; }
        public string gastype { get; set; }

        public override string ToString()
        {
            return String.Format("reading= {0}, gastype= {1}", this.reading, this.gastype);
        }
    }

    /// <summary>
    /// 生物气溶胶
    /// </summary>
    public class Bioaerosol
    {
        public string reading { get; set; }
        public string error { get; set;}

        private string status;
        public string Status 
        {
            get { return status; }
            set {
                if (value == "alarm")
                {
                    status = "报警";
                    error = "生物气溶剂超标";
                }
                else if (value == "normal")
                {
                    status = "正常";
                }
            }
        }

        public override string ToString()
        {
            return String.Format("reading= {0}, status= {1}",this.reading, this.status);
        }

    }
}
