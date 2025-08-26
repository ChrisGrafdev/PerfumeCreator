using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{
    public static class CreatorSettings
    {
        public static string Perfumer = "unnamed";
        //...
    }

    public static class Globals
    {
        public static float DropWeight = 15.0f;
        public static void SetDropWeight(float dropWeight)
        {
            Globals.DropWeight = dropWeight;
        }
        public static UnitType ViewportMaterialUnit = UnitType.Drops;
    }

    public enum DilutionTarget
    {
        TargetAmount,
        InputAmount
    }

    public enum UnitType
    {
        Drops,
        Milligram
    }

    public enum NoteLevel
    {
        HeadNote,
        HeartNote,
        BaseNote,
        UNKNOWN
    }

    public enum ScentCategory
    {
        Woody,
        Earthy,
        Musky,
        Leather,
        Aromatic,
        Citrusy,
        Marine,
        Green,
        Fruity,
        Floral,
        Oriental,
        UNKNOWN
    }

    public enum DilutionType
    {
        Oil,
        Alcohol,
        Mix
    }
}
