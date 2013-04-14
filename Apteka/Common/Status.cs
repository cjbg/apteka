using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apteka.Common
{
    public class Status
    {
        public static Dictionary<string, string> statusy = new Dictionary<string, string>()
        {
        {"nowe", "nowe"},
	    {"do realizacji", "do realizacji"},
	    {"wpłata zrealizowana", "wpłata zrealizowana"},
	    {"wysłano", "wysłano"},
        {"zakończono", "zakończono"},
        {"wstrzymano", "wstrzymano"},
        {"anulowano", "anulowano"}
        };

        public static List<KeyValuePair<string, string>> getDurationListDD
        {
            get
            {
                List<KeyValuePair<string, string>> dDur = new List<KeyValuePair<string, string>>();
                dDur.Add(new KeyValuePair<string, string>("nowe", "nowe"));
                dDur.Add(new KeyValuePair<string, string>("do realizacji", "do realizacji"));
                dDur.Add(new KeyValuePair<string, string>("wpłata zrealizowana", "wpłata zrealizowana"));
                dDur.Add(new KeyValuePair<string, string>("wysłano", "wysłano"));
                dDur.Add(new KeyValuePair<string, string>("zakończono", "zakończono"));
                dDur.Add(new KeyValuePair<string, string>("anulowano", "anulowano"));

                return dDur;
            }
        }
    }
}