using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using OpenHardwareMonitor.Hardware;

namespace OpenPCINFO
{
    class CPUTemperatures
    {
        public class UpdateVisitor : IVisitor
        {
            public void VisitComputer(IComputer computer)
            {
                computer.Traverse(this);
            }
            public void VisitHardware(IHardware hardware)
            {
                hardware.Update();
                foreach (IHardware subHardware in hardware.SubHardware)
                    subHardware.Accept(this);
            }
            public void VisitSensor(ISensor sensor) { }
            public void VisitParameter(IParameter parameter) { }
        }

        public static ArrayList GetTemperature()
        {
            ArrayList temperatures_list = new ArrayList();
            Computer myComputer = new Computer();
            UpdateVisitor updateVisitor = new UpdateVisitor();
            myComputer.Open();
            myComputer.CPUEnabled = true;
            myComputer.Accept(updateVisitor);

            foreach (var hardwareItem in myComputer.Hardware)
            {
                if (hardwareItem.HardwareType == HardwareType.CPU)
                {
                    foreach (var sensor in hardwareItem.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature)
                        {
                            //Console.WriteLine("NAME:" + sensor.Name + " Value:" + sensor.Value
                            //+ "°C MIN:" + sensor.Min + "°C Max:" + sensor.Max + "°C");
                            temperatures_list.Add(new Temperatures(sensor.Name, 
                                Convert.ToInt32(sensor.Value)));
                        }
                    }
                }
            }
            myComputer.Close();
            return temperatures_list;
        }
    }
}
