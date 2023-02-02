using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewManagingApp.Classes
{
    internal class Plant
    {
        public int PlantId { get; set; }

        public Plant(int plantId)
        {
            PlantId = plantId;
        }
        public string PlantName
        {
            get
            {
                if (PlantId == 2031)
                    return "Morliny";
                else if (PlantId == 2032)
                    return "Starachowice";
                else if (PlantId == 2033)
                    return "Szczecin";
                else if (PlantId == 2034)
                    return "Elk";
                else if (PlantId == 2035)
                    return "Kutno4";
                else if (PlantId == 2121)
                    return "Kutno1";
                else if (PlantId == 2122)
                    return "Kutno2";
                else if (PlantId == 3023)
                    return "Kutno3";
                else if (PlantId == 3061)
                    return "Ilawa";
                else if (PlantId == 3063)
                    return "Opole";
                else if (PlantId == 3064)
                    return "Suwalki";
                else if (PlantId == 3067)
                    return "Krakow";
                else if (PlantId == 3069)
                    return "IlawaCF";
                else
                    return "";
            }
        }
    }
}
