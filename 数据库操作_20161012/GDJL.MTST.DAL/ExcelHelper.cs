using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpreadsheetGear;
using GDJL.MTST.Model;
using System.Reflection;

namespace GDJL.MTST.DAL
{
   public class ExcelHelper
    {
       IWorkbook workbook;
       IWorksheet worksheet;
       private string GetValue(object value)
       {
           return value == null ? null : value.ToString();
       }
       #region 从acess数据库导出到excel的数据，然后读取excel,存放到sql
       public List<Capacitor> GetDatasFromAccess_Capacitor(string path, string sheetName = "Sheet1")
       {
           try
           {
               workbook = Factory.GetWorkbook(path);
               worksheet = workbook.Worksheets[sheetName];
               if (worksheet == null)
                   throw new Exception("worksheet为空");
               int count = worksheet.UsedRange.RowCount - 1;              
               List<Capacitor> lstCapacitor = new List<Capacitor>();
               for (int i = 0; i < count; i++)
               {
                   Capacitor obj = new Capacitor();
                   //从第2行开始为第一个数据
                   obj.PartNumber = worksheet.Cells[string.Format("A{0}", i + 2)].Value.ToString();
                   obj.PartType = worksheet.Cells[string.Format("B{0}", i + 2)].Value.ToString();
                   obj.Value =worksheet.Cells[string.Format("C{0}", i + 2)].Value==null?null:worksheet.Cells[string.Format("C{0}", i + 2)].Value.ToString();
                   obj.Description = worksheet.Cells[string.Format("D{0}", i + 2)].Value == null ? null : worksheet.Cells[string.Format("D{0}", i + 2)].Value.ToString();
                   obj.RatedVoltage = worksheet.Cells[string.Format("E{0}", i + 2)].Value == null ? null : worksheet.Cells[string.Format("E{0}", i + 2)].Value.ToString();
                   obj.Tolerance = worksheet.Cells[string.Format("F{0}", i + 2)].Value == null ? null : worksheet.Cells[string.Format("F{0}", i + 2)].Value.ToString();
                   obj.SchematicPart = worksheet.Cells[string.Format("G{0}", i + 2)].Value == null ? null : worksheet.Cells[string.Format("G{0}", i + 2)].Value.ToString();
                   obj.LayoutPCBFootprint = worksheet.Cells[string.Format("H{0}", i + 2)].Value == null ? null : worksheet.Cells[string.Format("H{0}", i + 2)].Value.ToString();
                   obj.AllegroPCBFootprint = worksheet.Cells[string.Format("I{0}", i + 2)].Value == null ? null : worksheet.Cells[string.Format("I{0}", i + 2)].Value.ToString();
                   obj.PSpice = worksheet.Cells[string.Format("J{0}", i + 2)].Value == null ? null : worksheet.Cells[string.Format("J{0}", i + 2)].Value.ToString();
                   obj.ManufacturerPartNumber = worksheet.Cells[string.Format("K{0}", i + 2)].Value == null ? null : worksheet.Cells[string.Format("K{0}", i + 2)].Value.ToString();
                   obj.Manufacturer = worksheet.Cells[string.Format("L{0}", i + 2)].Value == null ? null : worksheet.Cells[string.Format("L{0}", i + 2)].Value.ToString();
                   obj.DistributorPartNumber = worksheet.Cells[string.Format("M{0}", i + 2)].Value == null ? null : worksheet.Cells[string.Format("M{0}", i + 2)].Value.ToString();
                   obj.Distributor = worksheet.Cells[string.Format("N{0}", i + 2)].Value == null ? null : worksheet.Cells[string.Format("N{0}", i + 2)].Value.ToString();
                   obj.Price = worksheet.Cells[string.Format("O{0}", i + 2)].Value == null ? 0 : Convert.ToDouble(worksheet.Cells[string.Format("O{0}", i + 2)].Value.ToString());
                   obj.Availability = worksheet.Cells[string.Format("P{0}", i + 2)].Value == null ? null : worksheet.Cells[string.Format("P{0}", i + 2)].Value.ToString();
                   obj.Datasheet = GetValue(worksheet.Cells[string.Format("Q{0}", i + 2)].Value);
                   obj.ActivepartsID = GetValue(worksheet.Cells[string.Format("R{0}", i + 2)].Value);
                   obj.OperatingTemperatureRange = GetValue(worksheet.Cells[string.Format("S{0}", i + 2)].Value);
                   obj.StorageTemperatureRange = GetValue(worksheet.Cells[string.Format("T{0}", i + 2)].Value);
                   lstCapacitor.Add(obj);
               }
               
               workbook.Close();
               return lstCapacitor;
           }
           catch (Exception e)
           {
               workbook.Close();
               string exPath = "exception.txt";
               System.IO.File.AppendAllText(exPath, e.Message);
               throw e;
           }
       }
       public List<IC> GetDatasFromAccess_IC(string path, string sheetName = "Sheet1")
       {
           try
           {
               workbook = Factory.GetWorkbook(path);
               worksheet = workbook.Worksheets[sheetName];
               if (worksheet == null)
                   throw new Exception("worksheet为空");
               int count = worksheet.UsedRange.RowCount - 1;
               List<IC> lstCapacitor = new List<IC>();
               for (int i = 0; i < count; i++)
               {
                   IC obj = new IC();
                   //从第2行开始为第一个数据
                   obj.PartNumber = worksheet.Cells[string.Format("A{0}", i + 2)].Value.ToString();
                   obj.PartType = worksheet.Cells[string.Format("B{0}", i + 2)].Value.ToString();
                   obj.Value = GetValue(worksheet.Cells[string.Format("C{0}", i + 2)].Value);
                   obj.Description = GetValue(worksheet.Cells[string.Format("D{0}", i + 2)].Value);

                   obj.SchematicPart = GetValue(worksheet.Cells[string.Format("E{0}", i + 2)].Value);
                   obj.LayoutPCBFootprint = GetValue(worksheet.Cells[string.Format("F{0}", i + 2)].Value);
                   obj.AllegroPCBFootprint = GetValue(worksheet.Cells[string.Format("G{0}", i + 2)].Value);
                   obj.PSpice = GetValue(worksheet.Cells[string.Format("H{0}", i + 2)].Value);
                   obj.ManufacturerPartNumber = GetValue(worksheet.Cells[string.Format("I{0}", i + 2)].Value);
                   obj.Manufacturer = GetValue(worksheet.Cells[string.Format("J{0}", i + 2)].Value);
                   obj.DistributorPartNumber = GetValue(worksheet.Cells[string.Format("K{0}", i + 2)].Value);
                   obj.Distributor = GetValue(worksheet.Cells[string.Format("L{0}", i + 2)].Value);
                   obj.Price =worksheet.Cells[string.Format("M{0}", i + 2)].Value==null?0: Convert.ToDouble(worksheet.Cells[string.Format("M{0}", i + 2)].Value);
                   obj.Availability = GetValue(worksheet.Cells[string.Format("N{0}", i + 2)].Value);
                   obj.Datasheet = GetValue(worksheet.Cells[string.Format("O{0}", i + 2)].Value);
                   obj.ActivepartsID = GetValue(worksheet.Cells[string.Format("P{0}", i + 2)].Value);
                   obj.OperatingTemperatureRange = GetValue(worksheet.Cells[string.Format("Q{0}", i + 2)].Value);
                   obj.StorageTemperatureRange = GetValue(worksheet.Cells[string.Format("R{0}", i + 2)].Value);
                   lstCapacitor.Add(obj);
               }
               workbook.Close();
               return lstCapacitor;
           }
           catch (Exception e)
           {
               workbook.Close();
               string exPath = "exception.txt";
               System.IO.File.AppendAllText(exPath, e.Message);
               throw e;
           }
       }
       public List<Inductor> GetDatasFromAccess_Inductor(string path, string sheetName = "Sheet1")
       {
           try
           {
               workbook = Factory.GetWorkbook(path);
               worksheet = workbook.Worksheets[sheetName];
               if (worksheet == null)
                   throw new Exception("worksheet为空");
               int count = worksheet.UsedRange.RowCount - 1;
               List<Inductor> lstCapacitor = new List<Inductor>();
               for (int i = 0; i < count; i++)
               {
                   Inductor obj = new Inductor();
                   //从第2行开始为第一个数据
                   obj.PartNumber = GetValue(worksheet.Cells[string.Format("A{0}", i + 2)].Value);
                   obj.PartType = GetValue(worksheet.Cells[string.Format("B{0}", i + 2)].Value);
                   obj.Value = GetValue(worksheet.Cells[string.Format("C{0}", i + 2)].Value);
                   obj.Description = GetValue(worksheet.Cells[string.Format("D{0}", i + 2)].Value);
                   obj.Rating = GetValue(worksheet.Cells[string.Format("E{0}", i + 2)].Value);
                   obj.Tolerance = GetValue(worksheet.Cells[string.Format("F{0}", i + 2)].Value);
                   obj.SchematicPart = GetValue(worksheet.Cells[string.Format("G{0}", i + 2)].Value);
                   obj.LayoutPCBFootprint = GetValue(worksheet.Cells[string.Format("H{0}", i + 2)].Value);
                   obj.AllegroPCBFootprint = GetValue(worksheet.Cells[string.Format("I{0}", i + 2)].Value);
                   obj.PSpice = GetValue(worksheet.Cells[string.Format("J{0}", i + 2)].Value);
                   obj.ManufacturerPartNumber = GetValue(worksheet.Cells[string.Format("K{0}", i + 2)].Value);
                   obj.Manufacturer = GetValue(worksheet.Cells[string.Format("L{0}", i + 2)].Value);
                   obj.DistributorPartNumber = GetValue(worksheet.Cells[string.Format("M{0}", i + 2)].Value);
                   obj.Distributor = GetValue(worksheet.Cells[string.Format("N{0}", i + 2)].Value);
                   obj.Price =worksheet.Cells[string.Format("O{0}", i + 2)].Value==null?0: Convert.ToDouble(worksheet.Cells[string.Format("O{0}", i + 2)].Value.ToString());
                   obj.Availability = GetValue(worksheet.Cells[string.Format("P{0}", i + 2)].Value);
                   obj.Datasheet = GetValue(worksheet.Cells[string.Format("Q{0}", i + 2)].Value);
                   obj.ActivepartsID = GetValue(worksheet.Cells[string.Format("R{0}", i + 2)].Value);
                   obj.OperatingTemperatureRange = GetValue(worksheet.Cells[string.Format("S{0}", i + 2)].Value);
                   obj.StorageTemperatureRange = GetValue(worksheet.Cells[string.Format("T{0}", i + 2)].Value);
                   lstCapacitor.Add(obj);
               }
               workbook.Close();
               return lstCapacitor;
           }
           catch (Exception e)
           {
               workbook.Close();
               string exPath = "exception.txt";
               System.IO.File.AppendAllText(exPath, e.Message);
               throw e;
           }
       }
       public List<Misc> GetDatasFromAccess_Misc(string path, string sheetName = "Sheet1")
       {
           try
           {
               workbook = Factory.GetWorkbook(path);
               worksheet = workbook.Worksheets[sheetName];
               if (worksheet == null)
                   throw new Exception("worksheet为空");
               int count = worksheet.UsedRange.RowCount - 1;
               List<Misc> lstCapacitor = new List<Misc>();
               for (int i = 0; i < count; i++)
               {
                   Misc obj = new Misc();
                   //从第2行开始为第一个数据
                   obj.PartNumber = GetValue(worksheet.Cells[string.Format("A{0}", i + 2)].Value);
                   obj.PartType = GetValue(worksheet.Cells[string.Format("B{0}", i + 2)].Value);
                   obj.Value = GetValue(worksheet.Cells[string.Format("C{0}", i + 2)].Value);
                   obj.Description = GetValue(worksheet.Cells[string.Format("D{0}", i + 2)].Value);
                   obj.Rating = GetValue(worksheet.Cells[string.Format("E{0}", i + 2)].Value);
                   obj.Tolerance =GetValue(worksheet.Cells[string.Format("F{0}", i + 2)].Value);
                   obj.SchematicPart = GetValue(worksheet.Cells[string.Format("G{0}", i + 2)].Value);
                   obj.LayoutPCBFootprint = GetValue(worksheet.Cells[string.Format("H{0}", i + 2)].Value);
                   obj.AllegroPCBFootprint = GetValue(worksheet.Cells[string.Format("I{0}", i + 2)].Value);
                   obj.PSpice = GetValue(worksheet.Cells[string.Format("J{0}", i + 2)].Value);
                   obj.ManufacturerPartNumber = GetValue(worksheet.Cells[string.Format("K{0}", i + 2)].Value);
                   obj.Manufacturer = GetValue(worksheet.Cells[string.Format("L{0}", i + 2)].Value);
                   obj.DistributorPartNumber = GetValue(worksheet.Cells[string.Format("M{0}", i + 2)].Value);
                   obj.Distributor = GetValue(worksheet.Cells[string.Format("N{0}", i + 2)].Value);
                   obj.Price =worksheet.Cells[string.Format("O{0}", i + 2)].Value==null?0: Convert.ToDouble(worksheet.Cells[string.Format("O{0}", i + 2)].Value.ToString());
                   obj.Availability = GetValue(worksheet.Cells[string.Format("P{0}", i + 2)].Value);
                   obj.Datasheet = GetValue(worksheet.Cells[string.Format("Q{0}", i + 2)].Value);
                   obj.ActivepartsID = GetValue(worksheet.Cells[string.Format("R{0}", i + 2)].Value);
                   obj.OperatingTemperatureRange = GetValue(worksheet.Cells[string.Format("S{0}", i + 2)].Value);
                   obj.StorageTemperatureRange = GetValue(worksheet.Cells[string.Format("T{0}", i + 2)].Value);
                   lstCapacitor.Add(obj);
               }
               workbook.Close();
               return lstCapacitor;
           }
           catch (Exception e)
           {
               workbook.Close();
               string exPath = "exception.txt";
               System.IO.File.AppendAllText(exPath, e.Message);
               throw e;
           }
       }
       public List<GDJL.MTST.Model.Module> GetDatasFromAccess_Module(string path, string sheetName = "Sheet1")
       {
           try
           {
               workbook = Factory.GetWorkbook(path);
               worksheet = workbook.Worksheets[sheetName];
               if (worksheet == null)
                   throw new Exception("worksheet为空");
               int count = worksheet.UsedRange.RowCount - 1;
               List<GDJL.MTST.Model.Module> lstCapacitor = new List<GDJL.MTST.Model.Module>();
               for (int i = 0; i < count; i++)
               {
                   GDJL.MTST.Model.Module obj = new GDJL.MTST.Model.Module();
                   //从第2行开始为第一个数据
                   obj.PartNumber = worksheet.Cells[string.Format("A{0}", i + 2)].Value.ToString();
                   obj.PartType = worksheet.Cells[string.Format("B{0}", i + 2)].Value.ToString();
                   obj.Value = GetValue(worksheet.Cells[string.Format("C{0}", i + 2)].Value);
                   obj.Description = GetValue(worksheet.Cells[string.Format("D{0}", i + 2)].Value);
                   obj.SchematicPart = GetValue(worksheet.Cells[string.Format("E{0}", i + 2)].Value);
                   obj.LayoutPCBFootprint = GetValue(worksheet.Cells[string.Format("F{0}", i + 2)].Value);
                   obj.AllegroPCBFootprint = GetValue(worksheet.Cells[string.Format("G{0}", i + 2)].Value);
                   obj.PSpice = GetValue(worksheet.Cells[string.Format("H{0}", i + 2)].Value);
                   obj.ManufacturerPartNumber = GetValue(worksheet.Cells[string.Format("I{0}", i + 2)].Value);
                   obj.Manufacturer = GetValue(worksheet.Cells[string.Format("J{0}", i + 2)].Value);
                   obj.DistributorPartNumber = GetValue(worksheet.Cells[string.Format("K{0}", i + 2)].Value);
                   obj.Distributor = GetValue(worksheet.Cells[string.Format("L{0}", i + 2)].Value);
                   obj.Price =worksheet.Cells[string.Format("M{0}", i + 2)].Value==null?0: Convert.ToDouble(worksheet.Cells[string.Format("M{0}", i + 2)].Value.ToString());
                   obj.Availability = GetValue(worksheet.Cells[string.Format("N{0}", i + 2)].Value);
                   obj.Datasheet = GetValue(worksheet.Cells[string.Format("O{0}", i + 2)].Value);
                   obj.ActivepartsID = GetValue(worksheet.Cells[string.Format("P{0}", i + 2)].Value);
                   obj.OperatingTemperatureRange = GetValue(worksheet.Cells[string.Format("Q{0}", i + 2)].Value);
                   obj.StorageTemperatureRange = GetValue(worksheet.Cells[string.Format("R{0}", i + 2)].Value);
                   lstCapacitor.Add(obj);
               }
               workbook.Close();
               return lstCapacitor;
           }
           catch (Exception e)
           {
               workbook.Close();
               string exPath = "exception.txt";
               System.IO.File.AppendAllText(exPath, e.Message);
               throw e;
           }
       }
       public List<Oscillator> GetDatasFromAccess_Oscillator(string path, string sheetName = "Sheet1")
       {
           try
           {
               workbook = Factory.GetWorkbook(path);
               worksheet = workbook.Worksheets[sheetName];
               if (worksheet == null)
                   throw new Exception("worksheet为空");
               int count = worksheet.UsedRange.RowCount - 1;
               List<Oscillator> lstCapacitor = new List<Oscillator>();
               for (int i = 0; i < count; i++)
               {
                   Oscillator obj = new Oscillator();
                   //从第2行开始为第一个数据
                   obj.PartNumber = worksheet.Cells[string.Format("A{0}", i + 2)].Value.ToString();
                   obj.PartType = worksheet.Cells[string.Format("B{0}", i + 2)].Value.ToString();
                   obj.Value = GetValue(worksheet.Cells[string.Format("C{0}", i + 2)].Value);
                   obj.Description = GetValue(worksheet.Cells[string.Format("D{0}", i + 2)].Value);
                   obj.Rating = GetValue(worksheet.Cells[string.Format("E{0}", i + 2)].Value);
                   obj.Tolerance = GetValue(worksheet.Cells[string.Format("F{0}", i + 2)].Value);
                   obj.SchematicPart = GetValue(worksheet.Cells[string.Format("G{0}", i + 2)].Value);
                   obj.LayoutPCBFootprint = GetValue(worksheet.Cells[string.Format("H{0}", i + 2)].Value);
                   obj.AllegroPCBFootprint = GetValue(worksheet.Cells[string.Format("I{0}", i + 2)].Value);
                   obj.PSpice = GetValue(worksheet.Cells[string.Format("J{0}", i + 2)].Value);
                   obj.ManufacturerPartNumber = GetValue(worksheet.Cells[string.Format("K{0}", i + 2)].Value);
                   obj.Manufacturer = GetValue(worksheet.Cells[string.Format("L{0}", i + 2)].Value);
                   obj.DistributorPartNumber = GetValue(worksheet.Cells[string.Format("M{0}", i + 2)].Value);
                   obj.Distributor = GetValue(worksheet.Cells[string.Format("N{0}", i + 2)].Value);
                   obj.Price = worksheet.Cells[string.Format("O{0}", i + 2)].Value==null?0:Convert.ToDouble(worksheet.Cells[string.Format("O{0}", i + 2)].Value.ToString());
                   obj.Availability = GetValue(worksheet.Cells[string.Format("P{0}", i + 2)].Value);
                   obj.Datasheet = GetValue(worksheet.Cells[string.Format("Q{0}", i + 2)].Value);
                   obj.ActivepartsID = GetValue(worksheet.Cells[string.Format("R{0}", i + 2)].Value);
                   obj.OperatingTemperatureRange = GetValue(worksheet.Cells[string.Format("S{0}", i + 2)].Value);
                   obj.StorageTemperatureRange = GetValue(worksheet.Cells[string.Format("T{0}", i + 2)].Value);


                   obj.TempratureStability = GetValue(worksheet.Cells[string.Format("U{0}", i + 2)].Value);
                   obj.PhaseNoise_10HZ = GetValue(worksheet.Cells[string.Format("V{0}", i + 2)].Value);
                   obj.PhaseNoise_100HZ = GetValue(worksheet.Cells[string.Format("W{0}", i + 2)].Value);
                   obj.PhaseNoise_1KHZ = GetValue(worksheet.Cells[string.Format("X{0}", i + 2)].Value);
                   obj.PhaseNoise_10KHZ = GetValue(worksheet.Cells[string.Format("Y{0}", i + 2)].Value);
                   obj.PhaseNoise_100KHZ = GetValue(worksheet.Cells[string.Format("Z{0}", i + 2)].Value);
                   lstCapacitor.Add(obj);
               }
               workbook.Close();
               return lstCapacitor;
           }
           catch (Exception e)
           {
               workbook.Close();
               string exPath = "exception.txt";
               System.IO.File.AppendAllText(exPath, e.Message);
               throw e;
           }
       }
       public List<Resistor> GetDatasFromAccess_Resistor(string path, string sheetName = "Sheet1")
       {
           try
           {
               workbook = Factory.GetWorkbook(path);
               worksheet = workbook.Worksheets[sheetName];
               if (worksheet == null)
                   throw new Exception("worksheet为空");
               int count = worksheet.UsedRange.RowCount - 1;
               List<Resistor> lstCapacitor = new List<Resistor>();
               for (int i = 0; i < count; i++)
               {
                   Resistor obj = new Resistor();
                   //从第2行开始为第一个数据
                   obj.PartNumber = worksheet.Cells[string.Format("A{0}", i + 2)].Value.ToString();
                   obj.PartType = worksheet.Cells[string.Format("B{0}", i + 2)].Value.ToString();
                   obj.Value = GetValue(worksheet.Cells[string.Format("C{0}", i + 2)].Value);
                   obj.Description = GetValue(worksheet.Cells[string.Format("D{0}", i + 2)].Value);
                   obj.Power = GetValue(worksheet.Cells[string.Format("E{0}", i + 2)].Value);
                   obj.Tolerance = GetValue(worksheet.Cells[string.Format("F{0}", i + 2)].Value);
                   obj.SchematicPart = GetValue(worksheet.Cells[string.Format("G{0}", i + 2)].Value);
                   obj.LayoutPCBFootprint = GetValue(worksheet.Cells[string.Format("H{0}", i + 2)].Value);
                   obj.AllegroPCBFootprint = GetValue(worksheet.Cells[string.Format("I{0}", i + 2)].Value);
                   obj.PSpice = GetValue(worksheet.Cells[string.Format("J{0}", i + 2)].Value);
                   obj.ManufacturerPartNumber = GetValue(worksheet.Cells[string.Format("K{0}", i + 2)].Value);
                   obj.Manufacturer = GetValue(worksheet.Cells[string.Format("L{0}", i + 2)].Value);
                   obj.DistributorPartNumber = GetValue(worksheet.Cells[string.Format("M{0}", i + 2)].Value);
                   obj.Distributor = GetValue(worksheet.Cells[string.Format("N{0}", i + 2)].Value);
                   obj.Price =worksheet.Cells[string.Format("O{0}", i + 2)].Value==null?0: Convert.ToDouble(worksheet.Cells[string.Format("O{0}", i + 2)].Value.ToString());
                   obj.Availability = GetValue(worksheet.Cells[string.Format("P{0}", i + 2)].Value);
                   obj.Datasheet = GetValue(worksheet.Cells[string.Format("Q{0}", i + 2)].Value);
                   obj.ActivepartsID = GetValue(worksheet.Cells[string.Format("R{0}", i + 2)].Value);
                   obj.OperatingTemperatureRange = GetValue(worksheet.Cells[string.Format("S{0}", i + 2)].Value);
                   obj.StorageTemperatureRange = GetValue(worksheet.Cells[string.Format("T{0}", i + 2)].Value);
                   lstCapacitor.Add(obj);
               }
               workbook.Close();
               return lstCapacitor;
           }
           catch (Exception e)
           {
               workbook.Close();
               string exPath = "exception.txt";
               System.IO.File.AppendAllText(exPath, e.Message);
               throw e;
           }
       }
       public List<Sensors> GetDatasFromAccess_Sensors(string path, string sheetName = "Sheet1")
       {
           try
           {
               workbook = Factory.GetWorkbook(path);
               worksheet = workbook.Worksheets[sheetName];
               if (worksheet == null)
                   throw new Exception("worksheet为空");
               int count = worksheet.UsedRange.RowCount - 1;
               List<Sensors> lstCapacitor = new List<Sensors>();
               for (int i = 0; i < count; i++)
               {
                   Sensors obj = new Sensors();
                   //从第2行开始为第一个数据
                   obj.PartNumber = worksheet.Cells[string.Format("A{0}", i + 2)].Value.ToString();
                   obj.PartType = worksheet.Cells[string.Format("B{0}", i + 2)].Value.ToString();
                   obj.Value = GetValue(worksheet.Cells[string.Format("C{0}", i + 2)].Value);
                   obj.Description = GetValue(worksheet.Cells[string.Format("D{0}", i + 2)].Value);                
                   obj.SchematicPart = GetValue(worksheet.Cells[string.Format("E{0}", i + 2)].Value);
                   obj.LayoutPCBFootprint = GetValue(worksheet.Cells[string.Format("F{0}", i + 2)].Value);
                   obj.AllegroPCBFootprint = GetValue(worksheet.Cells[string.Format("G{0}", i + 2)].Value);
                   obj.PSpice = GetValue(worksheet.Cells[string.Format("H{0}", i + 2)].Value);
                   obj.ManufacturerPartNumber = GetValue(worksheet.Cells[string.Format("I{0}", i + 2)].Value);
                   obj.Manufacturer = GetValue(worksheet.Cells[string.Format("J{0}", i + 2)].Value);
                   obj.DistributorPartNumber = GetValue(worksheet.Cells[string.Format("K{0}", i + 2)].Value);
                   obj.Distributor = GetValue(worksheet.Cells[string.Format("L{0}", i + 2)].Value);
                   object VVV = worksheet.Cells[string.Format("M{0}", i + 2)].Value;
                   obj.Price =worksheet.Cells[string.Format("M{0}", i + 2)].Value==null?0: Convert.ToDouble(worksheet.Cells[string.Format("M{0}", i + 2)].Value.ToString());
                   obj.Availability = GetValue(worksheet.Cells[string.Format("N{0}", i + 2)].Value);
                   obj.Datasheet = GetValue(worksheet.Cells[string.Format("O{0}", i + 2)].Value);
                   obj.ActivepartsID = GetValue(worksheet.Cells[string.Format("P{0}", i + 2)].Value);
                   obj.OperatingTemperatureRange = GetValue(worksheet.Cells[string.Format("Q{0}", i + 2)].Value);
                   obj.StorageTemperatureRange = GetValue(worksheet.Cells[string.Format("R{0}", i + 2)].Value);
                   lstCapacitor.Add(obj);
               }
               workbook.Close();
               return lstCapacitor;
           }
           catch (Exception e)
           {
               workbook.Close();
               string exPath = "exception.txt";
               System.IO.File.AppendAllText(exPath, e.Message);
               throw e;
           }
       }
       #endregion
    }
}
