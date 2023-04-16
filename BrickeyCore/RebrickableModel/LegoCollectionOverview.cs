using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickeyCore.RebrickableModel
{
    public class LegoCollectionOverview
    {
        int total_sets;
        int total_loose_parts;
        int total_set_parts;
        int lost_set_parts;
        UInt64 all_parts;
        int total_figures;
    }

    public class Lego
    {
        public int total_sets { get; set; }
        public int total_loose_parts { get; set; }
        public int total_set_parts { get; set; }
        public int lost_set_parts { get; set; }
        public int all_parts { get; set; }
        public int total_figs { get; set; }
    }
}
