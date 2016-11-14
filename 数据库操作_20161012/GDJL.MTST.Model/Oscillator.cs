using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDJL.MTST.Model
{
   public class Oscillator
    {
        public virtual string PartNumber
        {
            get;
            set;
        }
        public virtual string PartType
        {
            get;
            set;
        }
        public virtual string Value
        {
            get;
            set;
        }
        public virtual string Description
        {
            get;
            set;
        }
        public virtual string Rating
        {
            get;
            set;
        }
        public virtual string Tolerance
        {
            get;
            set;
        }
        public virtual string SchematicPart
        {
            get;
            set;
        }
        public virtual string LayoutPCBFootprint
        {
            get;
            set;
        }
        public virtual string AllegroPCBFootprint
        {
            get;
            set;
        }
        public virtual string PSpice
        {
            get;
            set;
        }
        public virtual string ManufacturerPartNumber
        {
            get;
            set;
        }
        public virtual string Manufacturer
        {
            get;
            set;
        }
        public virtual string DistributorPartNumber
        {
            get;
            set;
        }
        public virtual string Distributor
        {
            get;
            set;
        }
        public virtual double Price
        {
            get;
            set;
        }
        public virtual string Availability
        {
            get;
            set;
        }
        public virtual string Datasheet
        {
            get;
            set;
        }
        public virtual string ActivepartsID
        {
            get;
            set;
        }
        public virtual string OperatingTemperatureRange
        {
            get;
            set;
        }
        public virtual string StorageTemperatureRange
        {
            get;
            set;
        }
        public virtual string TempratureStability
        {
            get;
            set;
        }
        public virtual string PhaseNoise_10HZ
        {
            get;
            set;
        }
        public virtual string PhaseNoise_100HZ
        {
            get;
            set;
        }
        public virtual string PhaseNoise_1KHZ
        {
            get;
            set;
        }
        public virtual string PhaseNoise_10KHZ
        {
            get;
            set;
        }
        public virtual string PhaseNoise_100KHZ
        {
            get;
            set;
        }
    }
}
