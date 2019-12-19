using OpenHardwareMonitor.Hardware;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace OpenPCINFO
{
    class CpuTemperatureReader : IDisposable
    {
        private Computer _computer;

        public CpuTemperatureReader()
        {
            _computer = new Computer
            {
                CPUEnabled = true,
            };
            _computer.Open();
        }

        public ArrayList GetTemperaturesInCelsius()
        {
            ArrayList temperatures_list = new ArrayList();
            try
            {
                foreach (var hardware in _computer.Hardware)
                {
                    hardware.Update(); //use hardware.Name to get CPU model
                    if (hardware.HardwareType == HardwareType.CPU)
                    {
                        foreach (var sensor in hardware.Sensors)
                        {
                            if (sensor.SensorType == SensorType.Temperature && sensor.Value.HasValue)
                            {
                                //Console.WriteLine("{0}, Value={1}, Min Value={2}, Max Value={3}",
                                //    sensor.Name, sensor.Value.Value, sensor.Min.Value, sensor.Max.Value);
                                temperatures_list.Add(new Temperatures(sensor.Name, sensor.Value.Value,
                                    sensor.Min.Value, sensor.Max.Value));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return temperatures_list;
        }

        public void Dispose()
        {
            try
            {
                _computer.Close();
            }
            catch (Exception)
            {
                //ignore closing errors
            }
        }
    }
}
